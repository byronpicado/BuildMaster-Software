using CapaDeDatos.CRUD;
using Entidades;
using System;
using System.Data;

namespace CapaDeNegocio.CN_CRUD
{
    public class HabilidadCN
    {
        // Instancia de la capa de datos para Habilidad
        private readonly HabilidadCD habilidadCD = new HabilidadCD();

        // Método para obtener todas las habilidades
        public DataTable ObtenerHabilidad()
        {
            return habilidadCD.ObtenerHabilidad();
        }

        // Método para insertar una nueva habilidad
        public bool Insertar(Habilidad habilidad)
        {
            ValidarHabilidad(habilidad);
            ValidarAntesDeCrear(habilidad);
            return habilidadCD.Insertar(habilidad);
        }

        // Método para editar una habilidad existente
        public bool Editar(Habilidad habilidad)
        {
            ValidarHabilidad(habilidad);
            ValidarAntesDeEditar(habilidad);
            return habilidadCD.Editar(habilidad);
        }

        // Método para eliminar una habilidad por ID
        public bool Eliminar(int idHabilidad)
        {
            ValidarAntesDeEliminar(idHabilidad);
            return habilidadCD.Eliminar(idHabilidad);
        }

        // Método de validación de los datos de la habilidad
        public void ValidarHabilidad(Habilidad habilidad)
        {
            if (string.IsNullOrWhiteSpace(habilidad.codigo))
                throw new ArgumentException("El campo Código no puede estar vacío o contener solo espacios en blanco");

            if (string.IsNullOrWhiteSpace(habilidad.descripcion))
                throw new ArgumentException("El campo Descripción no puede estar vacío o contener solo espacios en blanco");

            if (habilidad.codigo.Length > 50)
                throw new ArgumentException("El campo Código no puede contener más de 50 caracteres");

            if (habilidad.descripcion.Length > 200)
                throw new ArgumentException("El campo Descripción no puede contener más de 200 caracteres");
        }

        // Método para validar antes de crear una nueva habilidad
        public void ValidarAntesDeCrear(Habilidad habilidad)
        {
            if (habilidadCD.ExisteHabilidad(habilidad))
                throw new InvalidOperationException("Ya existe una habilidad con el código proporcionado");
        }

        // Método para validar antes de editar una habilidad
        public void ValidarAntesDeEditar(Habilidad habilidad)
        {
            if (string.IsNullOrWhiteSpace(habilidad.codigo))
                throw new ArgumentException("El campo Código no puede estar vacío o contener solo espacios en blanco");

            if (string.IsNullOrWhiteSpace(habilidad.descripcion))
                throw new ArgumentException("El campo Descripción no puede estar vacío o contener solo espacios en blanco");
        }

        // Método para validar antes de eliminar una habilidad
        public void ValidarAntesDeEliminar(int idHabilidad)
        {
            if (habilidadCD.HabilidadConHabilidad_Personal(idHabilidad))
                throw new InvalidOperationException("La habilidad a eliminar está relacionada con proyectos");
        }
    }
}
