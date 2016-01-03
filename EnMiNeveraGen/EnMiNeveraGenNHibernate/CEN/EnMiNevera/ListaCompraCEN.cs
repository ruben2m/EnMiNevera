

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
 *      Definition of the class ListaCompraCEN
 *
 */
public partial class ListaCompraCEN
{
private IListaCompraCAD _IListaCompraCAD;

public ListaCompraCEN()
{
        this._IListaCompraCAD = new ListaCompraCAD ();
}

public ListaCompraCEN(IListaCompraCAD _IListaCompraCAD)
{
        this._IListaCompraCAD = _IListaCompraCAD;
}

public IListaCompraCAD get_IListaCompraCAD ()
{
        return this._IListaCompraCAD;
}

public int New_ (string p_nombre, Nullable<DateTime> p_fecha, int p_usuario)
{
        ListaCompraEN listaCompraEN = null;
        int oid;

        //Initialized ListaCompraEN
        listaCompraEN = new ListaCompraEN ();
        listaCompraEN.Nombre = p_nombre;

        listaCompraEN.Fecha = p_fecha;


        if (p_usuario != -1) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                listaCompraEN.Usuario = new EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN ();
                listaCompraEN.Usuario.Id = p_usuario;
        }

        //Call to ListaCompraCAD

        oid = _IListaCompraCAD.New_ (listaCompraEN);
        return oid;
}

public void Modify (int p_ListaCompra_OID, string p_nombre, Nullable<DateTime> p_fecha)
{
        ListaCompraEN listaCompraEN = null;

        //Initialized ListaCompraEN
        listaCompraEN = new ListaCompraEN ();
        listaCompraEN.Id = p_ListaCompra_OID;
        listaCompraEN.Nombre = p_nombre;
        listaCompraEN.Fecha = p_fecha;
        //Call to ListaCompraCAD

        _IListaCompraCAD.Modify (listaCompraEN);
}

public void Destroy (int id)
{
        _IListaCompraCAD.Destroy (id);
}
}
}
