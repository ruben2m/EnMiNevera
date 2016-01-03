
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
 * Clase Pasos:
 *
 */

namespace EnMiNeveraGenNHibernate.CAD.EnMiNevera
{
public partial class PasosCAD : BasicCAD, IPasosCAD
{
public PasosCAD() : base ()
{
}

public PasosCAD(ISession sessionAux) : base (sessionAux)
{
}



public PasosEN ReadOIDDefault (int id)
{
        PasosEN pasosEN = null;

        try
        {
                SessionInitializeTransaction ();
                pasosEN = (PasosEN)session.Get (typeof(PasosEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in PasosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pasosEN;
}

public System.Collections.Generic.IList<PasosEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PasosEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PasosEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<PasosEN>();
                        else
                                result = session.CreateCriteria (typeof(PasosEN)).List<PasosEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in PasosCAD.", ex);
        }

        return result;
}

public int New_ (PasosEN pasos)
{
        try
        {
                SessionInitializeTransaction ();
                if (pasos.Receta != null) {
                        // Argumento OID y no colección.
                        pasos.Receta = (EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN)session.Load (typeof(EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN), pasos.Receta.Id);

                        pasos.Receta.Pasos
                        .Add (pasos);
                }

                session.Save (pasos);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in PasosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pasos.Id;
}

public void Modify (PasosEN pasos)
{
        try
        {
                SessionInitializeTransaction ();
                PasosEN pasosEN = (PasosEN)session.Load (typeof(PasosEN), pasos.Id);

                pasosEN.Descripcion = pasos.Descripcion;


                pasosEN.NumeroPaso = pasos.NumeroPaso;

                session.Update (pasosEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in PasosCAD.", ex);
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
                PasosEN pasosEN = (PasosEN)session.Load (typeof(PasosEN), id);
                session.Delete (pasosEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in PasosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
