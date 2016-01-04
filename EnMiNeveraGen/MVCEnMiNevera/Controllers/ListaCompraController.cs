using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCEnMiNevera.Models;
using EnMiNeveraGenNHibernate.CAD.EnMiNevera;
using EnMiNeveraGenNHibernate.CEN.EnMiNevera;
using EnMiNeveraGenNHibernate.EN.EnMiNevera;
using NHibernate;

namespace MVCEnMiNevera.Controllers
{
    public class ListaCompraController : BasicController
    {
        // GET: ListaCompra
        [Authorize]
        public ActionResult Index(int id = -1)
        {
            SessionInitialize();

            UsuarioEN usuarioEn = new UsuarioCAD(session).GetByNick(User.Identity.Name);

            IList<ListaCompra> listListaCompra = new AssemblerListaCompra().ConvertListENToModel(usuarioEn.ListasCompra).ToList();

            // Hago persistentes los datos
            foreach(ListaCompra l in listListaCompra)
                foreach (LineaListaCompraEN lin in l.LineasListaCompra)
                {
                    lin.Ingrediente.Id = lin.Ingrediente.Id;
                    lin.Ingrediente.Nombre = lin.Ingrediente.Nombre;
                }

            SessionClose();

            if(listListaCompra.Count == 0)
                ViewData["idListaActiva"] = -1;
            else if (id == -1)
                ViewData["idListaActiva"] = listListaCompra.First().Id;
            else
                ViewData["idListaActiva"] = id;

            var tuple = new Tuple<IList<ListaCompra>, LineaListaCompra>(listListaCompra, new LineaListaCompra());
            
            return View(tuple);
        }

        // GET: ListaCompra/check/1
        [Authorize]
        public ActionResult Check(int id)
        {
            // TODO comprobar que pertecene a usuario actual

            // Utilizando session no funciona
            //SessionInitialize();
            //LineaListaCompraCAD lineaListaCompraCad = new LineaListaCompraCAD(session);
            //LineaListaCompraCEN lineaListaCompraCen = new LineaListaCompraCEN(lineaListaCompraCad);
            //LineaListaCompraEN en = lineaListaCompraCad.ReadOIDDefault(id);
            ////lineaListaCompraCen.Modify(en.Id, en.Cantidad, en.Unidad, !en.Comprado);
            ////lineaListaCompraEn.Comprado = !lineaListaCompraEn.Comprado;
            ////lineaListaCompraCad.Modify(lineaListaCompraEn);
            //SessionClose();

            int idListaCompra = -1;

            LineaListaCompraCAD cad = new LineaListaCompraCAD();
            LineaListaCompraEN en = new LineaListaCompraEN();

            en = cad.ReadOIDDefault(id);
            idListaCompra = en.ListaCompra.Id;  // No da lazyException... Solo se puede acceder al ID para que no dé.

            en.Comprado = !en.Comprado;
            cad.Modify(en);


            return RedirectToAction("Index", new { id = idListaCompra });
        }


        // POST: ListaCompra/Add
        // Añade una linea a la lista de la compra
        [Authorize]
        [HttpPost]
        public ActionResult Add(LineaListaCompra lineaListaCompra, int idListaCompra)
        {
            // TODO comprobar que pertecene a usuario actual

            // Siempre en minusculas
            lineaListaCompra.NombreIngrediente = lineaListaCompra.NombreIngrediente.ToLower();

            IngredienteCEN ingredienteCen = new IngredienteCEN();
            IngredienteEN ingredienteEn = ingredienteCen.GetPorNombre(lineaListaCompra.NombreIngrediente);

            int idIngrediente;

            // Buscamos el NombreIngrediente en ingredientes, si no existe creamos
            if (ingredienteEn == null)
                idIngrediente = ingredienteCen.New_(lineaListaCompra.NombreIngrediente);
            else
                idIngrediente = ingredienteEn.Id;

            LineaListaCompraCEN lineaListaCompraCen = new LineaListaCompraCEN();
            lineaListaCompraCen.New_(lineaListaCompra.Cantidad, lineaListaCompra.Unidad, idIngrediente, idListaCompra, false);


            return RedirectToAction("Index", new { id = idListaCompra });
        }


        // GET: ListaCompra/Remove/2
        // Borra una linea de la lista de la compra
        [Authorize]
        public ActionResult Remove(int id)
        {
            // TODO comprobar que pertecene a usuario actual

            // Obtengo en que lista de la compra estoy
            LineaListaCompraCAD cad = new LineaListaCompraCAD();
            LineaListaCompraEN en = cad.ReadOIDDefault(id);

            int idListaCompra = en.ListaCompra.Id;

            cad.Destroy(id);

            return RedirectToAction("Index", new { id = idListaCompra });
        }

 

        // POST: ListaCompra/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(ListaCompra listaCompra)
        {
            try
            {

                // Obtenemos usuario actual
                UsuarioEN usuarioEn = new UsuarioCAD().GetByNick(User.Identity.Name);

                listaCompra.Fecha = DateTime.Now;

                int id = new ListaCompraCEN().New_(listaCompra.Nombre, listaCompra.Fecha, usuarioEn.Id);

                return RedirectToAction("Index", new { id = id });
            }
            catch
            {
                return View();
            }
        }


        // GET: ListaCompra/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            // TODO comprobar que pertecene a usuario actual

            new ListaCompraCAD().Destroy(id);

            return RedirectToAction("Index");
        }

    }
}
