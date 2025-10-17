using System; 
using System.Collections.Generic;
namespace Library
{
    public class Administrador
    {
        public List<Usuario> Usuarios { get; private set; } = new List<Usuario>();

        public Usuario CrearUsuario()
        {
            var usuario = new Usuario();
            Usuarios.Add(usuario);
            return usuario;
        }

        public void SuspenderUsuario(Usuario usuario)
        {
            Console.WriteLine("Usuario suspendido.");

        }

        public void EliminarUsuario(Usuario usuario)
        {
            Usuarios.Remove(usuario);
            Console.WriteLine("Usuario eliminado.");
        }
    }
}
