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
            Receta model = new Receta();
            model.id = en.Id;
            model.Nombre = en.Nombre;
            model.Descripcion = en.Descripcion;
            model.Foto = en.Foto;
            model.FechaCreacion = en.FechaCreacion;
            model.Estado = en.Estado;

            model.IdUsuario = en.Usuario.Id;
            model.NombreUsuario = en.Usuario.Nick;

            model.UsuariosFavorito = en.UsuariosFavorito.ToList();
            // Pasos ordenados por numero paso
            model.Pasos = new AssemblerPaso().ConvertListENToModel(en.Pasos);
            model.Pasos = model.Pasos.OrderBy(f => f.NumeroPaso).ToList();

            model.Comentarios = new AssemblerComentario().ConvertListENToModel(en.Comentarios);
            //model.Comentarios = en.Comentarios.ToList();

            model.LineasIngrediente = new AssemblerLineaIngrediente().ConvertListENToModel(en.LineasIngrediente);
            //model.LineasIngrediente = en.LineasIngrediente.ToList();

            model.LineasListaCompra = en.LineasListaCompra.ToList();

            return model;
        }
        public IList<Receta> ConvertListENToModel(IList<RecetaEN> ens)
        {
            IList<Receta> lista = new List<Receta>();
            foreach (RecetaEN en in ens)
            {
                lista.Add(ConvertENToModelUI(en));
            }
            return lista;
        }
    }

}
