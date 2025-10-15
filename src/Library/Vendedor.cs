using System;
using System.Collections.Generic;

namespace Library
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }

        public Vendedor(int id, string nombre)
        {
            Id = id;
            NombreCompleto = nombre;
        }

        public void AsignarCliente(Cliente cliente)
        {
            if (cliente != null)
            {
                Console.WriteLine($"Al cliente {cliente.Nombre} {cliente.Apellido} se le asignó: {NombreCompleto}");
            }
        }
    }
}