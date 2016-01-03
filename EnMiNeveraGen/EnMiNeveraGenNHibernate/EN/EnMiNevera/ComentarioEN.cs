
using System;
// Definición clase ComentarioEN
namespace EnMiNeveraGenNHibernate.EN.EnMiNevera
{
public partial class ComentarioEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo usuario
 */
private EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN usuario;



/**
 *	Atributo receta
 */
private EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN receta;



/**
 *	Atributo comentario
 */
private string comentario;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN Receta {
        get { return receta; } set { receta = value;  }
}



public virtual string Comentario {
        get { return comentario; } set { comentario = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}





public ComentarioEN()
{
}



public ComentarioEN(int id, EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN usuario, EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN receta, string comentario, Nullable<DateTime> fecha
                    )
{
        this.init (Id, usuario, receta, comentario, fecha);
}


public ComentarioEN(ComentarioEN comentario)
{
        this.init (Id, comentario.Usuario, comentario.Receta, comentario.Comentario, comentario.Fecha);
}

private void init (int id, EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN usuario, EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN receta, string comentario, Nullable<DateTime> fecha)
{
        this.Id = id;


        this.Usuario = usuario;

        this.Receta = receta;

        this.Comentario = comentario;

        this.Fecha = fecha;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ComentarioEN t = obj as ComentarioEN;
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
