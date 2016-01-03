
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
public void Comentar (int p_oid, int p_receta, string p_comentario)
{
        /*PROTECTED REGION ID(EnMiNeveraGenNHibernate.CEN.EnMiNevera_Usuario_comentar) ENABLED START*/

        // Write here your custom code...
        if (p_comentario.Trim ().CompareTo ("") != 0) {
                ComentarioCEN comentarioCEN = new ComentarioCEN ();
                //comentarioCEN.New_ (p_oid, p_comentario, DateTime.Now.TimeOfDay);
        }
        else{
                throw new Exception ("No se puede crear un comentario vacio");
        }


        //throw new NotImplementedException ("Method Comentar() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
