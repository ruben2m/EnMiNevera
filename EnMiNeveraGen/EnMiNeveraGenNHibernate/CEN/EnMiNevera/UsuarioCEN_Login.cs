
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
public partial class UsuarioCEN
{
public bool Login (ref int p_oid, string p_nick, string p_email, String p_contrasena)
{
        /*PROTECTED REGION ID(EnMiNeveraGenNHibernate.CEN.EnMiNevera_Usuario_login) ENABLED START*/


        UsuarioEN usuarioEN = _IUsuarioCAD.ReadOIDDefault (p_oid);
        bool encontrado = false;

        if ((p_email != null) && (p_contrasena != null) && (usuarioEN.Email.Equals (p_email) && (usuarioEN.Contrasena.Equals (Utils.Util.GetEncondeMD5 (p_contrasena))))) {
                p_oid = usuarioEN.Id;
                encontrado = true;
        }
        else if ((p_nick != null) && (p_contrasena != null) && (usuarioEN.Nick.Equals (p_nick) && (usuarioEN.Contrasena.Equals (Utils.Util.GetEncondeMD5 (p_contrasena))))) {
                p_oid = usuarioEN.Id;
                encontrado = true;
        }
        /* else
         * {
         *   throw new NotImplementedException("No ha podido loguearse.");
         * }*/

        return encontrado;


        /*PROTECTED REGION END*/
}
}
}
