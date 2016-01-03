
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
public partial class PasosCEN
{
public void CambiarNumPaso (int p_oid, int p_num_paso_old, int p_num_paso_new)
{
        /*PROTECTED REGION ID(EnMiNeveraGenNHibernate.CEN.EnMiNevera_Pasos_cambiarNumPaso) ENABLED START*/

        // Write here your custom code...

        PasosEN paso = _IPasosCAD.ReadOIDDefault (p_oid);

        if (paso.NumeroPaso != p_num_paso_new) {
                paso.NumeroPaso = p_num_paso_new;
                _IPasosCAD.Modify (paso);
        }

        //como acceder a un paso mediante su numero de paso? puedo podificar el CAD para a�adir funciones?
        //en caso de que no, deberiamos pasar la OID del paso a sustituir




        //throw new NotImplementedException ("Method CambiarNumPaso() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
