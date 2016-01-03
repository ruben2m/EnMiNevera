
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
public partial class LineaListaCompraCEN
{
public void DesmarcarComprado (int p_oid)
{
        /*PROTECTED REGION ID(EnMiNeveraGenNHibernate.CEN.EnMiNevera_LineaListaCompra_desmarcarComprado) ENABLED START*/

        // Write here your custom code...

        LineaListaCompraEN lineaListaCompraEN = null;

        lineaListaCompraEN = _ILineaListaCompraCAD.ReadOIDDefault (p_oid);

        lineaListaCompraEN.Comprado = false;
        _ILineaListaCompraCAD.Modify (lineaListaCompraEN);

        //throw new NotImplementedException("Method DesmarcarComprado() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
