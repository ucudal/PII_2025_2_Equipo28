using System;
using System.Collections.Generic;

namespace Library
{
    // SRP 
    // Esta clase cumple SRP porque su única responsabilidad es modelar un cliente
    // y permitir modificar su información básica (nombre, apellido, teléfono, correo, género, etiqueta, fecha de nacimiento).
    //
    // Expert 
    // La clase Cliente es experta en manejar su propia información, ya que contiene todos
    // los datos relevantes de un cliente y proporciona métodos para modificarlos.
    public class Cliente
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Genero { get; set; }
        public List<string> Etiquetas { get; set; } = new List<string>();
        public string FechaDeNacimiento { get; set; }

        public Cliente(string nombre, string apellido, string telefono, string correo)
        {
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
            Correo = correo;

            Genero = string.Empty;
            FechaDeNacimiento = string.Empty;
        }
        
        public void CambiarNombre(string nuevoNombre)
        {
            Nombre = nuevoNombre;
        }

        public void CambiarApellido(string nuevoApellido)
        {
            Apellido = nuevoApellido;
        }

        public void CambiarTelefono(string nuevoTelefono)
        {
            Telefono = nuevoTelefono;
        }

        public void CambiarCorreo(string nuevoCorreo)
        {
            Correo = nuevoCorreo;
        }

        public void AsignarGenero(string nuevoGenero)
        {
            Genero = nuevoGenero;
        }
        
        public void AsignarEtiqueta(string nuevaEtiqueta)
        {
            Etiquetas.Add(nuevaEtiqueta);
            Console.WriteLine($"Se asignó la etiqueta '{nuevaEtiqueta}' a {Nombre}");
        }

        
        public void AsignarFechaDeNacimiento(string nuevaFecha)
        {
            FechaDeNacimiento = nuevaFecha;
        }
        
        public override string ToString()
        {
            return $"{Nombre} {Apellido} ({Correo})";
        }
    }
}