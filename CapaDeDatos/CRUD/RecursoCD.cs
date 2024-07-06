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
    public class RecursoCD
    {
        // Cadena de Conexión
        private ConexionCD Conexion = new ConexionCD();

        // Variables a Utilizar
        private SqlDataReader LectorDatos;
        private DataTable Tabla = new DataTable();

        // Obtener todos los registros de la tabla Recurso
        public DataTable ObtenerRecurso()
        {
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "ObtenerRecursos"; // Asumiendo que tienes un procedimiento almacenado llamado ObtenerRecursos
                comando.CommandType = CommandType.StoredProcedure;
                LectorDatos = comando.ExecuteReader();
                Tabla.Load(LectorDatos);
                Conexion.CerrarConexion();
            }

            return Tabla;
        }

        // Insertar un registro en la tabla Recurso
        public bool Insertar(Recurso recurso)
        {
            bool agregado = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "InsertarRecurso"; // Asumiendo que tienes un procedimiento almacenado llamado InsertarRecurso
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("codigo", recurso.codigo);
                comando.Parameters.AddWithValue("@tipo", recurso.tipo);
                comando.Parameters.AddWithValue("@descripcion", recurso.descripcion);
                comando.Parameters.AddWithValue("@costo", recurso.costo);
                agregado = comando.ExecuteNonQuery() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return agregado;
        }

        // Editar un registro en la tabla Recurso
        public bool Editar(Recurso recurso)
        {
            bool editado = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "ActualizarRecurso"; // Asumiendo que tienes un procedimiento almacenado llamado ActualizarRecurso
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_recurso", recurso.id_recurso);
                comando.Parameters.AddWithValue("@codigo", recurso.codigo);
                comando.Parameters.AddWithValue("@tipo", recurso.tipo);
                comando.Parameters.AddWithValue("@descripcion", recurso.descripcion);
                comando.Parameters.AddWithValue("@costo", recurso.costo);
                editado = comando.ExecuteNonQuery() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return editado;
        }

        // Eliminar un registro de la tabla Recurso
        public bool Eliminar(int recursoId)
        {
            bool eliminado = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "EliminarRecurso"; // Asumiendo que tienes un procedimiento almacenado llamado EliminarRecurso
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_recurso", recursoId);
                eliminado = comando.ExecuteNonQuery() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return eliminado;
        }

        public bool ExisteRecurso(Recurso recurso)
        {
            bool existe = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "ExisteRecurso";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@codigo", recurso.codigo);
                existe = (int)comando.ExecuteScalar() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return existe;
        }

        public bool ExisteOtroRecurso(Recurso recurso)
        {
            bool existe = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "ExisteOtroRecurso";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@codigo", recurso.codigo);
                comando.Parameters.AddWithValue("@id_recurso", recurso.id_recurso);
                existe = (int)comando.ExecuteScalar() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return existe;
        }

        public bool RecursoConProyectoDetalle(int recursoId)
        {
            bool existe = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "RecursoConProyectoDetalle";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_recurso", recursoId);
                existe = (int)comando.ExecuteScalar() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return existe;
        }
    }
}
    
