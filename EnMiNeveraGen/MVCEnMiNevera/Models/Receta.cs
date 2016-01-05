using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EnMiNeveraGenNHibernate.EN.EnMiNevera;
using EnMiNeveraGenNHibernate.Enumerated.EnMiNevera;

namespace MVCEnMiNevera.Models
{
    public class Receta
    {
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [Display(Prompt = "Nombre de la receta", Description = "Nombre de la receta", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar un nombre para la receta")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre de la receta no puede tener más de 200 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Descripción de la receta", Description = "Descripción de la receta", Name = "Descripcion ")]
        [Required(ErrorMessage = "Debe indicar una descripción para la receta")]
        public string Descripcion { get; set; }

        [Display(Prompt = "Foto de la receta", Description = "Foto de la receta", Name = "Foto ")]
        [Required(ErrorMessage = "Debe indicar una foto para la receta")]
        public string Foto { get; set; }

        [Display(Prompt = "Fecha de creación de la receta", Description = "Fecha de creación de la receta", Name = "Fecha de Creación ")]
        [DataType(DataType.Date)]
        public Nullable<DateTime> FechaCreacion { get; set; }

        [Display(Prompt = "Estado de publicación de la receta", Description = "Estado de publicación de la receta", Name = "Estado ")]
        public EstadosEnum Estado { get; set; }


        // Relaciones a 1

        [ScaffoldColumn(false)]
        public string NombreUsuario { get; set; }

        [ScaffoldColumn(false)]
        public int IdUsuario { get; set; }


        // Relaciones a *

        [ScaffoldColumn(false)]
        public IList<UsuarioEN> UsuariosFavorito { get; set; }

        [ScaffoldColumn(false)]
        public IList<PasosEN> Pasos { get; set; }

        [ScaffoldColumn(false)]
        public IList<Comentario> Comentarios { get; set; }

        [ScaffoldColumn(false)]
        public IList<LineaIngredienteEN> LineasIngrediente { get; set; }

        [ScaffoldColumn(false)]
        public IList<LineaListaCompraEN> LineasListaCompra { get; set; }
    }
}
