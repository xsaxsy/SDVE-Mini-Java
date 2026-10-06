using MySqlConnector;

namespace SDVE
{
    public class Conexion
    {
        private string cadenaConexion =
            "Server=localhost;Database=sdve;User=root;Password=Dragonbolzcai1;SslMode=None;";

        protected MySqlConnection conexion;

        public Conexion()
        {
            conexion = new MySqlConnection(cadenaConexion);
        }

        public MySqlConnection ObtenerConexion()
        {
            return conexion;
        }

        public void AbrirConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
                conexion.Open();
        }

        public void CerrarConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
        }
    }
}