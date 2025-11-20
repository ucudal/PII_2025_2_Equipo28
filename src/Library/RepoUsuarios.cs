using System;
using System.Collections.Generic;

namespace Library
{
    // SRP 
    // Esta clase cumple SRP porque su única responsabilidad es mantener listas globales
    // de usuarios, administradores, vendedores y clientes, y proporcionar métodos de búsqueda.
    //
    // Expert 
    // usuarios es la experta en acceder a estas colecciones, ya que conoce todas las listas
    // y puede buscar elementos por ID de manera eficiente.
    public class RepoUsuarios
    {
        private List<Usuario> usuarios = new List<Usuario>();
        private List<Administrador> administradores = new List<Administrador>();
        private List<Vendedor> vendedores = new List<Vendedor>();
        private List<Cliente> clientesTotales = new List<Cliente>();

        public IEnumerable<Usuario> Usuarios
        {
            get { return usuarios; }
        }
        public IEnumerable<Administrador> Administradores
        {
            get { return administradores; }
        }
        public IEnumerable<Vendedor> Vendedores
        {
            get { return vendedores; }
        }
        public IEnumerable<Cliente> ClientesTotales
        {
            get { return clientesTotales; }
        }

        public void AgregarUsuario(Usuario usuario)
        {
            this.usuarios.Add(usuario);
        }
        public void AgregarAdministraodr(Administrador admin)
        {
            this.administradores.Add(admin);
        }
        public void AgregarVnededor(Vendedor vendedor)
        {
            this.vendedores.Add(vendedor);
        }

        public void EliminarUsuario(Usuario usuario)
        {
            this.usuarios.Remove(usuario);
        }
        
        public void EliminarAdministrador(Administrador admin)
        {
            this.usuarios.Remove(admin);
        }

        public Usuario BuscarUsuario(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("datos de usuario null");
            }

            if (id == "")
            {
                throw new ArgumentException("datos de usuario vacios");
            }
            foreach (Usuario usuario in this.usuarios)
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
            foreach (Vendedor vendedor in this.vendedores)
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
            foreach (Administrador administrador in this.administradores)
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
            foreach (Cliente cliente in this.clientesTotales)
            {
                if (cliente.Id == id)
                {
                    return cliente;
                }
            }
            
            return null;
        }
        /// <summary>
        /// para los test
        /// </summary>
        public void EliminarDatos()
        {
            this.usuarios.Clear();
            this.administradores.Clear();
            this.clientesTotales.Clear();
            this.vendedores.Clear();
        }
    }
}