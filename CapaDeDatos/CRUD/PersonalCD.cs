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
    public class PersonalCD
    {       //Cadena de Conexion
        // Cadena de Conexion
        private ConexionCD Conexion = new ConexionCD();

        // Variables a Utilizar
        private SqlDataReader LectorDatos;
        private DataTable Tabla = new DataTable();

        public DataTable ObtenerPersonal()
        {
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "ObtenerPersonal";
                comando.CommandType = CommandType.StoredProcedure;
                LectorDatos = comando.ExecuteReader();
                Tabla.Load(LectorDatos);
                Conexion.CerrarConexion();
            }

            return Tabla;
        }

        public bool Insertar(Personal personal)
        {
            bool agregado = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "InsertarPersonal";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@codigo", personal.codigo);
                comando.Parameters.AddWithValue("@nombre1", personal.nombre1);
                comando.Parameters.AddWithValue("@nombre2", personal.nombre2);
                comando.Parameters.AddWithValue("@apellidoPaterno", personal.apellidoPaterno);
                comando.Parameters.AddWithValue("@apellidoMaterno", personal.apellidoMaterno);
                comando.Parameters.AddWithValue("@cargo", personal.cargo);
                comando.Parameters.AddWithValue("@fecha_contratacion", personal.fecha_contratacion);

                agregado = comando.ExecuteNonQuery() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return agregado;
        }

        public bool Editar(Personal personal)
        {
            bool editado = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "ActualizarPersonal";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("id_personal", personal.id_personal);
                comando.Parameters.AddWithValue("@codigo", personal.codigo);
                comando.Parameters.AddWithValue("@nombre1", personal.nombre1);
                comando.Parameters.AddWithValue("@nombre2", personal.nombre2);
                comando.Parameters.AddWithValue("@apellidoPaterno", personal.apellidoPaterno);
                comando.Parameters.AddWithValue("@apellidoMaterno", personal.apellidoMaterno);
                comando.Parameters.AddWithValue("@cargo", personal.cargo);
                comando.Parameters.AddWithValue("@fecha_contratacion", personal.fecha_contratacion);

                editado = comando.ExecuteNonQuery() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return editado;
        }

        public bool Eliminar(int personalId)
        {
            bool eliminado = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "EliminarPersonal";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_personal", personalId);
                eliminado = comando.ExecuteNonQuery() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return eliminado;
        }

        public bool ExistePersonal(Personal personal)
        {
            bool existe = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "ExistePersonal";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@codigo", personal.codigo);
                existe = (int)comando.ExecuteScalar() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return existe;
        }

        public bool ExisteOtroPersonal(Personal personal)
        {
            bool existe = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion(); 
                comando.CommandText = "ExisteOtroPersonal";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@codigo", personal.codigo);
                comando.Parameters.AddWithValue("@id_personal", personal.id_personal);
                existe = (int)comando.ExecuteScalar() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return existe;
        }

        public bool PersonalConPersonal_Proyecto(int personalId)
        {
            bool existe = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "PersonalConPersonal_Proyecto";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_personal", personalId);
                existe = (int)comando.ExecuteScalar() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return existe;
        }
    }
}
