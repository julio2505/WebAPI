using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebAPI.Models;
using System.Security.Cryptography;
using System.Web.Http;

namespace WebAPI.Data
{
    public class InscripcionesData
    {
        public static bool Registrar(Inscripciones oInscripciones)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("icion_registrar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdAlumno", oInscripciones.IdAlumno);
                cmd.Parameters.AddWithValue("@IdCurso", oInscripciones.IdCurso);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool Modificar(Inscripciones oInscripciones)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("icion_modificar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdInscripcion", oInscripciones.IdInscripcion);
                cmd.Parameters.AddWithValue("@IdAlumno", oInscripciones.IdAlumno);
                cmd.Parameters.AddWithValue("@IdCurso", oInscripciones.IdCurso);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static List<Inscripciones> Listar()
        {
            List<Inscripciones> oListaInscripciones = new List<Inscripciones>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("icion_listar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaInscripciones.Add(new Inscripciones()
                            {
                                IdInscripcion = Convert.ToInt32(dr["IdInscripcion"]),
                                IdAlumno = dr["IdAlumno"].ToString(),
                                IdCurso = dr["IdCurso"].ToString()

                            });
                        }

                    }



                    return oListaInscripciones;
                }
                catch (Exception ex)
                {
                    return oListaInscripciones;
                }
            }
        }

        public static Inscripciones Obtener(int IdInscripcion)
        {
            Inscripciones oIncripciones = new Inscripciones();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("icion_obtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdInscripcion", IdInscripcion);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oIncripciones = new Inscripciones()
                            {
                                IdInscripcion = Convert.ToInt32(dr["IdInscripcion"]),
                                IdAlumno = dr["IdAlumno"].ToString(),
                                IdCurso = dr["IdCurso"].ToString()
                            };
                        }

                    }



                    return oIncripciones;
                }
                catch (Exception ex)
                {
                    return oIncripciones;
                }
            }
        }

        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("icion_eliminar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdInscripcion", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
 
        public static List<InscripcionesLista> ListarCursosAlumnos()
        {
            List<InscripcionesLista> oInscripcionesCursosAlumnos = new List<InscripcionesLista>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("icion_listar_cursos_alumnos", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oInscripcionesCursosAlumnos.Add(new InscripcionesLista()
                            {
                               
                                NombreAlumno = dr["Nombre"].ToString(),
                                ApellidoAlumno = dr["Apellido"].ToString(),
                                Numero_unico = dr["Numero_unico"].ToString(),
                                NombreCurso = dr["NombreCurso"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                Codigo_Unico = dr["Codigo_unico"].ToString(),
                                NombreMaestro = dr["NombreMaestro"].ToString(),
                                ApellidoMaestro = dr["ApellidoMaestro"].ToString()


                            });
                        }

                    }



                    return oInscripcionesCursosAlumnos;
                }
                catch (Exception ex)
                {
                    return oInscripcionesCursosAlumnos;
                }
            }
        }
    }
}