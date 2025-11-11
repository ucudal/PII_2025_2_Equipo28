using System;
using System.Collections.Generic;

namespace Library
{
    // SRP 
    // Esta clase cumple SRP porque su única responsabilidad es mantener listas globales
    // de usuarios, administradores, vendedores y clientes, y proporcionar métodos de búsqueda.
    //
    // Expert 
    // Usuarios es la experta en acceder a estas colecciones, ya que conoce todas las listas
    // y puede buscar elementos por ID de manera eficiente.
    public class RepoUsuarios
    {
        public List<Usuario> Usuarios = new List<Usuario>();
        public List<Administrador> Administradores = new List<Administrador>();
        public List<Vendedor> Vendedores = new List<Vendedor>();
        public List<Cliente> ClientesTotales = new List<Cliente>();

        public void AgregarUsuario(Usuario usuario)
        {
            this.Usuarios.Add(usuario);
        }

        public void EliminarUsuario(Usuario usuario)
        {
            this.Usuarios.Remove(usuario);
        }
        
        public void EliminarAdministrador(Administrador admin)
        {
            this.Usuarios.Remove(admin);
        }

        public Usuario BuscarUsuario(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("datos de usuario null");
            }

            if (id == "")
            {
                throw new Excepciones.EmptyStringException("datos de usuario vacios");
            }
            foreach (Usuario usuario in this.Usuarios)
            {
                if (usuario.ID == id)
                {
                    return usuario;
                }
                
            }
            
            return null;
        }

        public Vendedor BuscarVendedor(string id)
        {
            foreach (Vendedor vendedor in this.Vendedores)
            {
                if (vendedor.Id == id)
                {
                    return vendedor;
                }
            }
            
            return null;
        }
        public Administrador BuscarAdministrador(string id)
        {
            foreach (Administrador administrador in this.Administradores)
            {
                if (administrador.ID == id)
                {
                    return administrador;
                }
            }
            
            return null;
        }
        public Cliente BuscarCliente(string id)
        {
            foreach (Cliente cliente in this.ClientesTotales)
            {
                if (cliente.Id == id)
                {
                    return cliente;
                }
            }
            
            return null;
        }
    }
}