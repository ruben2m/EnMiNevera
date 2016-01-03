
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
 * Clase Usuario:
 *
 */

namespace EnMiNeveraGenNHibernate.CAD.EnMiNevera
{
public partial class UsuarioCAD : BasicCAD, IUsuarioCAD
{
public UsuarioCAD() : base ()
{
}

public UsuarioCAD(ISession sessionAux) : base (sessionAux)
{
}



public UsuarioEN ReadOIDDefault (int id)
{
        UsuarioEN usuarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Get (typeof(UsuarioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(UsuarioEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<UsuarioEN>();
                        else
                                result = session.CreateCriteria (typeof(UsuarioEN)).List<UsuarioEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }

        return result;
}

public int New_ (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (usuario);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuario.Id;
}

public void Modify (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioEN usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), usuario.Id);

                usuarioEN.Nombre = usuario.Nombre;


                usuarioEN.Contrasena = usuario.Contrasena;


                usuarioEN.Email = usuario.Email;


                usuarioEN.Apellidos = usuario.Apellidos;


                usuarioEN.Nick = usuario.Nick;


                usuarioEN.Foto = usuario.Foto;


                usuarioEN.Biografia = usuario.Biografia;


                usuarioEN.FechaNacim = usuario.FechaNacim;


                usuarioEN.Baneado = usuario.Baneado;


                usuarioEN.Rol = usuario.Rol;

                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
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
                UsuarioEN usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), id);
                session.Delete (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: VerPerfilOtro
//Con e: UsuarioEN
public UsuarioEN VerPerfilOtro (int id)
{
        UsuarioEN usuarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Get (typeof(UsuarioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioEN;
}

//Sin e: VerPerfilPropio
//Con e: UsuarioEN
public UsuarioEN VerPerfilPropio (int id)
{
        UsuarioEN usuarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Get (typeof(UsuarioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioEN;
}

public System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN> VerActividadSeguidos (int p_Usuario_OID)
{
        System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where FROM UsuarioEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENverActividadSeguidosHQL");
                query.SetParameter ("p_Usuario_OID", p_Usuario_OID);

                result = query.List<EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN> VerNumSeguidores (int p_oid)
{
        System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where SELECT COUNT(se) FROM UsuarioEN us INNER JOIN us.Seguidores se WHERE se.Id = :p_oid";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENverNumSeguidoresHQL");
                query.SetParameter ("p_oid", p_oid);

                result = query.List<EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN> VerNumSeguidos (int p_oid)
{
        System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where SELECT COUNT(se) FROM UsuarioEN us INNER JOIN us.Seguidos se WHERE us.id = :p_oid";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENverNumSeguidosHQL");
                query.SetParameter ("p_oid", p_oid);

                result = query.List<EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is EnMiNeveraGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new EnMiNeveraGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
