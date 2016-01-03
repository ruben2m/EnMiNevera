

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
 *      Definition of the class PasosCEN
 *
 */
public partial class PasosCEN
{
private IPasosCAD _IPasosCAD;

public PasosCEN()
{
        this._IPasosCAD = new PasosCAD ();
}

public PasosCEN(IPasosCAD _IPasosCAD)
{
        this._IPasosCAD = _IPasosCAD;
}

public IPasosCAD get_IPasosCAD ()
{
        return this._IPasosCAD;
}

public int New_ (string p_descripcion, int p_receta, int p_numeroPaso)
{
        PasosEN pasosEN = null;
        int oid;

        //Initialized PasosEN
        pasosEN = new PasosEN ();
        pasosEN.Descripcion = p_descripcion;


        if (p_receta != -1) {
                // El argumento p_receta -> Property receta es oid = false
                // Lista de oids id
                pasosEN.Receta = new EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN ();
                pasosEN.Receta.Id = p_receta;
        }

        pasosEN.NumeroPaso = p_numeroPaso;

        //Call to PasosCAD

        oid = _IPasosCAD.New_ (pasosEN);
        return oid;
}

public void Modify (int p_Pasos_OID, string p_descripcion, int p_numeroPaso)
{
        PasosEN pasosEN = null;

        //Initialized PasosEN
        pasosEN = new PasosEN ();
        pasosEN.Id = p_Pasos_OID;
        pasosEN.Descripcion = p_descripcion;
        pasosEN.NumeroPaso = p_numeroPaso;
        //Call to PasosCAD

        _IPasosCAD.Modify (pasosEN);
}

public void Destroy (int id)
{
        _IPasosCAD.Destroy (id);
}
}
}
