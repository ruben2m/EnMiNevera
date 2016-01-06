using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EnMiNeveraGenNHibernate.EN.EnMiNevera;

namespace MVCEnMiNevera.Models
{
    public class AssemblerLineaIngrediente
    {
        public LineaIngrediente ConvertENToModelUI(LineaIngredienteEN en)
        {
            LineaIngrediente model = new LineaIngrediente();
            model.Id = en.Id;
            model.Cantidad = en.Cantidad;
            model.Unidad = en.Unidad;

            model.IdIngrediente = en.Ingrediente.Id;
            model.NombreIngrediente = en.Ingrediente.Nombre;

            return model;
        }
        public IList<LineaIngrediente> ConvertListENToModel(IList<LineaIngredienteEN> ens)
        {
            IList<LineaIngrediente> lista = new List<LineaIngrediente>();
            foreach (LineaIngredienteEN l in ens)
            {
                lista.Add(ConvertENToModelUI(l));
            }
            return lista;
        }
    }

}
