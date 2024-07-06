using CapaDeDatos.CRUD;
using Entidades;
using System;
using System.Data;

namespace CapaDeNegocio.CN_CRUD
{
    public class PersonalCN
    {
        // Instancia de la capa de datos para Personal
        private readonly PersonalCD personalCD = new PersonalCD();

        // Método para obtener todos los registros de personal
        public DataTable ObtenerPersonal()
        {
            return personalCD.ObtenerPersonal();
        }

        // Método para insertar un nuevo registro de personal
        public bool Insertar(Personal personal)
        {
            ValidarPersonal(personal);
            ValidarAntesDeCrear(personal);
            return personalCD.Insertar(personal);
        }

        // Método para editar un registro de personal existente
        public bool Editar(Personal personal)
        {
            ValidarPersonal(personal);
            ValidarAntesDeEditar(personal);
            return personalCD.Editar(personal);
        }

        // Método para eliminar un registro de personal por ID
        public bool Eliminar(int personalId)
        {
            ValidarAntesDeEliminar(personalId);
            return personalCD.Eliminar(personalId);
        }

        // Método de validación de los datos de personal
        public void ValidarPersonal(Personal personal)
        {
            if (string.IsNullOrWhiteSpace(personal.codigo))
                throw new ArgumentException("El campo Código no puede estar vacío o contener solo espacios en blanco");

            if (string.IsNullOrWhiteSpace(personal.nombre1))
                throw new ArgumentException("El campo Primer Nombre no puede estar vacío o contener solo espacios en blanco");

            if (personal.codigo.Length > 50)
                throw new ArgumentException("El campo Código no puede contener más de 50 caracteres");

            if (personal.nombre1.Length > 50)
                throw new ArgumentException("El campo Primer Nombre no puede contener más de 50 caracteres");

            if (!string.IsNullOrEmpty(personal.nombre2) && personal.nombre2.Length > 50)
                throw new ArgumentException("El campo Segundo Nombre no puede contener más de 50 caracteres");

            if (string.IsNullOrWhiteSpace(personal.apellidoPaterno))
                throw new ArgumentException("El campo Apellido Paterno no puede estar vacío o contener solo espacios en blanco");

            if (personal.apellidoPaterno.Length > 50)
                throw new ArgumentException("El campo Apellido Paterno no puede contener más de 50 caracteres");

            if (!string.IsNullOrEmpty(personal.apellidoMaterno) && personal.apellidoMaterno.Length > 50)
                throw new ArgumentException("El campo Apellido Materno no puede contener más de 50 caracteres");

            if (string.IsNullOrWhiteSpace(personal.cargo))
                throw new ArgumentException("El campo Cargo no puede estar vacío o contener solo espacios en blanco");

            if (personal.cargo.Length > 100)
                throw new ArgumentException("El campo Cargo no puede contener más de 100 caracteres");

            if (personal.fecha_contratacion == default(DateTime))
                throw new ArgumentException("El campo Fecha de Contratación no puede ser una fecha por defecto");
        }

        // Método para validar antes de crear un nuevo registro de personal
       public void ValidarAntesDeCrear(Personal personal)
        {
            if (personalCD.ExisteOtroPersonal(personal))
                throw new InvalidOperationException("Ya existe un registro con el mismo Código.");
        }

        // Método para validar antes de editar un registro de personal
        public void ValidarAntesDeEditar(Personal personal)
        {
            if (string.IsNullOrWhiteSpace(personal.codigo))
                throw new ArgumentException("El campo Código no puede estar vacío o contener solo espacios en blanco");

            if (string.IsNullOrWhiteSpace(personal.nombre1))
                throw new ArgumentException("El campo Primer Nombre no puede estar vacío o contener solo espacios en blanco");

            if (personal.codigo.Length > 50)
                throw new ArgumentException("El campo Código no puede contener más de 50 caracteres");

            if (personal.nombre1.Length > 50)
                throw new ArgumentException("El campo Primer Nombre no puede contener más de 50 caracteres");

            if (!string.IsNullOrEmpty(personal.nombre2) && personal.nombre2.Length > 50)
                throw new ArgumentException("El campo Segundo Nombre no puede contener más de 50 caracteres");

            if (string.IsNullOrWhiteSpace(personal.apellidoPaterno))
                throw new ArgumentException("El campo Apellido Paterno no puede estar vacío o contener solo espacios en blanco");

            if (personal.apellidoPaterno.Length > 50)
                throw new ArgumentException("El campo Apellido Paterno no puede contener más de 50 caracteres");

            if (!string.IsNullOrEmpty(personal.apellidoMaterno) && personal.apellidoMaterno.Length > 50)
                throw new ArgumentException("El campo Apellido Materno no puede contener más de 50 caracteres");

            if (string.IsNullOrWhiteSpace(personal.cargo))
                throw new ArgumentException("El campo Cargo no puede estar vacío o contener solo espacios en blanco");

            if (personal.cargo.Length > 100)
                throw new ArgumentException("El campo Cargo no puede contener más de 100 caracteres");
        }

        // Método para validar antes de eliminar un registro de personal
        public  void ValidarAntesDeEliminar(int personalId)
        {
            if (personalCD.PersonalConPersonal_Proyecto(personalId))
                throw new InvalidOperationException("El personal a eliminar está relacionado con proyectos.");
        }
    }
}
