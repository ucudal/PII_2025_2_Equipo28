using System;
using System.Collections.Generic;

namespace Library
{
    // SRP 
    // Esta clase cumple SRP porque su única responsabilidad es gestionar una lista de clientes:
    // agregar, eliminar y buscar clientes dentro de la lista.
    //
    // Expert 
    // ClienteLista es la experta en gestionar la colección de clientes, ya que conoce todas
    // las operaciones posibles sobre la lista (agregar, eliminar, buscar) y tiene acceso a todos
    // los datos necesarios de los clientes para esas operaciones.
    public class RepoClientes
    {
        private List<Cliente> Clientes = new List<Cliente>();
        
        public IEnumerable<Cliente> Clientes2
        {
            get { return Clientes; }
        }

        private RepoEtiquetas etiquetas;
        private RepoUsuarios usuarios;

        public RepoClientes(RepoEtiquetas etiquetas, RepoUsuarios usuarios)
        {
            this.etiquetas = etiquetas;
            this.usuarios = usuarios;
        }

        public void AgregaCliente(Cliente cliente)
        {
            if (cliente != null)
            {
                Clientes.Add(cliente);
                usuarios.ClientesTotales.Add(cliente);
            }
        }

        public void EliminarCliente(Cliente cliente)
        {
            bool removed = Clientes.Remove(cliente);
        }

        public List<Cliente> BuscarCliente(string atributo, string valorBusqueda)
        {
            string attr = atributo.Trim().ToLower();
            string val = valorBusqueda.Trim();

            List<Cliente> resultados = new List<Cliente>();

            switch (attr)
            {
                case "id":
                    foreach (Cliente cliente in Clientes)
                    {
                        if (cliente.Id == val)
                        {
                            resultados.Add(cliente);
                        }
                    }
                    break;
                case "nombre":
                    foreach (Cliente cliente in Clientes)
                    {
                        if (cliente.Nombre == val)
                        {
                            resultados.Add(cliente);
                        }
                    }
                    break;
                case "apellido":
                    foreach (Cliente cliente in Clientes)
                    {
                        if (cliente.Apellido == val)
                        {
                            resultados.Add(cliente);
                        }
                    }
                    break;
                case "telefono":
                    foreach (Cliente cliente in Clientes)
                    {
                        if (cliente.Telefono == val)
                        {
                            resultados.Add(cliente);
                        }
                    }
                    break;
                case "correo":
                    foreach (Cliente cliente in Clientes)
                    {
                        if (cliente.Correo == val)
                        {
                            resultados.Add(cliente);
                        }
                    }
                    break;
                case "genero":
                    foreach (Cliente cliente in Clientes)
                    {
                        if (cliente.Genero == val)
                        {
                            resultados.Add(cliente);
                        }
                    }
                    break;
                case "fechadenacimiento":
                    foreach (Cliente cliente in Clientes)
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

        public Cliente BuscarUnCliente(string ClienteId)
        {
            if (ClienteId == null)
            {
                throw new ArgumentNullException("Datos de cliente null");
            }

            if (ClienteId == "")
            {
                throw new Excepciones.EmptyStringException("Datos de cliente vacios");
            }
            
            foreach (var cliente in Clientes)
            {
                if (cliente.Id == ClienteId)
                {
                    return cliente;
                }
            }
            
            return null;
        }
    }
}