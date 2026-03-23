using CineStar.Data;
using CineStar.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CineStar.Data
{
    public class PeliculaDAO
    {
        
        public List<Pelicula> ObtenerPeliculasPorEstado(int idEstado)
        {
            List<Pelicula> lista = new List<Pelicula>();
            try
            {
                using (var cn = Conexion.Instancia.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("sp_getPeliculas", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idEstado", idEstado);

                    cn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Pelicula
                            {
                                Id = Convert.ToInt32(dr["id"]),
                                Titulo = dr["Titulo"].ToString().Trim(),
                                Link = dr["Link"].ToString().Trim(),
                                Sinopsis = dr["Sinopsis"].ToString().Trim()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en DAO: " + ex.Message);
            }
            return lista;
        }

        
        public Pelicula ObtenerPelicula(int id)
        {
            Pelicula pelicula = null;
            try
            {
                using (var cn = Conexion.Instancia.ObtenerConexion())
                {
                    
                    SqlCommand cmd = new SqlCommand("sp_getPelicula", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            pelicula = new Pelicula
                            {
                                Id = Convert.ToInt32(dr["id"]),
                                Titulo = dr["Titulo"].ToString().Trim(),
                                Sinopsis = dr["Sinopsis"].ToString().Trim(),
                                FechaEstreno = dr["FechaEstreno"].ToString().Trim(),
                                Generos = dr["Generos"].ToString().Trim(),
                                Director = dr["Director"].ToString().Trim(),
                                Reparto = dr["Reparto"].ToString().Trim(),
                                Link = dr["Link"].ToString().Trim()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en DAO Detalle: " + ex.Message);
            }
            return pelicula;
        }
    }
}
