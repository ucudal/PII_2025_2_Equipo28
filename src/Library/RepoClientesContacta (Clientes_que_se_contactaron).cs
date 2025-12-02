using System;
using System.Collections.Generic;

namespace Library
{
    public class RepoClientesContacta__Clientes_que_se_contactaron_
    {
        private Dictionary<Usuario, List<Cliente>> ClientesContacto = new Dictionary<Usuario, List<Cliente>>();
        
        public string AgregarClienteQueSeContacta(Usuario usuario, Cliente cliente)
        {
            if (usuario != null && cliente != null)
            {
                if (!(this.ClientesContacto.ContainsKey(usuario)))
                {
                    this.ClientesContacto[usuario] = new List<Cliente>();
                    this.ClientesContacto[usuario].Add(cliente);
                }
                else
                {
                    this.ClientesContacto[usuario].Add(cliente);
                }
                return "cliente agregado";
            }
            return "usuario o cliente no puden ser null";
        }
        /// <summary>
        /// Permite ver los cleintes que se pusieron en contacto con el usuario y que este aun no les haya respondido.
        /// Principios que cumple:
        /// - SRP: Cumple SRP porque solo muestra la lista de clientes pendientes.
        /// No modifica datos ni hace validaciones externas.
        /// - Bajo acoplamiento: Solo usa propiedades públicas de Usuario y Cliente
        /// como Nombre y Apellido.
        /// - Alta cohesion: Toda la lógica se enfoca en obtener y mostrar
        /// información de contactos pendientes.
        /// </summary>
        /// <param name="usuario">El usuario a asignarle ese cliente ausente.</param>
        /// <returns>Devuelve un string con el nombre de los clientes que se pusieron en contacto.</returns>
        public string VerClienteQueSeContacta(Usuario usuario)
        {
            string clientes = $"Los clientes que se pusieron en contacto contigo son:\n";
            if (usuario != null)
            {
                List<Cliente> lista = ClientesContacto[usuario];
                foreach (var VARIABLE in lista)
                {
                    clientes += $"{VARIABLE.Nombre} {VARIABLE.Apellido}\n";
                }

                return clientes;
            }

            return "Usuario null";
        }

        public string EliminarClienteQueSeContacta(Usuario usuario, Cliente cliente)
        {
            if (usuario != null && cliente != null)
            {
                if (this.ClientesContacto.ContainsKey(usuario))
                {
                    if (this.ClientesContacto[usuario].Contains(cliente))
                    {
                        this.ClientesContacto[usuario].Remove(cliente);
                        return "cliente eliminado de la lista";
                    }

                    return "la lisat actual no contiene el cliente que desea eliminar";
                }

                return "el usuario aun no ah agregado ningun cliente a la lista";

            }
            return "usuario o cliente no puden ser null";
        }

        public void ElminarDatos()
        {
            ClientesContacto.Clear();
        }
    }
}