

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
 *      Definition of the class ComentarioCEN
 *
 */
public partial class ComentarioCEN
{
private IComentarioCAD _IComentarioCAD;

public ComentarioCEN()
{
        this._IComentarioCAD = new ComentarioCAD ();
}

public ComentarioCEN(IComentarioCAD _IComentarioCAD)
{
        this._IComentarioCAD = _IComentarioCAD;
}

public IComentarioCAD get_IComentarioCAD ()
{
        return this._IComentarioCAD;
}

public int New_ (int p_usuario, int p_receta, string p_comentario, Nullable<DateTime> p_fecha)
{
        ComentarioEN comentarioEN = null;
        int oid;

        //Initialized ComentarioEN
        comentarioEN = new ComentarioEN ();

        if (p_usuario != -1) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                comentarioEN.Usuario = new EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN ();
                comentarioEN.Usuario.Id = p_usuario;
        }


        if (p_receta != -1) {
                // El argumento p_receta -> Property receta es oid = false
                // Lista de oids id
                comentarioEN.Receta = new EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN ();
                comentarioEN.Receta.Id = p_receta;
        }

        comentarioEN.Comentario = p_comentario;

        comentarioEN.Fecha = p_fecha;

        //Call to ComentarioCAD

        oid = _IComentarioCAD.New_ (comentarioEN);
        return oid;
}

public void Modify (int p_Comentario_OID, string p_comentario, Nullable<DateTime> p_fecha)
{
        ComentarioEN comentarioEN = null;

        //Initialized ComentarioEN
        comentarioEN = new ComentarioEN ();
        comentarioEN.Id = p_Comentario_OID;
        comentarioEN.Comentario = p_comentario;
        comentarioEN.Fecha = p_fecha;
        //Call to ComentarioCAD

        _IComentarioCAD.Modify (comentarioEN);
}

public void Destroy (int id)
{
        _IComentarioCAD.Destroy (id);
}
}
}
