using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// - Expert: porque es responsable de gestionar las listas de usuarios y conoce cómo buscarlos.
    /// - Polimorfismo: almacena Usuario y sus subtipos (Administrador, Vendedor), tratándolos de forma polimórfica.
    /// - SRP: tiene una única responsabilidad: gestionar usuarios en el sistema.
    /// - Alta Cohesión: todos sus métodos y atributos pertenecen al propósito de gestionar usuarios.
    /// - Bajo Acoplamiento: depende únicamente de Usuario, Cliente, Administrador, Vendedor.
    /// </summary>
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

        /// <summary>
        /// Agrega un usuario a la lista de usuarios
        /// </summary>
        /// <param name="usuario">Usuario a agregar</param>
        public void AgregarUsuario(Usuario usuario)
        {
            this.usuarios.Add(usuario);
        }

        /// <summary>
        /// Agrega un administrador a la lista de administradores
        /// </summary>
        /// <param name="admin">Administrador a agregar</param>
        public void AgregarAdministraodr(Administrador admin)
        {
            this.administradores.Add(admin);
        }

        /// <summary>
        /// Agrega un vendedor a la lista de vendedores
        /// </summary>
        /// <param name="vendedor">Vendedor a agregar</param>
        public void AgregarVendedor(Vendedor vendedor)
        {
            this.vendedores.Add(vendedor);
        }

        /// <summary>
        /// Agrega un cliente a la lista de clientes
        /// </summary>
        /// <param name="cliente">Cliente a agregar</param>
        public void AgregarCliente(Cliente cliente)
        {
            this.clientesTotales.Add(cliente);
        }

        /// <summary>
        /// Elimina un usuario de la lista de usuarios
        /// </summary>
        /// <param name="usuario">Usuario a eliminar</param>
        public void EliminarUsuario(Usuario usuario)
        {
            this.usuarios.Remove(usuario);
        }

        /// <summary>
        /// Elimina un administrador de la lista de administradores
        /// </summary>
        /// <param name="admin">Administrador a eliminar</param>
        public void EliminarAdministrador(Administrador admin)
        {
            this.usuarios.Remove(admin);
        }

        /// <summary>
        /// Busca un usuario en la lista de usuarios
        /// </summary>
        /// <param name="id">ID del usuario a buscar</param>
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

        /// <summary>
        /// Busca un vendedor en la lista de vendedores
        /// </summary>
        /// <param name="id">ID del vendedor a buscar</param>
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

        /// <summary>
        /// Busca un administrador en la lista de administradores
        /// </summary>
        /// <param name="id">ID del administrador a buscar</param>
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

        /// <summary>
        /// Busca un cliente en la lista de clientes
        /// </summary>
        /// <param name="id">ID del cliente a buscar</param>
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
        /// Elimina todos los datos de los usuarios, administradores, clientes y vendedores
        /// </summary>
        public void EliminarDatos()
        {
            this.usuarios.Clear();
            this.administradores.Clear();
            this.clientesTotales.Clear();
            this.vendedores.Clear();
        }

        /// <summary>
        /// Devuelve la lista de usuarios
        /// </summary>
        public List<Usuario> VerUsuarios()
        {
            return usuarios;
        }
    }
}