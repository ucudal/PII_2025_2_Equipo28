// using System;
// using System.Globalization;
//
// namespace Library
// {
//     // Representa una interacción de tipo mensaje con un cliente y el usuario.
//     // 
//     // SRP
//     // La clase tiene la responsabilidad de definir el comportamiento
//     // y características específicas de una interacción que es mensaje.
//     // 
//     // Herencia y Polimorfismo 
//     // Llamadas hereda de Interaccion, usando sus atributos
//     // comunes y comportamientos básicos.
//     // Gracias al polimorfismo, puede tratarse como una interaccion
//     // en contextos donde se manejen distintos tipos de interacciones.
//     // 
//     // Expert
//     // Según el patrón Expert, esta clase es experta en manejar la información
//     // propia de las mensajes, como su tipo o contenido, sin delegar esa
//     // responsabilidad a otras clases.
//     // 
//     // LSP
//     // Cumple con el principio de sustitución de Liskov ya que puede reemplazar
//     // a su clase base sin alterar el comportamiento
//     // esperado del sistema. Donde se use una Interaccion, se puede usar un
//     // Mensajes sin romper la lógica.
//     public class Mensajes : Interaccion
//     {
//         public Mensajes(Usuario usuario, Cliente cliente, string tema, string mensaje, string cuando) : base(usuario,cliente,
//             tema, mensaje,cuando)
//         {
//                 this.Tipo = TipoInterracion.Mensaje;
//         }
//         }
//     }
//
//         
//     
