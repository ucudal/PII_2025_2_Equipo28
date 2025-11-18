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
        private List<Cliente> clientes = new List<Cliente>();
        
        public IEnumerable<Cliente> Clientes
        {
            get { return clientes; }
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
                clientes.Add(cliente);
                usuarios.ClientesTotales.Add(cliente);
            }
        }

        public void EliminarCliente(Cliente cliente)
        {
            bool removed = clientes.Remove(cliente);
        }

        public List<Cliente> BuscarCliente(string atributo, string valorBusqueda)
        {
            string attr = atributo.Trim().ToLower();
            string val = valorBusqueda.Trim();

            List<Cliente> resultados = new List<Cliente>();

            switch (attr)
            {
                case "id": 
                    resultados = clientes.FindAll(c => c.Id.Equals(val, StringComparison.OrdinalIgnoreCase));
                    break;
                case "nombre":
                    resultados = clientes.FindAll(c => c.Nombre.Equals(val, StringComparison.OrdinalIgnoreCase));
                    break;
                case "apellido":
                    resultados = clientes.FindAll(c => c.Apellido.Equals(val, StringComparison.OrdinalIgnoreCase));
                    break;
                case "telefono":
                    resultados = clientes.FindAll(c => c.Telefono.Equals(val, StringComparison.OrdinalIgnoreCase));
                    break;
                case "correo":
                    resultados = clientes.FindAll(c => c.Correo.Equals(val, StringComparison.OrdinalIgnoreCase));
                    break;
                case "genero":
                    resultados = clientes.FindAll(c => c.Genero.Equals(val, StringComparison.OrdinalIgnoreCase));
                    break;
                case "fechadenacimiento":
                    resultados = clientes.FindAll(c => c.FechaDeNacimiento.Equals(val, StringComparison.OrdinalIgnoreCase));
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
                throw new ArgumentException("Datos de cliente vacios");
            }
            
            foreach (var cliente in clientes)
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