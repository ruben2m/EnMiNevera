

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
 *      Definition of the class UsuarioCEN
 *
 */
public partial class UsuarioCEN
{
private IUsuarioCAD _IUsuarioCAD;

public UsuarioCEN()
{
        this._IUsuarioCAD = new UsuarioCAD ();
}

public UsuarioCEN(IUsuarioCAD _IUsuarioCAD)
{
        this._IUsuarioCAD = _IUsuarioCAD;
}

public IUsuarioCAD get_IUsuarioCAD ()
{
        return this._IUsuarioCAD;
}

public int New_ (string p_nombre, String p_contrasena, string p_email, string p_apellidos, string p_nick, string p_foto, string p_biografia, Nullable<DateTime> p_fechaNacim, bool p_baneado, EnMiNeveraGenNHibernate.Enumerated.EnMiNevera.RolesEnum p_rol)
{
        UsuarioEN usuarioEN = null;
        int oid;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Nombre = p_nombre;

        usuarioEN.Contrasena = Utils.Util.GetEncondeMD5 (p_contrasena);

        usuarioEN.Email = p_email;

        usuarioEN.Apellidos = p_apellidos;

        usuarioEN.Nick = p_nick;

        usuarioEN.Foto = p_foto;

        usuarioEN.Biografia = p_biografia;

        usuarioEN.FechaNacim = p_fechaNacim;

        usuarioEN.Baneado = p_baneado;

        usuarioEN.Rol = p_rol;

        //Call to UsuarioCAD

        oid = _IUsuarioCAD.New_ (usuarioEN);
        return oid;
}

public void Modify (int p_Usuario_OID, string p_nombre, String p_contrasena, string p_email, string p_apellidos, string p_nick, string p_foto, string p_biografia, Nullable<DateTime> p_fechaNacim, bool p_baneado, EnMiNeveraGenNHibernate.Enumerated.EnMiNevera.RolesEnum p_rol)
{
        UsuarioEN usuarioEN = null;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Id = p_Usuario_OID;
        usuarioEN.Nombre = p_nombre;
        usuarioEN.Contrasena = Utils.Util.GetEncondeMD5 (p_contrasena);
        usuarioEN.Email = p_email;
        usuarioEN.Apellidos = p_apellidos;
        usuarioEN.Nick = p_nick;
        usuarioEN.Foto = p_foto;
        usuarioEN.Biografia = p_biografia;
        usuarioEN.FechaNacim = p_fechaNacim;
        usuarioEN.Baneado = p_baneado;
        usuarioEN.Rol = p_rol;
        //Call to UsuarioCAD

        _IUsuarioCAD.Modify (usuarioEN);
}

public void Destroy (int id)
{
        _IUsuarioCAD.Destroy (id);
}

public UsuarioEN VerPerfilOtro (int id)
{
        UsuarioEN usuarioEN = null;

        usuarioEN = _IUsuarioCAD.VerPerfilOtro (id);
        return usuarioEN;
}

public UsuarioEN VerPerfilPropio (int id)
{
        UsuarioEN usuarioEN = null;

        usuarioEN = _IUsuarioCAD.VerPerfilPropio (id);
        return usuarioEN;
}

public System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN> VerActividadSeguidos (int p_Usuario_OID)
{
        return _IUsuarioCAD.VerActividadSeguidos (p_Usuario_OID);
}
public System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN> VerNumSeguidores (int p_oid)
{
        return _IUsuarioCAD.VerNumSeguidores (p_oid);
}
public System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN> VerNumSeguidos (int p_oid)
{
        return _IUsuarioCAD.VerNumSeguidos (p_oid);
}
public EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN GetByNick (string p_nick)
{
        return _IUsuarioCAD.GetByNick (p_nick);
}
public EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN GetByEmail (string p_email)
{
        return _IUsuarioCAD.GetByEmail (p_email);
}
}
}
