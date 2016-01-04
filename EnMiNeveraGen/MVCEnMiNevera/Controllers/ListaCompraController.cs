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

            if (id == -1)
                ViewData["idListaActiva"] = listListaCompra.First().Id;
            else
                ViewData["idListaActiva"] = id;

            return View(listListaCompra);
        }

        // GET: ListaCompra/check/1
        [Authorize]
        public ActionResult Check(int id)
        {
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
            en.Comprado = !en.Comprado;
            idListaCompra = en.ListaCompra.Id;  // No da lazyException... Solo se puede acceder al ID para que no dé.
            cad.Modify(en);

            return RedirectToAction("Index", new { id = idListaCompra });
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
