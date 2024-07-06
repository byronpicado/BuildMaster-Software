using System;
using System;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using Entidades.Entidades;

namespace CapaDeDatos.CRUD
{
    public class EquipoCD
    {
        // Cadena de Conexion
        private ConexionCD Conexion = new ConexionCD();

        // Variables a Utilizar
        private SqlDataReader LectorDatos;
        private DataTable Tabla = new DataTable();

        public DataTable ObtenerEquipo()
        {
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "ObtenerEquipos";
                comando.CommandType = CommandType.StoredProcedure;
                LectorDatos = comando.ExecuteReader();
                Tabla.Load(LectorDatos);
                Conexion.CerrarConexion();
            }

            return Tabla;
        }

        public bool Insertar(Equipo equipo)
        {
            bool agregado = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "InsertarEquipo";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@codigo", equipo.codigo);
                comando.Parameters.AddWithValue("@tipo", equipo.tipo);
                comando.Parameters.AddWithValue("@marca", equipo.marca);
                comando.Parameters.AddWithValue("@fecha_adquisicion", equipo.fecha_adquisicion);

                agregado = comando.ExecuteNonQuery() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return agregado;
        }

        public bool Editar(Equipo equipo)
        {
            bool editado = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "ActualizarEquipo";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_equipo", equipo.id_equipo);
                comando.Parameters.AddWithValue("@codigo", equipo.codigo);
                comando.Parameters.AddWithValue("@tipo", equipo.tipo);
                comando.Parameters.AddWithValue("@marca", equipo.marca);
                comando.Parameters.AddWithValue("@fecha_adquisicion", equipo.fecha_adquisicion);
                editado = comando.ExecuteNonQuery() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return editado;
        }

        public bool Eliminar(int equipoId)
        {
            bool eliminado = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "EliminarEquipo";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_equipo", equipoId);
                eliminado = comando.ExecuteNonQuery() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return eliminado;
        }

        public bool ExisteEquipo(Equipo equipo)
        {
            bool existe = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "ExisteEquipo";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@codigo", equipo.codigo);
                existe = (int)comando.ExecuteScalar() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return existe;
        }

        public bool ExisteOtroEquipo(Equipo equipo)
        {
            bool existe = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "ExisteOtroEquipo";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@codigo", equipo.codigo);
                comando.Parameters.AddWithValue("@id_equipo",  equipo.id_equipo);
                existe = (int)comando.ExecuteScalar() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return existe;
        }

        public bool EquipoConMantenimientoEquipo(int equipoId)
        {
            bool existe = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "EquipoConMantenimientoEquipo";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_equipo", equipoId);
                existe = (int)comando.ExecuteScalar() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return existe;
        }
        public bool EquipoConProyectodetalle(int equipoId)
        {
            bool existe = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "EquipoConProyectoDetalle";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_equipo", equipoId);
                existe = (int)comando.ExecuteScalar() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return existe;
        }
    }
}
