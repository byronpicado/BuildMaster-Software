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
    public class Personal_ProyectoCD
    {
        //Cadena de Conexion
        private ConexionCD Conexion = new ConexionCD();

        //Variables 
        SqlDataReader LectorDatos;
        DataTable Tabla = new DataTable();
        SqlCommand Comando = new SqlCommand();

        //obtenemos todos lo registro de la tabla personalProyecto
        public DataTable ObtenerPersonalProyecto()
        {
            try
            {
                Comando.Connection = Conexion.AbrirConexion();
                Comando.CommandText = "SELECT * FROM Personal_Proyecto";
                Comando.CommandType = CommandType.Text;
                LectorDatos = Comando.ExecuteReader();
                Tabla.Load(LectorDatos);
                LectorDatos.Close();
                Conexion.CerrarConexion();
               
            }
            catch (Exception ex)
            {
                string excepxion = ex.Message;
            }
            return Tabla;
        }

        public bool Insertar(Personal_Proyecto personal_Proyecto)
        {
            bool agregado = false;
            try

            {
                Comando.Connection = Conexion.AbrirConexion();
                Comando.CommandText = "Insert INTO PersonalProyecto (id_Personal_proyecto,id_proyecto,id_cliente,id_responsable,id_personal) VALUES (@id_Personal_proyecto,@id_proyecto,@id_cliente,@id_responsable,@id_personal)";
                Comando.CommandType = CommandType.Text;

                Comando.Parameters.AddWithValue("@id_Personal_proyecto", personal_Proyecto.id_Personal_proyecto);
                Comando.Parameters.AddWithValue("@id_proyecto", personal_Proyecto.id_proyecto );
                Comando.Parameters.AddWithValue("@id_cliente", personal_Proyecto.id_cliente);
                Comando.Parameters.AddWithValue("@id_responsable", personal_Proyecto.id_responsable);
                Comando.Parameters.AddWithValue("@id_personal", personal_Proyecto.id_personal);


             agregado=Comando.ExecuteNonQuery()>0;
                Comando.Parameters.Clear();
                Conexion.CerrarConexion();
                return agregado;
            }
            catch (Exception ex)
            {
                String msj = ex.ToString();
                return false;
            }

        }
        //para editar un registro en la tabla Personal_Proyecto
        public bool Editar(Personal_Proyecto personal_Proyecto)
        {
            bool editado = false;
            try
            {
                Comando.Connection = Conexion.AbrirConexion();
                Comando.CommandText = "UPDATE personal_Proyecto SET id_proyecto=@idproyecto,id_cliente=@id_cliente,id_responsable=@id_responsable,id_personal=@id_personal WHERE id_Personal_proyecto = @id_Personal_proyecto";
                Comando.CommandType = CommandType.Text;
                Comando.Parameters.AddWithValue("@id_Personal_proyecto", personal_Proyecto.id_Personal_proyecto);
                Comando.Parameters.AddWithValue("@id_proyecto", personal_Proyecto.id_proyecto);
                Comando.Parameters.AddWithValue("@id_cliente", personal_Proyecto.id_cliente);
                Comando.Parameters.AddWithValue("@id_responsable", personal_Proyecto.id_responsable);
                Comando.Parameters.AddWithValue("@id_personal", personal_Proyecto.id_personal);

                editado = Comando.ExecuteNonQuery() > 0;
                Comando.Parameters.Clear();
                Conexion.CerrarConexion();
                return editado;
            }
            catch (Exception ex)
            {
                String msj = ex.ToString();
                return false;
            }
        }
        public bool Eliminar(int personal_proyectoId)
        {
            bool eliminado = false;
            try
            {
                Comando.Connection = Conexion.AbrirConexion();
                Comando.CommandText = "DELETE FROM Categorias WHERE id_Personal_proyectod = @id_Personal_proyectod";
                Comando.Parameters.AddWithValue("@id_Personal_proyecto", personal_proyectoId);
                eliminado = Comando.ExecuteNonQuery() > 0;
                Comando.Parameters.Clear();
                Conexion.CerrarConexion();
                return eliminado;
            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
                return false;
            }

        }


    }

}