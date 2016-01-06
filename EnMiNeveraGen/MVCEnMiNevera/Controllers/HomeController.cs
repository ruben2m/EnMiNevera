using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCEnMiNevera.Filters;
using MVCEnMiNevera.Models;
using EnMiNeveraGenNHibernate.CEN.EnMiNevera;
using EnMiNeveraGenNHibernate.EN.EnMiNevera;
using EnMiNeveraGenNHibernate.CAD.EnMiNevera;
using EnMiNeveraGenNHibernate.Enumerated.EnMiNevera;

namespace MVCEnMiNevera.Controllers
{
    public class HomeController : BasicController
    {
        public ActionResult Index()
        {
            SessionInitialize();
            IngredienteCEN ingredienteCen = new IngredienteCEN();
            IList<Ingrediente> ingredientes = new AssemblerIngrediente().ConvertListENToModel(ingredienteCen.VerNubeIngredientes());
            SessionClose();
            return View(ingredientes);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}