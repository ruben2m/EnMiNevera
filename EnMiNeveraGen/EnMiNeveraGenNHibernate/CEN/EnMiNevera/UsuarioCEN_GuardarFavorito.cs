
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
public void GuardarFavorito (int p_oid, int p_receta)
{
        /*PROTECTED REGION ID(EnMiNeveraGenNHibernate.CEN.EnMiNevera_Usuario_guardarFavorito) ENABLED START*/

        // Write here your custom code...


        /*
         * UsuarioEN usuarioEN = _IUsuarioCAD.ReadOIDDefault (p_oid);
         * RecetaEN favorito = new RecetaEN ();
         *
         * //favorito = _IRecetaCAD.ReadOIDDefault(p_receta);
         *
         * if (!usuarioEN.Favoritos.Contains (favorito))
         *  usuarioEN.Favoritos.Add (favorito);
         * else
         *  usuarioEN.Favoritos.Remove (favorito);
         */


        using (ISession session = NHibernateHelper.OpenSession ())
        {
                using (var transaction = session.BeginTransaction ())
                {
                        UsuarioEN usuarioEn = new UsuarioCAD (session).ReadOIDDefault (p_oid);
                        RecetaEN recetaEn = new RecetaCAD (session).ReadOIDDefault (p_receta);

                        if (!usuarioEn.Favoritos.Contains (recetaEn)) {
                                usuarioEn.Favoritos.Add (recetaEn);
                                recetaEn.UsuariosFavorito.Add (usuarioEn);
                        }
                        else{
                                recetaEn.UsuariosFavorito.Remove (usuarioEn);
                                usuarioEn.Favoritos.Remove (recetaEn);
                        }

                        transaction.Commit ();
                }
        }

        //throw new NotImplementedException ("Method GuardarFavorito() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
