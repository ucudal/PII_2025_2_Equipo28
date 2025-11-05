using System;
using System.Globalization;

namespace Library
{
    /// Representa una interacción de tipo correo con un cliente y el usuario.
    /// 
    /// SRP
    /// La clase tiene la responsabilidad de definir el comportamiento
    /// y características específicas de una interacción que es correo.
    /// 
    /// Herencia y Polimorfismo 
    /// Llamadas hereda de Interaccion, usando sus atributos
    /// comunes y comportamientos básicos.
    /// Gracias al polimorfismo, puede tratarse como una interaccion
    /// en contextos donde se manejen distintos tipos de interacciones.
    /// 
    /// Expert
    /// Según el patrón Expert, esta clase es experta en manejar la información
    /// propia de las correos, como su tipo o contenido, sin delegar esa
    /// responsabilidad a otras clases.
    /// 
    /// LSP
    /// Cumple con el principio de sustitución de Liskov ya que puede reemplazar
    /// a su clase base sin alterar el comportamiento
    /// esperado del sistema. Donde se use una Interaccion, se puede usar un
    /// Correos sin romper la lógica.

    public class Correos : Interaccion
    {
        public Correos(Cliente cliente, string tema, string correo, string cuando = "00/00/0000") : base(cliente, tema,correo)
        {
            if (cliente == null || tema == null || correo == null || cuando == null)
            {
                throw new ArgumentNullException();
            }

            if (tema == "" || correo == "" || cuando == "")
            {
                throw new Excepciones.EmptyStringException();
            }
            if (cuando != "00/00/0000")
            {
                DateTime fecha;
                if (DateTime.TryParseExact(cuando, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha))
                {
                    this.Fecha = fecha;
                }
                else
                {
                    Console.WriteLine("Fecha no valida");
                    throw new Excepciones.InvalidDateException();
                }
            }
            this.Tipo = TipoInterracion.Correo;
        }
    }
}