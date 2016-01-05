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
    public class ComentarioController : BasicController
    {
        // POST: Comentario/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(Comentario comentario, int idReceta)
        {
            try
            {
                // Obtenemos usuario actual
                UsuarioEN usuarioEn = new UsuarioCAD().GetByNick(User.Identity.Name);

                comentario.Fecha = DateTime.Now;

                int id = new ComentarioCEN().New_(usuarioEn.Id, idReceta, comentario.ComentarioTexto, comentario.Fecha);

                return RedirectToAction("ver", "receta", new { id = idReceta });
            }
            catch
            {
                return View();
            }
        }

        // GET: Comentario/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            SessionInitialize();

            ComentarioCAD cad = new ComentarioCAD(session);
            ComentarioEN en = cad.ReadOIDDefault(id);
            int idReceta = en.Receta.Id;
            if(en.Usuario.Nick != User.Identity.Name)
                return RedirectToAction("Index");

            SessionClose();

            new ComentarioCAD().Destroy(id);  // Si lo hago dentro del session, no hace nada


            return RedirectToAction("ver", "receta", new { id = idReceta });
        }

    }
}
