
using System;
using EnMiNeveraGenNHibernate.EN.EnMiNevera;

namespace EnMiNeveraGenNHibernate.CAD.EnMiNevera
{
public partial interface IListaCompraCAD
{
ListaCompraEN ReadOIDDefault (int id);

int New_ (ListaCompraEN listaCompra);

void Modify (ListaCompraEN listaCompra);


void Destroy (int id);
}
}
