using Microsoft.Data.SqlClient;

namespace CineStar.Data
{
    public class Conexion
    {
        private static Conexion _instancia = null;
        private readonly string _cadenaConexion;

        // Constructor privado para evitar que la instancien desde fuera (Regla del Singleton)
        private Conexion(IConfiguration config)
        {
            _cadenaConexion = config.GetConnectionString("AzureCineStar");
        }

        // Método estático para inicializar el Singleton al arrancar la app
        public static void Inicializar(IConfiguration config)
        {
            if (_instancia == null)
            {
                _instancia = new Conexion(config);
            }
        }

        public static Conexion Instancia
        {
            get
            {
                if (_instancia == null) throw new Exception("La conexión no ha sido inicializada.");
                return _instancia;
            }
        }

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(_cadenaConexion);
        }
    }
}
