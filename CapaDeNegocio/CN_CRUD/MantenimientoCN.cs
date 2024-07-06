using CapaDeDatos.CRUD;
using Entidades;
using System;
using System.Data;

namespace CapaDeNegocio.CN_CRUD
{
    public class MantenimientoCN
    {
        // Instancia de la capa de datos para Mantenimiento
        private readonly MantenimientoCD mantenimientoCD = new MantenimientoCD();

        // Método para obtener todos los mantenimientos
        public DataTable ObtenerMantenimiento()
        {
            return mantenimientoCD.ObtenerMantenimiento();
        }

        // Método para insertar un nuevo mantenimiento
        public bool Insertar(Mantenimiento mantenimiento)
        {
            ValidarMantenimiento(mantenimiento);
            ValidarAntesDeCrear(mantenimiento);
            return mantenimientoCD.Insertar(mantenimiento);
        }

        // Método para editar un mantenimiento existente
        public bool Editar(Mantenimiento mantenimiento)
        {
            ValidarMantenimiento(mantenimiento);
            ValidarAntesDeEditar(mantenimiento);
            return mantenimientoCD.Editar(mantenimiento);
        }

        // Método para eliminar un mantenimiento por ID
        public bool Eliminar(int idMantenimiento)
        {
            ValidarAntesDeEliminar(idMantenimiento);
            return mantenimientoCD.Eliminar(idMantenimiento);
        }

        // Método de validación de los datos del mantenimiento
        public void ValidarMantenimiento(Mantenimiento mantenimiento)
        {
            if (string.IsNullOrWhiteSpace(mantenimiento.codigo))
                throw new ArgumentException("El campo Código no puede estar vacío o contener solo espacios en blanco");

            if (string.IsNullOrWhiteSpace(mantenimiento.descripcion))
                throw new ArgumentException("El campo Descripción no puede estar vacío o contener solo espacios en blanco");

            if (mantenimiento.codigo.Length > 50)
                throw new ArgumentException("El campo Código no puede contener más de 50 caracteres");

            if (mantenimiento.descripcion.Length > 200)
                throw new ArgumentException("El campo Descripción no puede contener más de 200 caracteres");

            if (mantenimiento.fecha_mantenimiento == default(DateTime))
                throw new ArgumentException("El campo Fecha de Mantenimiento no puede ser una fecha por defecto");
        }

        // Método para validar antes de crear un nuevo mantenimiento
        public void ValidarAntesDeCrear(Mantenimiento mantenimiento)
        {
            if (mantenimientoCD.ExisteMantenimiento(mantenimiento))
                throw new InvalidOperationException("Ya existe un mantenimiento con el código proporcionado");
        }

        // Método para validar antes de editar un mantenimiento
        public void ValidarAntesDeEditar(Mantenimiento mantenimiento)
        {
            if (string.IsNullOrWhiteSpace(mantenimiento.codigo))
                throw new ArgumentException("El campo Código no puede estar vacío o contener solo espacios en blanco");

            if (string.IsNullOrWhiteSpace(mantenimiento.descripcion))
                throw new ArgumentException("El campo Descripción no puede estar vacío o contener solo espacios en blanco");
        }

        // Método para validar antes de eliminar un mantenimiento
        public void ValidarAntesDeEliminar(int idMantenimiento)
        {
            if (mantenimientoCD.MantenimientoConMantenimientoEquipo(idMantenimiento))
                throw new InvalidOperationException("El mantenimiento a eliminar está relacionado con proyectos");
        }
    }
}
