using System;
using System.Collections.Generic;

namespace Library
{
    // SRP 
    // Esta clase cumple SRP porque su única responsabilidad es representar un vendedor
    // y gestionar la asignación de clientes a él.
    //
    // Expert 
    // Vendedor es la experta en manejar su propia lista de clientes,
    // ya que conoce todos los clientes que le han sido asignados y puede agregarlos.
    public class Vendedor : Usuario
    {
        public List<Cliente> Clientes = new List<Cliente>();
        public string Id { get; set; }
        public string NombreCompleto { get; set; }

        public Vendedor(string id, string nombre) : base(id, nombre)
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