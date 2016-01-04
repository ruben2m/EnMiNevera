using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EnMiNeveraGenNHibernate.EN.EnMiNevera;
using EnMiNeveraGenNHibernate.Enumerated.EnMiNevera;

namespace MVCEnMiNevera.Models
{
    public class ListaCompra
    {
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [Display(Prompt = "Nombre de la lista de la compra", Description = "Nombre de la lista de la compra", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar un nombre para la lista de la compra")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre de la lista de la compra no puede tener más de 200 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Fecha de la lista de la compra", Description = "Fecha de la lista de la compra", Name = "Fecha ")]
        [DataType(DataType.Date)]
        public Nullable<DateTime> Fecha { get; set; }

        // Relaciones a 1
        [ScaffoldColumn(false)]
        public string NombreUsuario { get; set; }

        [ScaffoldColumn(false)]
        public int IdUsuario { get; set; }


        // Relaciones a *

        [ScaffoldColumn(false)]
        public IList<LineaListaCompraEN> LineasListaCompra { get; set; }
    }
}
