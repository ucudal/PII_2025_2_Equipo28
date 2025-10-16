using System;

namespace Library
{
    public class Cliente
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Genero { get; set; }
        public string Etiqueta { get; set; }
        public string FechaDeNacimiento { get; set; }

        public Cliente(string nombre, string apellido, string telefono, string correo)
        {
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
            Correo = correo;

            Genero = string.Empty;
            Etiqueta = string.Empty;
            FechaDeNacimiento = string.Empty;
        }

        public void ModificarInfo(string nuevoTelefono, string nuevoCorreo)
        {
            Telefono = nuevoTelefono;
            Correo = nuevoCorreo;
            Console.WriteLine($"Se actualizó la información de {Nombre} {Apellido}. Nuevo teléfono: {Telefono}");
        }

        public override string ToString()
        {
            return $"{Nombre} {Apellido} ({Correo})";
        }
    }
}