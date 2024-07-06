using CapaDeDatos.CRUD;
using Entidades;
using System.Data;
using System;

public class TareaCN
{
    private readonly TareaCD tareaCD = new TareaCD();

    public DataTable ObtenerTarea()
    {
        return tareaCD.ObtenerTarea();
    }

    public bool Insertar(Tarea tarea)
    {
        try
        {
            ValidarTarea(tarea);
            return tareaCD.Insertar(tarea);
        }
        catch (Exception ex)
        {
            // Manejar el error según sea necesario, tal vez loguearlo
            throw new Exception("Error al insertar la tarea: " + ex.Message);
        }
    }

    public bool Editar(Tarea tarea)
    {
        try
        {
            ValidarTarea(tarea);
            return tareaCD.Editar(tarea);
        }
        catch (Exception ex)
        {
            // Manejar el error según sea necesario, tal vez loguearlo
            throw new Exception("Error al editar la tarea: " + ex.Message);
        }
    }

    public bool Eliminar(int tareaId)
    {
        try
        {
            ValidarAntesDeEliminar(tareaId);
            return tareaCD.Eliminar(tareaId);
        }
        catch (Exception ex)
        {
            // Manejar el error según sea necesario, tal vez loguearlo
            throw new Exception("Error al eliminar la tarea: " + ex.Message);
        }
    }

    public void ValidarTarea(Tarea tarea)
    {
        if (string.IsNullOrWhiteSpace(tarea.descripcion))
            throw new ArgumentException("El campo Descripción no puede estar vacío o contener solo espacios en blanco");

        if (tarea.descripcion.Length > 200)
            throw new ArgumentException("El campo Descripción no puede contener más de 200 caracteres");

    }

    public void ValidarAntesDeCrear(Tarea tarea)
    {
        if (tareaCD.ExisteTarea(tarea))
            throw new InvalidOperationException("Ya existe una tarea con la misma descripción en el mismo período");
    }

    public void ValidarAntesDeEliminar(int tareaId)
    {
        if (tareaCD.TareaConProyectoDetalle(tareaId))
            throw new InvalidOperationException("La tarea a eliminar está en proyectos relacionados");
    }
}
