
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
public int Login (string p_nick, string p_email, String p_contrasena)
{
        /*PROTECTED REGION ID(EnMiNeveraGenNHibernate.CEN.EnMiNevera_Usuario_login) ENABLED START*/

        int oid = -1;

        UsuarioCEN usuarioCen = new UsuarioCEN ();
        UsuarioEN usuarioEn = usuarioCen.GetByNick (p_nick);     // _IUsuarioCAD.ReadOIDDefault(p_oid);

        if (usuarioEn != null && usuarioEn.Contrasena.Equals (Utils.Util.GetEncondeMD5 (p_contrasena)))
                oid = usuarioEn.Id;
        else{
                usuarioEn = usuarioCen.GetByEmail (p_email);
                if (usuarioEn != null && usuarioEn.Contrasena.Equals (Utils.Util.GetEncondeMD5 (p_contrasena)))
                        oid = usuarioEn.Id;
        }


        //if ((p_email != null) && (p_contrasena != null) && (usuarioEN.Email.Equals(p_email) && (usuarioEN.Contrasena.Equals(Utils.Util.GetEncondeMD5(p_contrasena)))))
        //{
        //    p_oid = usuarioEN.Id;
        //}
        //else if ((p_nick != null) && (p_contrasena != null) && (usuarioEN.Nick.Equals(p_nick) && (usuarioEN.Contrasena.Equals(Utils.Util.GetEncondeMD5(p_contrasena)))))
        //{
        //    p_oid = usuarioEN.Id;
        //}
        /* else
         * {
         *   throw new NotImplementedException("No ha podido loguearse.");
         * }*/

        return oid;


        /*PROTECTED REGION END*/
}
}
}
