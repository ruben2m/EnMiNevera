using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EnMiNeveraGenNHibernate.EN.EnMiNevera;
using EnMiNeveraGenNHibernate.Enumerated.EnMiNevera;

namespace MVCEnMiNevera.Models
{
    public class LineaIngrediente
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Cantidad", Description = "Cantidad", Name = "Cantidad ")]
        [Required(ErrorMessage = "Debe indicar la cantidad del ingrediente")]
        public int Cantidad { get; set; }


        [Display(Prompt = "Unidad de medida", Description = "Unidad de medida", Name = "Unidad de medida ")]
        [Required(ErrorMessage = "Debe indicar la unidad de medida del ingrediente")]
        public UnidadesEnum Unidad { get; set; }

        [ScaffoldColumn(false)]
        public int IdIngrediente { get; set; }

        [Display(Prompt = "Nombre del ingrediente", Description = "Nombre del ingrediente", Name = "Nombre del ingrediente ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el ingrediente")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre del ingrediente no puede tener más de 200 caracteres")]
        public string NombreIngrediente { get; set; }

    }
}
