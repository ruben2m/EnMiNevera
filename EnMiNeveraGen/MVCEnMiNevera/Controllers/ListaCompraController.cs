using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCEnMiNevera.Models;
using EnMiNeveraGenNHibernate.CAD.EnMiNevera;
using EnMiNeveraGenNHibernate.CEN.EnMiNevera;
using EnMiNeveraGenNHibernate.EN.EnMiNevera;

namespace MVCEnMiNevera.Controllers
{
    public class ListaCompraController : BasicController
    {
        // GET: ListaCompra
        public ActionResult Index()
        {
            SessionInitialize();

            int oid_usuario = 1; // TODO obtener el usuario actual
            UsuarioEN usuarioEn = new UsuarioCAD(session).ReadOIDDefault(oid_usuario);

            IEnumerable<ListaCompra> listListaCompra = new AssemblerListaCompra().ConvertListENToModel(usuarioEn.ListasCompra).ToList();

            foreach(ListaCompra l in listListaCompra)
                foreach (LineaListaCompraEN lin in l.LineasListaCompra)
                {
                    lin.Ingrediente.Id = lin.Ingrediente.Id;
                    lin.Ingrediente.Nombre = lin.Ingrediente.Nombre;
                }

            //IList<LineaListaCompraEN> lineasListaCompraEn = new Linea


            SessionClose();

            return View(listListaCompra);
        }

        // GET: ListaCompra/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ListaCompra/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListaCompra/Create
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

        // GET: ListaCompra/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ListaCompra/Edit/5
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

        // GET: ListaCompra/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ListaCompra/Delete/5
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
