using CapaDeDatos.CRUD;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocio.CN_CRUD
{
    public class PersonalProyectoCN
    {
        private Personal_ProyectoCD personal_ProyectoCD = new Personal_ProyectoCD();
        public DataTable ObtenerPersonal_proyecto()
        {
            DataTable tabla = new DataTable();
            tabla = personal_ProyectoCD.ObtenerPersonalProyecto();
            return tabla;
        }
        //pasar a capa de datos
        public bool Insertar(Personal_Proyecto personal_Proyecto)
        {
            return personal_ProyectoCD.Insertar(personal_Proyecto);
        }
        public bool Editar(Personal_Proyecto personal_Proyecto)
        {
            return personal_ProyectoCD.Editar(personal_Proyecto);
        }

        public bool Eliminar(int personal_ProyectoId)
        {
            return personal_ProyectoCD.Eliminar(personal_ProyectoId);
            return false;
        }
    }
}
