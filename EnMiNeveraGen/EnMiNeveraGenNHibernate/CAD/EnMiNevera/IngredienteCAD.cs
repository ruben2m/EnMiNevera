
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
 * Clase Ingrediente:
 *
 */

namespace EnMiNeveraGenNHibernate.CAD.EnMiNevera
{
public partial class IngredienteCAD : BasicCAD, IIngredienteCAD
{
public IngredienteCAD() : base ()
{
}

public IngredienteCAD(ISession sessionAux) : base (sessionAux)
{
}



public IngredienteEN ReadOIDDefault (int id)
{
        IngredienteEN ingredienteEN = null;

        try
        {
                SessionInitializeTransaction ();
                ingredienteEN = (IngredienteEN)session.Get (typeof(IngredienteEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in IngredienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return ingredienteEN;
}

public System.Collections.Generic.IList<IngredienteEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<IngredienteEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(IngredienteEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<IngredienteEN>();
                        else
                                result = session.CreateCriteria (typeof(IngredienteEN)).List<IngredienteEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in IngredienteCAD.", ex);
        }

        return result;
}

public int New_ (IngredienteEN ingrediente)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (ingrediente);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in IngredienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return ingrediente.Id;
}

public void Modify (IngredienteEN ingrediente)
{
        try
        {
                SessionInitializeTransaction ();
                IngredienteEN ingredienteEN = (IngredienteEN)session.Load (typeof(IngredienteEN), ingrediente.Id);

                ingredienteEN.Nombre = ingrediente.Nombre;

                session.Update (ingredienteEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in IngredienteCAD.", ex);
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
                IngredienteEN ingredienteEN = (IngredienteEN)session.Load (typeof(IngredienteEN), id);
                session.Delete (ingredienteEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in IngredienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.IngredienteEN> VerNubeIngredientes ()
{
        System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.IngredienteEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM IngredienteEN self where SELECT ing FROM IngredienteEN ing LEFT JOIN ing.LineasIngrediente lin GROUP BY ing.Id, ing.Nombre ORDER BY COUNT(lin) DESC TAKE 12";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("IngredienteENverNubeIngredientesHQL");

                result = query.List<EnMiNeveraGenNHibernate.EN.EnMiNevera.IngredienteEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in IngredienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public EnMiNeveraGenNHibernate.EN.EnMiNevera.IngredienteEN GetPorNombre (string p_nombre)
{
        EnMiNeveraGenNHibernate.EN.EnMiNevera.IngredienteEN result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM IngredienteEN self where FROM IngredienteEN ing WHERE ing.Nombre = :p_nombre";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("IngredienteENgetPorNombreHQL");
                query.SetParameter ("p_nombre", p_nombre);


                result = query.UniqueResult<EnMiNeveraGenNHibernate.EN.EnMiNevera.IngredienteEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in IngredienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
