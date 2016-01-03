
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
public int Registro (string p_nombre, String p_contrasena, String p_repetir_contrasena, string p_email, string p_apellidos, string p_nick, string p_foto, string p_biografia, Nullable<DateTime> p_fecha_nacim)
{
        /*PROTECTED REGION ID(EnMiNeveraGenNHibernate.CEN.EnMiNevera_Usuario_registro) ENABLED START*/

        // Write here your custom code...

        UsuarioCEN usuarioCEN = new UsuarioCEN ();
        int oid = 0;
        String sFormato;

        sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
        if (p_nombre != null && p_email != null && p_contrasena != null && p_repetir_contrasena != null && p_apellidos != null && p_nick != null && p_foto != null && p_biografia != null && p_fecha_nacim != null)

                if ((p_contrasena.Length >= 6) && (p_contrasena.Equals (p_repetir_contrasena))) {
                        if (System.Text.RegularExpressions.Regex.IsMatch (p_email, sFormato)) {
                                if (System.Text.RegularExpressions.Regex.Replace (p_email, sFormato, String.Empty).Length == 0) {
                                        oid = usuarioCEN.New_ (p_nombre, p_contrasena, p_email, p_apellidos, p_nick, p_foto, p_biografia, p_fecha_nacim, false, Enumerated.EnMiNevera.RolesEnum.usuario);
                                }
                        }
                }
                else{
                        throw new NotImplementedException ("No se ha podido registrar el usuario.");
                }

        return oid;


        /*PROTECTED REGION END*/
}
}
}
