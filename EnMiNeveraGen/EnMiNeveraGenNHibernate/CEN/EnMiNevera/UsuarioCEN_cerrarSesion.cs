
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
public int CerrarSesion (int p_oid)
{
        /*PROTECTED REGION ID(EnMiNeveraGenNHibernate.CEN.EnMiNevera_Usuario_cerrarSesion) ENABLED START*/
        UsuarioEN usuarioEN = new UsuarioEN ();
        int oid = 1;

        usuarioEN = _IUsuarioCAD.ReadOIDDefault (p_oid);
        if (usuarioEN.Id != 0)
                oid = 0;

        return oid;


        //throw new NotImplementedException ("Method CerrarSesion() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
