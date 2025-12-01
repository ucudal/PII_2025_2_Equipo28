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
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Genero { get; set; }
        public List<string> Etiquetas { get; set; } = new List<string>();
        public string FechaDeNacimiento { get; set; }
        

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

                default:
                    Console.WriteLine($"Atributo '{atributo}' no reconocido.");
                    break;
            }
        }
        
        /// <summary>
        /// Asigna una etiqueta al cliente
        /// </summary>
        /// <param name="nuevaEtiqueta">Etiqueta a asignar</param>
        public void AsignarEtiqueta(string nuevaEtiqueta)
        {
            Etiquetas.Add(nuevaEtiqueta);
            Console.WriteLine($"Se asignó la etiqueta '{nuevaEtiqueta}' a {Nombre}");
        }
        
        /// <summary>
        /// Devuelve una representación string del cliente
        /// </summary>
        /// <returns>Representación string del cliente</returns>
        public override string ToString()
        {
            return $"{Nombre} {Apellido} ({Correo}) - Id: {Id}";
        }
        
        /// <summary>
        /// Asigna un vendedor a este cliente.
        /// </summary>
        /// <param name="vendedor">Vendedor que se quiere asignar.</param>
        /// <exception cref="ArgumentNullException">Si el vendedor es null.</exception>
        /*public void AsignarVendedor(Usuario vendedor)
        {
            if (vendedor == null)
            {
                throw new ArgumentNullException(nameof(vendedor), "El vendedor no puede ser null.");
            }

            this.VendedorAsignado = vendedor;
        }*/
    }
}
    