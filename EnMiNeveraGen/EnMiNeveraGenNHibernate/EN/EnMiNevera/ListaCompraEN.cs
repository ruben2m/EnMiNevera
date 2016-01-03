
using System;
// Definición clase ListaCompraEN
namespace EnMiNeveraGenNHibernate.EN.EnMiNevera
{
public partial class ListaCompraEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo lineasListaCompra
 */
private System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.LineaListaCompraEN> lineasListaCompra;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo usuario
 */
private EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN usuario;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.LineaListaCompraEN> LineasListaCompra {
        get { return lineasListaCompra; } set { lineasListaCompra = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}





public ListaCompraEN()
{
        lineasListaCompra = new System.Collections.Generic.List<EnMiNeveraGenNHibernate.EN.EnMiNevera.LineaListaCompraEN>();
}



public ListaCompraEN(int id, System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.LineaListaCompraEN> lineasListaCompra, string nombre, Nullable<DateTime> fecha, EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN usuario
                     )
{
        this.init (Id, lineasListaCompra, nombre, fecha, usuario);
}


public ListaCompraEN(ListaCompraEN listaCompra)
{
        this.init (Id, listaCompra.LineasListaCompra, listaCompra.Nombre, listaCompra.Fecha, listaCompra.Usuario);
}

private void init (int id, System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.LineaListaCompraEN> lineasListaCompra, string nombre, Nullable<DateTime> fecha, EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN usuario)
{
        this.Id = id;


        this.LineasListaCompra = lineasListaCompra;

        this.Nombre = nombre;

        this.Fecha = fecha;

        this.Usuario = usuario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ListaCompraEN t = obj as ListaCompraEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
