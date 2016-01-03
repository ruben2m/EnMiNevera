using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnMiNeveraGenNHibernate.EN.EnMiNevera;
using EnMiNeveraGenNHibernate.CEN.EnMiNevera;
using EnMiNeveraGenNHibernate.CAD.EnMiNevera;
using NHibernate;

namespace EnMiNeveraCP.CPs
{
    public class ListaCompraCP : BasicCP
    {

        public ListaCompraCP() : base() { }

        public ListaCompraCP(ISession sessionAux)
            : base(sessionAux)
        {
        }

        public void CrearLineaListaCompra(int p_oid, int p_cantidad, EnMiNeveraGenNHibernate.Enumerated.EnMiNevera.UnidadesEnum p_unidad, string p_ingrediente)
        {
            IngredienteEN ingredienteEN = null;
            LineaListaCompraEN lineaListaCompraEN = null;

            int oid_ingrediente;

            try
            {
                SessionInitializeTransaction();


                IngredienteCAD ingredienteCAD = new IngredienteCAD(session);

                ingredienteEN = ingredienteCAD.GetPorNombre(p_ingrediente.ToLower());

                if (ingredienteEN == null)
                {
                    // Creamos el ingrediente si no existe
                    ingredienteEN = new IngredienteEN();
                    ingredienteEN.Nombre = p_ingrediente.ToLower();
                    oid_ingrediente = ingredienteCAD.New_(ingredienteEN);
                    ingredienteEN = ingredienteCAD.ReadOIDDefault(oid_ingrediente);
                } else
                {
                    oid_ingrediente = ingredienteEN.Id;
                }

                LineaListaCompraCAD lineaListaCompraCAD = new LineaListaCompraCAD(session);
                lineaListaCompraEN = new LineaListaCompraEN();
                lineaListaCompraEN.Ingrediente = ingredienteCAD.ReadOIDDefault(oid_ingrediente);
                lineaListaCompraEN.Cantidad = p_cantidad;
                lineaListaCompraEN.Unidad = p_unidad;
                lineaListaCompraEN.Comprado = false;

                lineaListaCompraEN.Ingrediente.Nombre = p_ingrediente.ToLower();

                lineaListaCompraCAD.New_(lineaListaCompraEN);

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                SessionClose();
            }
        }
       
    }
}
