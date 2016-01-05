using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using MVCEnMiNevera.Models;
using EnMiNeveraGenNHibernate.CAD.EnMiNevera;
using EnMiNeveraGenNHibernate.CEN.EnMiNevera;
using EnMiNeveraGenNHibernate.EN.EnMiNevera;
using EnMiNeveraGenNHibernate.Enumerated.EnMiNevera;

namespace MVCEnMiNevera.Controllers
{
    public class RecetaController : BasicController
    {
        // GET: Receta
        public ActionResult Index()
        {
            SessionInitialize();
            IList<RecetaEN> listRecetaEn = new RecetaCAD(session).ReadAllDefault(0, -1);

            IEnumerable<Receta> recetas = new AssemblerReceta().ConvertListENToModel(listRecetaEn);
            SessionClose();


            return View(recetas);
        }

        // GET: Receta/Ver/5
        public ActionResult Ver(int id)
        {
            SessionInitialize();

            RecetaEN en = new RecetaCAD(session).ReadOIDDefault(id);
            Receta receta = new AssemblerReceta().ConvertENToModelUI(en);

            // Aunque parezca una tontería, con esto consigo la persistencia de los datos
            //foreach (LineaIngredienteEN lin in receta.LineasIngrediente)
            //{
            //    lin.Ingrediente.Id = lin.Ingrediente.Id;
            //    lin.Ingrediente.Nombre = lin.Ingrediente.Nombre;
            //}

            //foreach(ComentarioEN com in receta.Comentarios)
            //{
            //    com.Usuario.Id = com.Usuario.Id;
            //    com.Usuario.Nick = com.Usuario.Nick;
            //}

            if (User.Identity.IsAuthenticated)
            {
                UsuarioEN usuarioEn = new UsuarioCAD(session).GetByNick(User.Identity.Name);
                if (en.UsuariosFavorito.Contains(usuarioEn))
                    ViewData["esFavorito"] = "si";
                else
                    ViewData["esFavorito"] = "no";

                // Obtengo listas de la compra del usuario actual
                ViewData["ListasCompra"] = usuarioEn.ListasCompra.ToList();
            }


            SessionClose();

            return View(receta);
        }
        
        // GET: Receta/Favorito/5
        [Authorize]
        public ActionResult Favorito(int id)
        {
            SessionInitialize();

            UsuarioCAD usuarioCad = new UsuarioCAD(session);

            UsuarioEN usuarioEn = usuarioCad.GetByNick(User.Identity.Name);

            new UsuarioCEN(usuarioCad).GuardarFavorito(usuarioEn.Id, id);

            SessionClose();

            return RedirectToAction("ver", new { id = id });
        }

        // GET: Receta/Crear
        public ActionResult Crear()
        {
            //return View(new Receta());
            return View();
        }

        // POST: Receta/Crear
        [HttpPost]
        //public ActionResult Crear(Receta rec, HttpPostedFileBase file, FormCollection datos)
        public ActionResult Crear(Receta rec, HttpPostedFileBase file, int[] canIngrediente, UnidadesEnum[] uniIngrediente, string[] nomIngrediente, int[] numPaso, string[] desPaso)
        {
            string imagesDir = "Images/Uploads";

            string fileName = "", path = "";
            // Verify that the user selected a file
            if (file != null && file.ContentLength > 0)
            {
                // extract only the fielname
                fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                path = Path.Combine(Server.MapPath("~/"+imagesDir), fileName);
                //string pathDef = path.Replace(@"\\", @"\");
                file.SaveAs(path);
            }

            try
            {
                fileName = "/"+imagesDir+"/" + fileName;

                // Parametros por defecto
                rec.FechaCreacion = DateTime.Now;
                rec.Estado = EnMiNeveraGenNHibernate.Enumerated.EnMiNevera.EstadosEnum.publicado;
                rec.Foto = fileName;

                // Obtenemos los pasos
                IList<Paso> pasos = new List<Paso>();
                Paso paso = null;
                for(int i=0; i<numPaso.Count(); i++)
                {
                    paso = new Paso();
                    paso.NumeroPaso = numPaso[i];
                    paso.Descripcion = desPaso[i];
                    pasos.Add(paso);
                }

                // Obtenemos las lineas de ingrediente 
                IList<LineaIngrediente> lineasIng = new List<LineaIngrediente>();
                LineaIngrediente lin = null;
                for(int i=0; i<canIngrediente.Count(); i++)
                {
                    lin = new LineaIngrediente();
                    lin.Cantidad = canIngrediente[i];
                    lin.NombreIngrediente = nomIngrediente[i];
                    lin.Unidad = uniIngrediente[i];
                    lineasIng.Add(lin);
                }


                SessionInitialize();
                using (var transaction = session.BeginTransaction ())
                {
                    // Obtengo el id del usuario
                    int idUsuario = new UsuarioCAD(session).GetByNick(User.Identity.Name).Id;

                    RecetaCAD cad = new RecetaCAD(session);
                    RecetaCEN cen = new RecetaCEN(cad);

                    int idReceta = cen.New_(rec.Nombre, rec.Descripcion, rec.Foto, idUsuario, rec.FechaCreacion, rec.Estado);

                    // Creamos los pasos
                    PasosCAD pasosCad = new PasosCAD(session);
                    PasosCEN pasosCen = new PasosCEN(pasosCad);
                    foreach(Paso p in pasos)
                    {
                        pasosCen.New_(p.Descripcion, idReceta, p.NumeroPaso);
                    }

                    // Creamos las lineas de ingrediente
                    LineaIngredienteCAD lineaIngredienteCad = new LineaIngredienteCAD(session);
                    LineaIngredienteCEN lineaIngredienteCen = new LineaIngredienteCEN(lineaIngredienteCad);

                    IngredienteCAD ingredienteCad = new IngredienteCAD(session);
                    IngredienteEN ingredienteEn;

                    foreach(LineaIngrediente l in lineasIng)
                    {
                        // por cada linea, si no existe el ingrediente, lo creamos
                        ingredienteEn = ingredienteCad.GetPorNombre(l.NombreIngrediente);
                        if(ingredienteEn==null)
                        {
                            ingredienteEn = new IngredienteEN();
                            ingredienteEn.Nombre = l.NombreIngrediente;
                            ingredienteEn.Id = ingredienteCad.New_(ingredienteEn);
                        }

                        lineaIngredienteCen.New_(l.Cantidad, l.Unidad, ingredienteEn.Id, idReceta);
                    }

                    transaction.Commit ();
                }
                SessionClose();





                //RecetaCEN cen = new RecetaCEN();

                //// Obtengo el id del usuario
                //int idUsuario = new UsuarioCAD().GetByNick(User.Identity.Name).Id;

                //rec.FechaCreacion = DateTime.Now;
                //rec.Estado = EnMiNeveraGenNHibernate.Enumerated.EnMiNevera.EstadosEnum.publicado;

                //cen.New_(rec.Nombre, rec.Descripcion, fileName, idUsuario, rec.FechaCreacion, rec.Estado);
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // POST: Receta/Buscar
        [HttpPost]
        public ActionResult BuscaPorIngrediente(string[] ingredientes)
        {
            SessionInitialize();

            // Buscamos ingrediente a ingrediente
            IList<int> idsIngredientes = new List<int>();
            IngredienteCAD ingredienteCad = new IngredienteCAD(session);
            IngredienteEN ingredienteEn = null;

            foreach(string ing in ingredientes)
            {
                // Solo si existe, añado a la lista. Solo buscamos por ingredientes que existen
                ingredienteEn = ingredienteCad.GetPorNombre(ing.ToLower());
                if (ingredienteEn != null)
                    idsIngredientes.Add(ingredienteEn.Id);
            }

            RecetaCAD cad = new RecetaCAD(session);
            RecetaCEN cen = new RecetaCEN(cad);
            IList<RecetaEN> listEn = cen.BuscarPorIngrediente(idsIngredientes);
            IList<Receta> list = new AssemblerReceta().ConvertListENToModel(listEn);

            SessionClose();

            ViewData["ingredientes"] = ingredientes;
      
            return View(list);
        }

        // GET: Receta/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Receta/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Receta/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Receta/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Receta/Ultimas
        public ActionResult Ultimas(string search)
        {
            SessionInitialize();
          
            RecetaCAD recCAD = new RecetaCAD(session);
            RecetaCEN cen = new RecetaCEN(recCAD);
            IList<RecetaEN> listRecetaEN;
            IEnumerable<Receta> list;

            if (!String.IsNullOrEmpty(search))
            {
                listRecetaEN = cen.Buscar(search);
                list = new AssemblerReceta().ConvertListENToModel(listRecetaEN).ToList();
            }
            else
            {
                listRecetaEN = cen.VerUltimasRecetas();
                list = new AssemblerReceta().ConvertListENToModel(listRecetaEN).ToList();
            }
            SessionClose();
            return View(list);
        }

    }

}
