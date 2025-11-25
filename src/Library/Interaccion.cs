using System;
using System.Globalization;

namespace Library
{
    /// <summary>
    /// <para><b>SRP:</b> Esta clase cumple el principio de responsabilidad única ya que su única función es modelar la información
    /// y el comportamiento relacionado a una interacción específica (mensaje, llamada o reunión) entre un cliente y un usuario.</para>
    /// 
    /// <para><b>Expert:</b> Siguiendo el patrón Expert, la clase Interaccion es experta en manejar sus propios datos,
    /// ya que contiene toda la información necesaria sobre la interacción (cliente, tema, fecha, contenido, notas, etc.) y provee un método para modificar sus notas.</para>
    /// 
    /// <para><b>Polimorfismo:</b> Esta clase actua como clase base para el tipo de interacción de reunión,
    /// permitiendo que la clase derivada utilice sus atributos y métodos sin modificar la clase original.</para>
    /// 
    /// <para><b>LSP:</b> Al crear la subclase de Interaccion (Reunion),
    /// esta pueden reemplazar a Interaccion sin alterar el funcionamiento del sistema, dado que comparten los mismos atributos y comportamientos básicos,
    /// excepto las extensiones propias.</para>
    ///
    /// <para><b>Alta cohesion:</b>Esta clase tiene alta cohesión porque todos sus atributos y
    /// métodos están directamente relacionados con la ideac de representar una interacción entre un cliente y un usuario. </para>
    ///
    ///<para><b>Bajo acoplamiento:</b>Esta clase depende unicamnete de usuario y cliente, por lo que tiene una baja dependencia. </para>
    /// </summary>

    public class Interaccion
    {
        public string Notas { get; protected set; }
        public Cliente Cliente { get; protected set; }
        public Usuario Usuario { get; protected set; }
        public string Tema { get; protected set; }
        public DateTime Fecha { get; protected set; }
        public TipoInterracion Tipo { get; protected set; }
        public string Contenido { get; protected set; }
        public string Lugar { get; protected set; }
        /// <summary>
        /// Es el creador de Interaccion.
        /// </summary>
        /// <param name="usuario">Recibe un usuario</param>
        /// <param name="cliente">Recibe un cliente</param>
        /// <param name="tipo">Recibe un tipo, el cual se espera que sea correo, mensaje, llamada. Reunion se hace con una clase herencia</param>
        /// <param name="tema">Recibe el tema de la interaccion</param>
        /// <param name="contenido">Recibe el contenido de la interaccion</param>
        /// <param name="fecha">Recibe la fecha en la cual se realizo la interaccion</param>
        /// <exception cref="ArgumentNullException">Tira una excepcion en caso de que algun parametro sea null</exception>
        /// <exception cref="ArgumentException">Tira una excepcion en el caso de que algun parametro de tipo string este vacio. Esta aparte de la anterior excepcion para poder diferenciar entre null y vacio</exception>
        /// <exception cref="InvalidDateException">Tira una excepcion en caso de que la fecha sea no respete el formato dado o no sea una fecha</exception>
        public Interaccion(Usuario usuario, Cliente cliente, Interaccion.TipoInterracion tipo, string tema, string contenido, string fecha)
        {
            if (cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente), "El cliente no puede ser null.");
            }
            
            if (tema == null)
            {
                throw new ArgumentNullException(nameof(tema), "El tema no puede ser null.");
            }
            
            if (contenido == null)
            {
                throw new ArgumentNullException(nameof(contenido), "El contenido no puede ser null.");
            }
            
            if (fecha == null)
            {
                throw new ArgumentNullException(nameof(fecha), "La fecha no puede ser null.");
            }
            
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario), "El usuario no puede ser null.");
            }
            //
            // if (string.IsNullOrEmpty(tipo))
            // {
            //     throw new ArgumentException("El tipo no puede estar vacío.", nameof(tipo));
            // }

            if (string.IsNullOrEmpty(contenido))
            {
                throw new ArgumentException("El contenido no puede estar vacío.", nameof(contenido));
            }

            if (string.IsNullOrEmpty(fecha))
            {
                throw new ArgumentException("La fecha no puede estar vacía.", nameof(fecha));
            }

            if (string.IsNullOrEmpty(tema))
            {
                throw new ArgumentException("El tema no puede estar vacío.", nameof(tema));
            }
            
            DateTime fechaFinal = new DateTime();
            if (DateTime.TryParseExact(fecha, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out fechaFinal))
            {
                this.FechaIncorrecta(fechaFinal);
                this.Fecha = fechaFinal;
            }
            else
            {
                throw new InvalidDateException($"la fecha no es valida. Recuerda escribir una fecha anterior o identica a la fecha actual, y usar el fomranto dd/mm/yyyy",nameof(fecha));
            }
            // tipo = tipo.ToLower();
            // Interaccion.TipoInterracion tipoFinal = Interaccion.TipoInterracion.Nada; //para inicializarlo
            // switch (tipo)
            // {
            //     case "mensaje":
            //         tipoFinal = Interaccion.TipoInterracion.Mensaje;
            //         break;
            //     case "llamada":
            //         tipoFinal = Interaccion.TipoInterracion.Llamada;
            //         break;
            //     case "correo":
            //         tipoFinal = Interaccion.TipoInterracion.Correo;
            //         break;
            //     case "reunion":
            //         tipoFinal = Interaccion.TipoInterracion.Reunion;
            //         break;
            // }
            this.Cliente = cliente;
            this.Tema = tema;
            this.Contenido = contenido;
            this.Usuario = usuario;
            this.Tipo = tipo;
        }

        /// <summary>
        /// Agrega una nota a la interaccion
        /// </summary>
        /// <param name="nota">La nota en cuestion</param>
        public void AgergarNotas(string nota)
        {
            if (nota == null)
            {
                throw new ArgumentNullException(nameof(nota),"El contenido de la nota es null");
            }

            if (string.IsNullOrEmpty(nota))
            {
                throw new ArgumentException("el contenido de la nota esta vacio",nameof(nota));
            }

            this.Notas = nota;
        }
        /// <summary>
        /// Define los tipo de interaccion posibles
        /// </summary>
        public enum TipoInterracion
        {
            Mensaje,
            Llamada,
            Reunion,
            Correo,
            Nada //Solo para inicializar el tipo en un metodo
        }
        /// <summary>
        /// Sirve para identificar si una fecha es valida al ser anterior o igual al dia actual
        /// </summary>
        /// <param name="fecha">la fecha a revisar</param>
        /// <exception cref="InvalidDateException">Tira una excepxion si la fecha es posterior a la actual</exception>
        protected virtual void
            FechaIncorrecta(DateTime fecha) //metodo creado para que no pudan usar fechas futuras (excepto en reuniones)
        {
            if (!(fecha <= DateTime.Today))
            {
                throw new InvalidDateException($"La fecha no es valida. Escriba una fecha anterior o igual a la fecha actual",nameof(fecha));
            }
        }
    }
}
