using System;
using System.Collections.Generic;

namespace Library
{
    // SRP: Su responsabilidad única sería “administrar la creación y gestión de usuarios, vendedores y administradores”,
    // no manejar datos de otras cosas fuera de eso.
    //Expert: La clase es la experta en crear y agregar objetos relacionados, porque tiene acceso a toda
    //la información necesaria para instanciarlos y registrarlos en las listas.
    public class Administrador : Usuario
    {
        public List<Usuario> UsuariosSuspendidos = new List<Usuario>();
        public string ID { get; set; }
        public string Nombre { get; set; }

        public Administrador(string id, string nombre) : base(id, nombre)
        {
            this.ID = id;
            this.Nombre = nombre;
        }

        public Usuario CrearUsuario(string id,string nombre)
        {
            Usuario usuario = new Usuario(id,nombre);
            Listas.Usuarios.Add(usuario);
            return usuario;
        }
        public Vendedor CrearVendedor(string id,string nombre)
        {
            Vendedor vendedor = new Vendedor(id,nombre);
            Listas.Vendedores.Add(vendedor);
            return vendedor;
        }
        public Administrador CrearAdministrador(string id,string nombre)
        {
            Administrador administrador = new Administrador(id,nombre);
            Listas.Administradores.Add(administrador);
            return administrador;
        }

        public void SuspenderUsuario(Usuario usuario)
        {
            Listas.Usuarios.Remove(usuario);
            UsuariosSuspendidos.Add(usuario);

        }

        public void EliminarUsuario(Usuario usuario)
        {
            Listas.Usuarios.Remove(usuario);
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
