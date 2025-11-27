using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// - Expert: porque es responsable de gestionar la lista de usuarios suspendidos.
    /// - Polimorfismo: hereda de Usuario, permitiendo que un Administrador sea tratado como Usuario.
    /// - SRP: tiene una única responsabilidad: gestionar usuarios suspendidos en el sistema.
    /// - Alta Cohesión: todos sus métodos y atributos pertenecen al propósito de administrar usuarios.
    /// </summary>
    public class Administrador : Usuario
    {
        public List<Usuario> UsuariosSuspendidos = new List<Usuario>();
        
        /// <summary>
        /// Constructor de la clase Administrador
        /// </summary>
        /// <param name="id">Id del Administrador</param>
        /// <param name="nombre">Nombre del Administrador</param>
        public Administrador(string id, string nombre) : base(id, nombre)
        {
            this.ID = id;
            this.Nombre = nombre;
        }
    }
}
