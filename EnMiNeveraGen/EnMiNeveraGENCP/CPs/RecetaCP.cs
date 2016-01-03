using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnMiNeveraGenNHibernate.EN.EnMiNevera; // <- Apuntar a los respectivos paquetes de vuestro proyecto.
using EnMiNeveraGenNHibernate.CAD.EnMiNevera;
using EnMiNeveraGenNHibernate.CEN.EnMiNevera;
using EnMiNeveraGenNHibernate.Enumerated.EnMiNevera;
using NHibernate;

namespace EnMiNeveraCP.CPs
{
    public class RecetaCP: BasicCP
    {

        public RecetaCP() : base() { }

        public RecetaCP(ISession sessionAux)
            : base(sessionAux)
        {
        }

        public bool banearCP(int p_oid, int p_usuario)
        {
            //IPedidoCAD _IPedidoCAD = null;
            //PedidoCEN pedidoCEN = null;
            //ArticuloCP articuloCP = null;
            int oid = -1;
            bool devuelve = false;
            RecetaCEN recetaCEN = null;
            UsuarioCEN usuarioCEN = null;
            
            try
            {
                SessionInitializeTransaction();
                RecetaCAD recetaCAD = new RecetaCAD(session);
                recetaCEN = new RecetaCEN(recetaCAD);
                UsuarioCAD usuarioCAD = new UsuarioCAD(session);
                usuarioCEN = new UsuarioCEN(usuarioCAD);
                RecetaEN recetaEN = new RecetaEN();
                recetaEN = recetaCAD.ReadOIDDefault(p_oid);
                UsuarioEN usuarioEN = new UsuarioEN();
                usuarioEN = usuarioCAD.ReadOIDDefault(p_usuario);
                recetaEN.Usuario = usuarioEN;
                System.Console.WriteLine("\n Entro aqui1 \n");
                if (recetaEN.Estado.Equals(EstadosEnum.publicado))
                {
                    System.Console.WriteLine("\n Entro aqui2\n");
                    recetaEN.Estado = EstadosEnum.baneado;
                    devuelve = true;
                }
                else if (recetaEN.Estado.Equals(EstadosEnum.baneado))
                {
                    System.Console.WriteLine("\n Entro aqui3\n");
                    recetaEN.Estado = EstadosEnum.publicado;
                    devuelve = true;
                }
                System.Console.WriteLine("\n Entro aqui4 \n");
                recetaCAD.Modify(recetaEN);
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

            return devuelve;
        }
        public void CrearLineaIngrediente(int p_oid, int p_cantidad, EnMiNeveraGenNHibernate.Enumerated.EnMiNevera.UnidadesEnum p_unidad, string p_ingrediente)
        {
            IngredienteEN ingredienteEN = null;
            LineaIngredienteEN lineaIngredienteEN = null;

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
                }
                else
                {
                    oid_ingrediente = ingredienteEN.Id;
                }

                LineaIngredienteCAD lineaIngredienteCAD = new LineaIngredienteCAD(session);
                lineaIngredienteEN = new LineaIngredienteEN();
                lineaIngredienteEN.Ingrediente = ingredienteCAD.ReadOIDDefault(oid_ingrediente);
                lineaIngredienteEN.Cantidad = p_cantidad;
                lineaIngredienteEN.Unidad = p_unidad;
                lineaIngredienteEN.Ingrediente.Nombre = p_ingrediente.ToLower();

                lineaIngredienteCAD.New_(lineaIngredienteEN);


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
                }
                else
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
