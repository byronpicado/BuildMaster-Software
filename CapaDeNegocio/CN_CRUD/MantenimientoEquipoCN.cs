using CapaDeDatos.CRUD;
using Entidades;
using System;
using System.Collections.Generic;

namespace CapaDeNegocio.CN_CRUD
{
    public class MantenimientoEquipoCN
    {
        private MantenimientoEquipoCD mantenimientoEquipoCD = new MantenimientoEquipoCD();

        // Obtener todos los registros de MantenimientoEquipo
        public List<MantenimientoEquipo> ObtenerMantenimientoEquipo()
        {
            // Llama al método de la capa de datos y retorna la lista de MantenimientoEquipo
            return mantenimientoEquipoCD.ObtenerMantenimientoEquipos();
        }

        // Insertar un nuevo registro de MantenimientoEquipo
        public bool Insertar(MantenimientoEquipo mantenimientoEquipo)
        {
            // Llama al método de inserción de la capa de datos
            return mantenimientoEquipoCD.InsertarMantenimientoEquipo(mantenimientoEquipo);
        }

        // Editar un registro existente de MantenimientoEquipo
        public bool Editar(MantenimientoEquipo mantenimientoEquipo)
        {
            // Llama al método de edición de la capa de datos
            return mantenimientoEquipoCD.EditarMantenimientoEquipo(mantenimientoEquipo);
        }

        // Eliminar un registro de MantenimientoEquipo por ID
        public bool Eliminar(int mantenimientoequipoId)
        {
            // Llama al método de eliminación de la capa de datos
            return mantenimientoEquipoCD.EliminarMantenimientoEquipo(mantenimientoequipoId);
        }
    }
}
