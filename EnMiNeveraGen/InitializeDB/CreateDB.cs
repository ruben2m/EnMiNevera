
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using EnMiNeveraGenNHibernate.EN.EnMiNevera;
using EnMiNeveraGenNHibernate.CEN.EnMiNevera;
using EnMiNeveraGenNHibernate.CAD.EnMiNevera;
using EnMiNeveraGenNHibernate.Enumerated.EnMiNevera;
using EnMiNeveraCP.CPs;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception ex)
        {
                throw ex;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
        try
        {
                UsuarioCEN usuarioCEN = new UsuarioCEN ();

                System.Console.WriteLine ("\n\n ----- INICIO: creamos usuarios ------------------------------------------\n");
                int oid1 = usuarioCEN.Registro ("ruben", "passs1", "passs1", "emailruben@gmail.com", "mor", "rub2m", "http://facebookmania.es/fb/wp-content/uploads/2010/09/Silueta-perfil-Facebookmania-122.jpg", "biografia", DateTime.Today);

                int oid2 = usuarioCEN.Registro ("constanza", "passs1", "passs1", "cons@gmail.com", "casquet", "coni", "http://facebookmania.es/fb/wp-content/uploads/2010/09/Silueta-perfil-Facebookmania-114.jpg", "Meh", DateTime.Today);

                int oid3 = usuarioCEN.Registro ("jose carlos", "passs1", "passs1", "jc@gmail.com", "valls", "jou", "http://facebookmania.es/fb/wp-content/uploads/2010/09/Silueta-perfil-Facebookmania-123.jpg", "biografia", DateTime.Today);
                System.Console.WriteLine ("\n ----- FIN: creamos usuarios ------------------------------------------\n\n\n");



                System.Console.WriteLine ("\n\n ----- INICIO: creamos recetas ------------------------------------------\n");
                RecetaCEN recetaCEN = new RecetaCEN ();
                int receta_oid1 = recetaCEN.New_ ("Nom receta1", "descrip", "/Images/Uploads/nevera.png", oid1, DateTime.Now, EnMiNeveraGenNHibernate.Enumerated.EnMiNevera.EstadosEnum.publicado);
                int receta_oid2 = recetaCEN.New_ ("Nom receta2", "descrip", "/Images/Uploads/nevera.png", oid1, DateTime.Now, EnMiNeveraGenNHibernate.Enumerated.EnMiNevera.EstadosEnum.publicado);
                int receta_oid3 = recetaCEN.New_ ("Nom receta3", "descrip", "/Images/Uploads/nevera.png", oid1, DateTime.Now, EnMiNeveraGenNHibernate.Enumerated.EnMiNevera.EstadosEnum.publicado);
                int receta_oid4 = recetaCEN.New_ ("Nom receta4", "descrip", "/Images/Uploads/nevera.png", oid1, DateTime.Now, EnMiNeveraGenNHibernate.Enumerated.EnMiNevera.EstadosEnum.publicado);
                int receta_oid5 = recetaCEN.New_ ("Nom receta5", "descrip", "/Images/Uploads/nevera.png", oid1, DateTime.Now, EnMiNeveraGenNHibernate.Enumerated.EnMiNevera.EstadosEnum.publicado);
                int receta_oid6 = recetaCEN.New_ ("Nom receta6", "descrip", "/Images/Uploads/nevera.png", oid1, DateTime.Now, EnMiNeveraGenNHibernate.Enumerated.EnMiNevera.EstadosEnum.publicado);
                System.Console.WriteLine ("\n ----- FIN: recetas creadas ------------------------------------------\n\n\n");



                System.Console.WriteLine ("\n\n ----- INICIO: creamos pasos de recetas ------------------------------------------\n");
                // Desordenados
                PasosCEN pasosCen = new PasosCEN ();
                System.Console.WriteLine ("Receta1 ------------------------------------------------------------------\n");
                pasosCen.New_ ("Paso 1", receta_oid1, 1);
                pasosCen.New_ ("Paso 3", receta_oid1, 3);
                pasosCen.New_ ("Paso 2", receta_oid1, 2);
                pasosCen.New_ ("Paso 4", receta_oid1, 4);
                System.Console.WriteLine ("Receta2 ------------------------------------------------------------------\n");
                pasosCen.New_ ("Paso 1_2", receta_oid2, 1);
                pasosCen.New_ ("Paso 2_2", receta_oid2, 2);
                pasosCen.New_ ("Paso 3_2", receta_oid2, 3);
                System.Console.WriteLine ("Receta3 ------------------------------------------------------------------\n");
                pasosCen.New_ ("Paso 1_3", receta_oid3, 1);
                pasosCen.New_ ("Paso 2_3", receta_oid3, 2);
                pasosCen.New_ ("Paso 3_3", receta_oid3, 3);
                System.Console.WriteLine ("Receta4 ------------------------------------------------------------------\n");
                pasosCen.New_ ("Paso 1_4", receta_oid4, 1);
                pasosCen.New_ ("Paso 2_4", receta_oid4, 2);
                pasosCen.New_ ("Paso 3_4", receta_oid4, 3);
                System.Console.WriteLine ("Receta5 ------------------------------------------------------------------\n");
                pasosCen.New_ ("Paso 1_5", receta_oid5, 1);
                pasosCen.New_ ("Paso 2_5", receta_oid5, 2);
                pasosCen.New_ ("Paso 3_5", receta_oid5, 3);
                System.Console.WriteLine ("Receta6 ------------------------------------------------------------------\n");
                pasosCen.New_ ("Paso 1_6", receta_oid6, 1);
                pasosCen.New_ ("Paso 2_6", receta_oid6, 2);
                pasosCen.New_ ("Paso 3_6", receta_oid6, 3);
                System.Console.WriteLine ("\n ----- FIN: pasos de recetas creadas ------------------------------------------\n\n\n");


                System.Console.WriteLine ("\n\n ----- INICIO: Ingrediente ------------------------------------------\n");
                IngredienteCEN ingredienteCen = new IngredienteCEN ();
                int idHuevos = ingredienteCen.New_ ("huevos");
                int idHarina = ingredienteCen.New_ ("harina");
                int idAceite = ingredienteCen.New_ ("aceite");
                int idArroz = ingredienteCen.New_ ("arroz");
                System.Console.WriteLine ("\n ----- FIN: Ingrediente ------------------------------------------\n\n\n");


                System.Console.WriteLine ("\n\n ----- INICIO: LineaIngrediente ------------------------------------------\n");
                LineaIngredienteCEN lineaIngredienteCen = new LineaIngredienteCEN ();
                System.Console.WriteLine ("LineaIngrediente de Receta1 ---------------------------------------------------\n");
                lineaIngredienteCen.New_ (10, UnidadesEnum.unidades, idHuevos, receta_oid1);
                lineaIngredienteCen.New_ (100, UnidadesEnum.gramos, idHarina, receta_oid1);
                lineaIngredienteCen.New_ (20, UnidadesEnum.mililitros, idAceite, receta_oid1);
                System.Console.WriteLine ("LineaIngrediente de Receta2 ---------------------------------------------------\n");
                lineaIngredienteCen.New_ (12, UnidadesEnum.unidades, idHuevos, receta_oid2);
                lineaIngredienteCen.New_ (150, UnidadesEnum.gramos, idHarina, receta_oid2);
                lineaIngredienteCen.New_ (25, UnidadesEnum.mililitros, idAceite, receta_oid2);
                System.Console.WriteLine ("LineaIngrediente de Receta3 ---------------------------------------------------\n");
                lineaIngredienteCen.New_ (14, UnidadesEnum.unidades, idHuevos, receta_oid3);
                lineaIngredienteCen.New_ (100, UnidadesEnum.gramos, idArroz, receta_oid3);
                lineaIngredienteCen.New_ (10, UnidadesEnum.mililitros, idAceite, receta_oid3);
                System.Console.WriteLine ("LineaIngrediente de Receta4 ---------------------------------------------------\n");
                lineaIngredienteCen.New_ (20, UnidadesEnum.unidades, idHuevos, receta_oid4);
                lineaIngredienteCen.New_ (200, UnidadesEnum.gramos, idHarina, receta_oid4);
                lineaIngredienteCen.New_ (40, UnidadesEnum.mililitros, idAceite, receta_oid4);
                System.Console.WriteLine ("LineaIngrediente de Receta5 ---------------------------------------------------\n");
                lineaIngredienteCen.New_ (30, UnidadesEnum.unidades, idHuevos, receta_oid5);
                lineaIngredienteCen.New_ (300, UnidadesEnum.gramos, idHarina, receta_oid5);
                lineaIngredienteCen.New_ (30, UnidadesEnum.mililitros, idAceite, receta_oid5);
                System.Console.WriteLine ("LineaIngrediente de Receta6 ---------------------------------------------------\n");
                lineaIngredienteCen.New_ (40, UnidadesEnum.unidades, idHuevos, receta_oid6);
                lineaIngredienteCen.New_ (400, UnidadesEnum.gramos, idHarina, receta_oid6);
                lineaIngredienteCen.New_ (50, UnidadesEnum.mililitros, idAceite, receta_oid6);
                System.Console.WriteLine ("\n ----- FIN: LineaIngrediente ------------------------------------------\n\n\n");


                System.Console.WriteLine ("\n\n ----- INICIO: ComentariosReceta ------------------------------------------\n");
                ComentarioCEN comentarioCen = new ComentarioCEN ();
                comentarioCen.New_ (oid1, receta_oid1, "Comentario uno de la receta", DateTime.Now);
                comentarioCen.New_ (oid2, receta_oid1, "Comentario dos de la receta", DateTime.Now);
                comentarioCen.New_ (oid3, receta_oid1, "Comentario tres de la receta", DateTime.Now);
                System.Console.WriteLine ("\n ----- FIN: ComentariosReceta ------------------------------------------\n\n\n");


                System.Console.WriteLine ("\n\n ----- INICIO: recetas favoritas ------------------------------------------\n");
                usuarioCEN.GuardarFavorito (oid1, receta_oid2);
                usuarioCEN.GuardarFavorito (oid1, receta_oid4);
                usuarioCEN.GuardarFavorito (oid1, receta_oid6);
                System.Console.WriteLine ("\n ----- FIN: recetas favoritas ------------------------------------------\n\n\n");


                System.Console.WriteLine ("\n\n ----- INICIO: seguir usuarios ------------------------------------------\n");
                usuarioCEN.Seguir (oid1, oid2);
                usuarioCEN.Seguir (oid3, oid1);
                System.Console.WriteLine ("\n ----- FIN: seguir usuarios ------------------------------------------\n\n\n");


                System.Console.WriteLine ("\n\n ----- INICIO: ListaCompra ------------------------------------------\n");
                ListaCompraCEN listaCompraCen = new ListaCompraCEN ();
                int idListaCompra1 = listaCompraCen.New_ ("Lista1", DateTime.Now, oid1);
                int idListaCompra2 = listaCompraCen.New_ ("Lista2", DateTime.Now, oid1);
                int idListaCompra3 = listaCompraCen.New_ ("Lista3", DateTime.Now, oid1);
                System.Console.WriteLine ("\n ----- Lineas -----------------------------------------------------\n");
                LineaListaCompraCEN lineaListaCompraCen = new LineaListaCompraCEN ();
                int idLineaListaCompra1_1 = lineaListaCompraCen.New_ (12, UnidadesEnum.unidades, idHuevos, idListaCompra1, false);
                int idLineaListaCompra1_2 = lineaListaCompraCen.New_ (100, UnidadesEnum.gramos, idHarina, idListaCompra1, false);
                int idLineaListaCompra1_3 = lineaListaCompraCen.New_ (1000, UnidadesEnum.mililitros, idAceite, idListaCompra1, false);
                int idLineaListaCompra2_1 = lineaListaCompraCen.New_ (22, UnidadesEnum.unidades, idHuevos, idListaCompra2, false);
                int idLineaListaCompra2_2 = lineaListaCompraCen.New_ (100, UnidadesEnum.gramos, idArroz, idListaCompra2, false);
                int idLineaListaCompra2_3 = lineaListaCompraCen.New_ (200, UnidadesEnum.mililitros, idAceite, idListaCompra2, false);
                System.Console.WriteLine ("\n ----- FIN: ListaCompra ------------------------------------------\n\n\n");




                //recetaCen.New_("Macarrones con queso", "Macarrones gratinados de la abuela", "/foto.png", 0123, new TimeSpan(1, 12, 5, 00), EnMiNeveraGenNHibernate.Enumerated.EnMiNevera.EstadosEnum.publicado);

                //int p_oid = usuarioCEN.New_("ruben", "contrasena", "email@email.com", "apellidos", "nick", "foto", "biografia", DateTime.Today, false, EnMiNeveraGenNHibernate.Enumerated.EnMiNevera.RolesEnum.usuario);
                //int p_receta = recetaCen.New_("Macarrones con queso", "Macarrones gratinados de la abuela", "/foto.png", 0123, new TimeSpan(1, 12, 5, 00), EnMiNeveraGenNHibernate.Enumerated.EnMiNevera.EstadosEnum.publicado);

                //System.Console.WriteLine(p_oid);+

                //usuarioCEN.Registro ("constanza", "pass1", "pass1", "cons@gmail.com", "casquet", "coni", "foto", "Meh", DateTime.Today);



                //int oid = usuarioCEN.New_ ("ruben", "contrasena", "email@email.com", "apellidos", "nick", "foto", "biografia", DateTime.Today, false, EnMiNeveraGenNHibernate.Enumerated.EnMiNevera.RolesEnum.usuario);
                //System.Console.WriteLine ("\n Usuario ruben creado: " + oid + "\n");
                //UsuarioCAD usuarioCAD = new UsuarioCAD ();
                //UsuarioEN uEn = usuarioCAD.ReadOIDDefault (oid);

                //int logueado = usuarioCEN.Login (oid2, "cons", "cons@hotmail.com", "passss1"); //acceso incorrecto
                //System.Console.WriteLine ("\n Usuaria constanza ha iniciado sesion 0: " + logueado + "\n");
                //logueado = usuarioCEN.Login (oid2, "cons", "cons@hotmail.com", "passs1"); //acceso incorrecto, bien contrasenya
                //System.Console.WriteLine ("\n Usuaria constanza ha iniciado sesion 0: " + logueado + "\n");
                //logueado = usuarioCEN.Login (oid2, "cons", "cons@gmail.com", "passs1"); //acceso correcto, bien email y contrasenya
                //System.Console.WriteLine ("\n Usuaria constanza ha iniciado sesion 1: " + logueado + "\n");
                //logueado = usuarioCEN.CerrarSesion (oid2);
                //System.Console.WriteLine ("\n Usuaria constanza ha cerrado sesion 0: " + logueado + "\n"); //salida correcta

                //UsuarioCP usuarioCP = new UsuarioCP ();
                //bool devuelve = usuarioCP.seguir (oid, oid2);
                //System.Console.WriteLine ("\n Usuario ruben sigue a usuaria constanza, true: " + devuelve + "\n");
                //devuelve = usuarioCP.seguir (oid, oid2);
                //System.Console.WriteLine ("\n Usuario ruben sigue a usuaria constanza, false: " + devuelve + "\n");
                //devuelve = usuarioCP.dejarSeguir (oid, oid2);
                //System.Console.WriteLine ("\n Usuario ruben deja de seguir a usuaria constanza, true: " + devuelve + "\n");
                //devuelve = usuarioCP.dejarSeguir (oid, oid2);
                //System.Console.WriteLine ("\n Usuario ruben deja de seguir a usuaria constanza, false: " + devuelve + "\n");

                //usuarioCEN.Banear (-1, oid);
                //System.Console.WriteLine ("\n Usuario baneado \n");

                //System.Console.WriteLine ("---Comentario del usuario INI------------------");
                //usuarioCEN.Comentar (oid, receta_oid, "El comentario");
                //System.Console.WriteLine ("---Comentario del usuario FIN--------------------");


                //System.Console.WriteLine ("---crearLineaListaCompraCP INI------------------");
                //System.Console.WriteLine ("..........creo lista de compra------------------");
                //ListaCompraCEN listaCompraCEN = new ListaCompraCEN ();
                //int oid_listaCompra = listaCompraCEN.New_ ("Lista1", DateTime.Today);
                //System.Console.WriteLine ("..........llamo a crearLineaListaCompra en CP-------");
                //ListaCompraCP listaCompraCP = new ListaCompraCP ();
                //System.Console.WriteLine ("..........2-------");
                //listaCompraCP.CrearLineaListaCompra (oid_listaCompra, 5, EnMiNeveraGenNHibernate.Enumerated.EnMiNevera.UnidadesEnum.unidades, "ingrediente1");

                //System.Console.WriteLine ("crearLineaListaCompraCP FIN------------------");


                //System.Console.WriteLine ("---crearLineaIngredienteCP INI------------------");
                //System.Console.WriteLine ("..........creo receta------------------");
                ////recetaCEN ya creada
                //System.Console.WriteLine ("..........llamo a crearLineaIngrediente en CP-------");
                //RecetaCP recetaCP = new RecetaCP ();
                //System.Console.WriteLine ("..........2-------");
                //recetaCP.CrearLineaIngrediente (receta_oid, 5, EnMiNeveraGenNHibernate.Enumerated.EnMiNevera.UnidadesEnum.unidades, "ingrediente1");

                //System.Console.WriteLine ("crearLineaIngredienteCP FIN------------------");


                //System.Console.WriteLine ("---crearLineaListaCompraCP INI------------------");
                //System.Console.WriteLine ("..........creo lista de compra------------------");
                //System.Console.WriteLine ("..........llamo a crearLineaListaCompra en CP-------");

                //System.Console.WriteLine ("..........2-------");
                //recetaCP.CrearLineaListaCompra (receta_oid, 5, EnMiNeveraGenNHibernate.Enumerated.EnMiNevera.UnidadesEnum.unidades, "ingrediente1");

                //System.Console.WriteLine ("crearLineaListaCompraCP FIN------------------");

                //System.Console.WriteLine ("\n Comentario del usuario INI------------------ \n");
                //usuarioCEN.Comentar (oid, receta_oid, "El comentario");
                //System.Console.WriteLine ("\n Comentario del usuario FIN-------------------- \n");


                //System.Console.WriteLine (receta_oid);
                //devuelve = recetaCP.banearCP(receta_oid);
                //recetaCEN.Banear (receta_oid);
                //System.Console.WriteLine ("\n Receta se ha baneado: ");

                ///*PasosCP pasosCP = new PasosCP ();
                // * devuelve = pasosCP.cambiarNumPasos (1, 1, 2, receta_oid, oid2);
                // * System.Console.WriteLine ("\n Paso cambiado: " + devuelve);*/

                //devuelve = usuarioCP.guardarFavorito (oid, receta_oid);
                //System.Console.WriteLine ("\n Receta se ha guardado, true: " + devuelve + "\n"); //se anyade
                //devuelve = usuarioCP.guardarFavorito (oid, receta_oid);
                //System.Console.WriteLine ("\n Receta se ha guardado, true: " + devuelve + "\n"); //se quita


                /*List<EnMiNeveraGenNHibernate.EN.Mediaplayer.MusicTrackEN> musicTracks = new List<EnMiNeveraGenNHibernate.EN.Mediaplayer.MusicTrackEN>();
                 * EnMiNeveraGenNHibernate.EN.Mediaplayer.UserEN userEN = new EnMiNeveraGenNHibernate.EN.Mediaplayer.UserEN();
                 * EnMiNeveraGenNHibernate.EN.Mediaplayer.ArtistEN artistEN = new EnMiNeveraGenNHibernate.EN.Mediaplayer.ArtistEN();
                 * EnMiNeveraGenNHibernate.EN.Mediaplayer.MusicTrackEN musicTrackEN = new EnMiNeveraGenNHibernate.EN.Mediaplayer.MusicTrackEN();
                 * EnMiNeveraGenNHibernate.CEN.Mediaplayer.ArtistCEN artistCEN = new EnMiNeveraGenNHibernate.CEN.Mediaplayer.ArtistCEN();
                 * EnMiNeveraGenNHibernate.CEN.Mediaplayer.UserCEN userCEN = new EnMiNeveraGenNHibernate.CEN.Mediaplayer.UserCEN();
                 * EnMiNeveraGenNHibernate.CEN.Mediaplayer.MusicTrackCEN musicTrackCEN = new EnMiNeveraGenNHibernate.CEN.Mediaplayer.MusicTrackCEN();
                 * EnMiNeveraGenNHibernate.CEN.Mediaplayer.PlayListCEN playListCEN = new EnMiNeveraGenNHibernate.CEN.Mediaplayer.PlayListCEN();
                 *
                 *              //Add Users
                 * userEN.Email = "user@user.com";
                 * userEN.Name = "user";
                 * userEN.Surname = "userSurname";
                 * userEN.Password = "user";
                 * userCEN.New_(userEN.Name, userEN.Surname, userEN.Email, userEN.Password);
                 *
                 * //Add Music Track1
                 * musicTrackEN.Id = "http://www2.b3ta.com/mp3/Beer Beer Beer (YOB mix).mp3";
                 * musicTrackEN.Format = "mp3";
                 * musicTrackEN.Lyrics = "Beer Beer Beer Beer Beer Beer ..";
                 * musicTrackEN.Name = "Beer Beer Beer";
                 * musicTrackEN.Company = "Company";
                 * musicTrackEN.Cover = "http://www.tomasabraham.com.ar/cajadig/2007/images/nro18-2/beer1.jpg";
                 * musicTrackEN.Price = 20;
                 * musicTrackEN.Rating = 5;
                 * musicTrackEN.CommunityRating = 5;
                 * musicTrackEN.Duration = 200;
                 * musicTrackCEN.New_(musicTrackEN.Id, musicTrackEN.Format, musicTrackEN.Lyrics, musicTrackEN.Name,
                 *  musicTrackEN.Company, musicTrackEN.Cover, musicTrackEN.CommunityRating, musicTrackEN.Rating,
                 *  musicTrackEN.Price, musicTrackEN.Duration);
                 * musicTracks.Add(musicTrackEN);
                 * musicTrackCEN.AsignUser(musicTrackEN.Id,userEN.Email);
                 *
                 * //Define Album
                 * //EnMiNeveraGenNHibernate.CEN.Mediaplayer.AlbumCEN albumCEN = new EnMiNeveraGenNHibernate.CEN.Mediaplayer.AlbumCEN();
                 * //albumCEN.New_("Album 1", "This is a Album 1", artists, musicTracks);*/
                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }
}
}
}
