
using System;
using EnMiNeveraGenNHibernate.EN.EnMiNevera;

namespace EnMiNeveraGenNHibernate.CAD.EnMiNevera
{
public partial interface IRecetaCAD
{
RecetaEN ReadOIDDefault (int id);

int New_ (RecetaEN receta);

void Modify (RecetaEN receta);


void Destroy (int id);


System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN> Buscar (string p_texto);


System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN> BuscarPorIngrediente (System.Collections.Generic.IList<int> p_lista_ingredientes);





System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN> VerUltimasRecetas ();
}
}
