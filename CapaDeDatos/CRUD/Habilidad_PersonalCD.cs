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
    public class Habilidad_PersonalCD
    {
        //Cadena de Conexion
        private ConexionCD Conexion = new ConexionCD();

        //Variables 
        SqlDataReader LectorDatos;
        DataTable Tabla = new DataTable();
        SqlCommand Comando = new SqlCommand();

        //obtenemos todos lo registro de la tabla habilidad_personal
        public DataTable ObtenerHabilidad_Personal()
        {
            try
            {
                Comando.Connection = Conexion.AbrirConexion();
                Comando.CommandText = "SELECT * FROM Habilidad_Personal";
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

        public bool Insertar(Habilidad_Personal habilidad_personal)
        {
            bool agregado = false;
            try

            {
                Comando.Connection = Conexion.AbrirConexion();
                Comando.CommandText = "Insert INTO Habilidad_Personal(id_habilidad_personal,id_personal,id_habilidad) VALUES (@id_habilidad_personal,@id_personal,@id_habilidad)";
                Comando.CommandType = CommandType.Text;

                Comando.Parameters.AddWithValue("@id_habilidad_personal", habilidad_personal.id_habilidad_personal);
                Comando.Parameters.AddWithValue("@id_personal", habilidad_personal.id_personal);
                Comando.Parameters.AddWithValue("@id_habilidad", habilidad_personal.Id_habilidad);


              agregado=  Comando.ExecuteNonQuery()>0;
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
        //para editar un registro en la tabla Habilidad_Personal
        public bool Editar(Habilidad_Personal habilidad_personal)
        {
            bool editado = false;
            try
            {
                Comando.Connection = Conexion.AbrirConexion();
                Comando.CommandText = "UPDATE habilidad_personal SET id_personal=@id_personal,id_habilidad=@id_habilidad WHERE id_habilidad_personal = @id_habilidad_personal";
                Comando.CommandType = CommandType.Text;
                Comando.Parameters.AddWithValue("@id_habilidad_personal", habilidad_personal.id_habilidad_personal);
                Comando.Parameters.AddWithValue("@id_personal", habilidad_personal.id_personal);
                Comando.Parameters.AddWithValue("@id_habilidad", habilidad_personal.Id_habilidad);
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
        public bool Eliminar(int habilidad_personalId)
        {
            bool eliminado = false;
            try
            {
                Comando.Connection = Conexion.AbrirConexion();
                Comando.CommandText = "DELETE FROM Habilidad_Personal WHERE id_habilidad_personal = @id_habilidad_personal";
                Comando.Parameters.AddWithValue("@id_habilidad_personal", habilidad_personalId);
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
