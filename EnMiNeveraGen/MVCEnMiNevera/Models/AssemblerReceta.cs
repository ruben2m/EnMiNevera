﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EnMiNeveraGenNHibernate.EN.EnMiNevera;

namespace MVCEnMiNevera.Models
{
    public class AssemblerReceta
    {
        public Receta ConvertENToModelUI(RecetaEN en)
        {
            Receta model = new Receta();
            model.id = en.Id;
            model.Nombre = en.Nombre;
            model.Descripcion = en.Descripcion;
            model.Foto = en.Foto;
            model.FechaCreacion = en.FechaCreacion;
            model.Estado = en.Estado;

            model.IdUsuario = en.Usuario.Id;
            model.NombreUsuario = en.Usuario.Nombre;

            model.UsuariosFavorito = en.UsuariosFavorito.ToList();
            // Pasos ordenados por numero paso
            model.Pasos = en.Pasos.OrderBy(f => f.NumeroPaso).ToList();
            model.Comentario = en.Comentarios.ToList();
            model.LineasIngrediente = en.LineasIngrediente.ToList();
            model.LineasListaCompra = en.LineasListaCompra.ToList();

            return model;
        }
        public IList<Receta> ConvertListENToModel(IList<RecetaEN> ens)
        {
            IList<Receta> lista = new List<Receta>();
            foreach (RecetaEN en in ens)
            {
                lista.Add(ConvertENToModelUI(en));
            }
            return lista;
        }
    }

}
