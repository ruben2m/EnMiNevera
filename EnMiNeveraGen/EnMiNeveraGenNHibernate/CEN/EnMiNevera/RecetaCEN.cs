

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
 *      Definition of the class RecetaCEN
 *
 */
public partial class RecetaCEN
{
private IRecetaCAD _IRecetaCAD;

public RecetaCEN()
{
        this._IRecetaCAD = new RecetaCAD ();
}

public RecetaCEN(IRecetaCAD _IRecetaCAD)
{
        this._IRecetaCAD = _IRecetaCAD;
}

public IRecetaCAD get_IRecetaCAD ()
{
        return this._IRecetaCAD;
}

public int New_ (string p_nombre, string p_descripcion, string p_foto, int p_usuario, Nullable<DateTime> p_fechaCreacion, EnMiNeveraGenNHibernate.Enumerated.EnMiNevera.EstadosEnum p_estado)
{
        RecetaEN recetaEN = null;
        int oid;

        //Initialized RecetaEN
        recetaEN = new RecetaEN ();
        recetaEN.Nombre = p_nombre;

        recetaEN.Descripcion = p_descripcion;

        recetaEN.Foto = p_foto;


        if (p_usuario != -1) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                recetaEN.Usuario = new EnMiNeveraGenNHibernate.EN.EnMiNevera.UsuarioEN ();
                recetaEN.Usuario.Id = p_usuario;
        }

        recetaEN.FechaCreacion = p_fechaCreacion;

        recetaEN.Estado = p_estado;

        //Call to RecetaCAD

        oid = _IRecetaCAD.New_ (recetaEN);
        return oid;
}

public void Modify (int p_Receta_OID, string p_nombre, string p_descripcion, string p_foto, Nullable<DateTime> p_fechaCreacion, EnMiNeveraGenNHibernate.Enumerated.EnMiNevera.EstadosEnum p_estado)
{
        RecetaEN recetaEN = null;

        //Initialized RecetaEN
        recetaEN = new RecetaEN ();
        recetaEN.Id = p_Receta_OID;
        recetaEN.Nombre = p_nombre;
        recetaEN.Descripcion = p_descripcion;
        recetaEN.Foto = p_foto;
        recetaEN.FechaCreacion = p_fechaCreacion;
        recetaEN.Estado = p_estado;
        //Call to RecetaCAD

        _IRecetaCAD.Modify (recetaEN);
}

public void Destroy (int id)
{
        _IRecetaCAD.Destroy (id);
}

public System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN> Buscar (string p_texto)
{
        return _IRecetaCAD.Buscar (p_texto);
}
public System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN> BuscarPorIngrediente (System.Collections.Generic.IList<int> p_lista_ingredientes)
{
        return _IRecetaCAD.BuscarPorIngrediente (p_lista_ingredientes);
}
public System.Collections.Generic.IList<EnMiNeveraGenNHibernate.EN.EnMiNevera.RecetaEN> VerUltimasRecetas ()
{
        return _IRecetaCAD.VerUltimasRecetas ();
}
}
}
