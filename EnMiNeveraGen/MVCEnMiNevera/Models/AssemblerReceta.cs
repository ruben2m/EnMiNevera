using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EnMiNeveraGenNHibernate.EN.EnMiNevera;

namespace MVCEnMiNevera.Models
{
    public class AssemblerReceta
    {
        public Receta ConvertENToModelUI(RecetaEN en)
        {
            Receta receta = new Receta();
            receta.id = en.Id;
            receta.Nombre = en.Nombre;
            receta.Descripcion = en.Descripcion;
            receta.Foto = en.Foto;
            receta.FechaCreacion = en.FechaCreacion;
            receta.Estado = en.Estado;

            receta.IdUsuario = en.Usuario.Id;
            receta.NombreUsuario = en.Usuario.Nombre;

            receta.UsuariosFavorito = en.UsuariosFavorito.ToList();
            // Pasos ordenados por numero paso
            receta.Pasos = en.Pasos.OrderBy(f => f.NumeroPaso).ToList();
            receta.Comentario = en.Comentarios.ToList();
            receta.LineasIngrediente = en.LineasIngrediente.ToList();
            receta.LineasListaCompra = en.LineasListaCompra.ToList();

            return receta;
        }
        public IList<Receta> ConvertListENToModel(IList<RecetaEN> ens)
        {
            IList<Receta> recetas = new List<Receta>();
            foreach (RecetaEN en in ens)
            {
                recetas.Add(ConvertENToModelUI(en));
            }
            return recetas;
        }
    }

}
