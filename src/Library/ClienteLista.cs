using System;
using System.Collections.Generic;

namespace Library
{
    public class ClienteLista
    {
        public List<Cliente> Clientes { get; private set; }

        public ClienteLista()
        {
            Clientes = new List<Cliente>();
        }

        public void AgregaCliente(Cliente cliente)
        {
            if (cliente != null)
            {
                Clientes.Add(cliente);
                Console.WriteLine($"Se agregó: {cliente.Nombre} {cliente.Apellido}");
            }
        }

        public void EliminarCliente(string correo)
        {
            int removed = Clientes.RemoveAll(c => c.Correo.Equals(correo, StringComparison.OrdinalIgnoreCase));
            if (removed > 0)
            {
                Console.WriteLine($"Se eliminó {removed} cliente con el mail: {correo}");
            }
            else
            {
                Console.WriteLine($"No se encontró el cliente con el mail {correo}");
            }
        }

        public List<Cliente> BuscarCliente(string nombre)
        {
            return Clientes.FindAll(c => c.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }

        public Cliente BuscarUnCliente(string nombre, string apellido)
        {
            foreach (var cliente in Clientes)
            {
                if (cliente.Nombre == nombre && cliente.Apellido == apellido)
                {
                    return cliente;
                }
               
            }
            Console.WriteLine("No se encontro el cliente");
            return null;
        }
    }
}