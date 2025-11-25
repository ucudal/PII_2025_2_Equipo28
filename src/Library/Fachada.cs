using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace Library
{
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
        /// El metodos RegistrarMensaje crea una instancia de interaccion de tipo mensaje y la guarda en repoInteracciones
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
        /// El metodos RegistrarCorreo crea una instancia de interaccion de tipo correo y la guarda en repoInteracciones
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
        /// El metodos RegistrarLlamada crea una instancia de interaccion de tipo llamada y la guarda en repoInteracciones
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
        /// El metodos RegistrarReunion crea una instancia de Reunion, subtipo de Interaccion, y la guarda en repoInteracciones
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
                }

                return informacion;
            }
        }
        /// <summary>
        /// Muestra los clientes cuya utlima interaccion fue hace mas de un mes.
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
        /// Muetra un panel con el nombre de todos los clientes, las interacciones recientes del usuario, y las reuniones proximas
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
                if (dato.Value.Fecha.AddDays(7) >= DateTime.Now)
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
        /// </summary>
        /// <param name="usuarioId">El id apra verificar si el usuario exite.</param>
        /// <param name="clienteId">El id del cliente para ver si el cliente existe.</param>
        /// <returns>debuelve una confirmacion en caso de que se haya agregado correctamente, en caso opuesto, devolbera un error y su explicacion.</returns>
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
        /// Aplica Expert: RepoEtiquetas conoce cómo gestionar etiquetas.
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

            return "Solo Usuarios pueden agregar etiquetas a los clientes";
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
        /// Crea un nuevo usuario si no existe otro con el mismo ID.
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
        

        /// <summary>
        /// Asigna un cliente de un vendedor a otro vendedor.
        /// </summary>
        public void AsignarClienteAOtroVendedor(string idVendedorActual, string idVendedorNuevo,
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
            //     Console.WriteLine("Cliente reasignado correctamente.");
            // }
            // else
            // {
            //     Console.WriteLine("Error: vendedor o cliente no encontrado.");
            // }
        }
        
        // public List<Llamadas> Llamadas = new List<Llamadas>();


        public List<Reunion> Reuniones = new List<Reunion>();

        /// <summary>
        /// Busca clientes según un atributo y valor específicos.
        /// Aplica Expert: RepoClientes conoce cómo buscar en su colección.
        /// </summary>
        public List<Cliente> BuscarClientesFachada(string atributo, string valorBusqueda)
        {
            return Clientes.BuscarCliente(atributo, valorBusqueda);
        }

        /// <summary>
        /// Crea un nuevo cliente y lo agrega al repositorio.
        /// Aplica Creator: Fachada coordina la creación y agregación del cliente.
        /// </summary>
        public Cliente CrearCliente(string id, string nombre, string apellido, string telefono, string correo)
        {
            this.Clientes.AgregaCliente(new Cliente(id, nombre, apellido, telefono, correo));
            return new Cliente(id, nombre, apellido, telefono, correo);
        }

        /// <summary>
        /// Modifica un atributo específico de un cliente existente.
        /// Aplica Expert: Cliente conoce cómo modificar sus propios atributos.
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
        /// Aplica Expert: RepoClientes conoce cómo eliminar de su colección.
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
        /// </summary>
        public RepoClientes VerClientes()
        {
            return Clientes;
        }
        
        // public void RegistrarLlamada(string id, string tema, string contenido)
        // {
        //     // Cliente cliente = Clientes.BuscarCliente("id", id)[0];
        //     // Llamada llamada = new Llamada(cliente, tema, contenido);
        //     // Llamada.Add(llamada);
        // }

        // public void RegistrarReunion(string id, string tema, string ubicacion, string reunion, string cuando)
        // {
        //     Cliente cliente = Clientes.BuscarCliente("id", id)[0];
        //     Reunion Reunion = new Reunion(cliente, tema, ubicacion, reunion, cuando);
        //     Reuniones.Add(Reunion);
        // }

        /// <summary>
        /// Busca un usuario por su ID.
        /// Aplica Expert: RepoUsuarios conoce cómo buscar usuarios.
        /// </summary>
        public Usuario BuscarUsuario(string usuarioId)
        {
            return this.Usuarios.BuscarUsuario(usuarioId);
        }
        //=======================================================================================
        //                          Venta
        //=======================================================================================
        /// <summary>
        /// Registra una venta de un cliente con manejo completo de errores.
        /// Aplica SRP: maneja únicamente el registro de ventas con validaciones.
        /// </summary>
        /*public string RegistrarVentaCliente(string clienteId, string producto, string fecha, string precio, string usuarioId)
        {
            Usuario usuario;
            Cliente cliente;

            // 1) Buscar usuario con manejo de errores propios
            try
            {
                usuario = this.Usuarios.BuscarUsuario(usuarioId);
                cliente = this.Clientes.BuscarUnCliente(clienteId);
                
                this.Ventas.AgregarVenta(cliente, fecha, precio, producto, usuario);
                return $"Venta registrada: {cliente.Nombre} compró '{producto}' por ${precio} el {fecha}.";
            }
            catch (ArgumentNullException)
            {
                return "Error: faltan datos para registrar la venta.";
            }
            catch (ArgumentException)
            {
                return "Error: uno o más campos están vacíos.";
            }
        }*/
        
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
        
        /// <summary>
        /// Calcula el total de ventas de un usuario en un período específico.
        /// Aplica Expert: Usuario conoce su lista de ventas totales.
        /// </summary>
        public string TotalDeVentasEnPeriodo(string usuarioId, string fechaInicioTexto, string fechaFinTexto)
        {
            // 1) Buscar usuario con manejo de errores estables
            Usuario usuario;
            try
            {
                usuario = this.Usuarios.BuscarUsuario(usuarioId);
            }
            catch (ArgumentNullException)
            {
                return "Error: faltan datos para registrar la venta.";
            }
            catch (ArgumentException)
            {
                return "Error: uno o más campos están vacíos.";
            }

            if (usuario == null)
            {
                return $"Error: no se encontró un usuario con ID '{usuarioId}'.";
            }

            // 2) Validar nulos / vacíos en fechas
            if (fechaInicioTexto == null || fechaFinTexto == null)
            {
                return "Error: faltan datos para registrar la venta.";
            }
            if (string.IsNullOrWhiteSpace(fechaInicioTexto) || string.IsNullOrWhiteSpace(fechaFinTexto))
            {
                return "Error: uno o más campos están vacíos.";
            }

            // 3) Parsear fechas con dd/MM/yyyy
            DateTime fechaInicio, fechaFin;
            if (!DateTime.TryParseExact(fechaInicioTexto, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaInicio) ||
                !DateTime.TryParseExact(fechaFinTexto, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaFin))
            {
                return "Error: la fecha ingresada no es válida.";
            }

            // 4) Sumar importes en el rango [inicio, fin] 
            /*double total = 0.0;
>>>>>>> Horacio
            foreach (var venta in usuario.VentasUsuario)
            {
                if (venta.Fecha >= fechaInicio && venta.Fecha <= fechaFin)
                {
                    double importe;
                    if (double.TryParse(venta.Importe, out importe))
                    {
                        total += importe;
                    }
                }
            }*/
            double total = usuario.SumarImportes(fechaInicio, fechaFin);

            // 5) Respuesta formateada
            return $"Total de ventas desde {fechaInicio:dd/MM/yyyy} hasta {fechaFin:dd/MM/yyyy}: ${total:0.##}";
        }
        
        /// <summary>
        /// Registra una cotización para un cliente con validaciones.
        /// Aplica SRP: responsable únicamente del registro de cotizaciones.
        /// </summary>
        public string RegistrarCotizacionCliente(string clienteId, string fecha, string precio, string usuarioId)
        {
            Usuario usuario;
            Cliente cliente;

            // 1) Buscar usuario
            try
            {
                usuario = this.Usuarios.BuscarUsuario(usuarioId);
            }
            catch (ArgumentNullException)
            {
                return "Error: faltan datos para registrar la cotización.";
            }
            catch (ArgumentException)
            {
                return "Error: uno o más campos están vacíos.";
            }

            if (usuario == null)
            {
                return $"Error: no se encontró un usuario con ID '{usuarioId}'.";
            }

            // 2) Buscar cliente
            try
            {
                cliente = this.Clientes.BuscarUnCliente(clienteId);
            }
            catch (ArgumentNullException)
            {
                return "Error: faltan datos para registrar la cotización.";
            }
            catch (ArgumentException)
            {
                return "Error: uno o más campos están vacíos.";
            }

            if (cliente == null)
            {
                return $"Error: no se encontró un cliente con ID '{clienteId}'.";
            }

            // 3) Registrar cotización
            try
            {
                this.Cotizaciones.AgregarCotizacion(cliente, fecha, precio, usuario);
                return $"Cotización registrada: se envió a {cliente.Nombre} por ${precio} el {fecha}.";
            }
            catch (InvalidDateException)
            {
                return "Error: la fecha ingresada no es válida.";
            }
            catch (ArgumentNullException)
            {
                return "Error: uno o más campos están vacíos.";
            }
            catch (ArgumentException)
            {
                return "Error: faltan datos para registrar la cotización.";
            }
            catch (Exception)
            {
                return "Error: ocurrió un problema al registrar la cotización.";
            }
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
                Usuarios.AgregarVnededor(vendedor);
                return vendedor;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                throw;
            }
        }

        /// <summary>
        /// Crea un nuevo administrador en el sistema.
        /// Aplica Creator: crea instancias de Administrador y las agrega al repositorio.
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
                Console.WriteLine($"Error: {e.Message}");
                throw;
            }
        }
    }
}