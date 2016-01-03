using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace MVCEnMiNevera.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }

    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "Nombre de usuario")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña actual")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nueva contraseña")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar la nueva contraseña")]
        [Compare("NewPassword", ErrorMessage = "La nueva contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "Nombre de usuario")]
        public string Nick { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "¿Recordar cuenta?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
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

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Contrasena", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmaContrasena { get; set; }

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


    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}
