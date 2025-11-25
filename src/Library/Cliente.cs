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

        public Cliente(string id, string nombre, string apellido, string telefono, string correo)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
            Correo = correo;

            Genero = string.Empty;
            FechaDeNacimiento = string.Empty;
        }

        public void ModificarInformacion(string atributo, string nuevoValor)
        {
            string atributoNormalizado = atributo.Trim().ToLower();
            switch (atributoNormalizado)
            {
                case "nombre":
                    this.Nombre = nuevoValor;
                    break;

                case "apellido":
                    this.Apellido = nuevoValor;
                    break;

                case "telefono":
                    this.Telefono = nuevoValor;
                    break;

                case "correo":
                    this.Correo = nuevoValor;
                    break;

                case "genero":
                    this.Genero = nuevoValor;
                    break;

                case "etiqueta":
                    this.AsignarEtiqueta(nuevoValor);
                    break;

                case "fechadenacimiento":
                    this.FechaDeNacimiento = nuevoValor;
                    break;

                default:
                    Console.WriteLine($"Atributo '{atributo}' no reconocido.");
                    break;
            }
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