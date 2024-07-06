using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace CapaDeDatos.CRUD
{
    public class MantenimientoEquipoCD
    {
        // Cadena de Conexion
        private ConexionCD Conexion = new ConexionCD();

        // Variables a Utilizar
        SqlDataReader LectorDatos;
        SqlCommand Comando = new SqlCommand();

        // Obtener todos los registros de la tabla MantenimientoEquipo
        public List<MantenimientoEquipo> ObtenerMantenimientoEquipos()
        {
            List<MantenimientoEquipo> listaMantenimientos = new List<MantenimientoEquipo>();

            try
            {
                Comando.Connection = Conexion.AbrirConexion();
                Comando.CommandText = "ObtenerEquipos"; // Nombre del procedimiento almacenado
                Comando.CommandType = CommandType.StoredProcedure;
                LectorDatos = Comando.ExecuteReader();

                while (LectorDatos.Read())
                {
                    MantenimientoEquipo mantenimiento = new MantenimientoEquipo
                    {
                        id_mantenimiento_Equipo = (int)LectorDatos["id_mantenimiento_Equipo"],
                        id_mantenimiento = (int)LectorDatos["id_mantenimiento"],
                        id_equipo = (int)LectorDatos["id_equipo"]
                    };
                    listaMantenimientos.Add(mantenimiento);
                }

                LectorDatos.Close();
                Conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                // Manejo de la excepción (puedes registrar el mensaje o lanzar una excepción personalizada)
                string msj = ex.ToString();
            }

            return listaMantenimientos;
        }

        // Insertar un nuevo registro en la tabla MantenimientoEquipo
        public bool InsertarMantenimientoEquipo(MantenimientoEquipo mantenimientoEquipo)
        {
            bool agregado = false;
            try
            {
                Comando.Connection = Conexion.AbrirConexion();
                Comando.CommandText = "InsertarMantenimientoEquipo"; // Nombre del procedimiento almacenado
                Comando.CommandType = CommandType.StoredProcedure;

                // Agregar los parámetros al comando
                Comando.Parameters.AddWithValue("@id_mantenimiento_Equipo", mantenimientoEquipo.id_mantenimiento_Equipo);
                Comando.Parameters.AddWithValue("@id_mantenimiento", mantenimientoEquipo.id_mantenimiento);
                Comando.Parameters.AddWithValue("@id_equipo", mantenimientoEquipo.id_equipo);

                // Ejecutar la consulta y verificar si se insertó algún registro
                agregado = Comando.ExecuteNonQuery() > 0;
                Comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                // Manejo de la excepción
                string msj = ex.ToString();
            }
            return agregado;
        }

        // Editar un registro existente en la tabla MantenimientoEquipo
        public bool EditarMantenimientoEquipo(MantenimientoEquipo mantenimientoEquipo)
        {
            bool editado = false;
            try
            {
                Comando.Connection = Conexion.AbrirConexion();
                Comando.CommandText = "ActualizarMantenimientoEquipo"; // Nombre del procedimiento almacenado
                Comando.CommandType = CommandType.StoredProcedure;

                // Agregar los parámetros al comando
                Comando.Parameters.AddWithValue("@id_mantenimiento_Equipo", mantenimientoEquipo.id_mantenimiento_Equipo);
                Comando.Parameters.AddWithValue("@id_mantenimiento", mantenimientoEquipo.id_mantenimiento);
                Comando.Parameters.AddWithValue("@id_equipo", mantenimientoEquipo.id_equipo);

                // Ejecutar la consulta y verificar si se actualizó algún registro
                editado = Comando.ExecuteNonQuery() > 0;
                Comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                // Manejo de la excepción
                string msj = ex.ToString();
            }
            return editado;
        }

        // Eliminar un registro en la tabla MantenimientoEquipo
        public bool EliminarMantenimientoEquipo(int id_mantenimiento_Equipo)
        {
            bool eliminado = false;
            try
            {
                Comando.Connection = Conexion.AbrirConexion();
                Comando.CommandText = "EliminarMantenimientoEquipo"; // Nombre del procedimiento almacenado
                Comando.CommandType = CommandType.StoredProcedure;

                // Agregar los parámetros al comando
                Comando.Parameters.AddWithValue("@id_mantenimiento_Equipo", id_mantenimiento_Equipo);

                // Ejecutar la consulta y verificar si se eliminó algún registro
                eliminado = Comando.ExecuteNonQuery() > 0;
                Comando.Parameters.Clear();
                Conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                // Manejo de la excepción
                string msj = ex.ToString();
            }
            return eliminado;
        }
    }
}
