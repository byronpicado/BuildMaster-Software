using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDeDatos
{
    public class ConexionCD
    {
        private SqlConnection conexion;

        public ConexionCD()
        {
            // Inicializa la cadena de conexión directamente aquí
            string connectionString = "Data Source=DESKTOP-CAKRKLJ\\SQLEXPRESS;Database=BuildMasterDB;Integrated Security=True";
            conexion = new SqlConnection(connectionString);
        }

        // Método para abrir la conexión
        public SqlConnection AbrirConexion()
        {
            if (conexion.State == ConnectionState.Closed)
                conexion.Open();
            return conexion;
        }

        // Método para cerrar la conexión
        public SqlConnection CerrarConexion()
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Close();
            return conexion;
        }
    }
}
