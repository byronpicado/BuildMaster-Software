using CapaDeDatos.CRUD;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocio.CN_CRUD
{
    public class RecursoCN
    {
        private readonly RecursoCD recursoCD = new RecursoCD();

        public DataTable ObtenerRecurso()
        {
            return recursoCD.ObtenerRecurso();
        }

        public bool Insertar(Recurso recurso)
        {
            ValidarRecurso(recurso);
            ValidarAntesDeCrear(recurso);
            return recursoCD.Insertar(recurso);
        }

        public bool Editar(Recurso recurso)
        {
            ValidarRecurso(recurso);
            ValidarAntesDeEditar(recurso);
            return recursoCD.Editar(recurso);
        }

        public bool Eliminar(int recursoId)
        {
            ValidarAntesDeEliminar(recursoId);
            return recursoCD.Eliminar(recursoId);
        }

        private void ValidarRecurso(Recurso recurso)
        {
            if (string.IsNullOrWhiteSpace(recurso.tipo))
                throw new ArgumentException("El campo Tipo no puede estar vacío o contener solo espacios en blanco");

            if (string.IsNullOrWhiteSpace(recurso.descripcion))
                throw new ArgumentException("El campo Descripción no puede estar vacío o contener solo espacios en blanco");

            if (recurso.tipo.Length > 100)
                throw new ArgumentException("El campo Tipo no puede contener más de 100 caracteres");

            if (recurso.descripcion.Length > 200)
                throw new ArgumentException("El campo Descripción no puede contener más de 200 caracteres");

            if (recurso.costo <= 0)
                throw new ArgumentException("El campo Costo debe ser mayor que cero");
        }

        private void ValidarAntesDeCrear(Recurso recurso)
        {
            if (recursoCD.ExisteRecurso(recurso))
                throw new InvalidOperationException("Ya existe un recurso con la misma descripción y tipo");
        }

        private void ValidarAntesDeEditar(Recurso recurso)
        {
            if (string.IsNullOrWhiteSpace(recurso.tipo))
                throw new ArgumentException("El campo Tipo no puede estar vacío o contener solo espacios en blanco");

            if (string.IsNullOrWhiteSpace(recurso.descripcion))
                throw new ArgumentException("El campo Descripción no puede estar vacío o contener solo espacios en blanco");

            if (recurso.tipo.Length > 100)
                throw new ArgumentException("El campo Tipo no puede contener más de 100 caracteres");

            if (recurso.descripcion.Length > 200)
                throw new ArgumentException("El campo Descripción no puede contener más de 200 caracteres");

            if (recurso.costo <= 0)
                throw new ArgumentException("El campo Costo debe ser mayor que cero");
        }

        private void ValidarAntesDeEliminar(int recursoId)
        {
            if (recursoCD.RecursoConProyectoDetalle(recursoId))
                throw new InvalidOperationException("El recurso a eliminar está asignado a uno o más proyectos");
        }
    }
}
