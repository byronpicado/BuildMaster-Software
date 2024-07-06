using Entidades;using System;using System.Data;using System.Data.SqlClient;namespace CapaDeDatos.CRUD{    public class ProyectoCD    {
        // Cadena de Conexion
        private ConexionCD Conexion = new ConexionCD();

        // Variables a Utilizar
        private SqlDataReader LectorDatos;        private DataTable Tabla = new DataTable();

        // Método para obtener la vista VistaProyectosDetalle
        public DataTable ObtenerProyectosDetalle()
        {
            using (SqlCommand comando = new SqlCommand())
            {
                DataTable dt = new DataTable();
                string query = "SELECT * FROM VistaProyectosDetalle";

                try
                {
                    // Abre la conexión
                    using (SqlConnection con = Conexion.AbrirConexion())
                    {
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                da.Fill(dt); // Ejecuta la consulta y llena el DataTable
                            }
                        }
                    } // Cierra automáticamente la conexión al salir del bloque using
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener los detalles de los proyectos: " + ex.Message);
                }

                return dt; // Devuelve el DataTable con los datos obtenidos
            }
        }
        public DataTable ObtenerProyectos()        {            using (SqlCommand comando = new SqlCommand())            {                comando.Connection = Conexion.AbrirConexion();                comando.CommandText = "ObtenerProyectos";                comando.CommandType = CommandType.StoredProcedure;                LectorDatos = comando.ExecuteReader();                Tabla.Load(LectorDatos);                Conexion.CerrarConexion();            }            return Tabla;        }        public bool Insertar(Proyecto proyecto)        {            bool agregado = false;            using (SqlCommand comando = new SqlCommand())            {                comando.Connection = Conexion.AbrirConexion();                comando.CommandText = "InsertarProyecto";                comando.CommandType = CommandType.StoredProcedure;                comando.Parameters.AddWithValue("@codigo", proyecto.codigo);                comando.Parameters.AddWithValue("@id_cliente", proyecto.id_cliente);                comando.Parameters.AddWithValue("@id_responsable", proyecto.id_responsable);                comando.Parameters.AddWithValue("@id_progreso", proyecto.id_progreso);                comando.Parameters.AddWithValue("@descripcion", proyecto.descripcion);                comando.Parameters.AddWithValue("@fecha_inicio", proyecto.fecha_inicio);                comando.Parameters.AddWithValue("@fecha_fin", proyecto.fecha_fin);                comando.Parameters.AddWithValue("@estado", proyecto.Estado);                agregado = comando.ExecuteNonQuery() > 0;                comando.Parameters.Clear();                Conexion.CerrarConexion();            }            return agregado;        }        public bool Editar(Proyecto proyecto)        {            bool editado = false;            using (SqlCommand comando = new SqlCommand())            {                comando.Connection = Conexion.AbrirConexion();                comando.CommandText = "ActualizarProyecto";                comando.CommandType = CommandType.StoredProcedure;                comando.Parameters.AddWithValue("@id_proyecto", proyecto.id_proyecto);                comando.Parameters.AddWithValue("@codigo", proyecto.codigo);                comando.Parameters.AddWithValue("@id_cliente", proyecto.id_cliente);                comando.Parameters.AddWithValue("@id_responsable", proyecto.id_responsable);                comando.Parameters.AddWithValue("@id_progreso", proyecto.id_progreso);                comando.Parameters.AddWithValue("@descripcion", proyecto.descripcion);                comando.Parameters.AddWithValue("@fecha_inicio", proyecto.fecha_inicio);                comando.Parameters.AddWithValue("@fecha_fin", proyecto.fecha_fin);                comando.Parameters.AddWithValue("@estado", proyecto.Estado);                editado = comando.ExecuteNonQuery() > 0;                comando.Parameters.Clear();                Conexion.CerrarConexion();            }            return editado;        }        public bool Eliminar(int proyectoId)        {            bool eliminado = false;            using (SqlCommand comando = new SqlCommand())            {                comando.Connection = Conexion.AbrirConexion();                comando.CommandText = "EliminarProyecto";                comando.CommandType = CommandType.StoredProcedure;                comando.Parameters.AddWithValue("@id_proyecto", proyectoId);                eliminado = comando.ExecuteNonQuery() > 0;                comando.Parameters.Clear();                Conexion.CerrarConexion();            }            return eliminado;        }        public bool ExisteProyecto(Proyecto proyecto)        {            bool existe = false;            using (SqlCommand comando = new SqlCommand())            {                comando.Connection = Conexion.AbrirConexion();                comando.CommandText = "ExisteProyecto";                comando.CommandType = CommandType.StoredProcedure;                comando.Parameters.AddWithValue("@codigo", proyecto.codigo);                existe = (int)comando.ExecuteScalar() > 0;                comando.Parameters.Clear();                Conexion.CerrarConexion();            }            return existe;        }        public bool ExisteOtroProyecto(Proyecto proyecto)        {            bool existe = false;            using (SqlCommand comando = new SqlCommand())            {                comando.Connection = Conexion.AbrirConexion();                comando.CommandText = "ExisteOtroProyecto";                comando.CommandType = CommandType.StoredProcedure;                comando.Parameters.AddWithValue("@codigo", proyecto.codigo);                comando.Parameters.AddWithValue("@id_proyecto", proyecto.id_proyecto);                existe = (int)comando.ExecuteScalar() > 0;                comando.Parameters.Clear();                Conexion.CerrarConexion();            }            return existe;        }    }}