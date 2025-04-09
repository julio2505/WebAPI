using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class CursoData
    {
        public static bool Registrar(Curso oCurso)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("cso_registrar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreCurso", oCurso.NombreCurso);
                cmd.Parameters.AddWithValue("@Descripcion", oCurso.Descripcion);
                cmd.Parameters.AddWithValue("@Codigo_unico", oCurso.Codigo_unico);

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

        public static bool Modificar(Curso oCurso)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("cso_modificar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCurso", oCurso.IdCurso);
                cmd.Parameters.AddWithValue("@NombreCurso", oCurso.NombreCurso);
                cmd.Parameters.AddWithValue("@Descripcion", oCurso.Descripcion);
                cmd.Parameters.AddWithValue("@Codigo_unico", oCurso.Codigo_unico);

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

        public static List<Curso> Listar()
        {
            List<Curso> oListaCurso = new List<Curso>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("cso_listar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaCurso.Add(new Curso()
                            {
                                IdCurso = Convert.ToInt32(dr["IdCurso"]),
                                NombreCurso = dr["NombreCurso"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                Codigo_unico = dr["Codigo_unico"].ToString()

                            });
                        }

                    }



                    return oListaCurso;
                }
                catch (Exception ex)
                {
                    return oListaCurso;
                }
            }
        }

        public static Curso Obtener(int IdCurso)
        {
            Curso oCurso = new Curso();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("cso_obtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCurso", IdCurso);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oCurso = new Curso()
                            {
                                IdCurso = Convert.ToInt32(dr["IdCurso"]),
                                NombreCurso = dr["NombreCurso"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                Codigo_unico = dr["Codigo_unico"].ToString()
                            };
                        }

                    }



                    return oCurso;
                }
                catch (Exception ex)
                {
                    return oCurso;
                }
            }
        }

        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("cso_eliminar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCurso", id);

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