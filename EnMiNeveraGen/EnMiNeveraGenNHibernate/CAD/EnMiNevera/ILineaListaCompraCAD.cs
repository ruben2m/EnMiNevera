
using System;
using EnMiNeveraGenNHibernate.EN.EnMiNevera;

namespace EnMiNeveraGenNHibernate.CAD.EnMiNevera
{
public partial interface ILineaListaCompraCAD
{
LineaListaCompraEN ReadOIDDefault (int id);

int New_ (LineaListaCompraEN lineaListaCompra);

void Modify (LineaListaCompraEN lineaListaCompra);


void Destroy (int id);
}
}
