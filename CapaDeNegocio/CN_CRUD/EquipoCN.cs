using CapaDeDatos.CRUD;
using Entidades;
using Entidades.Entidades;
using System;
using System.Data;

namespace CapaDeNegocio.CN_CRUD
{
    public class EquipoCN
    {
        // Instancia de la capa de datos para Equipo
        private readonly EquipoCD equipoCD = new EquipoCD();

        // Método para obtener todos los equipos
        public DataTable ObtenerEquipos()
        {
            return equipoCD.ObtenerEquipo();
        }

        // Método para insertar un nuevo equipo
        public bool Insertar(Equipo equipo)
        {
            ValidarEquipo(equipo);
            ValidarAntesDeCrear(equipo);
            return equipoCD.Insertar(equipo);
        }

        // Método para editar un equipo existente
        public bool Editar(Equipo equipo)
        {
            ValidarEquipo(equipo);
            ValidarAntesDeEditar(equipo);
            return equipoCD.Editar(equipo);
        }

        // Método para eliminar un equipo por ID
        public bool Eliminar(int equipoId)
        {
            ValidarAntesDeEliminar(equipoId);
            return equipoCD.Eliminar(equipoId);
        }

        // Método de validación de los datos del equipo
        public  void ValidarEquipo(Equipo equipo)
        {
            if (string.IsNullOrWhiteSpace(equipo.codigo))
                throw new ArgumentException("El campo Código no puede estar vacío o contener solo espacios en blanco");

            if (string.IsNullOrWhiteSpace(equipo.tipo))
                throw new ArgumentException("El campo Tipo no puede estar vacío o contener solo espacios en blanco");

            if (string.IsNullOrWhiteSpace(equipo.marca))
                throw new ArgumentException("El campo Marca no puede estar vacío o contener solo espacios en blanco");

            if (equipo.codigo.Length > 100)
                throw new ArgumentException("El campo Código no puede contener más de 100 caracteres");

            if (equipo.tipo.Length > 50)
                throw new ArgumentException("El campo Tipo no puede contener más de 50 caracteres");

            if (equipo.marca.Length > 50)
                throw new ArgumentException("El campo Marca no puede contener más de 50 caracteres");

  
        }

        // Método para validar antes de crear un nuevo equipo
        public void ValidarAntesDeCrear(Equipo equipo)
        {
            if (equipoCD.ExisteEquipo(equipo))
                throw new InvalidOperationException("Ya existe un equipo con el código proporcionado");
        }

        // Método para validar antes de editar un equipo
        public void ValidarAntesDeEditar(Equipo equipo)
        {

            if (string.IsNullOrWhiteSpace(equipo.codigo))
                throw new ArgumentException("El campo Código no puede estar vacío o contener solo espacios en blanco");

            if (string.IsNullOrWhiteSpace(equipo.tipo))
                throw new ArgumentException("El campo Tipo no puede estar vacío o contener solo espacios en blanco");

            if (string.IsNullOrWhiteSpace(equipo.marca))
                throw new ArgumentException("El campo Marca no puede estar vacío o contener solo espacios en blanco");
        }

        // Método para validar antes de eliminar un equipo
        public void ValidarAntesDeEliminar(int equipoId)
        {
            if (equipoCD.EquipoConMantenimientoEquipo(equipoId))
                throw new InvalidOperationException("El equipo a eliminar tiene proyectos relacionados");
        }
    }
}
