using System;
using System.Collections.Generic;

namespace Library
{
    // SRP 
    // Esta clase cumple SRP porque su única responsabilidad es mantener listas globales
    // de usuarios, administradores, vendedores y clientes, y proporcionar métodos de búsqueda.
    //
    // Expert 
    // Listas es la experta en acceder a estas colecciones, ya que conoce todas las listas
    // y puede buscar elementos por ID de manera eficiente.
    public class Listas
    {
        public static List<Usuario> Usuarios = new List<Usuario>();
        public static List<Administrador> Administradores = new List<Administrador>();
        public static List<Vendedor> Vendedores = new List<Vendedor>();
        public static List<Cliente> ClientesTotales = new List<Cliente>();

    public static Usuario BuscarUsuario(string id)
        {
            foreach (Usuario usuario in Listas.Usuarios)
            {
                if (usuario.ID == id)
                {
                    return usuario;
                }
                
            }

            Console.WriteLine(
                "Su Id de usuario no corresponde con una id conocida\nPor favor verifique el ID. En caso de no tener un usuario, solicitelo a un administrador");
            return null;
        }

        public static Vendedor BuscarVendedor(string id)
        {
            foreach (Vendedor vendedor in Listas.Vendedores)
            {
                if (vendedor.Id == id)
                {
                    return vendedor;
                }
            }

            Console.WriteLine(
                "Su Id de vendedor no corresponde con una id conocida\nPor favor verifique el ID. En caso de no tener un vendedor, solicitelo a un administrador");
            return null;
        }
        public static Administrador BuscarAdministrador(string id)
        {
            foreach (Administrador administrador in Listas.Administradores)
            {
                if (administrador.ID == id)
                {
                    return administrador;
                }
            }

            Console.WriteLine(
                "Su Id de Administrador no corresponde con una id conocida\nPor favor verifique el ID.");
            return null;
        }
        public static Cliente BuscarCliente(string id)
        {
            foreach (Cliente cliente in Listas.ClientesTotales)
            {
                if (cliente.Id == id)
                {
                    return cliente;
                }
            }

            Console.WriteLine(
                "Su Id de cliente no corresponde con una id conocida\nPor favor verifique el ID.");
            return null;
        }
    }
}