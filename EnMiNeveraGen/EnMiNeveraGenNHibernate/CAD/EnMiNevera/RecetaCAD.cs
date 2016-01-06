
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
 * Clase Receta:
 *
 */

namespace EnMiNeveraGenNHibernate.CAD.EnMiNevera
{
public partial class RecetaCAD : BasicCAD, IRecetaCAD
{
public RecetaCAD() : base ()
{
}

public RecetaCAD(ISession sessionAux) : base (sessionAux)
{
}



public RecetaEN ReadOIDDefault (int id)
{
        RecetaEN recetaEN = null;

        try
        {
                SessionInitializeTransaction ();
                recetaEN = (RecetaEN)session.Get (typeof(RecetaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in RecetaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return recetaEN;
}

public System.Collections.Generic.IList<RecetaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<RecetaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(RecetaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<RecetaEN>();
                        else
                                result = session.CreateCriteria (typeof(RecetaEN)).List<RecetaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in RecetaCAD.", ex);
        }

        return result;
}

public int New_ (RecetaEN receta)
{
        try
        {
                SessionInitializeTransaction ();
                if (receta.Usuario != null) {
                        // Argumento OID y no colección.
                        receta.Usuario = (EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN)session.Load (typeof(EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN), receta.Usuario.Id);

                        receta.Usuario.Recetas
                        .Add (receta);
                }

                session.Save (receta);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in RecetaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return receta.Id;
}

public void Modify (RecetaEN receta)
{
        try
        {
                SessionInitializeTransaction ();
                RecetaEN recetaEN = (RecetaEN)session.Load (typeof(RecetaEN), receta.Id);

                recetaEN.Nombre = receta.Nombre;


                recetaEN.Descripcion = receta.Descripcion;


                recetaEN.Foto = receta.Foto;


                recetaEN.FechaCreacion = receta.FechaCreacion;


                recetaEN.Estado = receta.Estado;

                session.Update (recetaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in RecetaCAD.", ex);
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
                RecetaEN recetaEN = (RecetaEN)session.Load (typeof(RecetaEN), id);
                session.Delete (recetaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in RecetaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN> Buscar (string p_texto)
{
        System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM RecetaEN self where FROM RecetaEN re WHERE re.Descripcion LIKE CONCAT( '%', :p_texto, '%') OR re.Nombre LIKE CONCAT('%', :p_texto, '%')";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("RecetaENbuscarHQL");
                query.SetParameter ("p_texto", p_texto);

                result = query.List<EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in RecetaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN> BuscarPorIngrediente (System.Collections.Generic.IList<int> p_lista_ingredientes)
{
        System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM RecetaEN self where SELECT DISTINCT re FROM RecetaEN re INNER JOIN re.LineasIngrediente lin INNER JOIN lin.Ingrediente ing WHERE ing.Id IN (:p_lista_ingredientes)";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("RecetaENbuscarPorIngredienteHQL");
                /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
                //query.SetParameter ("p_lista_ingredientes", p_lista_ingredientes);
                System.Collections.Generic.List<int> ids = new System.Collections.Generic.List<int>();
                foreach (var p in p_lista_ingredientes)
                    ids.Add(p);
                query.SetParameterList("p_lista_ingredientes", ids);
                /*PROTECTED REGION END*/

                result = query.List<EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in RecetaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN> VerUltimasRecetas ()
{
        System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM RecetaEN self where FROM RecetaEN re ORDER BY re.FechaCreacion DESC";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("RecetaENverUltimasRecetasHQL");

                result = query.List<EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in RecetaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
