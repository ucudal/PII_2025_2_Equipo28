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
                Listas.ClientesTotales.Add(cliente);
                Console.WriteLine($"Se agregó: {cliente.Nombre} {cliente.Apellido}");
            }
        }

        public void EliminarCliente(Cliente cliente)
        {
            bool removed = Clientes.Remove(cliente);
            if (removed)
            {
                Console.WriteLine($"Se eliminó el cliente.");
            }
            else
            {
                Console.WriteLine($"No se encontró el cliente.");
            }
        }

        public List<Cliente> BuscarCliente(string atributo, string valorBusqueda)
        {
            string attr = atributo.Trim().ToLower();
            string val = valorBusqueda.Trim();

            List<Cliente> resultados = new List<Cliente>();

            switch (attr)
            {
                case "id": 
                    resultados = Clientes.FindAll(c => c.Id.Equals(val, StringComparison.OrdinalIgnoreCase));
                    break;
                case "nombre":
                    resultados = Clientes.FindAll(c => c.Nombre.Equals(val, StringComparison.OrdinalIgnoreCase));
                    break;

                case "apellido":
                    resultados = Clientes.FindAll(c => c.Apellido.Equals(val, StringComparison.OrdinalIgnoreCase));
                    break;

                case "telefono":
                    resultados = Clientes.FindAll(c => c.Telefono.Equals(val, StringComparison.OrdinalIgnoreCase));
                    break;

                case "correo":
                    resultados = Clientes.FindAll(c => c.Correo.Equals(val, StringComparison.OrdinalIgnoreCase));
                    break;

                case "etiqueta":
                    resultados = Clientes.FindAll(c => c.Etiqueta.Equals(val, StringComparison.OrdinalIgnoreCase));
                    break;
                
                case "genero":
                    resultados = Clientes.FindAll(c => c.Genero.Equals(val, StringComparison.OrdinalIgnoreCase));
                    break;

                case "fechadenacimiento":
                    resultados = Clientes.FindAll(c => c.FechaDeNacimiento.Equals(val, StringComparison.OrdinalIgnoreCase));
                    break;

                default:
                    Console.WriteLine($"No es un atributo válido");
                    break;
            }

            return resultados;
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