﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EnMiNeveraGenNHibernate.EN.EnMiNevera;

namespace MVCEnMiNevera.Models
{
    public class AssemblerListaCompra
    {
        public ListaCompra ConvertENToModelUI(ListaCompraEN en)
        {
            ListaCompra model = new ListaCompra();
            model.id = en.Id;
            model.Nombre = en.Nombre;
            model.Fecha = en.Fecha;
            model.LineasListaCompra = en.LineasListaCompra.ToList();

            return model;
        }
        public IList<ListaCompra> ConvertListENToModel(IList<ListaCompraEN> ens)
        {
            IList<ListaCompra> lista = new List<ListaCompra>();
            foreach (ListaCompraEN l in ens)
            {
                lista.Add(ConvertENToModelUI(l));
            }
            return lista;
        }
    }

}