
using System;
using EnMiNeveraGenNHibernate.EN.EnMiNevera;

namespace EnMiNeveraGenNHibernate.CAD.EnMiNevera
{
public partial interface ILineaIngredienteCAD
{
LineaIngredienteEN ReadOIDDefault (int id);

int New_ (LineaIngredienteEN lineaIngrediente);

void Modify (LineaIngredienteEN lineaIngrediente);


void Destroy (int id);
}
}
