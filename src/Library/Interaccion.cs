using System;
using System.Globalization;

namespace Library
{
    /// <summary>
    /// Representa una interacción entre un cliente y un usuario.
    ///
    /// <para><b>SRP:</b> La clase se ocupa exclusivamente de cambiar y validar una interacción.</para>
    ///
    /// <para><b>OCP:</b> Está diseñada para extenderse (por ejemplo, en <c>Reunion</c>)
    /// sin modificar su estructura base.</para>
    ///
    /// <para><b>LSP:</b> Las subclases pueden reemplazar a <c>Interaccion</c>
    /// sin alterar el funcionamiento previsto.</para>
    ///
    /// <para><b>DIP:</b> Depende de abstracciones externas (<c>Usuario</c>, <c>Cliente</c>)
    /// en lugar de crearlas internamente.</para>
    ///
    /// <para><b>Expert (GRASP):</b> La clase contiene toda la información necesaria
    /// para gestionarse a sí misma.</para>
    /// 
    /// <para><b>Bajo acomplamiento:</b> Sus dependencias externas son mínimas.</para>
    ///
    /// <para><b>Alta Cohesion:</b> Todos los atributos y métodos están directamente
    /// relacionados con el concepto de interacción.</para>
    ///
    /// <para><b>Polymorphism (GRASP):</b> Utiliza métodos virtuales para permitir comportamientos
    /// distintos en subclases.</para>
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
        /// /// <summary>
        /// Crea una nueva interacción.
        /// <para><b>SRP:</b> El constructor tiene una única responsabilidad:
        /// validar y asignar el estado inicial de la interacción.</para>
        /// <para><b>OCP:</b> La validación de fechas está delegada al método virtual
        /// <c>FechaIncorrecta</c>, permitiendo modificar el comportamiento sin modificar este código.</para>
        /// <para><b>LSP:</b> Las subclase <c>Reunion</c> puede reemplazar este comportamiento
        /// sin modificando la funcionalidad esperada.</para>
        /// <para><b>Expert:</b> La clase valida y usa su propia información (fecha, contenido,
        /// tema, usuario, cliente).</para>
        /// <para><b>Alta Cohesion:</b> Todas las validaciones pertenecen al proceso coherente de
        /// construir una interacción.</para>
        /// <para><b>Bajo Acoplamiento:</b> Solo depende de <c>Usuario</c>, <c>Cliente</c>
        /// y excepciones necesarias.</para>
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
        /// Agrega o modifica la nota de la interacción.
        /// <para><b>SRP:</b> Su única responsabilidad es validar y asignar la nota.</para>
        /// <para><b>LSP:</b> La subclase pueden definir cómo manejan notas sin romper la compatibilidad.</para>
        /// <para><b>Information Expert:</b> Interacción administra sus propias notas porque
        /// tiene toda la información necesaria.</para>
        /// <para><b>Alta Cohesion:</b> Manejar notas es parte integral de la interacción.</para>
        /// <para><b>Bajo Acoplamiento:</b> No depende de otras clases para su funcionamiento.</para>
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
        /// Define los tipos posibles de interacción.
        /// <para><b>SRP:</b> Su única responsabilidad es representar los valores permitidos.</para>
        /// <para><b>Polymorphism:</b> Permite que la subclase <c>Reunion</c>
        /// redefinan comportamientos según el tipo sin modificar <c>Interaccion</c>.</para>
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
        /// Valida que la fecha no sea posterior a la actual.
        /// <para><b>OCP:</b> Es <c>virtual</c>, permitiendo que las subclases redefinan la validación
        /// sin modificar la clase base.</para>
        /// <para><b>LSP:</b> La Subclase <c>Reunion</c> puede reemplazar este método
        /// manteniendo el contrato esperado por la clase base.</para>
        /// <para><b>Polymorphism:</b> Se redefine según el tipo de interacción
        /// evitando condicionales como <c>if(tipo == Reunion)</c>.</para>
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
