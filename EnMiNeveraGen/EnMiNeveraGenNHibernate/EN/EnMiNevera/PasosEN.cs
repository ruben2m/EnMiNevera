
using System;
// Definición clase PasosEN
namespace EnMiNeveraGenNHibernate.EN.EnMiNevera
{
public partial class PasosEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo receta
 */
private EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN receta;



/**
 *	Atributo numeroPaso
 */
private int numeroPaso;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN Receta {
        get { return receta; } set { receta = value;  }
}



public virtual int NumeroPaso {
        get { return numeroPaso; } set { numeroPaso = value;  }
}





public PasosEN()
{
}



public PasosEN(int id, string descripcion, EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN receta, int numeroPaso
               )
{
        this.init (Id, descripcion, receta, numeroPaso);
}


public PasosEN(PasosEN pasos)
{
        this.init (Id, pasos.Descripcion, pasos.Receta, pasos.NumeroPaso);
}

private void init (int id, string descripcion, EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN receta, int numeroPaso)
{
        this.Id = id;


        this.Descripcion = descripcion;

        this.Receta = receta;

        this.NumeroPaso = numeroPaso;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PasosEN t = obj as PasosEN;
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
