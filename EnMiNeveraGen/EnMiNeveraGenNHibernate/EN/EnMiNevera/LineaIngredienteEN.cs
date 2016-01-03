
using System;
// Definición clase LineaIngredienteEN
namespace EnMiNeveraGenNHibernate.EN.EnMiNevera
{
public partial class LineaIngredienteEN
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
 *	Atributo receta
 */
private EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN receta;






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



public virtual EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN Receta {
        get { return receta; } set { receta = value;  }
}





public LineaIngredienteEN()
{
}



public LineaIngredienteEN(int id, int cantidad, EnMiNeveraGenNHibernate.Enumerated.EnMiNevera.UnidadesEnum unidad, EnMiNeveraGenNHibernate.EN.EnMiNevera.IngredienteEN ingrediente, EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN receta
                          )
{
        this.init (Id, cantidad, unidad, ingrediente, receta);
}


public LineaIngredienteEN(LineaIngredienteEN lineaIngrediente)
{
        this.init (Id, lineaIngrediente.Cantidad, lineaIngrediente.Unidad, lineaIngrediente.Ingrediente, lineaIngrediente.Receta);
}

private void init (int id, int cantidad, EnMiNeveraGenNHibernate.Enumerated.EnMiNevera.UnidadesEnum unidad, EnMiNeveraGenNHibernate.EN.EnMiNevera.IngredienteEN ingrediente, EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN receta)
{
        this.Id = id;


        this.Cantidad = cantidad;

        this.Unidad = unidad;

        this.Ingrediente = ingrediente;

        this.Receta = receta;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        LineaIngredienteEN t = obj as LineaIngredienteEN;
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
