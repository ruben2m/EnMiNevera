using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EnMiNeveraGenNHibernate.EN.EnMiNevera;
using EnMiNeveraGenNHibernate.Enumerated.EnMiNevera;

namespace MVCEnMiNevera.Models
{
    public class Comentario
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Comentario", Description = "Comentario", Name = "Comentario ")]
        [Required(ErrorMessage = "El comentario no puede ser vacio")]
        public string ComentarioTexto { get; set; }

        [Display(Prompt = "Fecha del comentario", Description = "Fecha del comentario", Name = "Fecha ")]
        [DataType(DataType.Date)]
        public Nullable<DateTime> Fecha { get; set; }



        // Relaciones a 1

        [ScaffoldColumn(false)]
        public string NombreUsuario { get; set; }

        [ScaffoldColumn(false)]
        public int IdUsuario { get; set; }

        [ScaffoldColumn(false)]
        public int IdReceta { get; set; }
    }
}
