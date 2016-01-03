

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
 *      Definition of the class IngredienteCEN
 *
 */
public partial class IngredienteCEN
{
private IIngredienteCAD _IIngredienteCAD;

public IngredienteCEN()
{
        this._IIngredienteCAD = new IngredienteCAD ();
}

public IngredienteCEN(IIngredienteCAD _IIngredienteCAD)
{
        this._IIngredienteCAD = _IIngredienteCAD;
}

public IIngredienteCAD get_IIngredienteCAD ()
{
        return this._IIngredienteCAD;
}

public int New_ (string p_nombre)
{
        IngredienteEN ingredienteEN = null;
        int oid;

        //Initialized IngredienteEN
        ingredienteEN = new IngredienteEN ();
        ingredienteEN.Nombre = p_nombre;

        //Call to IngredienteCAD

        oid = _IIngredienteCAD.New_ (ingredienteEN);
        return oid;
}

public void Modify (int p_Ingrediente_OID, string p_nombre)
{
        IngredienteEN ingredienteEN = null;

        //Initialized IngredienteEN
        ingredienteEN = new IngredienteEN ();
        ingredienteEN.Id = p_Ingrediente_OID;
        ingredienteEN.Nombre = p_nombre;
        //Call to IngredienteCAD

        _IIngredienteCAD.Modify (ingredienteEN);
}

public void Destroy (int id)
{
        _IIngredienteCAD.Destroy (id);
}

public System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.IngredienteEN> VerNubeIngredientes ()
{
        return _IIngredienteCAD.VerNubeIngredientes ();
}
public EnMiNeveraGenNHibernate.EN.EnMiNevera.IngredienteEN GetPorNombre (string p_nombre)
{
        return _IIngredienteCAD.GetPorNombre (p_nombre);
}
}
}
