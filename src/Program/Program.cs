using System;
using System.Collections.Generic;
using Library;

namespace Program
{
    class Program
    {
        // Variables de instancia del programa
        private static Fachada fachada = new Fachada();
        private static Administrador administrador = new Administrador("0000001", "AR");

        static void Main(string[] args)
        {
            // Llamamos a nuestro método de ejemplo
            RegistrarMensaje();
        }

        // Método para registrar un mensaje
        public static void RegistrarMensaje()
        {
            // Crear usuario desde el administrador
            Usuario usuario = administrador.CrearUsuario("000002", "AR2");

            // Crear cliente
            Cliente cliente = new Cliente("Luis", "Suarez", "098881777", "Lusitoarriba@cabezatermo.com");

            // Registrar mensaje en la fachada
            fachada.RegistarMensaje(
                cliente.Nombre,
                cliente.Apellido,
                "Tres trigos comiendo trigal trigo nose",
                "trigo",
                usuario.ID
            );

            // Buscar la interacción (mensaje)
            Interaccion interaccion = usuario.BuscarInteraccion("mensaje", "trigo");
            Console.WriteLine(interaccion.tipo);

            
        }
    }
}

