using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace Library
{
    /// <summary>
    /// Fachada de la aplicacion
    /// </summary>
    public class Fachada
    {
        public Dictionary<Usuario, List<Cliente>> ClientesContacto = new Dictionary<Usuario, List<Cliente>>();
        public RepoEtiquetas Etiquetas = new RepoEtiquetas();
        public RepoClientes Clientes;
        public RepoInteracciones Interacciones = new RepoInteracciones();
        public RepoCotizaciones Cotizaciones = new RepoCotizaciones();
        public RepoVentas Ventas = new RepoVentas();
        public RepoUsuarios Usuarios = new RepoUsuarios();
        public List<Usuario> UsuariosSuspendidos = new List<Usuario>();
        public List<Reunion> Reuniones = new List<Reunion>();

        private Fachada()
        {
            this.Clientes = new RepoClientes(this.Etiquetas, this.Usuarios);
        }
        private static Fachada instancia;

        public static Fachada Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new Fachada();
                return instancia;
            }
        }
        /// <summary>
        /// El metodos RegistrarMensaje crea una instancia de interaccion de tipo mensaje y la guarda en repoInteracciones.
        /// Principios que cumple:
        /// - SRP: Se encarga únicamente de registrar mensajes.
        /// - EXPERT: Maneja la información necesaria para validar y crear la interacción.
        /// - Bajo acoplamiento: Mantiene dependencias mínimas fuera del método.
        /// - Alta cohesion: Cada línea del método contribuye al registro del mensaje.
        /// </summary>
        /// <param name="clienteId">El id del cliente al cual asociar la interaccion, para buscarlo</param>
        /// <param name="contenido (mensaje,llamada,correo,reunion)">El contenido o descipcion de la interaccion</param>
        /// <param name="tema">El tema de la interaccion</param>
        /// <param name="usuarioId">El id del usuario al cual asociar la interaccion, para busarlo y verficar que sea valido</param>
        /// <param name="fecha">La fecha en la cual se realizo la interracion</param>
        /// <returns>Devuelve un mensaje confirmado que el registro fue un exito, o comentado que hubo un error, cual fue y donde fue</returns>
        public string RegistrarMensaje(string clienteId, string contenido, string tema,
            string usuarioId, string fecha)
        {
            Usuario usuario = null;
            Interaccion Mensaje = null; //Inicializando larailala
            Cliente cliente = null;
            try
            {
                usuario = this.Usuarios.BuscarUsuario(usuarioId);
                cliente = Clientes.BuscarUnCliente(clienteId);
                Mensaje = Interacciones.CrearMensaje(usuario, cliente, tema, contenido, fecha);
            }
            catch (ArgumentNullException e)
            {
                return $"{e.Message} {e.ParamName}";
            }
            catch (InvalidDateException e)
            {
                return $"{e.Message} {e.ParamName}";

            }
            catch (ArgumentException e)
            {
                return $"{e.Message} {e.ParamName}";

            }
            if (usuario != null)
            {
                if (cliente != null)
                {
                    Interacciones.AgregarInteraccion(Mensaje, usuario);
                    return "Mensaje registrado";
                }

                return "no se encontro al cliente";
            }

            return "No se encontro al usuario";
        }

        /// <summary>
        /// El metodos RegistrarCorreo crea una instancia de interaccion de tipo correo y la guarda en repoInteracciones.
        /// Principios que cumple:
        /// - SRP: Se encarga únicamente de registrar correo.
        /// - EXPERT: Maneja la información necesaria para validar y crear la interacción.
        /// - Bajo acoplamiento: Mantiene dependencias mínimas fuera del método.
        /// - Alta cohesion: Cada línea del método contribuye al registro del correo.
        /// </summary>
        /// <param name="clienteId">El id del cliente al cual asociar la interaccion, para buscarlo</param>
        /// <param name="contenido (mensaje,llamada,correo,reunion)">El contenido o descipcion de la interaccion</param>
        /// <param name="tema">El tema de la interaccion</param>
        /// <param name="usuarioId">El id del usuario al cual asociar la interaccion, para busarlo y verficar que sea valido</param>
        /// <param name="fecha">La fecha en la cual se realizo la interracion</param>
        /// <returns>Devuelve un mensaje confirmado que el registro fue un exito, o comentado que hubo un error, cual fue y donde fue</returns>
        public string RegistrarCorreo(string clienteId, string contenido, string tema,
            string usuarioId, string fecha)
        {
            Usuario usuario = null;
            Interaccion Correo = null; //Inicializando larailala
            Cliente cliente = null;
            try
            {
                usuario = this.Usuarios.BuscarUsuario(usuarioId);
                cliente = Clientes.BuscarUnCliente(clienteId);
                Correo = Interacciones.CrearCorreo(usuario,cliente, tema, contenido, fecha);
            }
            catch (ArgumentNullException e)
            {
                return $"{e.Message} {e.ParamName}";
            }
            catch (InvalidDateException e)
            {
                return $"{e.Message} {e.ParamName}";

            }
            catch (ArgumentException e)
            {
                return $"{e.Message} {e.ParamName}";

            }

            if (usuario != null)
            {
                if (cliente != null)
                {
                    Interacciones.AgregarInteraccion(Correo, usuario);
                    return "Correo registrado";
                }
           
                return "no se encontro al cliente";
            }

            return "No se encontro al usuario";
        }

        /// <summary>
        /// El metodos RegistrarLlamada crea una instancia de interaccion de tipo llamada y la guarda en repoInteracciones.
        /// Principios que cumple:
        /// - SRP: Se encarga únicamente de registrar una llamdada.
        /// - EXPERT: Maneja la información necesaria para validar y crear la interacción.
        /// - Bajo acoplamiento: Mantiene dependencias mínimas fuera del método.
        /// - Alta cohesion: Cada línea del método contribuye al registro de la llamada.
        /// </summary>
        /// <param name="clienteId">El id del cliente al cual asociar la interaccion, para buscarlo</param>
        /// <param name="contenido (mensaje,llamada,correo,reunion)">El contenido o descipcion de la interaccion</param>
        /// <param name="tema">El tema de la interaccion</param>
        /// <param name="usuarioId">El id del usuario al cual asociar la interaccion, para busarlo y verficar que sea valido</param>
        /// <param name="fecha">La fecha en la cual se realizo la interracion</param>
        /// <returns>Devuelve un mensaje confirmado que el registro fue un exito, o comentado que hubo un error, cual fue y donde fue</returns>
        public string RegistrarLlamada(string clienteId, string contenido, string tema,
            string usuarioId, string fecha)
        {
            Usuario usuario = null;
            Interaccion LLamada = null; //Inicializando larailala
            Cliente cliente = null;
            try
            {
                usuario = this.Usuarios.BuscarUsuario(usuarioId);
                cliente = Clientes.BuscarUnCliente(clienteId);

                LLamada = Interacciones.CrearLlamada(usuario, cliente, tema, contenido, fecha);

            }
            catch (ArgumentNullException e)
            {
                return $"{e.Message} {e.ParamName}";
            }
            catch (InvalidDateException e)
            {
                return $"{e.Message} {e.ParamName}";

            }
            catch (ArgumentException e)
            {
                return $"{e.Message} {e.ParamName}";

            }

            if (usuario != null)
            {
                if (cliente != null)
                {
                    Interacciones.AgregarInteraccion(LLamada, usuario);
                    return "Mensaje registrado";
                }
            
                return "no se encontro al cliente";
            }

            return "No se encontro al usuario";
        }
        /// <summary>
        /// El metodos RegistrarReunion crea una instancia de Reunion, subtipo de Interaccion, y la guarda en repoInteracciones.
        /// Principios que cumple:
        /// - SRP: Se encarga únicamente de registrar reuniones.
        /// - EXPERT: Maneja la información necesaria para validar y crear la interacción.
        /// - Bajo acoplamiento: Mantiene dependencias mínimas fuera del método.
        /// - Alta cohesion: Cada línea del método contribuye al registro del reuniones.
        /// </summary>
        /// <param name="clienteId">El id del cliente al cual asociar la interaccion, para buscarlo</param>
        /// <param name="contenido (mensaje,llamada,correo,reunion)">El contenido o descipcion de la interaccion</param>
        /// <param name="tema">El tema de la interaccion</param>
        /// <param name="usuarioId">El id del usuario al cual asociar la interaccion, para busarlo y verficar que sea valido</param>
        /// <param name="fecha">La fecha en la cual se realizo la interracion</param>
        /// /// <param name="lugar">El lugar en el cual se realizo la interracion</param>
        /// <returns>Devuelve un mensaje confirmado que el registro fue un exito, o comentado que hubo un error, cual fue y donde fue</returns>
        public string RegistrarReunion(string clienteId, string contenido, string tema,
            string usuarioId, string fecha, string lugar)
        {
            Usuario usuario = null;
            Interaccion Reunion = null; //Inicializando larailala
            Cliente cliente = null;
            try
            {
                usuario = this.Usuarios.BuscarUsuario(usuarioId);
                cliente = Clientes.BuscarUnCliente(clienteId);
                Reunion = Interacciones.CrearReunion(usuario, cliente, tema, contenido, fecha,lugar);

            }
            catch (ArgumentNullException e)
            {
                return $"{e.Message} {e.ParamName}";

            }
            catch (InvalidDateException e)
            {
                return $"{e.Message} {e.ParamName}";

            }
            catch (ArgumentException e)
            {
                return $"{e.Message} {e.ParamName}";

            }

            if (usuario != null)
            {
                if (cliente != null)
                {
                    Interacciones.AgregarInteraccion(Reunion, usuario);
                    return "Reunion registrada";

                }
          
                return "no se encontro al cliente";
            }

            return "No se encontro al usuario";
        }

        /// <summary>
        /// Agrega una nota a una interaccion ya existente.
        /// Principios que cumple:
        /// - SRP: Solo agrega una nota a una interacción.
        /// - EXPERT: La clase conoce cómo ubicar la interacción según tipo/tema y modificarla.
        /// - Bajo acoplamiento: No asume detalles internos de las interacciones más allá de lo público.
        /// - Alta cohesion: Todo el método sirve a la intencion de agregar una nota.
        /// </summary>

        /// </summary>
        /// <param name="nota">la nota a ser agregada</param>
        /// <param name="tipointeraccion">recibe un tipo de interaccion, para identificar la interaccion</param>
        /// <param name="tema">recibe el tema de la interaccion para identificar la interaccion</param>
        /// <param name="usuarioId">recibe el id del usuario asociado a la interaccion</param>
        /// <returns>debuelve la confirmacion de que se agrego la nota. de lo contrario devuelbe un error./returns>
        public string AgregarNota(string nota, string tipointeraccion, string tema, string usuarioId)
        {
            Usuario usuario = null;
            Interaccion interaccion = null;
            try
            {
                usuario = this.Usuarios.BuscarUsuario(usuarioId);
                interaccion = Interacciones.BuscarInteraccion(usuario,tipointeraccion, tema);
                interaccion.AgergarNotas(nota);
            }
            catch (ArgumentNullException e)
            {
                return $"{e.Message} {e.ParamName}";
            }
            catch (ArgumentException e)
            {
                return $"{e.Message} {e.ParamName}";

            }
            if (usuario != null)
            {
                if (interaccion != null)
                {
                    return "Nota agregada";
                }
                return "no se encontro la interaccion";
            }

            return "No se encontro al usuario";
        }

        /// <summary>
        /// Muestra todas las interaccion de los clientes en base a los paramtros de tipo y fehca, que puden o no brindarse.
        /// Principios que cumple:
        /// - SRP: Solo muetrsa interacciones según filtros.
        /// - EXPERT: Esta clase posee acceso a los repositorios necesarios para encontrar y usar los datos.
        /// - POLIMORFISMO: Las interacciones se tratan sin conocer su implementación exacta.
        /// - Alta cohesion: Todo el método se centra en generar el informe de interacciones del cliente.
        /// </summary>
        /// <param name="clienteId">El cliente cuyas interacciones ver.</param>
        /// <param name="usuarioId">El usuarioid para verificar que es un usuario valido</param>
        /// <param name="tipo">el tipo de interaccion, parametro opcional para buscar en base a el</param>
        /// <param name="fecha">la fecha de la interaccion, parametro opcional para buscar en base a el.</param>
        /// <returns>Devuelbe un string de las interacciones del cliente en base a los datos brindados</returns>
        public string InteraccionesCliente(string clienteId,string usuarioId,string tipo="",string fecha="")
        {
            Usuario usuario = null;
            List<Interaccion> interaccionesCliente = null;
            Cliente cliente = null;
            try
            {
                usuario = this.Usuarios.BuscarUsuario(usuarioId);
                cliente = Clientes.BuscarUnCliente(clienteId);
                interaccionesCliente = Interacciones.BuscarInteraccion(usuario,cliente, tipo, fecha);
            }
            catch (ArgumentNullException e)
            {
                return $"{e.Message} {e.ParamName}";

            }
            catch (InvalidDateException e)
            {
                return $"{e.Message} {e.ParamName}";

            }
            catch (ArgumentException e)
            {
                return $"{e.Message} {e.ParamName}";

            }
            
            if (tipo != "" && fecha != "")
            {
                string informacion =
                    $"las interaccion de {cliente.Nombre} {cliente.Apellido} del tipo {tipo} de la fecha {fecha} son las siguientes:\n";
                foreach (Interaccion interaccion in interaccionesCliente)
                {
                    informacion += $"\n{interaccion.Tema}:\n{interaccion.Contenido}\n";
                    if (interaccion.Notas != null)
                    {
                        informacion += $"Notas: {interaccion.Notas}\n";
                    }
                }

                return informacion;
            }
            else if (tipo=="" && fecha !="")
            {
                string informacion =
                    $"las interaccion de {cliente.Nombre} {cliente.Apellido} de la fecha {fecha} son las siguientes:\n";
                foreach (Interaccion interaccion in interaccionesCliente)
                {
                    informacion += $"\nTipo: {interaccion.Tipo}\n{interaccion.Tema}:\n{interaccion.Contenido}\n";
                    if (interaccion.Notas != null)
                    {
                        informacion += $"Notas: {interaccion.Notas}\n";
                    }
                }

                return informacion;
            }
            else if (tipo!="" && fecha =="")
            {
                string informacion =
                    $"las interaccion de {cliente.Nombre} {cliente.Apellido} del tipo {tipo} son las siguientes:\n";
                foreach (Interaccion interaccion in interaccionesCliente)
                {
                    informacion += $"\nFecha: {interaccion.Fecha}\n{interaccion.Tema}:\n{interaccion.Contenido}\n";
                    if (interaccion.Notas != null)
                    {
                        informacion += $"Notas: {interaccion.Notas}\n";
                    }
                }

                return informacion;
            }
            else 
            {
                string informacion = $"Las interacciones de {cliente.Nombre} {cliente.Apellido} son:\n";
                foreach (Interaccion interaccion in interaccionesCliente)
                {
                    informacion +=
                        $"\n{interaccion.Tipo} del {interaccion.Fecha}\n{interaccion.Tema}:\n{interaccion.Contenido}\n";
                    if (interaccion.Notas != null)
                    {
                        informacion += $"Notas: {interaccion.Notas}\n";
                    }
                }

                return informacion;
            }
        }

        /// <summary>
        /// Muestra los clientes cuya utlima interaccion fue hace mas de un mes.
        /// Principios que cumple:
        /// - SRP: Solo identifica clientes con más de 1 mes sin interacciones.
        /// - EXPERT: Maneja los datos para conocer la última interacción de cada cliente.
        /// - Bajo acoplamiento: Debe saber unicamente si usario exite.
        /// - Alta cohesion: Su unico proposito es dar la informacion que debe obtener.
        /// </summary>
        /// <param name="usuarioId">Para ver los clientes del usuario, y verificar si es un usuario valido</param>
        /// <returns>devuelbe un string con los nombres de los clientes con los cuales el usuario no interacta hace mas de un mes</returns>
        public string InterraccionClienteAusente(string usuarioId)
        {
            Usuario usuario = null;
            try
            {
                usuario=this.Usuarios.BuscarUsuario(usuarioId);
            }
            catch (ArgumentNullException e)
            {
                return $"{e.Message} {e.ParamName}";

            }
            catch (ArgumentException e)
            {
                return $"{e.Message} {e.ParamName}";

            }
            if (usuario == null)
            {
                return "No se reconoce el usuario";
            }
            Dictionary<Cliente, Interaccion> InteraccionLista = this.Interacciones.UltimasInteraccionesClientes(usuario);
            string ClientesAusentes=$"Los clientes con los que no interactua hace un mes o mas son:\n";
            foreach (var dato in InteraccionLista)
            {
                if (dato.Value.Fecha.AddMonths(1) <= DateTime.Now)
                {
                    ClientesAusentes += $"{dato.Key}";
                }
            }
            return ClientesAusentes;
        }

        /// <summary>
        /// Muetra un panel con el nombre de todos los clientes, las interacciones recientes del usuario, y las reuniones proximas.
        /// Principios que cumple:
        /// - SRP: Solo construye el panel del usuario.
        /// - EXPERT: Accede a la información para mostrar clientes, interacciones recientes y reuniones.
        /// - Bajo acoplamiento: Usa repositorios sin conocer detalles internos.
        /// - Alta cohesion: todoo el método se dedica a hacer un panel con los datos deseados.
        /// </summary>
        /// <param name="usuarioId">Para verificar las interacciones del usuario, y validar si existe.</param>
        /// <returns>debuelve un string con los nombres de todos los clientes, las interacciones del usuario de hace una semana, y sus reuniones que se encuentren registradas para una fecha posterior a la fecha actual.</returns>
        public string Panel(string usuarioId)
        {
            Usuario usuario = null;
            try
            {
                usuario=this.Usuarios.BuscarUsuario(usuarioId);
            }
            catch (ArgumentNullException e)
            {
                return $"{e.Message} {e.ParamName}";

            }
            catch (ArgumentException e)
            {
                return $"{e.Message} {e.ParamName}";

            }
            if (usuario == null)
            {
                return "No se reconoce el usuario";
            }

            string Panel = $"Los Clientes totales son los siguientes:\n";
            foreach (Cliente cliente in this.Clientes.Clientes)
            {
                Panel += $"{cliente.Nombre} {cliente.Apellido}\n";
            }

            Panel += $"Sus interacciones mas recientes son:\n";
            Dictionary<Cliente,Interaccion> interaccionesRecientes = this.Interacciones.UltimasInteraccionesClientes(usuario);
            foreach (var dato in interaccionesRecientes)
            {
                if (dato.Value.Fecha.AddDays(7) >= DateTime.Now && dato.Value.Fecha<=DateTime.Now)
                {
                    Panel +=
                        $"{dato.Key.Nombre} {dato.Key.Apellido}. Interaccion de tipo {dato.Value.Tipo}. Tema: {dato.Value.Tema}\n";
                }
            }
            Panel += $"Sus reuniones proximas son:\n";
            foreach (Interaccion interaccion in this.Interacciones.Interacciones)
            {
                if (interaccion.Tipo == Interaccion.TipoInterracion.Reunion && interaccion.Fecha >= DateTime.Now)
                {
                    Panel += $"Tema de la reunion: {interaccion.Tema}. Fecha: {interaccion.Fecha}\n";
                }
            }
            return Panel;
        }

        /// <summary>
        /// Agrega los clientes que se pusieron en contacto con el usuario y que aun no les ha respondido.
        /// /// Principios que cumple:
        /// - SRP: Cumple SRP porque solo se encarga de agregar un cliente que se contacto,
        /// sin mezclarse con otras tareas.
        /// - Bajo acoplamiento: Usa métodos públicos para obtener usuario y cliente,
        /// sin depender de detalles internos
        /// - Alta cohesion: La lógica se mantiene centrada en agregar
        /// a la lista de contactos que se pusieron en contacto.
        /// <param name="usuarioId">El id apra verificar si el usuario exite.</param>
        /// <param name="clienteId">El id del cliente para ver si el cliente existe.</param>
        /// <returns>devuelve una confirmacion en caso de que se haya agregado correctamente, en caso opuesto, devolbera un error y su explicacion.</returns>
        public string AgregarClienteContacto(string usuarioId, string clienteId)
        {
            Usuario usuario = null;
            Cliente cliente = null;
            try
            {
                usuario = this.BuscarUsuario(usuarioId);
                cliente = this.Clientes.BuscarUnCliente(clienteId);
            }
            catch (ArgumentNullException e)
            {
                return $"{e.Message} {e.ParamName}";

            }
            catch (ArgumentException e)
            {
                return $"{e.Message} {e.ParamName}";

            }

            if (usuario != null && cliente != null)
            {
                if (!(this.ClientesContacto.ContainsKey(usuario)))
                {
                    this.ClientesContacto[usuario] = new List<Cliente>();
                    this.ClientesContacto[usuario].Add(cliente);
                }
                else
                {
                    this.ClientesContacto[usuario].Add(cliente);
                }
                return "cliente agregado";
            }

            return "usuario o cliente no puden ser null";
        }

        /// <summary>
        /// Permite ver los cleintes que se pusieron en contacto con el usuario y que este aun no les haya respondido.
        /// Principios que cumple:
        /// - SRP: Cumple SRP porque solo muestra la lista de clientes pendientes.
        /// No modifica datos ni hace validaciones externas.
        /// - Bajo acoplamiento: Solo usa propiedades públicas de Usuario y Cliente
        /// como Nombre y Apellido.
        /// - Alta cohesion: Toda la lógica se enfoca en obtener y mostrar
        /// información de contactos pendientes.
        /// </summary>
        /// <param name="usuarioId">Para verificar el si el usuario es valido.</param>
        /// <returns>Devuelbe un string con el nombre de los clientes que se pusieron en contacto.</returns>
        public string VerClienteContacto(string usuarioId)
        {
            Usuario usuario = null;
            try
            {
                usuario = this.BuscarUsuario(usuarioId);
            }
            catch (ArgumentNullException e)
            {
                return $"{e.Message} {e.ParamName}";

            }
            catch (ArgumentException e)
            {
                return $"{e.Message} {e.ParamName}";

            }

            string clientes = $"Los clientes que se pusieron en contacto contigo son:\n";
            if (usuario != null)
            {
                List<Cliente> lista = ClientesContacto[usuario];
                foreach (var VARIABLE in lista)
                {
                    clientes += $"{VARIABLE.Nombre} {VARIABLE.Apellido}\n";
                }

                return clientes;
            }

            return "Usuario null";
        }
        /// <summary>
        /// Permite eliminar clientes de la lista de clientesContacta.
        ///  /// Principios que cumple:
        /// - SRP: CCumple SRP porque su única responsabilidad es remover
        /// un cliente de la lista
        /// - Bajo acoplamiento: Solo usa propiedades públicas de Usuario y Cliente
        /// como Nombre y Apellido.
        /// - Alta cohesion:  todoo el método está relacionado con eliminar
        /// de la lista de cleitnes que se contactaron.
        /// </summary>
        /// <param name="usuarioId">id de usuario para verficar si exite y ver sus clientes asociados</param>
        /// <param name="clienteId">id del cliente a eliminar</param>
        /// <returns>devuelve la confirmacion si se hizo o no, y cual el problema</returns>
        public string EliminarClienteContacto(string usuarioId, string clienteId)
        {
            Usuario usuario = null;
            Cliente cliente = null;
            try
            {
                usuario = this.BuscarUsuario(usuarioId);
                cliente = this.Clientes.BuscarUnCliente(clienteId);
            }
            catch (ArgumentNullException e)
            {
                return $"{e.Message} {e.ParamName}";

            }
            catch (ArgumentException e)
            {
                return $"{e.Message} {e.ParamName}";

            }

            if (usuario != null && cliente != null)
            {
                if (this.ClientesContacto.ContainsKey(usuario))
                {
                    if (this.ClientesContacto[usuario].Contains(cliente))
                    {
                        this.ClientesContacto[usuario].Remove(cliente);
                        return "cliente eliminado de la lista";
                    }

                    return "la lisat actual no contiene el cliente que desea eliminar";
                }

                return "el usuario aun no ah agregado ningun cliente a la lista";

            }

            return "usuario o cliente no puden ser null";
        }

        
        /// <summary>
        /// Crea una nueva etiqueta en el sistema.
        /// - SRP: delega la validación y persistencia a las clases expertas (Usuarios, Etiquetas), coordinando solo el flujo.
        /// - Expert: utiliza a RepoUsuarios y RepoEtiquetas para buscar y guardar información, ya que son los expertos en sus dominios.
        /// - Bajo acoplamiento: mantiene bajo acoplamiento al depender de las operaciones públicas de los repositorios sin conocer su implementación interna.
        /// </summary>
        public string CrearEtiqueta(string etiqueta, string idUsuario)
        {
            Usuario usuario = this.Usuarios.BuscarUsuario(idUsuario);
            if (Usuarios.Usuarios.Contains(usuario))
            {
                try
                {
                    if (etiqueta == null)
                    {
                        throw new ArgumentNullException("La etiqueta no puede ser nula.");
                    }

                    if (string.IsNullOrWhiteSpace(etiqueta))
                    {
                        throw new ArgumentException("La etiqueta no puede estar vacía.");
                    }

                    Etiquetas.AgregarEtiqueta(etiqueta.Trim());
                    return "Etiqueta creada correctamente.";
                }
                catch (ArgumentNullException ex)
                {
                    return $"Error: {ex.Message}";
                }
                catch (ArgumentException ex)
                {
                    return $"Error: {ex.Message}";
                }
                catch (Exception ex)
                {
                    return $"Error: {ex.Message}";
                }
            }

            return "Solo Usuarios pueden crear Etiquetas.";
        }

        
        /// <summary>
        /// Agrega una etiqueta existente a un cliente.
        /// - SRP: coordina la asignación delegando la búsqueda y validación a los expertos (Usuarios, Etiquetas).
        /// - Expert: utiliza RepoUsuarios y RepoEtiquetas para obtener las instancias necesarias, respetando su responsabilidad.
        /// - Bajo acoplamiento: interactúa con los objetos a través de sus interfaces públicas sin conocer detalles de persistencia.
        /// </summary>
        public string AgregarEtiquetaCliente(string clienteId, string etiqueta, string usuarioId)
        { 
            Usuario usuario = Usuarios.BuscarUsuario(usuarioId); 
            if (usuario != null)
            {
                Cliente cliente = Usuarios.BuscarCliente(clienteId);
                if (cliente != null)
                {
                    if (Etiquetas.BuscarEtiqueta(etiqueta))
                    {
                        cliente.Etiquetas.Add(etiqueta);
                        return "Etiqueta agregada";
                    }
                }
            }
            else
            {
                return "Solo Usuarios pueden agregar etiquetas a los clientes";
            }

            return usuario.Nombre;
        }

        /*public void RegistrarVenta(string clienteId, string producto, string fecha,
            string precio, string usuarioId)
        {
            Usuario usuario = this.Usuarios.BuscarUsuario(usuarioId);
            if (usuario != null)
            {
                Cliente cliente = Clientes.BuscarUnCliente(clienteId);
                if (cliente != null)
                {
                    Ventas.AgregarVenta(cliente, fecha, precio, producto, usuario);
                }
            }
        }*/

        /*
        public void RegistarCotizacion(string clienteId, string fecha,
            string precio, string usuarioId)
        {
            Usuario usuario = this.Usuarios.BuscarUsuario(usuarioId);
            if (usuario != null)
            {
                Cliente cliente = Clientes.BuscarUnCliente(clienteId);
                if (cliente != null)
                {
                    Cotizaciones.AgregarCotizacion(cliente, fecha, precio, usuario);
                }
            }
        }
        */

        // Como administrador quiero crear, suspender o eliminar usuarios, para mantener control sobre los accesos.
       

        
        /// <summary>
        /// Crea un nuevo usuario en el sistema verificando permisos de administrador.
        /// - SRP: coordina la creación delegando la validación de permisos y persistencia a RepoUsuarios.
        /// - Expert: utiliza RepoUsuarios para verificar permisos de administrador y unicidad del ID.
        /// - Creator: asume la responsabilidad de instanciar el nuevo Usuario para luego agregarlo al repositorio.
        /// </summary>
        public string CrearUsuario(string id, string nombre, string idAdmin)
        {
            Usuario admin = this.Usuarios.BuscarAdministrador(idAdmin);
            if (Usuarios.Administradores.Contains(admin))
            {
                if (this.Usuarios.BuscarUsuario(id) != null)
                {
                    return $"Ya existe un usuario con el ID '{id}'.";
                }
                
                Usuario nuevo = new Usuario(id, nombre);
                this.Usuarios.AgregarUsuario(nuevo);
                return $"Usuario '{nombre}' (ID: {id}) creado correctamente.";   
            }

            return "Solo Administradores pueden crear Usuarios.";
        }

        
        /// <summary>
        /// Suspende a un usuario activo y lo mueve a la lista de suspendidos.
        /// - SRP: coordina la suspensión delegando la validación de permisos y persistencia a RepoUsuarios.
        /// - Expert: utiliza RepoUsuarios para verificar permisos de administrador y obtener el usuario a suspender.
        /// - Bajo acoplamiento: interactúa con los objetos a través de sus interfaces públicas sin conocer detalles de persistencia.
        /// </summary>
        public string SuspenderUsuario(string idSuspender, string idAdmin)
        {
            Usuario usuario = this.Usuarios.BuscarUsuario(idSuspender);
            if (usuario == null)
            {
                return $"No se encontró un usuario con ID '{idSuspender}'.";
            }

            Usuario admin = this.Usuarios.BuscarAdministrador(idAdmin);
            if (Usuarios.Administradores.Contains(admin))
            {
                Usuarios.EliminarUsuario(usuario);
                UsuariosSuspendidos.Add(usuario);
                return $" El usuario '{usuario.Nombre}' ha sido suspendido correctamente.";   
            }

            return "Solo Administradores pueden suspender usuarios.";
        }

        /// <summary>
        /// Elimina completamente a un usuario (activo o suspendido).
        /// - SRP: coordina la eliminación delegando la validación de permisos y persistencia a RepoUsuarios.
        /// - Expert: utiliza RepoUsuarios para verificar permisos de administrador y obtener el usuario a eliminar.
        /// - Bajo acoplamiento: interactúa con los objetos a través de sus interfaces públicas sin conocer detalles de persistencia.
        /// </summary>
        public string EliminarUsuario(string idEliminar, string idAdmin)
        {
            Usuario usuario = this.BuscarUsuario(idEliminar);
            bool eliminado = false;

            Usuario admin = this.Usuarios.BuscarAdministrador(idAdmin);
            if (Usuarios.Administradores.Contains(admin))
            {
                if (usuario != null)
                {
                    Usuarios.EliminarUsuario(usuario);
                    eliminado = true;
                }

                foreach (Usuario u in UsuariosSuspendidos)
                {
                    if (u.ID == idEliminar)
                    {
                        usuario = u;
                    }
                }

                if (usuario != null)
                {
                    UsuariosSuspendidos.Remove(usuario);
                    eliminado = true;
                }

                if (eliminado)
                {
                    return $"El usuario '{usuario.Nombre}' ha sido eliminado del sistema.";
                }
                else
                {
                    return $"No se encontró un usuario con ID '{idEliminar}'.";
                }
            }

            return "Solo Adminsitradores pueden eliminar usuarios.";
        }
        

        
        /*public void AsignarClienteAOtroVendedor(string idVendedorActual, string idVendedorNuevo,
            string nombreCliente,
            string apellidoCliente)
        {
            Vendedor vendedorActual = this.Usuarios.BuscarVendedor(idVendedorActual);
            Vendedor vendedorNuevo = this.Usuarios.BuscarVendedor(idVendedorNuevo);
            // Cliente cliente = Clientes.BuscarUnCliente(nombreCliente, apellidoCliente);
        
            // if (vendedorActual != null && vendedorNuevo != null && cliente != null)
            // {
            //     vendedorActual.Clientes.Remove(cliente);
            //     vendedorNuevo.Clientes.Add(cliente);
            // }
            // else
            // {
            // }
        }*/

        public string AsignarClienteAVendedor(string clienteId, string vendedorId)
        {
            Usuario vendedor = null;
            Cliente cliente = null;

            // 1) Buscar vendedor y cliente con manejo de errores "a lo fachada"
            try
            {
                vendedor = this.Usuarios.BuscarUsuario(vendedorId);
                cliente = this.Clientes.BuscarUnCliente(clienteId);
            }
            catch (ArgumentNullException e)
            {
                return $"{e.Message} {e.ParamName}";
            }
            catch (ArgumentException e)
            {
                return $"{e.Message} {e.ParamName}";
            }

            if (vendedor == null)
            {
                return $"No se encontro un vendedor con ID '{vendedorId}'.";
            }

            if (cliente == null)
            {
                return $"No se encontro un cliente con ID '{clienteId}'.";
            }
            
            
            return $"El cliente {cliente.Nombre} {cliente.Apellido} fue asignado al vendedor con ID '{vendedorId}'.";
        }
        /// <summary>
        /// Busca clientes en el sistema según un criterio específico.
        /// - SRP: delega la responsabilidad de búsqueda al repositorio de clientes, encargándose solo de formatear la respuesta.
        /// - Expert: utiliza RepoClientes para realizar la búsqueda, ya que es el experto en la colección de clientes.
        /// - Controller: recibe la solicitud de búsqueda y coordina la obtención de datos para devolverlos a la UI.
        /// - Bajo acoplamiento: depende de la abstracción del repositorio para realizar la búsqueda.
        /// </summary>
        public List<Cliente> BuscarCliente(string atributo, string valorBusqueda)
        {
            List<Cliente> resultadoBusqueda = Clientes.BuscarCliente(atributo, valorBusqueda);
            return resultadoBusqueda;
        }

        /// <summary>
        /// Crea un nuevo cliente y lo agrega al repositorio.
        /// - Creator: Fachada coordina la creación y agregación del cliente.
        /// </summary>
        public string CrearCliente(string id, string nombre, string apellido, string telefono, string correo)
        {
            try
            {
                Cliente nuevo = new Cliente(id, nombre, apellido, telefono, correo);
                this.Clientes.AgregaCliente(nuevo);
                
                return $"Cliente {nuevo} creado correctamente";
            }
            catch (Exception err)
            {
                return "No se pudo crear el cliente";
            }
        }

        /// <summary>
        /// Modifica un atributo específico de un cliente existente.
        /// - Expert: Cliente conoce cómo modificar sus propios atributos.
        /// </summary>
        public string ModificarInfo(string id, string atributo, string nuevoValor)
        {
            try
            {
                Cliente cliente = Clientes.BuscarCliente("id", id)[0];
                cliente.ModificarInformacion(atributo, nuevoValor);
                
                return $"Se modificó la información del cliente {cliente.ToString()}. Su {atributo} ahora es {nuevoValor}";
            }
            catch (NullReferenceException ex)
            {
                return "No se encontró o no existe el cliente";
            }
        }

        /// <summary>
        /// Elimina un cliente del repositorio.
        /// - Expert: RepoClientes conoce cómo eliminar de su colección.
        /// </summary>
        public string EliminarCliente(string id)
        {
            try
            {
                Cliente cliente = Clientes.BuscarCliente("id", id)[0];
                Clientes.EliminarCliente(cliente);

                return $"Se eliminó el cliente {cliente.ToString()}";
            }
            catch (NullReferenceException err)
            {
                return "No se encontró o no existe el cliente";
            }
        }

        /// <summary>
        /// Retorna el repositorio de clientes.
        /// - Expert: RepoClientes conoce cómo obtener su colección.
        /// </summary>
        public string VerClientes()
        {
            IEnumerable<Cliente> clientes = this.Clientes.Clientes;
            string resultado = "";
            foreach (Cliente cliente in clientes)
            {
                resultado += $"{cliente.ToString()},";
            }

            return resultado;
        }

        /// <summary>
        /// Busca un usuario por su Id.
        /// - Expert: RepoUsuarios conoce cómo buscar usuarios.
        /// </summary>
        public Usuario BuscarUsuario(string usuarioId)
        {
            return this.Usuarios.BuscarUsuario(usuarioId);
        }
        
        public string RegistrarVentaCliente(string clienteId, string producto, string fecha, string precio, string usuarioId)
        {
            Usuario usuario = null;
            Cliente cliente = null;

            try
            {
                // Buscar usuario y cliente
                usuario = this.Usuarios.BuscarUsuario(usuarioId);
                cliente = this.Clientes.BuscarUnCliente(clienteId);

                
                this.Ventas.AgregarVenta(cliente, fecha, precio, producto, usuario);
            }
            catch (ArgumentNullException e)
            {
                return $"{e.Message} {e.ParamName}";
            }
            catch (InvalidDateException e)
            {
                // Ej: "La fecha es inválida fecha"
                return $"{e.Message} {e.ParamName}";
            }
            catch (ArgumentException e)
            {
                return $"{e.Message} {e.ParamName}";
            }

            // Si no hubo excepciones, validamos nulls igual que en RegistrarReunion
            if (usuario != null)
            {
                if (cliente != null)
                {
                    return $"Venta registrada: {cliente.Nombre} compró '{producto}' por ${precio} el {fecha}.";
                }

                return "no se encontro al cliente";
            }

            return "No se encontro al usuario";
        }
        
        
        public string TotalDeVentasEnPeriodo(string usuarioId, string fechaInicioTexto, string fechaFinTexto)
        {
            Usuario usuario = null;

            // 1) Buscar usuario con manejo de errores
            try
            {
                usuario = this.Usuarios.BuscarUsuario(usuarioId);
            }
            catch (ArgumentNullException e)
            {
                return $"{e.Message} {e.ParamName}";
            }
            catch (ArgumentException e)
            {
                return $"{e.Message} {e.ParamName}";
            }

            if (usuario == null)
            {
                return $"No se encontró un usuario con ID '{usuarioId}'.";
            }

            
            if (string.IsNullOrWhiteSpace(fechaInicioTexto))
            {
                return "La fecha de inicio no puede estar vacía.";
            }

            if (string.IsNullOrWhiteSpace(fechaFinTexto))
            {
                return "La fecha de fin no puede estar vacía.";
            }

            //  Parsear fechas con dd/MM/yyyy
            DateTime fechaInicio;
            DateTime fechaFin;

            if (!DateTime.TryParseExact(fechaInicioTexto, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaInicio))
            {
                return "Error: la fecha de inicio no es válida. Usa el formato dd/MM/yyyy.";
            }

            if (!DateTime.TryParseExact(fechaFinTexto, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaFin))
            {
                return "Error: la fecha de fin no es válida. Usa el formato dd/MM/yyyy.";
            }

            
            if (fechaInicio > fechaFin)
            {
                return "Error: la fecha de inicio no puede ser posterior a la fecha de fin.";
            }

          // Calcular total
            double total = usuario.SumarImportes(fechaInicio, fechaFin);

         
            return $"Total de ventas desde {fechaInicio:dd/MM/yyyy} hasta {fechaFin:dd/MM/yyyy}: ${total:0.##}";
        }
        
        public string RegistrarCotizacionCliente(string clienteId, string fecha, string precio, string usuarioId)
        {
            Usuario usuario = null;
            Cliente cliente = null;

            try
            {
                // Buscar usuario y cliente
                usuario = this.Usuarios.BuscarUsuario(usuarioId);
                cliente = this.Clientes.BuscarUnCliente(clienteId);

                // Registrar cotización
                // Acá adentro AgregarCotizacion debería:
                // - validar fecha y lanzar InvalidDateException
                // - validar datos null/vacíos y lanzar ArgumentNullException / ArgumentException
                this.Cotizaciones.AgregarCotizacion(cliente, fecha, precio, usuario);
            }
            catch (ArgumentNullException e)
            {
                // Mismo estilo que RegistrarReunion
                return $"{e.Message} {e.ParamName}";
            }
            catch (InvalidDateException e)
            {
                // Si la fecha está mal, el bot va a mostrar exactamente este mensaje
                return $"{e.Message} {e.ParamName}";
            }
            catch (ArgumentException e)
            {
                return $"{e.Message} {e.ParamName}";
            }

            // Si no hubo excepciones, validamos igual que en RegistrarReunion
            if (usuario != null)
            {
                if (cliente != null)
                {
                    return $"Cotización registrada: se envió a {cliente.Nombre} por ${precio} el {fecha}.";
                }

                return "no se encontro al cliente";
            }

            return "No se encontro al usuario";
        }
        
        /// <summary>
        /// Crea un nuevo vendedor en el sistema.
        /// Aplica Creator: crea instancias de Vendedor y las agrega al repositorio.
        /// </summary>
        public Vendedor CrearVendedor(string id, string nombre)
        {
            try
            {
                if (id == null)
                {
                    throw new ArgumentNullException(nameof(id), "El ID del vendedor no puede ser nulo");
                }
                if (nombre == null)
                {
                    throw new ArgumentNullException(nameof(nombre), "El nombre del vendedor no puede ser nulo");
                }
                
                if (string.IsNullOrWhiteSpace(id))
                {
                    throw new ArgumentException("El ID del vendedor no puede estar vacío");
                }
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    throw new ArgumentException("El nombre del vendedor no puede estar vacío");
                }
                
                foreach (Vendedor v in Usuarios.Vendedores)
                {
                    if (v.Id == id)
                    {
                        throw new InvalidOperationException($"Ya existe un vendedor con el ID: {id}");
                    }
                }

                Vendedor vendedor = new Vendedor(id, nombre);
                Usuarios.AgregarVendedor(vendedor);
                return vendedor;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// Crea un nuevo administrador en el sistema.
        /// Creator: crea instancias de Administrador y las agrega al repositorio.
        /// </summary>
        public Administrador CrearAdministrador(string id, string nombre)
        {
            try
            {
                if (id == null)
                {
                    throw new ArgumentNullException(nameof(id), "El ID del administrador no puede ser nulo");
                }
                if (nombre == null)
                {
                    throw new ArgumentNullException(nameof(nombre), "El nombre del administrador no puede ser nulo");
                }
                
                if (string.IsNullOrWhiteSpace(id))
                {
                    throw new ArgumentException("El ID del administrador no puede estar vacío");
                }
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    throw new ArgumentException("El nombre del administrador no puede estar vacío");
                }

                foreach (Administrador a in Usuarios.Administradores)
                {
                    if (a.ID == id)
                    {
                        throw new InvalidOperationException($"Ya existe un administrador con el ID: {id}");
                    }
                }

                Administrador administrador = new Administrador(id, nombre);
                Usuarios.AgregarAdministraodr(administrador);
                return administrador;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}