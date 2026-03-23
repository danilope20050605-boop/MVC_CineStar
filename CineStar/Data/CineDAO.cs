using CineStar.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CineStar.Data
{
    public class CineDAO
    {
        public List<Cine> ObtenerCines()
        {
            List<Cine> lista = new List<Cine>();
            try
            {
                using (var cn = Conexion.Instancia.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("sp_getCines", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Cine
                            {
                                Id = Convert.ToInt32(dr["id"]),
                                Nombre = dr["RazonSocial"].ToString().Trim(),
                                Direccion = dr["Direccion"].ToString().Trim(),
                                Telefonos = dr["Telefonos"].ToString().Trim(),
                                Distrito = dr["Detalle"].ToString().Trim()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en CineDAO (Lista): " + ex.Message);
            }
            return lista;
        }

        public Cine ObtenerCineDetalle(int id)
        {
            Cine cine = null;
            try
            {
                using (var cn = Conexion.Instancia.ObtenerConexion())
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_getCine", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                cine = new Cine
                                {
                                    Id = id,
                                    Nombre = dr["RazonSocial"].ToString().Trim(),
                                    Direccion = dr["Direccion"].ToString().Trim(),
                                    Telefonos = dr["Telefonos"].ToString().Trim(),
                                    ListaTarifas = new List<Tarifa>(),
                                    ListaPeliculas = new List<PeliculaHorario>()
                                };
                            }
                        }
                    }

                    if (cine != null)
                    {
                        using (SqlCommand cmdTarifas = new SqlCommand("sp_getCineTarifas", cn))
                        {
                            cmdTarifas.CommandType = CommandType.StoredProcedure;
                            cmdTarifas.Parameters.AddWithValue("@idCine", id); 
                            using (var dr = cmdTarifas.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    cine.ListaTarifas.Add(new Tarifa
                                    {
                                        Dias = dr["DiasSemana"].ToString().Trim(),
                                        Precio = dr["Precio"].ToString().Trim()
                                    });
                                }
                            }
                        }

                        using (SqlCommand cmdPelis = new SqlCommand("sp_getCinePeliculas", cn))
                        {
                            cmdPelis.CommandType = CommandType.StoredProcedure;
                            cmdPelis.Parameters.AddWithValue("@idCine", id);
                            using (var dr = cmdPelis.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    cine.ListaPeliculas.Add(new PeliculaHorario
                                    {
                                        Titulo = dr["Titulo"].ToString().Trim(),
                                        Horarios = dr["Horarios"].ToString().Trim()
                                    });
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en CineDAO (Detalle): " + ex.Message);
            }
            return cine;
        }
    }
}
