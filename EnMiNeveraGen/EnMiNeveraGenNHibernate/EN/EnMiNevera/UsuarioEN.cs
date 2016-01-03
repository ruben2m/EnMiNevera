
using System;
// Definición clase UsuarioEN
namespace EnMiNeveraGenNHibernate.EN.EnMiNevera
{
public partial class UsuarioEN
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
 *	Atributo contrasena
 */
private String contrasena;



/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo apellidos
 */
private string apellidos;



/**
 *	Atributo nick
 */
private string nick;



/**
 *	Atributo foto
 */
private string foto;



/**
 *	Atributo biografia
 */
private string biografia;



/**
 *	Atributo fechaNacim
 */
private Nullable<DateTime> fechaNacim;



/**
 *	Atributo recetas
 */
private System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN> recetas;



/**
 *	Atributo seguidores
 */
private System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN> seguidores;



/**
 *	Atributo seguidos
 */
private System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN> seguidos;



/**
 *	Atributo comentarios
 */
private System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.ComentarioEN> comentarios;



/**
 *	Atributo favoritos
 */
private System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN> favoritos;



/**
 *	Atributo baneado
 */
private bool baneado;



/**
 *	Atributo rol
 */
private EnMiNeveraGenNHibernate.Enumerated.EnMiNevera.RolesEnum rol;



/**
 *	Atributo listasCompra
 */
private System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.ListaCompraEN> listasCompra;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual String Contrasena {
        get { return contrasena; } set { contrasena = value;  }
}



public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual string Apellidos {
        get { return apellidos; } set { apellidos = value;  }
}



public virtual string Nick {
        get { return nick; } set { nick = value;  }
}



public virtual string Foto {
        get { return foto; } set { foto = value;  }
}



public virtual string Biografia {
        get { return biografia; } set { biografia = value;  }
}



public virtual Nullable<DateTime> FechaNacim {
        get { return fechaNacim; } set { fechaNacim = value;  }
}



public virtual System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN> Recetas {
        get { return recetas; } set { recetas = value;  }
}



public virtual System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN> Seguidores {
        get { return seguidores; } set { seguidores = value;  }
}



public virtual System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN> Seguidos {
        get { return seguidos; } set { seguidos = value;  }
}



public virtual System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.ComentarioEN> Comentarios {
        get { return comentarios; } set { comentarios = value;  }
}



public virtual System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN> Favoritos {
        get { return favoritos; } set { favoritos = value;  }
}



public virtual bool Baneado {
        get { return baneado; } set { baneado = value;  }
}



public virtual EnMiNeveraGenNHibernate.Enumerated.EnMiNevera.RolesEnum Rol {
        get { return rol; } set { rol = value;  }
}



public virtual System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.ListaCompraEN> ListasCompra {
        get { return listasCompra; } set { listasCompra = value;  }
}





public UsuarioEN()
{
        recetas = new System.Collections.Generic.List<EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN>();
        seguidores = new System.Collections.Generic.List<EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN>();
        seguidos = new System.Collections.Generic.List<EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN>();
        comentarios = new System.Collections.Generic.List<EnMiNeveraGenNHibernate.EN.EnMiNevera.ComentarioEN>();
        favoritos = new System.Collections.Generic.List<EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN>();
        ListasCompra = new System.Collections.Generic.List<EnMiNeveraGenNHibernate.EN.EnMiNevera.ListaCompraEN>();
}



public UsuarioEN(int id, string nombre, String contrasena, string email, string apellidos, string nick, string foto, string biografia, Nullable<DateTime> fechaNacim, System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN> recetas, System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN> seguidores, System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN> seguidos, System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.ComentarioEN> comentarios, System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN> favoritos, bool baneado, EnMiNeveraGenNHibernate.Enumerated.EnMiNevera.RolesEnum rol, System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.ListaCompraEN> listasCompra
                 )
{
        this.init (Id, nombre, contrasena, email, apellidos, nick, foto, biografia, fechaNacim, recetas, seguidores, seguidos, comentarios, favoritos, baneado, rol, listasCompra);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (Id, usuario.Nombre, usuario.Contrasena, usuario.Email, usuario.Apellidos, usuario.Nick, usuario.Foto, usuario.Biografia, usuario.FechaNacim, usuario.Recetas, usuario.Seguidores, usuario.Seguidos, usuario.Comentarios, usuario.Favoritos, usuario.Baneado, usuario.Rol, usuario.ListasCompra);
}

private void init (int id, string nombre, String contrasena, string email, string apellidos, string nick, string foto, string biografia, Nullable<DateTime> fechaNacim, System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN> recetas, System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN> seguidores, System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN> seguidos, System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.ComentarioEN> comentarios, System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN> favoritos, bool baneado, EnMiNeveraGenNHibernate.Enumerated.EnMiNevera.RolesEnum rol, System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.ListaCompraEN> listasCompra)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Contrasena = contrasena;

        this.Email = email;

        this.Apellidos = apellidos;

        this.Nick = nick;

        this.Foto = foto;

        this.Biografia = biografia;

        this.FechaNacim = fechaNacim;

        this.Recetas = recetas;

        this.Seguidores = seguidores;

        this.Seguidos = seguidos;

        this.Comentarios = comentarios;

        this.Favoritos = favoritos;

        this.Baneado = baneado;

        this.Rol = rol;

        this.ListasCompra = listasCompra;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuarioEN t = obj as UsuarioEN;
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
