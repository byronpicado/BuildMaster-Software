using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDeDatos.CRUD
{
    public class ProyectoDetalleCD
    {
        private ConexionCD Conexion = new ConexionCD();

        public DataTable ObtenerProyectoDetalle()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlConnection connection = Conexion.AbrirConexion())
                {
                    string query = "SELECT * FROM ProyectoDetalle";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            tabla.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                Console.WriteLine("Error al obtener los datos: " + ex.Message);
            }
            return tabla;
        }

        public bool Insertar(ProyectoDetalle proyectoDetalle)
        {
            try
            {
                using (SqlConnection connection = Conexion.AbrirConexion())
                {
                    string query = "INSERT INTO ProyectoDetalle (id_proyectoDetalle, descripcion, fecha_registro) " +
                                   "VALUES (@id_proyectoDetalle, @descripcion, @fecha_registro)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id_proyectoDetalle", proyectoDetalle.id_proyectoDetalle);
                        command.Parameters.AddWithValue("@descripcion", proyectoDetalle.descripcion);
                        command.Parameters.AddWithValue("@fecha_registro", proyectoDetalle.fecha_registro);
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                Console.WriteLine("Error al insertar el proyectoDetalle: " + ex.Message);
                return false;
            }
        }

        public bool Editar(ProyectoDetalle proyectoDetalle)
        {
            try
            {
                using (SqlConnection connection = Conexion.AbrirConexion())
                {
                    string query = "UPDATE ProyectoDetalle SET descripcion = @descripcion, fecha_registro = @fecha_registro " +
                                   "WHERE id_proyectoDetalle = @id_proyectoDetalle";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id_proyectoDetalle", proyectoDetalle.id_proyectoDetalle);
                        command.Parameters.AddWithValue("@descripcion", proyectoDetalle.descripcion);
                        command.Parameters.AddWithValue("@fecha_registro", proyectoDetalle.fecha_registro);
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                Console.WriteLine("Error al editar el proyectoDetalle: " + ex.Message);
                return false;
            }
        }

        public bool Eliminar(int proyectoDetalleId)
        {
            try
            {
                using (SqlConnection connection = Conexion.AbrirConexion())
                {
                    string query = "DELETE FROM ProyectoDetalle WHERE id_proyectoDetalle = @id_proyectoDetalle";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id_proyectoDetalle", proyectoDetalleId);
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                Console.WriteLine("Error al eliminar el proyectoDetalle: " + ex.Message);
                return false;
            }
        }
    }
}
