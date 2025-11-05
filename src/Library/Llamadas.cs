using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Library
{
    // Representa una interacción de tipo llamada con un cliente y el usuario.
    // 
    // SRP
    // La clase tiene la responsabilidad de definir el comportamiento
    // y características específicas de una interacción que es llamada.
    // 
    // Herencia y Polimorfismo 
    // Llamadas hereda de Interaccion, usando sus atributos
    // comunes y comportamientos básicos.
    // Gracias al polimorfismo, puede tratarse como una interaccion
    // en contextos donde se manejen distintos tipos de interacciones.
    // 
    // Expert
    // Según el patrón Expert, esta clase es experta en manejar la información
    // propia de las llamadas, como su tipo o contenido, sin delegar esa
    // responsabilidad a otras clases.
    // 
    // LSP
    // Cumple con el principio de sustitución de Liskov ya que puede reemplazar
    // a su clase base sin alterar el comportamiento
    // esperado del sistema. Donde se use una Interaccion, se puede usar una
    // Llamadas sin romper la lógica.
    public class Llamadas : Interaccion
    {
        
        public Llamadas(Cliente cliente, string tema,string llamada,string cuando = "00/00/0000") : base(cliente, tema,llamada)
        {
            if (cliente == null || tema == null || llamada == null || cuando == null)
            {
                throw new ArgumentNullException();
            }

            if (tema == "" || llamada == "" || cuando == "")
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
                this.Tipo = TipoInterracion.Llamada;
            }

        }
    }
}