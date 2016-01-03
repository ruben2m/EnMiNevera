
using System;
using EnMiNeveraGenNHibernate.EN.EnMiNevera;

namespace EnMiNeveraGenNHibernate.CAD.EnMiNevera
{
public partial interface IComentarioCAD
{
ComentarioEN ReadOIDDefault (int id);

int New_ (ComentarioEN comentario);

void Modify (ComentarioEN comentario);


void Destroy (int id);
}
}
