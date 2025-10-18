using System;
using System.Collections.Generic;

namespace Library
{
    public class Listas
    {
        public static List<Usuario> Usuarios = new List<Usuario>();
        public static List<Administrador> Administradores = new List<Administrador>();
        public static List<Vendedor> Vendedores = new List<Vendedor>();

        public Usuario BuscarUsuario(string id)
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

        public Vendedor BuscarVendedor(string id)
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
        public Administrador BuscarAdministrador(string id)
        {
            foreach (Administrador administrador in Listas.Administradores)
            {
                if (Administrador.ID == id)
                {
                    return administrador;
                }
            }

            Console.WriteLine(
                "Su Id de Administrador no corresponde con una id conocida\nPor favor verifique el ID.");
            return null;
        }
    }
}