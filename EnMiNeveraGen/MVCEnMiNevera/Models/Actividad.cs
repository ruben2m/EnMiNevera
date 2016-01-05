using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EnMiNeveraGenNHibernate.EN.EnMiNevera;
using EnMiNeveraGenNHibernate.Enumerated.EnMiNevera;

namespace MVCEnMiNevera.Models
{
    public class Actividad
    {
        [ScaffoldColumn(false)]
        public string Usuario { get; set; }

        [ScaffoldColumn(false)]
        public string Suceso { get; set; }

        [Display(Prompt = "Fecha de la lista de la compra", Description = "Fecha de la lista de la compra", Name = "Fecha ")]
        [DataType(DataType.Date)]
        public Nullable<DateTime> Fecha { get; set; }
    }
}