using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Representa a un vendedor del sistema y los clientes que tiene asignados.
    /// Principios que cumple:
    /// - SRP (Single Responsibility Principle): La clase se enfoca en modelar al vendedor y su relación con clientes.
    /// - EXPERT (Information Expert - GRASP): Es experta en conocer y administrar la lista de clientes asignados al vendedor.
    /// - Alta cohesión (High Cohesion - GRASP): Todas sus responsabilidades giran en torno al rol del vendedor y sus clientes.
    /// - Polymorphism: Hereda de Usuario, permitiendo tratar instancias de Vendedor polimórficamente como Usuarios.
    /// - OCP (Open/Closed Principle): Extiende el comportamiento de Usuario sin modificar el código que usa Usuario.
    /// </summary>

    
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

        public void AsignarCliente(Cliente cliente)
        {
            if (cliente != null)
            {
                this.Clientes.Add(cliente);
                Console.WriteLine($"Al cliente {cliente.Nombre} {cliente.Apellido} se le asignó: {this.NombreCompleto}");
            }
        }
    }
}