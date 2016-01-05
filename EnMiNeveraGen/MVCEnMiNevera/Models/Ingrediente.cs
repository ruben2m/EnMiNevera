using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EnMiNeveraGenNHibernate.EN.EnMiNevera;
using EnMiNeveraGenNHibernate.Enumerated.EnMiNevera;

namespace MVCEnMiNevera.Models
{
    public class Ingrediente
    {
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [Display(Prompt = "Nombre del ingrediente", Description = "Nombre del ingrediente", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el ingrediente")]
        [StringLength(maximumLength: 30, ErrorMessage = "El nombre del ingrediente no puede tener más de 30 caracteres")]
        public string Nombre { get; set; }
    }
}