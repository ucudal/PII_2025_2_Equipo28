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
        private List<Usuario> usuariosSuspendidos = new List<Usuario>();

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
            usuarios.Add(usuario);
        }

        /// <summary>
        /// Agrega un administrador a la lista de administradores
        /// </summary>
        /// <param name="admin">Administrador a agregar</param>
        public void AgregarAdministraodr(Administrador admin)
        {
            foreach (Administrador a in administradores)
            {
                if (a.ID == admin.ID)
                {
                    throw new InvalidOperationException($"Ya existe un administrador con el ID: {a.ID}");
                }
            }
            this.administradores.Add(admin);
        }

        /// <summary>
        /// Agrega un vendedor a la lista de vendedores
        /// </summary>
        /// <param name="vendedor">Vendedor a agregar</param>
        public void AgregarVendedor(Vendedor vendedor)
        {
            foreach (Vendedor v in vendedores)
            {
                if (v.ID == vendedor.ID)
                {
                    throw new InvalidOperationException($"Ya existe un vendedor con el ID: {v.ID}");
                }
            }
            this.vendedores.Add(vendedor);
        }

        /// <summary>
        /// Agrega un cliente a la lista de clientes
        /// </summary>
        /// <param name="cliente">Cliente a agregar</param>
        public void AgregarCliente(Cliente cliente)
        {
            foreach (Cliente c in clientesTotales)
            {
                if (c.Id == cliente.Id)
                {
                    throw new InvalidOperationException($"Ya existe un cliente con el ID: {c.Id}");
                }
            }
            this.clientesTotales.Add(cliente);
        }

        /// <summary>
        /// Elimina un usuario de la lista de usuarios
        /// </summary>
        /// <param name="usuario">Usuario a eliminar</param>
        public void EliminarUsuario(Usuario usuario)
        {
            foreach (Usuario u in usuarios)
            {
                if (u.ID == usuario.ID)
                {
                    this.usuarios.Remove(u);
                    return;
                }
            } 
            throw new InvalidOperationException($"No se encontro el usuario con el ID: {usuario.ID}");
        }

        /// <summary>
        /// Elimina un administrador de la lista de administradores
        /// </summary>
        /// <param name="admin">Administrador a eliminar</param>
        public void EliminarAdministrador(Administrador admin)
        {
            foreach (Administrador a in administradores)
            {
                if (a.ID == admin.ID)
                {
                    this.administradores.Remove(a);
                    return;
                }
            } 
            throw new InvalidOperationException($"No se encontro el administrador con el ID: {admin.ID}");
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
            if (id == null)
            {
                throw new ArgumentNullException("datos de administrador null");
            }

            if (id == "")
            {
                throw new ArgumentException("datos de administrador vacios");
            }

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
        public string VerUsuarios()
        {
            string resultado = "";
            foreach (Usuario u in this.usuarios)
            {
                if (!usuariosSuspendidos.Contains(u))
                {
                    resultado += u.ToString() + "\n";    
                }
            }

            if (this.usuarios.Count == 0)
            {
                resultado += "No hay usuarios\n";
            }

            resultado += "\nUsuarios suspendidos:\n";
            foreach (Usuario u in this.usuariosSuspendidos)
            { 
                resultado += u.ToString() + "\n";    
            }

            if (usuariosSuspendidos.Count == 0)
            {
                resultado += "No hay usuarios suspendidos";
            }
            return resultado;
        }

        public string VerAdministradores()
        {
            string resultado = "";
            foreach (Administrador administrador in administradores)
            {
                resultado += administrador.ToString() + "\n";
            }

            return resultado;
        }

        public void SuspenderUsuario(Usuario usuario)
        {
            this.usuariosSuspendidos.Add(usuario);
        }
    }
}