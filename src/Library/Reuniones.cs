using System;
using System.Globalization;

namespace Library
{
    // Representa una interacción de tipo reunión con un cliente y un usuario.
    // 
    // SRP 
    // Esta clase tiene la responsabilidad de modelar las características
    // y comportamientos específicos de una reunión, diferenciándola de otros
    // tipos de interacciones como llamadas o mensajes.
    // 
    // Expert
    // Según el patrón Expert, la clase Reunion es la más experta
    // en gestionar la información de una reunión, ya que conoce su ubicación,
    // la fecha y el cliente asociado, sin necesidad de depender de otras clases
    // para manejar esos datos.
    // 
    //Herencia y Polimorfismo 
    // Reunion hereda de Interaccion, usando sus atributos
    // comunes y comportamientos básicos.
    // Gracias al polimorfismo, puede tratarse como una interaccion
    // en contextos donde se manejen distintos tipos de interacciones.
    // 
    // LSP
    // Cumple con el principio de sustitución de Liskov ya que puede reemplazar
    // a su clase base sin alterar el comportamiento
    // esperado del sistema. Donde se use una Interaccion, se puede usar una
    // Reunion sin romper la lógica.
    public class Reunion : Interaccion
    {
        public Reunion(Cliente cliente, string tema, string lugar, string reunion, string cuando) :
            base(cliente, tema, reunion,cuando)
        {
            if (lugar == null)
            {
                throw new ArgumentNullException("Datos de interacion null");
            }

            if (lugar == "")
            {
                throw new Excepciones.EmptyStringException("datos de interaccion vacios");
            }
            this.Lugar = lugar;
            this.Tipo = TipoInterracion.Reunion;
            }
        }
    }

        
    
