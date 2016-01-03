using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EnMiNeveraGenNHibernate.EN.EnMiNevera;

namespace MVCEnMiNevera.Models
{
    public class Usuario
    {
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [Display(Prompt = "Nombre del usuario", Description = "Nombre del usuario", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el usuario")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre del usuario no puede tener más de 200 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Apellidos del usuario", Description = "Apellidos del usuario", Name = "Apellidos ")]
        [StringLength(maximumLength: 200, ErrorMessage = "Los apellidos del usuario no puede tener más de 200 caracteres")]
        public string Apellidos { get; set; }


        [Display(Prompt = "Contraseña del usuario", Description = "Contraseña del usuario", Name = "Contraseña ")]
        [Required(ErrorMessage = "Debe indicar una contraseña para el usuario")]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; }

        [Display(Prompt = "EMail del usuario", Description = "EMail del usuario", Name = "EMail ")]
        [Required(ErrorMessage = "Debe indicar un EMail para el usuario")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Prompt = "Nick del usuario", Description = "Nick del usuario", Name = "Nick ")]
        [Required(ErrorMessage = "Debe indicar un Nick para el usuario")]
        [StringLength(maximumLength: 200, ErrorMessage = "El Nick del usuario no puede tener más de 20 caracteres")]
        public string Nick { get; set; }

        [Display(Prompt = "Foto del usuario", Description = "Foto del usuario", Name = "Foto ")]
        public string Foto { get; set; }

        [Display(Prompt = "Biografía del usuario", Description = "Biografía del usuario", Name = "Biografía ")]
        [DataType(DataType.MultilineText)]
        public string Biografia { get; set; }

        [Display(Prompt = "Fecha de Nacimiento del usuario", Description = "Fecha de Nacimiento del usuario", Name = "Fecha de Nacimiento ")]
        [Required(ErrorMessage = "Debe indicar una Fecha de Nacimiento para el usuario")]
        [DataType(DataType.Date)]
        public Nullable<DateTime> FechaNacim { get; set; }

        [Display(Prompt = "El usuario está baneado", Description = "Usuario baneado", Name = "Baneado ")]
        public Boolean Baneado { get; set; }

        public IList<RecetaEN> Recetas { get; set; }

        public IList<RecetaEN> RecetasFavoritas { get; set; }

        public IList<UsuarioEN> Seguidores { get; set; }

        public IList<UsuarioEN> Seguidos { get; set; }
    }
}