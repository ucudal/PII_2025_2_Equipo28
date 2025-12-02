using System;
using System.Globalization;

namespace Library
{
    /// <summary>
    /// Representa una interacción de tipo reunión entre un usuario y un cliente.
    ///
    /// <para><b>SRP:</b> La clase tiene una única responsabilidad:
    /// modelar los datos y el comportamiento específico de una reunión.
    /// No gestiona tareas ajenas como almacenamiento, UI o lógica de negocio externa.</para>
    ///
    /// <para><b>OCP:</b> Extiende el comportamiento de <c>Interaccion</c>
    /// sin modificar la clase base. Modifica atributos (como <c>Lugar</c>)
    /// y redefine reglas de fecha de forma segura.</para>
    ///
    /// <para><b>LSP:</b> Una instancia de <c>Reunion</c> puede reemplazar a
    /// <c>Interaccion</c> sin alterar el funcionamiento del sistema.
    /// Cumple el contrato base y respeta las expectativas de uso.</para>
    ///
    /// <para><b>Polymorphismo:</b>
    /// Utiliza polimorfismo para redefinir la validación de fechas,
    /// adaptando el comportamiento sin romper la estructura general.</para>
    ///
    /// <para><b>Expert:</b>
    /// Es experta en gestionar todo lo realacionado a reunion (nose porque esta azul)
    /// lugar, fecha y participantes. Contiene los datos y la lógica necesaria.</para>
    ///
    /// <para><b>Bajo Acomplamiento:</b>
    /// Mantiene bajo acoplamiento al depender únicamente de <c>Usuario</c>
    /// y <c>Cliente</c> como colegas directamente relevantes.</para>
    ///
    /// <para><b>Alta cohesion:</b>
    /// Sus atributos y métodos están claramente enfocados en la noción de
    /// una reunión, evitando responsabilidades ajenas.</para>
    ///
    /// <para><b>Herencia y Polimorfismo:</b>
    /// Hereda los atributos y comportamientos comunes de <c>Interaccion</c>,
    /// y redefine solo lo necesario para reuniones, aprovechando el polymorphismo.</para>
    ///
    /// </summary>
    public class Reunion : Interaccion
    {
        public Reunion(Usuario usuario, Cliente cliente, string tema, string lugar, string contenido, string fecha, Interaccion.TipoInterracion tipo=Interaccion.TipoInterracion.Reunion) :
            base(usuario, cliente,tipo, tema, contenido, fecha)
        {
            if (lugar == null)
            {
                throw new ArgumentNullException("Datos de interacion null");
            }

            if (string.IsNullOrEmpty(lugar))
            {
                throw new ArgumentException("datos de interaccion vacios");
            }

            this.Lugar = lugar; 
        }
        /// <summary>
        /// Metodo modificado de la clase base, par permitir fechas futuras.
        /// </summary>
        protected override void FechaIncorrecta(DateTime fecha) //Alterado para que reuniones pueda resgistar reuniones pasasdas y proximas a realizar
        {
            //En blanco a proposito
        }
    }
}
        
    

        
    
