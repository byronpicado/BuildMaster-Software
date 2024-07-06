﻿using Entidades;
        // Cadena de Conexion
        private ConexionCD Conexion = new ConexionCD();

        // Variables a Utilizar
        private SqlDataReader LectorDatos;

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
