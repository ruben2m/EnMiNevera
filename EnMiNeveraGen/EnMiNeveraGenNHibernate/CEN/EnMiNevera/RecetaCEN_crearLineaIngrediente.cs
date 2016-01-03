
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using EnMiNeveraGenNHibernate.EN.EnMiNevera;
using EnMiNeveraGenNHibernate.CAD.EnMiNevera;

namespace EnMiNeveraGenNHibernate.CEN.EnMiNevera
{
public partial class RecetaCEN
{
public void CrearLineaIngrediente (int p_oid, int p_cantidad, EnMiNeveraGenNHibernate.Enumerated.EnMiNevera.UnidadesEnum p_unidad, string p_nombre)
{
        /*PROTECTED REGION ID(EnMiNeveraGenNHibernate.CEN.EnMiNevera_Receta_crearLineaIngrediente) ENABLED START*/

        // Write here your custom code...

        RecetaEN receta = _IRecetaCAD.ReadOIDDefault (p_oid);
        LineaIngredienteEN linea = new LineaIngredienteEN ();
        IngredienteEN ingrediente = new IngredienteEN ();

        linea.Cantidad = p_cantidad;
        linea.Unidad = p_unidad;
        linea.Ingrediente = ingrediente;


        //throw new NotImplementedException ("Method CrearLineaIngrediente() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
