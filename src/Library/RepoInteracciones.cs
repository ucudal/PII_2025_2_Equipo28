using System;
using System.Collections.Generic;
using System.Globalization;

namespace Library
{
    /// <summary>
    /// - Creator: porque contiene, agrega y utiliza instancias de Interaccion, por lo que es responsable de crearlas.
    /// - Expert: porque posee la información necesaria (la lista de interacciones) para buscarlas y filtrarlas.
    /// - Polimorfismo: almacena Interaccion y su subtipo (Reunion), tratándolos de forma igual.
    /// - SRP: tiene una única responsabilidad: gestionar interacciones (crear, almacenar y buscar).
    /// - Alta Cohesión: todos sus métodos pertenecen al propósito de administrar interacciones.
    /// - Bajo Acoplamiento: depende unicamente de Usuario, Cliente e Interaccion.
    /// </summary>
    public class RepoInteracciones
    {
        /// <summary>
        /// Lista que almacena las interacciones.
        /// </summary>
        private List<Interaccion> Interacciones = new List<Interaccion>();
        /// <summary>
        /// Lista de interaciiones de solo lectura.
        /// </summary>
        public IEnumerable<Interaccion> InteraccionesLectura
        {
            get { return Interacciones; } 
        }
        /// <summary>
        /// Métodos responsables de crear e inicializar diferentes tipos de Interaccion.
        /// (Mensaje, Llamada, Correo y Reunión).  
        /// Cada método valida los datos recibidos y devuelve una instancia creada.
        /// </summary>
        /// <param name="usuario">Usuario que realiza la interacción.</param>
        /// <param name="cliente">Cliente asociado a la interacción.</param>
        /// <param name="tema">Tema de la interacción.</param>
        /// <param name="contenido">Contenido o descripción de la interacción.</param>
        /// <param name="fecha">Fecha de la interacción, formato dd/MM/yyyy (posibilidad de ser futura para Reunion).</param>
        /// <param name="lugar">Lugar de la interacion(Usado unicamente por Reunion).</param>
        /// <returns>Una nueva instancia de Interaccion del tipo correspondiente.</returns>

        public Interaccion CrearMensaje(Usuario usuario, Cliente cliente, string tema, string contenido, string fecha)
        {
            this.GneradordeExcepcionesParaMetodosCrearInteraccion(usuario,  cliente,  tema,  contenido,  fecha);
            return new Interaccion(usuario, cliente, Interaccion.TipoInterracion.Mensaje, tema, contenido, contenido);
        }
        public Interaccion CrearLlamada(Usuario usuario, Cliente cliente, string tema, string contenido, string fecha)
        {
            this.GneradordeExcepcionesParaMetodosCrearInteraccion(usuario,  cliente,  tema,  contenido,  fecha);

            return new Interaccion(usuario, cliente, Interaccion.TipoInterracion.Llamada, tema, contenido, contenido);
        }
        public Interaccion CrearCorreo(Usuario usuario, Cliente cliente, string tema, string contenido, string fecha)
        {
            this.GneradordeExcepcionesParaMetodosCrearInteraccion(usuario,  cliente,  tema,  contenido,  fecha);

            return new Interaccion(usuario, cliente, Interaccion.TipoInterracion.Correo, tema, contenido, contenido);
        }
        public Interaccion CrearReunion(Usuario usuario, Cliente cliente, string tema, string contenido, string fecha, string lugar)
        {
            this.GneradordeExcepcionesParaMetodosCrearInteraccion(usuario,  cliente,  tema,  contenido,  fecha);
            if (lugar == null)
            {
                throw new ArgumentNullException(nameof(lugar), "El lugar no puede ser null.");
            }
            if (string.IsNullOrEmpty(lugar))
            {
                throw new ArgumentException("El lugar no puede estar vacio.", nameof(lugar));
            }
            return new Reunion(usuario, cliente, tema, lugar, contenido, contenido);
        }
        /// <summary>
        /// Busca una interracion por el usuario, tipo y tema.
        /// </summary>
        /// <param name="usuario">Usuario que realizo la interaccion</param>
        /// <param name="tipo">tipo de la interracion (mensaje, correo, llamada o reunion)</param>
        /// <param name="tema">tema de la interaccion</param>
        /// <returns>Devuelve la interracion que contenga y coinsida los paramtetros dados</returns>
        public Interaccion BuscarInteraccion(Usuario usuario, string tipo, string tema)
        {
            if (tipo == "" || tema == "")
            {
                throw new ArgumentException("datos vacios");
            }

            if (usuario == null||tipo==null||tema==null)
            {
                throw new ArgumentNullException("el usuario es null");
            }
            tipo = tipo.ToLower();
            Interaccion.TipoInterracion tipoFinal = Interaccion.TipoInterracion.Nada; //para inicializarlo
            switch (tipo)
            {
                case "mensaje":
                    tipoFinal = Interaccion.TipoInterracion.Mensaje;
                    break;
                case "reunion":
                    tipoFinal = Interaccion.TipoInterracion.Reunion;
                    break;
                case "llamada":
                    tipoFinal = Interaccion.TipoInterracion.Llamada;
                    break;
                case "correo":
                    tipoFinal = Interaccion.TipoInterracion.Correo;
                    break;
            }

            foreach (Interaccion interaccion in Interacciones)
            {
                if (interaccion.Tipo == tipoFinal && interaccion.Tema == tema && interaccion.Usuario == usuario)
                {
                    return interaccion;
                }
            }

            Console.WriteLine("No se encontro la interaccion");
            return null;
        }
        /// <summary>
        /// Variante de BuscarInterracion que busca en base al usuario y cliente, siendo el tipo y fecha dados de caracter opcional.
        /// </summary>
        /// <param name="usuario">Usuario que realizo la o las interaciones</param>
        /// <param name="cliente">Cliente asociado a la o las interacciones</param>
        /// <param name="tipo">Tipo de la o las interraciones (mensaje, correo, llamada o reunion)</param>
        /// <param name="fecha">La fecha en la cual se produjo la o las interraciones</param>
        /// <returns>Devueleve una lista con la o las interraciones que coincidieron con los parametros de busca brindados</returns>
        public List<Interaccion> BuscarInteraccion(Usuario usuario, Cliente cliente, string tipo = "", string fecha = "")
        {
            if (cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente), "El cliente no puede ser null.");
            }

            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario), "El usuario no puede ser null.");
            }

            if (tipo == null)
            {
                tipo = "";
            }

            if (fecha == null)
            {
                fecha ="01/01/0001";
            }

            DateTime FechaFinal;
            if (DateTime.TryParseExact(fecha, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out FechaFinal))
            {
                //en blanco a posta 
            }
            else
            {
                Console.WriteLine("Fecha no valida");
                throw new InvalidDateException($"la fecha no es valida. Recuerda usar el formato dd/mm/yyyy",nameof(fecha));
            }

            tipo = tipo.ToLower();
            Interaccion.TipoInterracion tipoFinal = Interaccion.TipoInterracion.Nada; //para inicializarlo
            switch (tipo)
            {
                case "mensaje":
                    tipoFinal = Interaccion.TipoInterracion.Mensaje;
                    break;
                case "reunion":
                    tipoFinal = Interaccion.TipoInterracion.Reunion;
                    break;
                case "llamada":
                    tipoFinal = Interaccion.TipoInterracion.Llamada;
                    break;
                case "correo":
                    tipoFinal = Interaccion.TipoInterracion.Correo;
                    break;
            }

            List<Interaccion> interaccionesCliente = new List<Interaccion>();
            if (tipo != "" && fecha != "01/01/0001")
            {
                foreach (Interaccion interaccion in Interacciones)
                {
                    if (interaccion.Tipo == tipoFinal && interaccion.Fecha == FechaFinal && interaccion.Usuario==usuario)
                    {
                        interaccionesCliente.Add(interaccion);
                    }
                }

            }
            else if (tipo != "" && fecha == "01/01/0001")
            {
                foreach (Interaccion interaccion in Interacciones)
                {
                    if (interaccion.Tipo == tipoFinal && interaccion.Usuario==usuario)
                    {
                        interaccionesCliente.Add(interaccion);
                    }
                }
            }
            else if (tipo == "" && fecha != "01/01/0001")
            {
                foreach (Interaccion interaccion in Interacciones)
                {
                    if (interaccion.Fecha == FechaFinal && interaccion.Usuario==usuario)
                    {
                        interaccionesCliente.Add(interaccion);
                    }
                }
            }
            else 
            {
                foreach (Interaccion interaccion in Interacciones)
                {
                    if (interaccion.Usuario==usuario)
                        interaccionesCliente.Add(interaccion);
                }
            }

            return interaccionesCliente;
        } 
        /// <summary>
        /// Metodo que agrega una interaccion a la lista de interacciones.
        /// </summary>
        /// <param name="interaccion">La interaccion a agregar</param>
        /// <param name="usuario">El usuario, para verficar que el que ejecute el metodo sea un usuario valido</param>
        public void AgregarInteraccion(Interaccion interaccion, Usuario usuario)
        {
            if (interaccion == null)
            {
                throw new ArgumentNullException(nameof(interaccion), "La interacción no puede ser null.");
            }

            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario), "El usuario no puede ser null.");
            }
            Interacciones.Add(interaccion);
            usuario.AgregarInteraccion(interaccion);
        }
        /// <summary>
        /// Metodo que devuelve las ultimas interraciones de los clientes de un usuario.
        /// </summary>
        /// <param name="usuario">El usuario que realizo las interacciones con sus clientes</param>
        /// <returns>Devuelve un diccionario con el cliente como llave y la interaccion mas reciente como valor</returns>
        public Dictionary<Cliente,Interaccion> UltimasInteraccionesClientes(Usuario usuario)
        {
            if (usuario==null)
            {
                throw new ArgumentNullException(nameof(usuario), "El usuario no puede ser null.");
                
            }
            Dictionary<Cliente, Interaccion> UltimaInterracion = new Dictionary<Cliente, Interaccion>();
            foreach (Interaccion interaccion in Interacciones)
            {
                if (UltimaInterracion.ContainsKey(interaccion.Cliente))
                {
                    if (UltimaInterracion[interaccion.Cliente].Fecha <= interaccion.Fecha && !(interaccion.Fecha > DateTime.Now))
                    {
                        UltimaInterracion[interaccion.Cliente] = interaccion;
                    }
                }
                else
                {
                    UltimaInterracion[interaccion.Cliente] = interaccion;
                }
            }

            return UltimaInterracion;
        }
        /// <summary>
        /// Metodo creado para limpiar la lista de interracion. Creado para los test
        /// </summary>
        public void eliminarinteraciones()//ciertos test no funcionan sin esto
        {
            Interacciones.Clear();
        }
        /// <summary>
        /// Metodo con las excepciones para los metodos CrearMensaje, CrearCorreo...
        /// </summary>
        /// <exception cref="ArgumentNullException">Tira un mensaje de que el valor revisado no pude ser null, y muestra el valor</exception>
        /// <exception cref="ArgumentException">Tira un mensaje de que el valor revisado no pude estar vacio, y muestra el valor</exception>
        public void GneradordeExcepcionesParaMetodosCrearInteraccion(Usuario usuario, Cliente cliente, string tema, string contenido, string fecha)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario), "El usuario no puede ser null.");
            }

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
            
            if (string.IsNullOrEmpty(tema))
            {
                throw new ArgumentException("El tema no puede estar vacío.", nameof(tema));
            }

            if (string.IsNullOrEmpty(contenido))
            {
                throw new ArgumentException("El contenido no puede estar vacío.", nameof(contenido));
            }

            if (string.IsNullOrEmpty(fecha))
            {
                throw new ArgumentException("La fecha no puede estar vacía.", nameof(fecha));
            }
        }
    }
}