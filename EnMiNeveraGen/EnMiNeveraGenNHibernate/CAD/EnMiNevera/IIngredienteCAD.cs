
using System;
using EnMiNeveraGenNHibernate.EN.EnMiNevera;

namespace EnMiNeveraGenNHibernate.CAD.EnMiNevera
{
public partial interface IIngredienteCAD
{
IngredienteEN ReadOIDDefault (int id);

int New_ (IngredienteEN ingrediente);

void Modify (IngredienteEN ingrediente);


void Destroy (int id);


System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.IngredienteEN> VerNubeIngredientes ();


EnMiNeveraGenNHibernate.EN.EnMiNevera.IngredienteEN GetPorNombre (string p_nombre);
}
}
