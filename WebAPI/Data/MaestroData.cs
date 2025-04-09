using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class MaestroData
    {
        public static bool Registrar(Maestro oMaestro)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("mtro_registrar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreMaestro", oMaestro.NombreMaestro);
                cmd.Parameters.AddWithValue("@ApellidoMaestro", oMaestro.ApellidoMaestro);
                cmd.Parameters.AddWithValue("@Numero_unicoMaestro", oMaestro.Numero_unicoMaestro);
                cmd.Parameters.AddWithValue("@edad", oMaestro.edad);

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

        public static bool Modificar(Maestro oMaestro)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("mtro_modificar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdMaestro", oMaestro.IdMaestro);
                cmd.Parameters.AddWithValue("@NombreMaestro", oMaestro.NombreMaestro);
                cmd.Parameters.AddWithValue("@ApellidoMaestro", oMaestro.ApellidoMaestro);
                cmd.Parameters.AddWithValue("@Numero_unicoMaestro", oMaestro.Numero_unicoMaestro);
                cmd.Parameters.AddWithValue("@edad", oMaestro.edad);

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

        public static List<Maestro> Listar()
        {
            List<Maestro> oListaMaestro = new List<Maestro>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("mtro_listar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaMaestro.Add(new Maestro()
                            {
                                IdMaestro = Convert.ToInt32(dr["IdMaestro"]),
                                NombreMaestro = dr["NombreMaestro"].ToString(),
                                ApellidoMaestro = dr["ApellidoMaestro"].ToString(),
                                Numero_unicoMaestro = dr["Numero_unicoMaestro"].ToString(),
                                edad = dr["edad"].ToString()

                            });
                        }

                    }



                    return oListaMaestro;
                }
                catch (Exception ex)
                {
                    return oListaMaestro;
                }
            }
        }

        public static Maestro Obtener(int IdMaestro)
        {
            Maestro oMaestro = new Maestro();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("mtro_obtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdMaestro", IdMaestro);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oMaestro = new Maestro()
                            {
                                IdMaestro = Convert.ToInt32(dr["IdMaestro"]),
                                NombreMaestro = dr["NombreMaestro"].ToString(),
                                ApellidoMaestro = dr["ApellidoMaestro"].ToString(),
                                Numero_unicoMaestro = dr["Numero_unicoMaestro"].ToString(),
                                edad = dr["edad"].ToString()
                            };
                        }

                    }



                    return oMaestro;
                }
                catch (Exception ex)
                {
                    return oMaestro;
                }
            }
        }

        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("mtro_eliminar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdMaestro", id);

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