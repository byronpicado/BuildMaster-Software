using CapaDeDatos.CRUD;
using Entidades;
using System;
using System.Data;

namespace CapaDeNegocio.CN_CRUD
{
    public class ResponsableCN
    {
        private ResponsableCD responsableCD = new ResponsableCD();

        public DataTable ObtenerResponsable()
        {
            return responsableCD.ObtenerResponsable();
        }

        public bool Insertar(Responsable responsable)
        {
            ValidarResponsable(responsable); // Validar los datos antes de insertar
            return responsableCD.Insertar(responsable);
        }

        public bool Editar(Responsable responsable)
        {
            ValidarResponsable(responsable); // Validar los datos antes de editar
            return responsableCD.Editar(responsable);
        }

        public bool Eliminar(int responsableId)
        {
            return responsableCD.Eliminar(responsableId);
        }

        private void ValidarResponsable(Responsable responsable)
        {
            if (string.IsNullOrWhiteSpace(responsable.codigo))
                throw new ArgumentException("El campo Código no puede estar vacío o contener solo espacios en blanco");

            if (string.IsNullOrWhiteSpace(responsable.nombre1))
                throw new ArgumentException("El campo Primer Nombre no puede estar vacío o contener solo espacios en blanco");

            if (string.IsNullOrWhiteSpace(responsable.apellidoPaterno))
                throw new ArgumentException("El campo Apellido Paterno no puede estar vacío o contener solo espacios en blanco");

            if (string.IsNullOrWhiteSpace(responsable.apellidoMaterno))
                throw new ArgumentException("El campo Apellido Materno no puede estar vacío o contener solo espacios en blanco");

            if (string.IsNullOrWhiteSpace(responsable.cargo))
                throw new ArgumentException("El campo Cargo no puede estar vacío o contener solo espacios en blanco");
        }
            // Método para validar antes de crear un nuevo registro de personal
            public void ValidarAntesDeCrear(Responsable responsable)
            {
                if (responsableCD.ExisteResponsable(responsable))
                    throw new InvalidOperationException("Ya existe un registro con el mismo Código.");
            }

            // Método para validar antes de editar un registro de personal
            public void ValidarAntesDeEditar(Responsable responsable)
            {
                if (responsableCD.ExisteOtroResponsable(responsable))
                    throw new InvalidOperationException("El código del Responsable ya está en uso por otro registro.");
            }

            // Método para validar antes de eliminar un registro de personal
            public void ValidarAntesDeEliminar(int responsableId)
            {
                if (responsableCD.ResponsableConProyecto(responsableId))
                    throw new InvalidOperationException("El Responsable a eliminar está relacionado con proyecto.");
            }
        }
    }

