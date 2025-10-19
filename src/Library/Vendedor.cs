using System;
using System.Collections.Generic;

namespace Library
{
    public class Vendedor
    {
        public List<Cliente> Clientes = new List<Cliente>();
        public string Id { get; set; }
        public string NombreCompleto { get; set; }

        public Vendedor(string id, string nombre)
        {
            Id = id;
            NombreCompleto = nombre;
        }

        public void AsignarCliente(Cliente cliente, Vendedor vendedor)
        {
            if (cliente != null)
            {
                vendedor.Clientes.Add(cliente);
                Console.WriteLine($"Al cliente {cliente.Nombre} {cliente.Apellido} se le asignó: {vendedor.NombreCompleto}");
            }
        }
    }
}