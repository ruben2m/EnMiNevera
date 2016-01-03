
using System;
using EnMiNeveraGenNHibernate.EN.EnMiNevera;

namespace EnMiNeveraGenNHibernate.CAD.EnMiNevera
{
public partial interface IPasosCAD
{
PasosEN ReadOIDDefault (int id);

int New_ (PasosEN pasos);

void Modify (PasosEN pasos);


void Destroy (int id);
}
}
