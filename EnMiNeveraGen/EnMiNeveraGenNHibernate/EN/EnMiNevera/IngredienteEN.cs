
using System;
// Definición clase IngredienteEN
namespace EnMiNeveraGenNHibernate.EN.EnMiNevera
{
public partial class IngredienteEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo lineasIngrediente
 */
private System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.LineaIngredienteEN> lineasIngrediente;



/**
 *	Atributo lineasListaCompra
 */
private System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.LineaListaCompraEN> lineasListaCompra;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.LineaIngredienteEN> LineasIngrediente {
        get { return lineasIngrediente; } set { lineasIngrediente = value;  }
}



public virtual System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.LineaListaCompraEN> LineasListaCompra {
        get { return lineasListaCompra; } set { lineasListaCompra = value;  }
}





public IngredienteEN()
{
        lineasIngrediente = new System.Collections.Generic.List<EnMiNeveraGenNHibernate.EN.EnMiNevera.LineaIngredienteEN>();
        lineasListaCompra = new System.Collections.Generic.List<EnMiNeveraGenNHibernate.EN.EnMiNevera.LineaListaCompraEN>();
}



public IngredienteEN(int id, string nombre, System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.LineaIngredienteEN> lineasIngrediente, System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.LineaListaCompraEN> lineasListaCompra
                     )
{
        this.init (Id, nombre, lineasIngrediente, lineasListaCompra);
}


public IngredienteEN(IngredienteEN ingrediente)
{
        this.init (Id, ingrediente.Nombre, ingrediente.LineasIngrediente, ingrediente.LineasListaCompra);
}

private void init (int id, string nombre, System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.LineaIngredienteEN> lineasIngrediente, System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.LineaListaCompraEN> lineasListaCompra)
{
        this.Id = id;


        this.Nombre = nombre;

        this.LineasIngrediente = lineasIngrediente;

        this.LineasListaCompra = lineasListaCompra;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        IngredienteEN t = obj as IngredienteEN;
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
