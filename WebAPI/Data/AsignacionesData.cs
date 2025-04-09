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
    public class AsignacionesData
    {
        public static bool Registrar(Asignaciones oAsignaciones)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("asig_registrar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdMaestro", oAsignaciones.IdMaestro);
                cmd.Parameters.AddWithValue("@IdCurso", oAsignaciones.IdCurso);

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

        public static bool Modificar(Asignaciones oAsignaciones)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("asig_modificar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdAsignacion", oAsignaciones.IdAsignacion);
                cmd.Parameters.AddWithValue("@IdMaestro", oAsignaciones.IdMaestro);
                cmd.Parameters.AddWithValue("@IdCurso", oAsignaciones.IdCurso);

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

        public static List<Asignaciones> Listar()
        {
            List<Asignaciones> oListaAsignaciones = new List<Asignaciones>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("asig_listar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaAsignaciones.Add(new Asignaciones()
                            {
                                IdAsignacion = Convert.ToInt32(dr["IdAsignacion"]),
                                IdMaestro = dr["IdMaestro"].ToString(),
                                IdCurso = dr["IdCurso"].ToString()

                            });
                        }

                    }



                    return oListaAsignaciones;
                }
                catch (Exception ex)
                {
                    return oListaAsignaciones;
                }
            }
        }

        public static Asignaciones Obtener(int IdAsignacion)
        {
            Asignaciones oAsignacion = new Asignaciones();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("asig_obtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdAsignacion", IdAsignacion);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oAsignacion = new Asignaciones()
                            {
                                IdAsignacion = Convert.ToInt32(dr["IdAsignacion"]),
                                IdMaestro = dr["IdMaestro"].ToString(),
                                IdCurso = dr["IdCurso"].ToString()
                            };
                        }

                    }



                    return oAsignacion;
                }
                catch (Exception ex)
                {
                    return oAsignacion;
                }
            }
        }

        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("asig_eliminar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdAsignacion", id);

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
 
        public static List<AsignacionesLista> ListarCursosMaestros()
        {
            List<AsignacionesLista> oInscripcionesCursosMaestros = new List<AsignacionesLista>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("asig_listar_cursos_maestros", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oInscripcionesCursosMaestros.Add(new AsignacionesLista()
                            {
                                NombreMaestro = dr["NombreMaestro"].ToString(),
                                ApellidoMaestro = dr["ApellidoMaestro"].ToString(),
                                NombreAlumno = dr["Nombre"].ToString(),
                                ApellidoAlumno = dr["Apellido"].ToString(),
                                Numero_unico = dr["Numero_unico"].ToString(),
                                NombreCurso = dr["NombreCurso"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                Codigo_Unico = dr["Codigo_unico"].ToString()


                            });
                        }

                    }



                    return oInscripcionesCursosMaestros;
                }
                catch (Exception ex)
                {
                    return oInscripcionesCursosMaestros;
                }
            }
        }
    }
}