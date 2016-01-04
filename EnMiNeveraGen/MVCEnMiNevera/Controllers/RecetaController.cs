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

namespace MVCEnMiNevera.Controllers
{
    public class RecetaController : BasicController
    {
        // GET: Receta
        public ActionResult Index()
        {
            return View();
        }

        // GET: Receta/Ver/5
        public ActionResult Ver(int id)
        {
            SessionInitialize();

            RecetaEN en = new RecetaCAD(session).ReadOIDDefault(id);
            Receta receta = new AssemblerReceta().ConvertENToModelUI(en);

            // Aunque parezca una tontería, con esto consigo la persistencia de los datos
            foreach(LineaIngredienteEN lin in receta.LineasIngrediente)
            {
                lin.Ingrediente.Id = lin.Ingrediente.Id;
                lin.Ingrediente.Nombre = lin.Ingrediente.Nombre;
            }

            foreach(ComentarioEN com in receta.Comentario)
            {
                com.Usuario.Id = com.Usuario.Id;
                com.Usuario.Nick = com.Usuario.Nick;
            }

            if (User.Identity.IsAuthenticated)
            {
                UsuarioEN usuarioEn = new UsuarioCAD(session).GetByNick(User.Identity.Name);
                if (en.UsuariosFavorito.Contains(usuarioEn))
                    ViewData["esFavorito"] = "si";
                else
                    ViewData["esFavorito"] = "no";
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

        // GET: Receta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Receta/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
        public ActionResult Ultimas()
        {


            // new RecetaCEN().VerUltimasRecetas();

            return View();
        }

    }
}
