
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
public partial class RecetaCEN
{
public void Banear (int p_oid)
{
        /*PROTECTED REGION ID(EnMiNeveraGenNHibernate.CEN.EnMiNevera_Receta_banear) ENABLED START*/

        // Write here your custom code...

        System.Console.WriteLine ("\n Entro aqui----------------------------------------------\n");

        RecetaEN receta = new RecetaEN ();
        receta = _IRecetaCAD.ReadOIDDefault (p_oid);

        //UsuarioEN usuario = _IUsuarioCAD.ReadOIDDefault(p_usuario);

        System.Console.WriteLine ("\n Entro aqui1\n");
        if (receta.Estado.Equals (Enumerated.EnMiNevera.EstadosEnum.publicado)) {
                System.Console.WriteLine ("\n Entro aqui2 \n");
                receta.Estado = Enumerated.EnMiNevera.EstadosEnum.baneado;
        }
        else if (receta.Estado.Equals (Enumerated.EnMiNevera.EstadosEnum.baneado)) {
                System.Console.WriteLine ("\n Entro aqui3\n");
                receta.Estado = Enumerated.EnMiNevera.EstadosEnum.publicado;
        }
        System.Console.WriteLine ("\n Entro aqui4 \n");
        _IRecetaCAD.Modify (receta);



        //throw new NotImplementedException ("Method Banear() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
