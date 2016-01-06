using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EnMiNeveraGenNHibernate.EN.EnMiNevera;

namespace MVCEnMiNevera.Models
{
    public class AssemblerPaso
    {
        public Paso ConvertENToModelUI(PasosEN en)
        {
            Paso model = new Paso();
            model.id = en.Id;
            model.Descripcion = en.Descripcion;
            model.NumeroPaso = en.NumeroPaso;

            model.IdReceta = en.Receta.Id;
            model.NombreReceta = en.Receta.Nombre;

            return model;
        }
        public IList<Paso> ConvertListENToModel(IList<PasosEN> ens)
        {
            IList<Paso> lista = new List<Paso>();
            foreach (PasosEN en in ens)
            {
                lista.Add(ConvertENToModelUI(en));
            }
            return lista;
        }
    }

}
