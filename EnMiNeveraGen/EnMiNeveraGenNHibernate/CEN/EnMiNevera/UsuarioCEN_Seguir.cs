
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
public bool Seguir (int p_oid, int p_usuario_a_seguir)
{
        /*PROTECTED REGION ID(EnMiNeveraGenNHibernate.CEN.EnMiNevera_Usuario_seguir) ENABLED START*/

        // Write here your custom code...

        using (ISession session = NHibernateHelper.OpenSession ())
        {
                using (var transaction = session.BeginTransaction ())
                {
                        UsuarioEN usuarioEn = new UsuarioCAD (session).ReadOIDDefault (p_oid);
                        UsuarioEN usuarioASeguirEn = new UsuarioCAD (session).ReadOIDDefault (p_usuario_a_seguir);

                        usuarioEn.Seguidos.Add (usuarioASeguirEn);

                        transaction.Commit ();
                }
        }

        return false;



        /*PROTECTED REGION END*/
}
}
}
