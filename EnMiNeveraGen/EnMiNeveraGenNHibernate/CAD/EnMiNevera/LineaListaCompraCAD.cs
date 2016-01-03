
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
 * Clase LineaListaCompra:
 *
 */

namespace EnMiNeveraGenNHibernate.CAD.EnMiNevera
{
public partial class LineaListaCompraCAD : BasicCAD, ILineaListaCompraCAD
{
public LineaListaCompraCAD() : base ()
{
}

public LineaListaCompraCAD(ISession sessionAux) : base (sessionAux)
{
}



public LineaListaCompraEN ReadOIDDefault (int id)
{
        LineaListaCompraEN lineaListaCompraEN = null;

        try
        {
                SessionInitializeTransaction ();
                lineaListaCompraEN = (LineaListaCompraEN)session.Get (typeof(LineaListaCompraEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in LineaListaCompraCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaListaCompraEN;
}

public System.Collections.Generic.IList<LineaListaCompraEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<LineaListaCompraEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(LineaListaCompraEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<LineaListaCompraEN>();
                        else
                                result = session.CreateCriteria (typeof(LineaListaCompraEN)).List<LineaListaCompraEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in LineaListaCompraCAD.", ex);
        }

        return result;
}

public int New_ (LineaListaCompraEN lineaListaCompra)
{
        try
        {
                SessionInitializeTransaction ();
                if (lineaListaCompra.Ingrediente != null) {
                        // Argumento OID y no colección.
                        lineaListaCompra.Ingrediente = (EnMiNeveraGenNHibernate.EN.EnMiNevera.IngredienteEN)session.Load (typeof(EnMiNeveraGenNHibernate.EN.EnMiNevera.IngredienteEN), lineaListaCompra.Ingrediente.Id);

                        lineaListaCompra.Ingrediente.LineasListaCompra
                        .Add (lineaListaCompra);
                }
                if (lineaListaCompra.ListaCompra != null) {
                        // Argumento OID y no colección.
                        lineaListaCompra.ListaCompra = (EnMiNeveraGenNHibernate.EN.EnMiNevera.ListaCompraEN)session.Load (typeof(EnMiNeveraGenNHibernate.EN.EnMiNevera.ListaCompraEN), lineaListaCompra.ListaCompra.Id);

                        lineaListaCompra.ListaCompra.LineasListaCompra
                        .Add (lineaListaCompra);
                }

                session.Save (lineaListaCompra);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in LineaListaCompraCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaListaCompra.Id;
}

public void Modify (LineaListaCompraEN lineaListaCompra)
{
        try
        {
                SessionInitializeTransaction ();
                LineaListaCompraEN lineaListaCompraEN = (LineaListaCompraEN)session.Load (typeof(LineaListaCompraEN), lineaListaCompra.Id);

                lineaListaCompraEN.Cantidad = lineaListaCompra.Cantidad;


                lineaListaCompraEN.Unidad = lineaListaCompra.Unidad;


                lineaListaCompraEN.Comprado = lineaListaCompra.Comprado;

                session.Update (lineaListaCompraEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in LineaListaCompraCAD.", ex);
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
                LineaListaCompraEN lineaListaCompraEN = (LineaListaCompraEN)session.Load (typeof(LineaListaCompraEN), id);
                session.Delete (lineaListaCompraEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in LineaListaCompraCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
