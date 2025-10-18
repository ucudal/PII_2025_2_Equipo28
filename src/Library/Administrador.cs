using System;
using System.Collections.Generic;

namespace Library
{
    public class Administrador
    {
        public List<Usuario> UsuariosSuspendidos = new List<Usuario>();
        public static string ID { get; set; }
        public string Nombre { get; set; }

        public Administrador(string id, string nombre)
        {
            
        }

        public void CrearUsuario(string id,string nombre)
        {
            Usuario usuario = new Usuario(id,nombre);
            Listas.Usuarios.Add(usuario);
        }
        public void CrearVendedor(string id,string nombre)
        {
            Vendedor vendedor = new Vendedor(id,nombre);
            Listas.Vendedores.Add(vendedor);
        }
        public void CrearAdministrador(string id,string nombre)
        {
            Administrador administrador = new Administrador(id,nombre);
            Listas.Administradores.Add(administrador);
        }

        public void SuspenderUsuario(Usuario usuario)
        {
            Console.WriteLine("Usuario suspendido.");
            Listas.Usuarios.Remove(usuario);
            UsuariosSuspendidos.Add(usuario);

        }

        public void EliminarUsuario(Usuario usuario)
        {
            Listas.Usuarios.Remove(usuario);
            Console.WriteLine("Usuario eliminado.");
        }
        public void AgregarAdministrador(Administrador administrador)
        {
            Listas.Administradores.Add(administrador);
        }
        public void AgregarVendedor(Vendedor vendedor)
        {
            Listas.Vendedores.Add(vendedor);
        }
        
    }
}
