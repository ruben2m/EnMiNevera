
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
public void MarcarComprado (int p_oid)
{
        /*PROTECTED REGION ID(EnMiNeveraGenNHibernate.CEN.EnMiNevera_LineaListaCompra_marcarComprado) ENABLED START*/

        // Write here your custom code...

        LineaListaCompraEN lineaListaCompraEN = null;

        lineaListaCompraEN = _ILineaListaCompraCAD.ReadOIDDefault (p_oid);

        lineaListaCompraEN.Comprado = true;
        _ILineaListaCompraCAD.Modify (lineaListaCompraEN);

        //throw new NotImplementedException("Method MarcarComprado() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
