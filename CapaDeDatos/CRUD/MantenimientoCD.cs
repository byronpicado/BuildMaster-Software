using System;
using System;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using Entidades.Entidades;

namespace CapaDeDatos.CRUD
{
    public class MantenimientoCD
    {
        // Cadena de Conexion
        private ConexionCD Conexion = new ConexionCD();

        // Variables a Utilizar
        private SqlDataReader LectorDatos;
        private DataTable Tabla = new DataTable();

        public DataTable ObtenerMantenimiento()
        {
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "ObtenerMantenimientos";
                comando.CommandType = CommandType.StoredProcedure;
                LectorDatos = comando.ExecuteReader();
                Tabla.Load(LectorDatos);
                Conexion.CerrarConexion();
            }

            return Tabla;
        }

        public bool Insertar(Mantenimiento mantenimiento)
        {
            bool agregado = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "InsertarMantenimiento";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@codigo", mantenimiento.codigo);
                comando.Parameters.AddWithValue("@fecha_mantenimiento", mantenimiento.fecha_mantenimiento);
                comando.Parameters.AddWithValue("@descripcion", mantenimiento.descripcion);

                agregado = comando.ExecuteNonQuery() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return agregado;
        }

        public bool Editar(Mantenimiento mantenimiento)
        {
            bool editado = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "ActualizarMantenimiento";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_mantenimiento", mantenimiento.id_mantenimiento);
                comando.Parameters.AddWithValue("@codigo", mantenimiento.codigo);
                comando.Parameters.AddWithValue("@fecha_mantenimiento", mantenimiento.fecha_mantenimiento);
                comando.Parameters.AddWithValue("@descripcion", mantenimiento.descripcion);

                editado = comando.ExecuteNonQuery() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return editado;
        }

        public bool Eliminar(int mantenimientoId)
        {
            bool eliminado = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "EliminarMantenimiento";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_mantenimiento", mantenimientoId);
                eliminado = comando.ExecuteNonQuery() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return eliminado;
        }

        public bool ExisteMantenimiento(Mantenimiento mantenimiento)
        {
            bool existe = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "ExisteMantenimiento";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@codigo", mantenimiento.codigo);
                existe = (int)comando.ExecuteScalar() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return existe;
        }

        public bool ExisteOtroMantenimiento(Mantenimiento mantenimiento)
        {
            bool existe = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "ExisteOtroMantenimiento";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@codigo", mantenimiento.codigo);
                comando.Parameters.AddWithValue("@id_equipo", mantenimiento.id_mantenimiento);
                existe = (int)comando.ExecuteScalar() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return existe;
        }

        public bool MantenimientoConMantenimientoEquipo(int mantenimientoId)
        {
            bool existe = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "MantenimientoConMantenimientoEquipo";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_mantenimiento", mantenimientoId);
                existe = (int)comando.ExecuteScalar() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return existe;
        }
    }
    }
