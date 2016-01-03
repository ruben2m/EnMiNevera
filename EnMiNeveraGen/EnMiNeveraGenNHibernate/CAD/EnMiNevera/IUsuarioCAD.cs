
using System;
using EnMiNeveraGenNHibernate.EN.EnMiNevera;

namespace EnMiNeveraGenNHibernate.CAD.EnMiNevera
{
public partial interface IUsuarioCAD
{
UsuarioEN ReadOIDDefault (int id);

int New_ (UsuarioEN usuario);

void Modify (UsuarioEN usuario);


void Destroy (int id);


UsuarioEN VerPerfilOtro (int id);


UsuarioEN VerPerfilPropio (int id);






System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN> VerActividadSeguidos (int p_Usuario_OID);






System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN> VerNumSeguidores (int p_oid);


System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN> VerNumSeguidos (int p_oid);
}
}
