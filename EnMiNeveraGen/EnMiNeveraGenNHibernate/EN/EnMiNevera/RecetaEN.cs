
using System;
// Definición clase RecetaEN
namespace EnMiNeveraGenNHibernate.EN.EnMiNevera
{
public partial class RecetaEN
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
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo foto
 */
private string foto;



/**
 *	Atributo usuario
 */
private EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN usuario;



/**
 *	Atributo lineasIngrediente
 */
private System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.LineaIngredienteEN> lineasIngrediente;



/**
 *	Atributo pasos
 */
private System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.PasosEN> pasos;



/**
 *	Atributo lineasListaCompra
 */
private System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.LineaListaCompraEN> lineasListaCompra;



/**
 *	Atributo comentarios
 */
private System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.ComentarioEN> comentarios;



/**
 *	Atributo usuariosFavorito
 */
private System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN> usuariosFavorito;



/**
 *	Atributo fechaCreacion
 */
private Nullable<DateTime> fechaCreacion;



/**
 *	Atributo estado
 */
private EnMiNeveraGenNHibernate.Enumerated.EnMiNevera.EstadosEnum estado;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual string Foto {
        get { return foto; } set { foto = value;  }
}



public virtual EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.LineaIngredienteEN> LineasIngrediente {
        get { return lineasIngrediente; } set { lineasIngrediente = value;  }
}



public virtual System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.PasosEN> Pasos {
        get { return pasos; } set { pasos = value;  }
}



public virtual System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.LineaListaCompraEN> LineasListaCompra {
        get { return lineasListaCompra; } set { lineasListaCompra = value;  }
}



public virtual System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.ComentarioEN> Comentarios {
        get { return comentarios; } set { comentarios = value;  }
}



public virtual System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN> UsuariosFavorito {
        get { return usuariosFavorito; } set { usuariosFavorito = value;  }
}



public virtual Nullable<DateTime> FechaCreacion {
        get { return fechaCreacion; } set { fechaCreacion = value;  }
}



public virtual EnMiNeveraGenNHibernate.Enumerated.EnMiNevera.EstadosEnum Estado {
        get { return estado; } set { estado = value;  }
}





public RecetaEN()
{
        lineasIngrediente = new System.Collections.Generic.List<EnMiNeveraGenNHibernate.EN.EnMiNevera.LineaIngredienteEN>();
        pasos = new System.Collections.Generic.List<EnMiNeveraGenNHibernate.EN.EnMiNevera.PasosEN>();
        lineasListaCompra = new System.Collections.Generic.List<EnMiNeveraGenNHibernate.EN.EnMiNevera.LineaListaCompraEN>();
        comentarios = new System.Collections.Generic.List<EnMiNeveraGenNHibernate.EN.EnMiNevera.ComentarioEN>();
        usuariosFavorito = new System.Collections.Generic.List<EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN>();
}



public RecetaEN(int id, string nombre, string descripcion, string foto, EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN usuario, System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.LineaIngredienteEN> lineasIngrediente, System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.PasosEN> pasos, System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.LineaListaCompraEN> lineasListaCompra, System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.ComentarioEN> comentarios, System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN> usuariosFavorito, Nullable<DateTime> fechaCreacion, EnMiNeveraGenNHibernate.Enumerated.EnMiNevera.EstadosEnum estado
                )
{
        this.init (Id, nombre, descripcion, foto, usuario, lineasIngrediente, pasos, lineasListaCompra, comentarios, usuariosFavorito, fechaCreacion, estado);
}


public RecetaEN(RecetaEN receta)
{
        this.init (Id, receta.Nombre, receta.Descripcion, receta.Foto, receta.Usuario, receta.LineasIngrediente, receta.Pasos, receta.LineasListaCompra, receta.Comentarios, receta.UsuariosFavorito, receta.FechaCreacion, receta.Estado);
}

private void init (int id, string nombre, string descripcion, string foto, EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN usuario, System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.LineaIngredienteEN> lineasIngrediente, System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.PasosEN> pasos, System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.LineaListaCompraEN> lineasListaCompra, System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.ComentarioEN> comentarios, System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN> usuariosFavorito, Nullable<DateTime> fechaCreacion, EnMiNeveraGenNHibernate.Enumerated.EnMiNevera.EstadosEnum estado)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.Foto = foto;

        this.Usuario = usuario;

        this.LineasIngrediente = lineasIngrediente;

        this.Pasos = pasos;

        this.LineasListaCompra = lineasListaCompra;

        this.Comentarios = comentarios;

        this.UsuariosFavorito = usuariosFavorito;

        this.FechaCreacion = fechaCreacion;

        this.Estado = estado;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        RecetaEN t = obj as RecetaEN;
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
