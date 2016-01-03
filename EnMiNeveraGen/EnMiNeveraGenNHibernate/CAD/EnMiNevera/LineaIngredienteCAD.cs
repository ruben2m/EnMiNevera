
using System;
using System.Text;
using EnMiNeveraGenNHibernate.CEN.EnMiNevera;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using EnMiNeveraGenNHibernate.EN.EnMiNevera;
using EnMiNeveraGenNHibernate.Exceptions;

/*
 * Clase LineaIngrediente:
 *
 */

namespace EnMiNeveraGenNHibernate.CAD.EnMiNevera
{
public partial class LineaIngredienteCAD : BasicCAD, ILineaIngredienteCAD
{
public LineaIngredienteCAD() : base ()
{
}

public LineaIngredienteCAD(ISession sessionAux) : base (sessionAux)
{
}



public LineaIngredienteEN ReadOIDDefault (int id)
{
        LineaIngredienteEN lineaIngredienteEN = null;

        try
        {
                SessionInitializeTransaction ();
                lineaIngredienteEN = (LineaIngredienteEN)session.Get (typeof(LineaIngredienteEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in LineaIngredienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaIngredienteEN;
}

public System.Collections.Generic.IList<LineaIngredienteEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<LineaIngredienteEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(LineaIngredienteEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<LineaIngredienteEN>();
                        else
                                result = session.CreateCriteria (typeof(LineaIngredienteEN)).List<LineaIngredienteEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in LineaIngredienteCAD.", ex);
        }

        return result;
}

public int New_ (LineaIngredienteEN lineaIngrediente)
{
        try
        {
                SessionInitializeTransaction ();
                if (lineaIngrediente.Ingrediente != null) {
                        // Argumento OID y no colección.
                        lineaIngrediente.Ingrediente = (EnMiNeveraGenNHibernate.EN.EnMiNevera.IngredienteEN)session.Load (typeof(EnMiNeveraGenNHibernate.EN.EnMiNevera.IngredienteEN), lineaIngrediente.Ingrediente.Id);

                        lineaIngrediente.Ingrediente.LineasIngrediente
                        .Add (lineaIngrediente);
                }
                if (lineaIngrediente.Receta != null) {
                        // Argumento OID y no colección.
                        lineaIngrediente.Receta = (EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN)session.Load (typeof(EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN), lineaIngrediente.Receta.Id);

                        lineaIngrediente.Receta.LineasIngrediente
                        .Add (lineaIngrediente);
                }

                session.Save (lineaIngrediente);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in LineaIngredienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaIngrediente.Id;
}

public void Modify (LineaIngredienteEN lineaIngrediente)
{
        try
        {
                SessionInitializeTransaction ();
                LineaIngredienteEN lineaIngredienteEN = (LineaIngredienteEN)session.Load (typeof(LineaIngredienteEN), lineaIngrediente.Id);

                lineaIngredienteEN.Cantidad = lineaIngrediente.Cantidad;


                lineaIngredienteEN.Unidad = lineaIngrediente.Unidad;

                session.Update (lineaIngredienteEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in LineaIngredienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id)
{
        try
        {
                SessionInitializeTransaction ();
                LineaIngredienteEN lineaIngredienteEN = (LineaIngredienteEN)session.Load (typeof(LineaIngredienteEN), id);
                session.Delete (lineaIngredienteEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in LineaIngredienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
