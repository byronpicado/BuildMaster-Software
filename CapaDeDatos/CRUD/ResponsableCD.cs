using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDeDatos.CRUD
{
    public class ResponsableCD
    {
        // Cadena de Conexion
        private ConexionCD Conexion = new ConexionCD();

        // Variables a Utilizar
        private SqlDataReader LectorDatos;
        private DataTable Tabla = new DataTable();

        public DataTable ObtenerResponsable()
        {
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "ObtenerResponsable";
                comando.CommandType = CommandType.StoredProcedure;
                LectorDatos = comando.ExecuteReader();
                Tabla.Load(LectorDatos);
                Conexion.CerrarConexion();
            }

            return Tabla;
        }

        public bool Insertar(Responsable responsable)
        {
            bool agregado = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "InsertarResponsable";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@codigo", responsable.codigo);
                comando.Parameters.AddWithValue("@nombre1", responsable.nombre1);
                comando.Parameters.AddWithValue("@nombre2", responsable.nombre2);
                comando.Parameters.AddWithValue("@apellidoPaterno", responsable.apellidoPaterno);
                comando.Parameters.AddWithValue("@apellidoMaterno", responsable.apellidoMaterno);
                comando.Parameters.AddWithValue("@cargo", responsable.cargo);
                agregado = comando.ExecuteNonQuery() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return agregado;
        }

        public bool Editar(Responsable responsable)
        {
            bool editado = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "ActualizarResponsable";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("id_responsable", responsable.id_responsable);
                comando.Parameters.AddWithValue("@codigo", responsable.codigo);
                comando.Parameters.AddWithValue("@nombre1", responsable.nombre1);
                comando.Parameters.AddWithValue("@nombre2", responsable.nombre2);
                comando.Parameters.AddWithValue("@apellidoPaterno", responsable.apellidoPaterno);
                comando.Parameters.AddWithValue("@apellidoMaterno", responsable.apellidoMaterno);
                comando.Parameters.AddWithValue("@cargo", responsable.cargo);

                editado = comando.ExecuteNonQuery() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return editado;
        }

        public bool Eliminar(int responsableId)
        {
            bool eliminado = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "EliminarResponsable";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_responsable", responsableId);
                eliminado = comando.ExecuteNonQuery() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return eliminado;
        }

        public bool ExisteResponsable(Responsable responsable)
        {
            bool existe = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "ExisteResponsable";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@codigo", responsable.codigo);
                existe = (int)comando.ExecuteScalar() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return existe;
        }

        public bool ExisteOtroResponsable(Responsable responsable)
        {
            bool existe = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "ExisteOtroResponsable";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@codigo", responsable.codigo);
                comando.Parameters.AddWithValue("@id_responsable", responsable.id_responsable);
                existe = (int)comando.ExecuteScalar() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return existe;
        }

        public bool ResponsableConProyecto(int responsableId)
        {
            bool existe = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "ResponsableConProyecto";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_responsable", responsableId);
                existe = (int)comando.ExecuteScalar() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return existe;
        }
    }
}