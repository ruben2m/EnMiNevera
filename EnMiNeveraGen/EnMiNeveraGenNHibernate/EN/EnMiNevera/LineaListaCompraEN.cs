
using System;
// Definición clase LineaListaCompraEN
namespace EnMiNeveraGenNHibernate.EN.EnMiNevera
{
public partial class LineaListaCompraEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo cantidad
 */
private int cantidad;



/**
 *	Atributo unidad
 */
private EnMiNeveraGenNHibernate.Enumerated.EnMiNevera.UnidadesEnum unidad;



/**
 *	Atributo ingrediente
 */
private EnMiNeveraGenNHibernate.EN.EnMiNevera.IngredienteEN ingrediente;



/**
 *	Atributo listaCompra
 */
private EnMiNeveraGenNHibernate.EN.EnMiNevera.ListaCompraEN listaCompra;



/**
 *	Atributo receta
 */
private EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN receta;



/**
 *	Atributo comprado
 */
private bool comprado;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual int Cantidad {
        get { return cantidad; } set { cantidad = value;  }
}



public virtual EnMiNeveraGenNHibernate.Enumerated.EnMiNevera.UnidadesEnum Unidad {
        get { return unidad; } set { unidad = value;  }
}



public virtual EnMiNeveraGenNHibernate.EN.EnMiNevera.IngredienteEN Ingrediente {
        get { return ingrediente; } set { ingrediente = value;  }
}



public virtual EnMiNeveraGenNHibernate.EN.EnMiNevera.ListaCompraEN ListaCompra {
        get { return listaCompra; } set { listaCompra = value;  }
}



public virtual EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN Receta {
        get { return receta; } set { receta = value;  }
}



public virtual bool Comprado {
        get { return comprado; } set { comprado = value;  }
}





public LineaListaCompraEN()
{
}



public LineaListaCompraEN(int id, int cantidad, EnMiNeveraGenNHibernate.Enumerated.EnMiNevera.UnidadesEnum unidad, EnMiNeveraGenNHibernate.EN.EnMiNevera.IngredienteEN ingrediente, EnMiNeveraGenNHibernate.EN.EnMiNevera.ListaCompraEN listaCompra, EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN receta, bool comprado
                          )
{
        this.init (Id, cantidad, unidad, ingrediente, listaCompra, receta, comprado);
}


public LineaListaCompraEN(LineaListaCompraEN lineaListaCompra)
{
        this.init (Id, lineaListaCompra.Cantidad, lineaListaCompra.Unidad, lineaListaCompra.Ingrediente, lineaListaCompra.ListaCompra, lineaListaCompra.Receta, lineaListaCompra.Comprado);
}

private void init (int id, int cantidad, EnMiNeveraGenNHibernate.Enumerated.EnMiNevera.UnidadesEnum unidad, EnMiNeveraGenNHibernate.EN.EnMiNevera.IngredienteEN ingrediente, EnMiNeveraGenNHibernate.EN.EnMiNevera.ListaCompraEN listaCompra, EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN receta, bool comprado)
{
        this.Id = id;


        this.Cantidad = cantidad;

        this.Unidad = unidad;

        this.Ingrediente = ingrediente;

        this.ListaCompra = listaCompra;

        this.Receta = receta;

        this.Comprado = comprado;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        LineaListaCompraEN t = obj as LineaListaCompraEN;
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
