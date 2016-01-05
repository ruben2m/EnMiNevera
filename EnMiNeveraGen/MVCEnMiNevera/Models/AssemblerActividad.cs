using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EnMiNeveraGenNHibernate.EN.EnMiNevera;

namespace MVCEnMiNevera.Models
{
    public class AssemblerActividad
    {
        public Actividad ConvertENToModelUI(UsuarioEN en)
        {
            Actividad model = new Actividad();

            return model;
        }
        public IList<Actividad> ConvertListENToModel(IList<UsuarioEN> ens)
        {
            IList<UsuarioEN> lista = new List<UsuarioEN>();
            foreach (UsuarioEN l in ens)
            {
                lista.Add(ConvertENToModelUI(l));
            }
            return lista;
        }
    }

}