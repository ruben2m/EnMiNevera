using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EnMiNeveraGenNHibernate.EN.EnMiNevera;

namespace MVCEnMiNevera.Models
{
    public class AssemblerIngrediente
    {
        public Ingrediente ConvertENToModelUI(IngredienteEN en)
        {
            Ingrediente model = new Ingrediente();
            model.id = en.Id;
            model.Nombre = en.Nombre;
            model.LineasIngrediente = en.LineasIngrediente.ToList();
            model.LineasListaCompra = en.LineasListaCompra.ToList();


            return model;
        }
        public IList<Ingrediente> ConvertListENToModel(IList<IngredienteEN> ens)
        {
            IList<Ingrediente> lista = new List<Ingrediente>();
            foreach (IngredienteEN en in ens)
            {
                lista.Add(ConvertENToModelUI(en));
            }
            return lista;
        }
    }

}
