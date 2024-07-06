using CapaDeDatos.CRUD;
using Entidades;
using System;
using System.Data;

namespace CapaDeNegocio.CN_CRUD
{
    public class ProyectoCN
    {
        private readonly ProyectoCD proyectoCD = new ProyectoCD();

        // Método para obtener los detalles de los proyectos
        public DataTable ObtenerProyectosDetalle()
        {
            return proyectoCD.ObtenerProyectosDetalle();
        }

        public DataTable ObtenerProyecto()
        {
            return proyectoCD.ObtenerProyectos();
        }

        public bool Insertar(Proyecto proyecto)
        {
            ValidarProyecto(proyecto);
            ValidarAntesDeCrear(proyecto);
            return proyectoCD.Insertar(proyecto);
        }

        public bool Editar(Proyecto proyecto)
        {
            ValidarProyecto(proyecto);
            ValidarAntesDeEditar(proyecto);
            return proyectoCD.Editar(proyecto);
        }

        public bool Eliminar(int proyectoId)
        {
            ValidarAntesDeEliminar(proyectoId);
            return proyectoCD.Eliminar(proyectoId);
        }

        public void ValidarProyecto(Proyecto proyecto)
        {
            if (string.IsNullOrWhiteSpace(proyecto.descripcion))
                throw new ArgumentException("El campo Descripción no puede estar vacío o contener solo espacios en blanco");
            if (proyecto.fecha_inicio >= proyecto.fecha_fin)
                throw new ArgumentException("La fecha de inicio no puede ser mayor o igual a la fecha de fin");
            if (proyecto.descripcion.Length > 500)
                throw new ArgumentException("El campo Descripción no puede contener más de 500 caracteres");
        }

        public void ValidarAntesDeCrear(Proyecto proyecto)
        {
            if (proyectoCD.ExisteProyecto(proyecto))
                throw new InvalidOperationException("Ya existe un proyecto con el Nombre proporcionado");
        }

        public void ValidarAntesDeEditar(Proyecto proyecto)
        {
            if (string.IsNullOrWhiteSpace(proyecto.descripcion))
                throw new ArgumentException("El campo Descripción no puede estar vacío o contener solo espacios en blanco");
            if (proyecto.fecha_inicio >= proyecto.fecha_fin)
                throw new ArgumentException("La fecha de inicio no puede ser mayor o igual a la fecha de fin");
            if (proyecto.descripcion.Length > 500)
                throw new ArgumentException("El campo Descripción no puede contener más de 500 caracteres");
        }

        public void ValidarAntesDeEliminar(int proyectoId)
        {
            // Aquí puedes agregar validaciones adicionales si es necesario
        }
    }
}
