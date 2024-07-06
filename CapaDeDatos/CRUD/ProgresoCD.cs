using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.CRUD
{
    public class ProgresoCD
    
    {       //Cadena de Conexion
        // Cadena de Conexion
        private ConexionCD Conexion = new ConexionCD();

        // Variables a Utilizar
        private SqlDataReader LectorDatos;
        private DataTable Tabla = new DataTable();

        public DataTable ObtenerProgreso()
        {
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "ObtenerProgreso";
                comando.CommandType = CommandType.StoredProcedure;
                LectorDatos = comando.ExecuteReader();
                Tabla.Load(LectorDatos);
                Conexion.CerrarConexion();
            }

            return Tabla;
        }

        public bool Insertar(Progreso progreso)
        {
            bool agregado = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "InsertarProgreso";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@codigo", progreso.codigo);
                comando.Parameters.AddWithValue("@descripcion", progreso.descripcion);
                comando.Parameters.AddWithValue("@fecha_registro", progreso.fecha_registro);
                agregado = comando.ExecuteNonQuery() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return agregado;
        }

        public bool Editar(Progreso progreso)
        {
            bool editado = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "ActualizarProgreso";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_progreso", progreso.id_progreso);
                comando.Parameters.AddWithValue("@codigo", progreso.codigo);
                comando.Parameters.AddWithValue("@descripcion", progreso.descripcion);
                comando.Parameters.AddWithValue("@fecha_registro", progreso.fecha_registro);

                editado = comando.ExecuteNonQuery() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return editado;
        }

        public bool Eliminar(int progresoId)
        {
            bool eliminado = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "EliminarProgreso";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_progreso", progresoId);
                eliminado = comando.ExecuteNonQuery() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return eliminado;
        }

        public bool ExisteProgreso(Progreso progreso)
        {
            bool existe = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "ExisteProgreso";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@codigo", progreso.codigo);
                existe = (int)comando.ExecuteScalar() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return existe;
        }

        public bool ExisteOtroProgreso(Progreso progreso)
        {
            bool existe = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "ExisteOtroProgreso";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@codigo", progreso.codigo);
                comando.Parameters.AddWithValue("@id_progreso", progreso.id_progreso);
                existe = (int)comando.ExecuteScalar() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return existe;
        }

        public bool ProgresoConProyectoDetalle(int progresoId)
        {
            bool existe = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "ProgresoConProyectoDetalle";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_progreso", progresoId);
                existe = (int)comando.ExecuteScalar() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return existe;
        }
    }
}