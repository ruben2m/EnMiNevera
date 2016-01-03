
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
 * Clase ListaCompra:
 *
 */

namespace EnMiNeveraGenNHibernate.CAD.EnMiNevera
{
public partial class ListaCompraCAD : BasicCAD, IListaCompraCAD
{
public ListaCompraCAD() : base ()
{
}

public ListaCompraCAD(ISession sessionAux) : base (sessionAux)
{
}



public ListaCompraEN ReadOIDDefault (int id)
{
        ListaCompraEN listaCompraEN = null;

        try
        {
                SessionInitializeTransaction ();
                listaCompraEN = (ListaCompraEN)session.Get (typeof(ListaCompraEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in ListaCompraCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return listaCompraEN;
}

public System.Collections.Generic.IList<ListaCompraEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ListaCompraEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ListaCompraEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ListaCompraEN>();
                        else
                                result = session.CreateCriteria (typeof(ListaCompraEN)).List<ListaCompraEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in ListaCompraCAD.", ex);
        }

        return result;
}

public int New_ (ListaCompraEN listaCompra)
{
        try
        {
                SessionInitializeTransaction ();
                if (listaCompra.Usuario != null) {
                        // Argumento OID y no colección.
                        listaCompra.Usuario = (EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN)session.Load (typeof(EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN), listaCompra.Usuario.Id);

                        listaCompra.Usuario.ListasCompra
                        .Add (listaCompra);
                }

                session.Save (listaCompra);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in ListaCompraCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return listaCompra.Id;
}

public void Modify (ListaCompraEN listaCompra)
{
        try
        {
                SessionInitializeTransaction ();
                ListaCompraEN listaCompraEN = (ListaCompraEN)session.Load (typeof(ListaCompraEN), listaCompra.Id);

                listaCompraEN.Nombre = listaCompra.Nombre;


                listaCompraEN.Fecha = listaCompra.Fecha;

                session.Update (listaCompraEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in ListaCompraCAD.", ex);
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
                ListaCompraEN listaCompraEN = (ListaCompraEN)session.Load (typeof(ListaCompraEN), id);
                session.Delete (listaCompraEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in ListaCompraCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
