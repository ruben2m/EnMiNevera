using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;
using System.IO;
using MVCEnMiNevera.Models;
using MVCEnMiNevera.Filters;
using EnMiNeveraGenNHibernate.CAD.EnMiNevera;
using EnMiNeveraGenNHibernate.CEN.EnMiNevera;
using EnMiNeveraGenNHibernate.EN.EnMiNevera;
using NHibernate;

namespace MVCEnMiNevera.Controllers
{
    public class UsuarioController : BasicController
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        // GET: Usuario/Perfil/5
        [Authorize]
        //[InitializeSimpleMembership]
        public ActionResult Perfil(int id = -1)
        {
            SessionInitialize();

            //int id = 1; // TODO poner el id a currentUser
            //int id = WebSecurity.GetUserId(User.Identity.Name);
            //UsuarioEN en = new UsuarioCAD(session).ReadOIDDefault(id);
            UsuarioEN en = null;
            UsuarioEN usuarioActualEn = new UsuarioCAD(session).GetByNick(User.Identity.Name);
            if(id==-1)
            {
                en = usuarioActualEn;
            }
            else
            {
                en = new UsuarioCAD(session).ReadOIDDefault(id);
            }

            ViewData["usuarioActual"] = (en.Nick == User.Identity.Name);

            ViewData["siguiendo"] = (usuarioActualEn.Seguidos.Contains(en));

            Usuario usuario = new AssemblerUsuario().ConvertENToModelUI(en);

            ViewData["numSeguidos"] = usuario.Seguidos.Count();
            ViewData["numSeguidores"] = usuario.Seguidores.Count();

            SessionClose();

            return View(usuario);
        }

        // GET: Usuario/Seguir/5
        [Authorize]
        public ActionResult seguir(int id)
        {
            SessionInitialize();

            UsuarioCAD usuarioCad = new UsuarioCAD(session);

            UsuarioEN usuarioEn = usuarioCad.GetByNick(User.Identity.Name);

            new UsuarioCEN(usuarioCad).Seguir(usuarioEn.Id, id);

            SessionClose();

            return RedirectToAction("perfil", new { id = id });
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
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

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuario/Edit/5
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

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
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
    }
}
