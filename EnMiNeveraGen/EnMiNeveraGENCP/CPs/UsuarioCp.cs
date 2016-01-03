using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnMiNeveraGenNHibernate.EN.EnMiNevera; // <- Apuntar a los respectivos paquetes de vuestro proyecto.
using EnMiNeveraGenNHibernate.CAD.EnMiNevera;
using EnMiNeveraGenNHibernate.CEN.EnMiNevera;
using NHibernate;

namespace EnMiNeveraCP.CPs
{
    public class UsuarioCP : BasicCP
    {

        public UsuarioCP() : base() { }

        public UsuarioCP(ISession sessionAux)
            : base(sessionAux)
        {
        }

        public int EjemploOperacionCP()
        {
            //IPedidoCAD _IPedidoCAD = null;
            //PedidoCEN pedidoCEN = null;
            //ArticuloCP articuloCP = null;
            int oid = -1;

            try
            {
                SessionInitializeTransaction();
               
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

            return oid;
        }

        public bool seguir(int p_oid, int p_usuario_a_seguir)
        {
            bool devuelve = false;
            bool encontrado = false;
            UsuarioCEN usuarioCEN = null;
            int cont = 0;

            try
            {
                SessionInitializeTransaction();
                UsuarioCAD usuarioCAD = new UsuarioCAD(session);
                usuarioCEN = new UsuarioCEN(usuarioCAD);
                UsuarioEN usuarioEN = new UsuarioEN();
                UsuarioEN usuarioASeguirEN = new UsuarioEN();
                usuarioEN = usuarioCAD.ReadOIDDefault(p_oid);
                usuarioASeguirEN = usuarioCAD.ReadOIDDefault(p_usuario_a_seguir);
               
                IList<UsuarioEN> listaSeguidos = usuarioEN.Seguidos;
                if (listaSeguidos != null)
                {
                    foreach (UsuarioEN entry in listaSeguidos)
                    {
                        if (!entry.Id.Equals(p_usuario_a_seguir))
                        {
                            encontrado = true;
                            
                        }
                        cont++;
                    }

                }
                if (encontrado == true) { 
                    listaSeguidos.Add(usuarioASeguirEN);
                    devuelve = true;
                }
                //Si al principio no tiene ningun seguidor y su lista esta vacia entra aquí y lo guarda
                if (cont == 0)
                {
                    listaSeguidos.Add(usuarioASeguirEN);
                    devuelve = true;
                }
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

        public bool dejarSeguir(int p_oid, int p_usuario)
        {
            bool devuelve = false;
            bool encontrado = false;
            UsuarioCEN usuarioCEN = null;
       

            try
            {
                SessionInitializeTransaction();
                UsuarioCAD usuarioCAD = new UsuarioCAD(session);
                usuarioCEN = new UsuarioCEN(usuarioCAD);
                UsuarioEN usuarioEN = new UsuarioEN();
                UsuarioEN usuarioASeguirEN = new UsuarioEN();
                usuarioEN = usuarioCAD.ReadOIDDefault(p_oid);
                usuarioASeguirEN = usuarioCAD.ReadOIDDefault(p_usuario);

                IList<UsuarioEN> listaSeguidos = usuarioEN.Seguidos;
                if (listaSeguidos != null)
                {
                    foreach (UsuarioEN entry in listaSeguidos)
                    {
                        if (entry.Id.Equals(p_usuario))
                        {
                            encontrado = true;

                        }
           
                    }

                }
                if (encontrado == true)
                {
                    listaSeguidos.Remove(usuarioASeguirEN);
                    devuelve = true;
                }
                
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

        public bool guardarFavorito(int p_oid, int p_receta)
        {
            bool devuelve = false;

            UsuarioCEN usuarioCEN = null;
            RecetaCEN recetaCEN = null;
        

            try
            {
                SessionInitializeTransaction();
                UsuarioCAD usuarioCAD = new UsuarioCAD(session);
                usuarioCEN = new UsuarioCEN(usuarioCAD);
                UsuarioEN usuarioEN = new UsuarioEN();
                usuarioEN = usuarioCAD.ReadOIDDefault(p_oid);
                RecetaCAD recetaCAD = new RecetaCAD(session);
                recetaCEN = new RecetaCEN(recetaCAD);
                RecetaEN recetaEN = new RecetaEN();
                recetaEN = recetaCAD.ReadOIDDefault(p_oid);

                if (!usuarioEN.Favoritos.Contains(recetaEN))
                {
                    usuarioEN.Favoritos.Add(recetaEN);
                    devuelve = true;
                }
                else
                    usuarioEN.Favoritos.Remove(recetaEN);
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

    }
}
