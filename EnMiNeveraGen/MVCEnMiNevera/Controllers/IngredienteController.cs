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
    public class IngredienteController : BasicController
    {
        // GET: Ingrediente
        public ActionResult Index()
        {
            SessionInitialize();

            IngredienteCAD ingCAD = new IngredienteCAD(session);
            IngredienteCEN cen = new IngredienteCEN(ingCAD);
            IList<IngredienteEN> listIngredienteEN = cen.VerNubeIngredientes();
            IEnumerable<Ingrediente> list = new AssemblerIngrediente().ConvertListENToModel(listIngredienteEN).ToList();
            SessionClose();
            return View(list);
        }

        // GET: Ingrediente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ingrediente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ingrediente/Create
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

        // GET: Ingrediente/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ingrediente/Edit/5
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

        // GET: Ingrediente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ingrediente/Delete/5
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