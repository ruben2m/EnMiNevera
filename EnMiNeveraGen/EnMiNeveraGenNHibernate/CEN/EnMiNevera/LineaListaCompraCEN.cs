

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
/*
 *      Definition of the class LineaListaCompraCEN
 *
 */
public partial class LineaListaCompraCEN
{
private ILineaListaCompraCAD _ILineaListaCompraCAD;

public LineaListaCompraCEN()
{
        this._ILineaListaCompraCAD = new LineaListaCompraCAD ();
}

public LineaListaCompraCEN(ILineaListaCompraCAD _ILineaListaCompraCAD)
{
        this._ILineaListaCompraCAD = _ILineaListaCompraCAD;
}

public ILineaListaCompraCAD get_ILineaListaCompraCAD ()
{
        return this._ILineaListaCompraCAD;
}

public int New_ (int p_cantidad, EnMiNeveraGenNHibernate.Enumerated.EnMiNevera.UnidadesEnum p_unidad, int p_ingrediente, int p_listaCompra, bool p_comprado)
{
        LineaListaCompraEN lineaListaCompraEN = null;
        int oid;

        //Initialized LineaListaCompraEN
        lineaListaCompraEN = new LineaListaCompraEN ();
        lineaListaCompraEN.Cantidad = p_cantidad;

        lineaListaCompraEN.Unidad = p_unidad;


        if (p_ingrediente != -1) {
                // El argumento p_ingrediente -> Property ingrediente es oid = false
                // Lista de oids id
                lineaListaCompraEN.Ingrediente = new EnMiNeveraGenNHibernate.EN.EnMiNevera.IngredienteEN ();
                lineaListaCompraEN.Ingrediente.Id = p_ingrediente;
        }


        if (p_listaCompra != -1) {
                // El argumento p_listaCompra -> Property listaCompra es oid = false
                // Lista de oids id
                lineaListaCompraEN.ListaCompra = new EnMiNeveraGenNHibernate.EN.EnMiNevera.ListaCompraEN ();
                lineaListaCompraEN.ListaCompra.Id = p_listaCompra;
        }

        lineaListaCompraEN.Comprado = p_comprado;

        //Call to LineaListaCompraCAD

        oid = _ILineaListaCompraCAD.New_ (lineaListaCompraEN);
        return oid;
}

public void Modify (int p_LineaListaCompra_OID, int p_cantidad, EnMiNeveraGenNHibernate.Enumerated.EnMiNevera.UnidadesEnum p_unidad, bool p_comprado)
{
        LineaListaCompraEN lineaListaCompraEN = null;

        //Initialized LineaListaCompraEN
        lineaListaCompraEN = new LineaListaCompraEN ();
        lineaListaCompraEN.Id = p_LineaListaCompra_OID;
        lineaListaCompraEN.Cantidad = p_cantidad;
        lineaListaCompraEN.Unidad = p_unidad;
        lineaListaCompraEN.Comprado = p_comprado;
        //Call to LineaListaCompraCAD

        _ILineaListaCompraCAD.Modify (lineaListaCompraEN);
}

public void Destroy (int id)
{
        _ILineaListaCompraCAD.Destroy (id);
}
}
}
