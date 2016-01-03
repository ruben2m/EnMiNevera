using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EnMiNeveraGenNHibernate.EN.EnMiNevera;
using EnMiNeveraGenNHibernate.CEN.EnMiNevera;
using EnMiNeveraGenNHibernate.CAD.EnMiNevera;

namespace MVCEnMiNevera.Models
{
    public class AssemblerUsuario
    {
        public Usuario ConvertENToModelUI(UsuarioEN en)
        {
            Usuario usu = new Usuario();
            usu.id = en.Id;
            usu.Nombre = en.Nombre;
            usu.Apellidos = en.Apellidos;
            usu.Contrasena = en.Contrasena;
            usu.Email = en.Email;
            usu.Nick = en.Nick;
            usu.Foto = en.Foto;
            usu.Biografia = en.Biografia;
            usu.FechaNacim = en.FechaNacim;
            usu.Baneado = en.Baneado;
            usu.Recetas = en.Recetas.ToList();
            usu.RecetasFavoritas = en.Favoritos.ToList();
            usu.Seguidores = en.Seguidores.ToList();
            usu.Seguidos = en.Seguidos.ToList();
            return usu;


        }
        public IList<Usuario> ConvertListENToModel(IList<UsuarioEN> ens)
        {
            IList<Usuario> usus = new List<Usuario>();
            foreach (UsuarioEN en in ens)
            {
                usus.Add(ConvertENToModelUI(en));
            }
            return usus;
        }
    }

}