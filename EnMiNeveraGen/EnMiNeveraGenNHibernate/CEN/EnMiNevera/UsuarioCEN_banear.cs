
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
public void Banear (int p_oid, int p_usuario)
{
        /*PROTECTED REGION ID(EnMiNeveraGenNHibernate.CEN.EnMiNevera_Usuario_banear) ENABLED START*/

        // Write here your custom code...

        UsuarioEN usuarioEN = _IUsuarioCAD.ReadOIDDefault (p_usuario);

        usuarioEN.Baneado = !usuarioEN.Baneado;

        _IUsuarioCAD.Modify (usuarioEN);


        //throw new NotImplementedException ("Method Banear() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
