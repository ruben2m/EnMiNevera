using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EnMiNeveraGenNHibernate.EN.EnMiNevera;

namespace MVCEnMiNevera.Models
{
    public class AssemblerComentario
    {
        public Comentario ConvertENToModelUI(ComentarioEN en)
        {
            Comentario model = new Comentario();
            model.Id = en.Id;
            model.ComentarioTexto = en.Comentario;
            model.Fecha = en.Fecha;

            model.IdUsuario = en.Usuario.Id;
            model.NombreUsuario = en.Usuario.Nick;

            model.IdReceta = en.Receta.Id;

            return model;
        }
        public IList<Comentario> ConvertListENToModel(IList<ComentarioEN> ens)
        {
            IList<Comentario> lista = new List<Comentario>();
            foreach (ComentarioEN en in ens)
            {
                lista.Add(ConvertENToModelUI(en));
            }
            return lista;
        }
    }

}
