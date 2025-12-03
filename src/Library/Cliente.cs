using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// - Expert: porque es responsable de manejar su propia información y conoce todos los datos relevantes de un cliente.
    /// - SRP: tiene una única responsabilidad: modelar un cliente y permitir modificar su información básica.
    /// - Alta Cohesión: todos sus métodos y atributos pertenecen al propósito de representar y gestionar la información de un cliente.
    /// </summary>
    public class Cliente
    {
        public string Id { get;  }
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public string Telefono { get; private set; }
        public string Correo { get; private set; }
        public string Genero { get; private set; }
        public List<string> Etiquetas { get; } = new List<string>();
        public string FechaDeNacimiento { get; private set; }
        

        /// <summary>
        /// Constructor de la clase Cliente
        /// </summary>
        /// <param name="id">Id del Cliente</param>
        /// <param name="nombre">Nombre del Cliente</param>
        /// <param name="apellido">Apellido del Cliente</param>
        /// <param name="telefono">Telefono del Cliente</param>
        /// <param name="correo">Correo del Cliente</param>
        public Cliente(string id, string nombre, string apellido, string telefono, string correo)
        {
            if (string.IsNullOrWhiteSpace(id)) {
                throw new ArgumentException("El ID no puede estar vacío.");
            }

            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre no puede estar vacío.");
            } 

            if (string.IsNullOrWhiteSpace(apellido))
            {
                throw new ArgumentException("El apellido no puede estar vacío.");
            }

            if (string.IsNullOrWhiteSpace(telefono))
            {
                throw new ArgumentException("El telefono no puede estar vacío.");
            }

            if (string.IsNullOrWhiteSpace(correo))
            {
                throw new ArgumentException("El correo no puede estar vacío.");
            }

            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
            Correo = correo;

            Genero = string.Empty;
            FechaDeNacimiento = string.Empty;
        }

        /// <summary>
        /// Modifica la información del cliente
        /// </summary>
        /// <param name="atributo">Atributo a modificar</param>
        /// <param name="nuevoValor">Nuevo valor del atributo</param>
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
            }
        }
        
        /// <summary>
        /// Asigna una etiqueta al cliente
        /// </summary>
        /// <param name="nuevaEtiqueta">Etiqueta a asignar</param>
        public string AsignarEtiqueta(string nuevaEtiqueta)
        {
            Etiquetas.Add(nuevaEtiqueta);
            return $"Se asignó la etiqueta '{nuevaEtiqueta}' a {Nombre}";
        }
        
        /// <summary>
        /// Devuelve una representación string del cliente
        /// </summary>
        /// <returns>Representación string del cliente</returns>
        public override string ToString()
        {
            string etiquetas = "";
            foreach (string e in Etiquetas)
            {
                etiquetas += e + ",";
            }    
            return $"{Nombre} {Apellido} - Id: {Id}\nCorreo: {Correo}\nTelefono: {Telefono}\nGenero: {Genero}\nFecha de nacimiento: {FechaDeNacimiento}\nEtiquetas: {etiquetas}";
        }
    }
}
    