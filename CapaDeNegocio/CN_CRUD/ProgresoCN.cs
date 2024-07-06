using CapaDeDatos.CRUD;
using Entidades;
using System;
using System.Data;

namespace CapaDeNegocio.CN_CRUD
{
    public class ProgresoCN
    {
        // Instancia de la capa de datos para Progreso
        private readonly ProgresoCD progresoCD = new ProgresoCD();

        // Método para obtener todos los registros de progreso
        public DataTable ObtenerProgreso()
        {
            return progresoCD.ObtenerProgreso();
        }

        // Método para insertar un nuevo registro de progreso
        public bool Insertar(Progreso progreso)
        {
            ValidarProgreso(progreso);
            return progresoCD.Insertar(progreso);
        }

        // Método para editar un registro de progreso existente
        public bool Editar(Progreso progreso)
        {
            ValidarProgreso(progreso);
            return progresoCD.Editar(progreso);
        }

        // Método para eliminar un registro de progreso por ID
        public bool Eliminar(int progresoId)
        {
            return progresoCD.Eliminar(progresoId);
        }

        // Método de validación de los datos de progreso
        private void ValidarProgreso(Progreso progreso)
        {
            if (string.IsNullOrWhiteSpace(progreso.codigo))
                throw new ArgumentException("El campo Código no puede estar vacío o contener solo espacios en blanco");

            if (string.IsNullOrWhiteSpace(progreso.descripcion))
                throw new ArgumentException("El campo Descripción no puede estar vacío o contener solo espacios en blanco");

            if (progreso.codigo.Length > 50)
                throw new ArgumentException("El campo Código no puede contener más de 50 caracteres");

            if (progreso.descripcion.Length > 200)
                throw new ArgumentException("El campo Descripción no puede contener más de 200 caracteres");

            if (progreso.fecha_registro == default(DateTime))
                throw new ArgumentException("El campo Fecha de Registro no puede ser una fecha por defecto");
        }
        // Método para validar antes de crear un nuevo registro de personal
        private void ValidarAntesDeCrear(Progreso progreso)
        {
            if (progresoCD.ExisteProgreso(progreso))
                throw new InvalidOperationException("Ya existe un registro con el mismo Código.");
        }

        // Método para validar antes de editar un registro de personal
        private void ValidarAntesDeEditar(Progreso progreso)
        {
            if (string.IsNullOrWhiteSpace(progreso.codigo))
                throw new ArgumentException("El campo Código no puede estar vacío o contener solo espacios en blanco");

            if (string.IsNullOrWhiteSpace(progreso.descripcion))
                throw new ArgumentException("El campo Descripción no puede estar vacío o contener solo espacios en blanco");
        }

        // Método para validar antes de eliminar un registro de personal
        private void ValidarAntesDeEliminar(int progresoId)
        {
            if (progresoCD.ProgresoConProyectoDetalle(progresoId))
                throw new InvalidOperationException("El personal a eliminar está relacionado con detalles del proyecto.");
        }
    }
}
