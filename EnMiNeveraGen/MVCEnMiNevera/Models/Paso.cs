using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EnMiNeveraGenNHibernate.EN.EnMiNevera;
using EnMiNeveraGenNHibernate.Enumerated.EnMiNevera;

namespace MVCEnMiNevera.Models
{
    public class Paso
    {
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [Display(Prompt = "Descripción del paso", Description = "Descripción del paso", Name = "Descripcion ")]
        [Required(ErrorMessage = "Debe indicar una descripción del paso")]
        public string Descripcion { get; set; }

        [Display(Prompt = "Número de paso para", Description = "Número de paso", Name = "Número de paso ")]
        [Required(ErrorMessage = "Debe indicar un número de paso")]
        public int NumeroPaso { get; set; }


        // Relaciones a 1

        [ScaffoldColumn(false)]
        public string NombreReceta { get; set; }

        [ScaffoldColumn(false)]
        public int IdReceta { get; set; }

    }
}
