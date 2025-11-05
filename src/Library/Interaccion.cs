using System;

namespace Library
{   //SRP 
    // Esta clase cumple el principio de responsabilidad única ya que
    // su única función es modelar la información y comportamiento
    // relacionado a una interacción específica (como un mensaje, llamada o reunión)
    // entre un cliente y un usuario.
    // 
    // Expert
    // Siguiendo el patrón Expert, la clase Interaccion es la experta en
    // manejar sus propios datos, ya que contiene toda la información necesaria
    // sobre la interacción (cliente, tema, fecha, contenido, notas, etc.)
    // y contiene un método para modificar sus notas.
    // 
    // Polimorfismo
    // Esta clase puede actua como clase base para diferentes tipos de interacciones
    // (por ejemplo, llamadas, mensajes, reuniones), permitiendo que clases derivadas
    // usen sus atributos y metodos sin modificar esta clase directamente.
    // 
    // LSP
    // Al crear subclases de Interaccion (por ejemplo, Llamada o Mensaje),
    // estas reemplazan a Interaccion sin alterar el funcionamiento del sistema,
    // ya que todas compartirían los mismos atributos y comportamientos básicos.
    public class Interaccion
    {
        public string Notas { get; set; }
        public Cliente Cliente { get; set; }
        public string Tema { get; set; }
        public DateTime Fecha { get; set; }
        public TipoInterracion Tipo { get; set; }
        public string Contenido { get; set; }
        public string Lugar { get; set; }
        public Interaccion(Cliente cliente, string tema, string contenido)
        {
            this.Cliente = cliente;
            this.Tema = tema;
            this.Fecha = DateTime.Today;
            this.Contenido = contenido;
        }

        public void AgergarNotas(string notas)
        {
            this.Notas = notas;

        }
        public enum TipoInterracion
        {
            Mensaje,
            Llamada,
            Reunion,
            Correo,
            Nada //Solo por necesidad
        }
    }
}