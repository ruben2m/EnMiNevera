

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
/*
 *      Definition of the class LineaIngredienteCEN
 *
 */
public partial class LineaIngredienteCEN
{
private ILineaIngredienteCAD _ILineaIngredienteCAD;

public LineaIngredienteCEN()
{
        this._ILineaIngredienteCAD = new LineaIngredienteCAD ();
}

public LineaIngredienteCEN(ILineaIngredienteCAD _ILineaIngredienteCAD)
{
        this._ILineaIngredienteCAD = _ILineaIngredienteCAD;
}

public ILineaIngredienteCAD get_ILineaIngredienteCAD ()
{
        return this._ILineaIngredienteCAD;
}

public int New_ (int p_cantidad, EnMiNeveraGenNHibernate.Enumerated.EnMiNevera.UnidadesEnum p_unidad, int p_ingrediente, int p_receta)
{
        LineaIngredienteEN lineaIngredienteEN = null;
        int oid;

        //Initialized LineaIngredienteEN
        lineaIngredienteEN = new LineaIngredienteEN ();
        lineaIngredienteEN.Cantidad = p_cantidad;

        lineaIngredienteEN.Unidad = p_unidad;


        if (p_ingrediente != -1) {
                // El argumento p_ingrediente -> Property ingrediente es oid = false
                // Lista de oids id
                lineaIngredienteEN.Ingrediente = new EnMiNeveraGenNHibernate.EN.EnMiNevera.IngredienteEN ();
                lineaIngredienteEN.Ingrediente.Id = p_ingrediente;
        }


        if (p_receta != -1) {
                // El argumento p_receta -> Property receta es oid = false
                // Lista de oids id
                lineaIngredienteEN.Receta = new EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN ();
                lineaIngredienteEN.Receta.Id = p_receta;
        }

        //Call to LineaIngredienteCAD

        oid = _ILineaIngredienteCAD.New_ (lineaIngredienteEN);
        return oid;
}

public void Modify (int p_LineaIngrediente_OID, int p_cantidad, EnMiNeveraGenNHibernate.Enumerated.EnMiNevera.UnidadesEnum p_unidad)
{
        LineaIngredienteEN lineaIngredienteEN = null;

        //Initialized LineaIngredienteEN
        lineaIngredienteEN = new LineaIngredienteEN ();
        lineaIngredienteEN.Id = p_LineaIngrediente_OID;
        lineaIngredienteEN.Cantidad = p_cantidad;
        lineaIngredienteEN.Unidad = p_unidad;
        //Call to LineaIngredienteCAD

        _ILineaIngredienteCAD.Modify (lineaIngredienteEN);
}

public void Destroy (int id)
{
        _ILineaIngredienteCAD.Destroy (id);
}
}
}
