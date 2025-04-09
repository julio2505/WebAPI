using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class AlumnoData
    {
        public static bool Registrar(Alumno oAlumno)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("amno_registrar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", oAlumno.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", oAlumno.Apellido);
                cmd.Parameters.AddWithValue("@FechaNacimiento", oAlumno.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Numero_unico", oAlumno.Numero_unico);

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

        public static bool Modificar(Alumno oAlumno)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("amno_modificar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdAlumno", oAlumno.IdAlumno);
                cmd.Parameters.AddWithValue("@Nombre", oAlumno.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", oAlumno.Apellido);
                cmd.Parameters.AddWithValue("@FechaNacimiento", oAlumno.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Numero_unico", oAlumno.Numero_unico);

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

        public static List<Alumno> Listar()
        {
            List<Alumno> oListaAlumno = new List<Alumno>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("amno_listar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaAlumno.Add(new Alumno()
                            {
                                IdAlumno = Convert.ToInt32(dr["IdAlumno"]),
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString(),
                                FechaNacimiento = dr["FechaNacimiento"].ToString(),
                                Numero_unico = dr["Numero_unico"].ToString()

                            });
                        }

                    }



                    return oListaAlumno;
                }
                catch (Exception ex)
                {
                    return oListaAlumno;
                }
            }
        }

        public static Alumno Obtener(int IdAlumno)
        {
            Alumno oAlumno = new Alumno();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("amno_obtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdAlumno", IdAlumno);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oAlumno = new Alumno()
                            {
                                IdAlumno = Convert.ToInt32(dr["IdAlumno"]),
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString(),
                                FechaNacimiento = dr["FechaNacimiento"].ToString(),
                                Numero_unico = dr["Numero_unico"].ToString()
                            };
                        }

                    }



                    return oAlumno;
                }
                catch (Exception ex)
                {
                    return oAlumno;
                }
            }
        }

        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("amno_eliminar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdAlumno", id);

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
    }
}