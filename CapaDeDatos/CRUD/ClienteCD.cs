 using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace CapaDeDatos.CRUD
{
    public class ClienteCD
    {
        // Cadena de Conexion
        private ConexionCD Conexion = new ConexionCD();

        // Variables a Utilizar
        private SqlDataReader LectorDatos;
        private DataTable Tabla = new DataTable();

        public DataTable ObtenerClientes()
        {
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "ObtenerClientes";
                comando.CommandType = CommandType.StoredProcedure;
                LectorDatos = comando.ExecuteReader();
                Tabla.Load(LectorDatos);
                Conexion.CerrarConexion();
            }

            return Tabla;
        }
        public List<Cliente> ObtenerCliente()
        {

            List<Cliente> clientes = new List<Cliente>();

            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "ObtenerClientes";
                comando.CommandType = CommandType.StoredProcedure;

                LectorDatos = comando.ExecuteReader();

                while (LectorDatos.Read())
                {
                    clientes.Add(new Cliente
                    {
                        id_cliente = (int)LectorDatos["id_cliente"],
                        nombre1 = (string)LectorDatos["nombre1"],
                        nombre2 = (string)LectorDatos["nombre2"],
                        apellidoPaterno = (string)LectorDatos["apellidoPaterno"],
                        apellidoMaterno = (string)LectorDatos["apellidoMaterno"],
                        telefono = (string)LectorDatos["telefono"],
                        correo = (string)LectorDatos["correo"]

                    });
                }

                return clientes;
            }
        }

        public bool Insertar(Cliente cliente)
        {
            bool agregado = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "InsertarCliente";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@codigo", cliente.codigo);
                comando.Parameters.AddWithValue("@nombre1", cliente.nombre1);
                comando.Parameters.AddWithValue("@nombre2", cliente.nombre2);
                comando.Parameters.AddWithValue("@apellidoPaterno", cliente.apellidoPaterno);
                comando.Parameters.AddWithValue("@apellidoMaterno", cliente.apellidoMaterno);
                comando.Parameters.AddWithValue("@telefono", cliente.telefono);
                comando.Parameters.AddWithValue("@correo", cliente.correo);
                agregado = comando.ExecuteNonQuery() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return agregado;
        }

        public bool Editar(Cliente cliente)
        {
            bool editado = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "ActualizarCliente";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_cliente", cliente.id_cliente);
                comando.Parameters.AddWithValue("@codigo", cliente.codigo);
                comando.Parameters.AddWithValue("@nombre1", cliente.nombre1);
                comando.Parameters.AddWithValue("@nombre2", cliente.nombre2);
                comando.Parameters.AddWithValue("@apellidoPaterno", cliente.apellidoPaterno);
                comando.Parameters.AddWithValue("@apellidoMaterno", cliente.apellidoMaterno);
                comando.Parameters.AddWithValue("@telefono", cliente.telefono);
                comando.Parameters.AddWithValue("@correo", cliente.correo);
                editado = comando.ExecuteNonQuery() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return editado;
        }

        public bool Eliminar(int clienteId)
        {
            bool eliminado = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "EliminarCliente";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_cliente", clienteId);
                eliminado = comando.ExecuteNonQuery() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return eliminado;
        }

        public bool ExisteCliente(Cliente cliente)
        {
            bool existe = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "ExisteCliente";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@codigo", cliente.codigo);
                existe = (int)comando.ExecuteScalar() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return existe;
        }

        public bool ExisteOtroCliente(Cliente cliente)
        {
            bool existe = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "ExisteOtroCliente";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@codigo", cliente.codigo);
                comando.Parameters.AddWithValue("@id_cliente", cliente.id_cliente);
                existe = (int)comando.ExecuteScalar() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return existe;
        }

        public bool ClienteConProyecto(int clienteId)
        {
            bool existe = false;
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "ClienteConProyecto";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_cliente", clienteId);
                existe = (int)comando.ExecuteScalar() > 0;
                comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }

            return existe;
        }
    }
}
