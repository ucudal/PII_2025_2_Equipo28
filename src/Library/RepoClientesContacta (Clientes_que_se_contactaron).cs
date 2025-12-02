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