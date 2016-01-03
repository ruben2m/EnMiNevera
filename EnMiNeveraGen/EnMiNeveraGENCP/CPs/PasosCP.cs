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
    public class PasosCP : BasicCP
    {

        public PasosCP() : base() { }

        public PasosCP(ISession sessionAux)
            : base(sessionAux)
        {
        }

        public bool cambiarNumPasos(int p_oid, int p_num_paso_old, int p_num_paso_new, int p_receta, int p_usuario)
        {
           
           
            bool devuelve = false;
            RecetaCEN recetaCEN = null;
            PasosCEN pasosCEN = null;
            UsuarioCEN usuarioCEN = null;

            try
            {
                SessionInitializeTransaction();
                RecetaCAD recetaCAD = new RecetaCAD(session);
                recetaCEN = new RecetaCEN(recetaCAD);
                UsuarioCAD usuarioCAD = new UsuarioCAD(session);
                usuarioCEN = new UsuarioCEN(usuarioCAD);
                PasosCAD pasosCAD = new PasosCAD(session);
                pasosCEN = new PasosCEN(pasosCAD);
                PasosEN pasosEN = new PasosEN();
                pasosEN = pasosCAD.ReadOIDDefault(p_oid);
                RecetaEN recetaEN = new RecetaEN();
                recetaEN = recetaCAD.ReadOIDDefault(p_receta);
                UsuarioEN usuarioEN = new UsuarioEN();
                usuarioEN = usuarioCAD.ReadOIDDefault(p_usuario);
                recetaEN.Usuario = usuarioEN;
                pasosEN.Receta = recetaEN;
                System.Console.WriteLine("\n Entro aqui1 \n");
                if (pasosEN.NumeroPaso != p_num_paso_new)
                {
                    pasosEN.NumeroPaso = p_num_paso_new;
                    pasosCAD.Modify(pasosEN);
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

    }
}
