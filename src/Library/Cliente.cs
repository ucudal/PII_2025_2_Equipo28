using System;

namespace Library
{
    public class Cliente
    {
        public string Id { get; set; }
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
        
        public void CambiarNombre(string nuevoNombre)
        {
            Nombre = nuevoNombre;
            Console.WriteLine($"Se actualizó el nombre del cliente a {Nombre} {Apellido}");
        }

        public void CambiarApellido(string nuevoApellido)
        {
            Apellido = nuevoApellido;
            Console.WriteLine($"Se actualizó el apellido del cliente a {Apellido}");
        }

        public void CambiarTelefono(string nuevoTelefono)
        {
            Telefono = nuevoTelefono;
            Console.WriteLine($"Se actualizó el teléfono de {Nombre} {Apellido} a: {Telefono}");
        }

        public void CambiarCorreo(string nuevoCorreo)
        {
            Correo = nuevoCorreo;
            Console.WriteLine($"Se actualizó el correo de {Nombre} {Apellido} a: {Correo}");
        }

        public void AsignarGenero(string nuevoGenero)
        {
            Genero = nuevoGenero;
            Console.WriteLine($"Se asignó el género '{Genero}' a {Nombre}");
        }
        
        public void AsignarEtiqueta(string nuevaEtiqueta)
        {
            Etiqueta = nuevaEtiqueta;
            Console.WriteLine($"Se asignó la etiqueta '{Etiqueta}' a {Nombre}");
        }

        
        public void AsignarFechaDeNacimiento(string nuevaFecha)
        {
            FechaDeNacimiento = nuevaFecha;
            Console.WriteLine($"Se registró la fecha de nacimiento de {Nombre}: {FechaDeNacimiento}");
        }
        

        public override string ToString()
        {
            return $"{Nombre} {Apellido} ({Correo})";
        }
    }
}