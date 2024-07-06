using Entidades;
using System.Data.SqlClient;
using System.Data;
using System;

namespace CapaDeDatos.CRUD
{
    public class TareaCD
    {
        // Cadena de Conexión
        private ConexionCD Conexion = new ConexionCD();

        // Variables a Utilizar
        private SqlDataReader LectorDatos;
        private DataTable Tabla = new DataTable();

        public DataTable ObtenerTarea()
        {
            using (SqlCommand comando = new SqlCommand())
            {
                try
                {
                    comando.Connection = Conexion.AbrirConexion();
                    comando.CommandText = "ObtenerTareas";
                    comando.CommandType = CommandType.StoredProcedure;
                    LectorDatos = comando.ExecuteReader();
                    Tabla.Load(LectorDatos);
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones
                    throw new Exception("Error al obtener tareas: " + ex.Message);
                }
                finally
                {
                    if (LectorDatos != null && !LectorDatos.IsClosed)
                    {
                        LectorDatos.Close();
                    }
                    Conexion.CerrarConexion();
                }
            }

            return Tabla;
        }

        public bool Insertar(Tarea tarea)
        {
            bool agregado = false;
            using (SqlCommand comando = new SqlCommand())
            {
                try
                {
                    comando.Connection = Conexion.AbrirConexion();
                    comando.CommandText = "InsertarTarea";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@codigo", tarea.codigo);
                    comando.Parameters.AddWithValue("@descripcion", tarea.descripcion);
                    comando.Parameters.AddWithValue("@fecha_inicio", tarea.fecha_inicio);
                    comando.Parameters.AddWithValue("@fecha_fin", tarea.fecha_fin);
                    comando.Parameters.AddWithValue("@estado", tarea.estado);
                    agregado = comando.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones
                    throw new Exception("Error al insertar la tarea: " + ex.Message);
                }
                finally
                {
                    comando.Parameters.Clear();
                    Conexion.CerrarConexion();
                }
            }

            return agregado;
        }

        public bool Editar(Tarea tarea)
        {
            bool editado = false;
            using (SqlCommand comando = new SqlCommand())
            {
                try
                {
                    comando.Connection = Conexion.AbrirConexion();
                    comando.CommandText = "ActualizarTarea";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@id_tarea", tarea.id_tarea);
                    comando.Parameters.AddWithValue("@codigo", tarea.codigo);
                    comando.Parameters.AddWithValue("@descripcion", tarea.descripcion);
                    comando.Parameters.AddWithValue("@fecha_inicio", tarea.fecha_inicio);
                    comando.Parameters.AddWithValue("@fecha_fin", tarea.fecha_fin);
                    comando.Parameters.AddWithValue("@estado", tarea.estado);
                    editado = comando.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones
                    throw new Exception("Error al editar la tarea: " + ex.Message);
                }
                finally
                {
                    comando.Parameters.Clear();
                    Conexion.CerrarConexion();
                }
            }

            return editado;
        }

        public bool Eliminar(int tareaId)
        {
            bool eliminado = false;
            using (SqlCommand comando = new SqlCommand())
            {
                try
                {
                    comando.Connection = Conexion.AbrirConexion();
                    comando.CommandText = "EliminarTarea";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@id_tarea", tareaId);
                    eliminado = comando.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones
                    throw new Exception("Error al eliminar la tarea: " + ex.Message);
                }
                finally
                {
                    comando.Parameters.Clear();
                    Conexion.CerrarConexion();
                }
            }

            return eliminado;
        }

        public bool ExisteTarea(Tarea tarea)
        {
            bool existe = false;
            using (SqlCommand comando = new SqlCommand())
            {
                try
                {
                    comando.Connection = Conexion.AbrirConexion();
                    comando.CommandText = "ExisteTarea";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@codigo", tarea.codigo);
                    existe = (int)comando.ExecuteScalar() > 0;
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones
                    throw new Exception("Error al verificar la existencia de la tarea: " + ex.Message);
                }
                finally
                {
                    comando.Parameters.Clear();
                    Conexion.CerrarConexion();
                }
            }

            return existe;
        }

        public bool ExisteOtraTarea(Tarea tarea)
        {
            bool existe = false;
            using (SqlCommand comando = new SqlCommand())
            {
                try
                {
                    comando.Connection = Conexion.AbrirConexion();
                    comando.CommandText = "ExisteOtraTarea";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@codigo", tarea.codigo);
                    comando.Parameters.AddWithValue("@id_tarea", tarea.id_tarea);
                    existe = (int)comando.ExecuteScalar() > 0;
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones
                    throw new Exception("Error al verificar la existencia de otra tarea: " + ex.Message);
                }
                finally
                {
                    comando.Parameters.Clear();
                    Conexion.CerrarConexion();
                }
            }

            return existe;
        }

        public bool TareaConProyectoDetalle(int tareaId)
        {
            bool existe = false;
            using (SqlCommand comando = new SqlCommand())
            {
                try
                {
                    comando.Connection = Conexion.AbrirConexion();
                    comando.CommandText = "TareaConProyectoDetalle";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@id_tarea", tareaId);
                    existe = (int)comando.ExecuteScalar() > 0;
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones
                    throw new Exception("Error al verificar si la tarea está en un proyecto: " + ex.Message);
                }
                finally
                {
                    comando.Parameters.Clear();
                    Conexion.CerrarConexion();
                }
            }

            return existe;
        }
    }
}
