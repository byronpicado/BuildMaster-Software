using CapaDeDatos.CRUD;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaDeNegocio.CN_CRUD
{
    public class ClienteCN
    {
        private readonly ClienteCD clienteCD = new ClienteCD();

        public List<Cliente> ObtenerCliente()
        {
            return clienteCD.ObtenerCliente();
        }

        public DataTable ObtenerClientes()
        {
            return clienteCD.ObtenerClientes();
        }

        public bool Insertar(Cliente cliente)
        {
            ValidarCliente(cliente);
            ValidarAntesDeCrear(cliente);
            return clienteCD.Insertar(cliente);
        }

        public bool Editar(Cliente cliente)
        {
            ValidarCliente(cliente);
            ValidarAntesDeEditar(cliente);
            return clienteCD.Editar(cliente);
        }

        public bool Eliminar(int clienteId)
        {
            ValidarAntesDeEliminar(clienteId);
            return clienteCD.Eliminar(clienteId);
        }

        public void ValidarCliente(Cliente cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.codigo))
                throw new ArgumentException("El campo Cédula no puede estar vacio o contener solo espacios en blanco");

            if (string.IsNullOrWhiteSpace(cliente.nombre1))
                throw new ArgumentException("El campo Primer Nombre no puede estar vacio o contener solo espacios en blanco");

            if (string.IsNullOrWhiteSpace(cliente.nombre2))
                throw new ArgumentException("El campo Segundo Nombre no puede estar vacio o contener solo espacios en blanco");

            if (cliente.codigo.Length > 100)
                throw new ArgumentException("El campo Cédula no puede contener mas de 100 caracteres");

            if (cliente.codigo.Length < 11)
                throw new ArgumentException("El campo Cédula no puede contener menos de 11 caracteres");

            if (cliente.nombre1.Length > 100)
                throw new ArgumentException("El campo Primer Nombre no puede contener mas de 100 caracteres");

            if (cliente.nombre2.Length > 100)
                throw new ArgumentException("El campo Segundo Nombre no puede contener mas de 100 caracteres");
        }

        public void ValidarAntesDeCrear(Cliente cliente)
        {
            if (clienteCD.ExisteCliente(cliente))
                throw new InvalidOperationException("Ya existe un registro con el Código, Nombres, Apellidos, Teléfono y Correo proporcionados");
        }

        public void ValidarAntesDeEditar(Cliente cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.apellidoPaterno))
                throw new ArgumentException("El campo Apellido Paterno no puede estar vacio o contener solo espacios en blanco");

            if (string.IsNullOrWhiteSpace(cliente.apellidoMaterno))
                throw new ArgumentException("El campo Apellido Materno no puede estar vacio o contener solo espacios en blanco");

            if (string.IsNullOrWhiteSpace(cliente.telefono))
                throw new ArgumentException("El campo Teléfono no puede estar vacio o contener solo espacios en blanco");

            if (string.IsNullOrWhiteSpace(cliente.correo))
                throw new ArgumentException("El campo Correo no puede estar vacio o contener solo espacios en blanco");

            if (cliente.apellidoPaterno.Length > 100)
                throw new ArgumentException("El campo Apellido Paterno no puede contener mas de 100 caracteres");

         
        }

        public void ValidarAntesDeEliminar(int clienteId)
        {
            if (clienteCD.ClienteConProyecto(clienteId))
                throw new InvalidOperationException("El Cliente a eliminar contiene Proyectos relacionados");
        }
    }
}
