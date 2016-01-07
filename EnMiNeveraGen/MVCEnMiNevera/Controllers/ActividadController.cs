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
    public class ActividadController : BasicController
    {
        // GET: Actividad
        public ActionResult Index()
        {
            return View();
        }

        // GET: Actividad/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Actividad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Actividad/Create
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

        // GET: Actividad/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Actividad/Edit/5
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

        // GET: Actividad/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Actividad/Delete/5
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

        // GET: Actividad/Ver
        public ActionResult  Ver(int id)
        {
            SessionInitialize();
            UsuarioEN usuEN = new UsuarioCAD(session).ReadOIDDefault(id);
            IList<UsuarioEN> listSeguidosEn = usuEN.Seguidos;
            IList<String> seguidosDeSeguidos = new List<String>();
            IList<UsuarioEN> seguidos = new List<UsuarioEN>();


            foreach (UsuarioEN usu in listSeguidosEn)
            {
                seguidos.Add(usu);
                foreach(UsuarioEN usuSeguidos in usu.Seguidos)
                {
                    seguidosDeSeguidos.Add(usuSeguidos.Nick);
                    
                }
            }

            //IEnumerable<Usuario> usuActividad = new AssemblerUsuario().ConvertListENToModel(seguidosDeSeguidos).ToList();
            IEnumerable<Usuario> usuDeQuien = new AssemblerUsuario().ConvertListENToModel(listSeguidosEn).ToList();

            SessionClose();
            return View(Tuple.Create(usuDeQuien, seguidosDeSeguidos));
        }
    }
}
