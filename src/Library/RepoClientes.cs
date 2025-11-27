using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// - Expert: porque es responsable de gestionar la lista de clientes.
    /// - SRP: tiene una única responsabilidad: gestionar clientes en el sistema.
    /// - Alta Cohesión: todos sus métodos y atributos pertenecen al propósito de gestionar clientes.
    /// </summary>
    public class RepoClientes
    {
        private List<Cliente> clientes = new List<Cliente>();
        
        public IEnumerable<Cliente> Clientes
        {
            get { return clientes; }
        }

        private RepoEtiquetas etiquetas;
        private RepoUsuarios usuarios;

        /// <summary>
        /// Constructor de la clase RepoClientes
        /// </summary>
        /// <param name="etiquetas">Repositorio de etiquetas</param>
        /// <param name="usuarios">Repositorio de usuarios</param>
        public RepoClientes(RepoEtiquetas etiquetas, RepoUsuarios usuarios)
        {
            this.etiquetas = etiquetas;
            this.usuarios = usuarios;
        }

        /// <summary>
        /// Agrega un cliente a la lista de clientes y lo registra en el repositorio de usuarios
        /// </summary>
        /// <param name="cliente">Cliente a agregar</param>
        public void AgregaCliente(Cliente cliente)
        {
            if (cliente != null)
            {
                this.clientes.Add(cliente);
                this.usuarios.AgregarCliente(cliente);
            }
        }

        /// <summary>
        /// Elimina un cliente de la lista de clientes
        /// </summary>
        /// <param name="cliente">Cliente a eliminar</param>
        public void EliminarCliente(Cliente cliente)
        {
            bool removed = this.clientes.Remove(cliente);
        }

        /// <summary>
        /// Busca clientes por atributo y valor de busqueda
        /// </summary>
        /// <param name="atributo">Atributo a buscar</param>
        /// <param name="valorBusqueda">Valor de busqueda</param>
        public List<Cliente> BuscarCliente(string atributo, string valorBusqueda)
        {
            string attr = atributo.Trim().ToLower();
            string val = valorBusqueda.Trim();

            List<Cliente> resultados = new List<Cliente>();

            switch (attr)
            {
                case "id":
                    foreach (Cliente cliente in this.clientes)
                    {
                        if (cliente.Id == val)
                        {
                            resultados.Add(cliente);
                        }
                    }
                    break;
                case "nombre":
                    foreach (Cliente cliente in this.clientes)
                    {
                        if (cliente.Nombre == val)
                        {
                            resultados.Add(cliente);
                        }
                    }
                    break;
                case "apellido":
                    foreach (Cliente cliente in this.clientes)
                    {
                        if (cliente.Apellido == val)
                        {
                            resultados.Add(cliente);
                        }
                    }
                    break;
                case "telefono":
                    foreach (Cliente cliente in this.clientes)
                    {
                        if (cliente.Telefono == val)
                        {
                            resultados.Add(cliente);
                        }
                    }
                    break;
                case "correo":
                    foreach (Cliente cliente in this.clientes)
                    {
                        if (cliente.Correo == val)
                        {
                            resultados.Add(cliente);
                        }
                    }
                    break;
                case "genero":
                    foreach (Cliente cliente in this.clientes)
                    {
                        if (cliente.Genero == val)
                        {
                            resultados.Add(cliente);
                        }
                    }
                    break;
                case "fechadenacimiento":
                    foreach (Cliente cliente in this.clientes)
                    {
                        if (cliente.FechaDeNacimiento == val)
                        {
                            resultados.Add(cliente);
                        }
                    } 
                    break;
                default:
                    break;
            }

            return resultados;
        }

        /// <summary>
        /// Busca un cliente por su ID
        /// </summary>
        /// <param name="ClienteId">ID del cliente a buscar</param>
        public Cliente BuscarUnCliente(string ClienteId)
        {
            if (ClienteId == null)
            {
                throw new ArgumentNullException("Datos de cliente null");
            }

            if (ClienteId == "")
            {
                throw new ArgumentException("Datos de cliente vacios");
            }
            
            foreach (Cliente cliente in this.clientes)
            {
                if (cliente.Id == ClienteId)
                {
                    return cliente;
                }
            }
            
            return null;
        }

        /// <summary>
        /// Elimina todos los clientes del repositorio
        /// </summary>
        public void EliminarDatos()
        {
            this.clientes.Clear();
        }
    }
}