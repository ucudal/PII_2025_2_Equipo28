using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace Library
{
    public class Fachada
    {
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

        public string RegistarMensaje(string clienteId, string mensaje, string tema,
            string usuarioId, string cuando)
        {
            Usuario usuario = null;
            Mensajes Mensaje = null; //Inicializando larailala
            Cliente cliente = null;
            try
            {
                usuario = this.Usuarios.BuscarUsuario(usuarioId);
                cliente = Clientes.BuscarUnCliente(clienteId);
                // Cliente cliente = Usuarios.BuscarCliente(clienteId); //Hecho comentario por si acaso
                Mensaje = new Mensajes(usuario, cliente, tema, mensaje, cuando);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
                return e.Message;
            }
            catch (Excepciones.EmptyStringException e)
            {
                Console.WriteLine(e.Message);
                return e.Message;
            }
            catch (Excepciones.InvalidDateException e)
            {
                Console.WriteLine(e.Message);
                return e.Message;
            }

            if (usuario != null)
            {
                if (cliente != null)
                {
                    Interacciones.AgregarInteraccion(Mensaje, usuario);
                    return "Mensaje registrado";
                }
            }

            return "El usuario o cliente no existen";
        }

        public string RegistrarCorreo(string clienteId, string correo, string tema,
            string usuarioId, string cuando)
        {
            Usuario usuario = null;
            Correos Correo = null; //Inicializando larailala
            Cliente cliente = null;
            try
            {
                usuario = this.Usuarios.BuscarUsuario(usuarioId);
                cliente = Clientes.BuscarUnCliente(clienteId);
                // Cliente cliente = Usuarios.BuscarCliente(clienteId); //Hecho comentario por si acaso
                Correo = new Correos(usuario,cliente, tema, correo, cuando);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
                return e.Message;
            }
            catch (Excepciones.EmptyStringException e)
            {
                Console.WriteLine(e.Message);
                return e.Message;
            }
            catch (Excepciones.InvalidDateException e)
            {
                Console.WriteLine(e.Message);
                return e.Message;
            }

            if (usuario != null)
            {
                if (cliente != null)
                {
                    Interacciones.AgregarInteraccion(Correo, usuario);
                    return "Correo registrado";
                }
            }
            return "El usuario o cliente no existen";
        }

        public string RegistarLlamada(string clienteId, string llamada, string tema,
            string usuarioId, string cuando)
        {
            Usuario usuario = null;
            Llamadas LLamada = null; //Inicializando larailala
            Cliente cliente = null;
            try
            {
                usuario = this.Usuarios.BuscarUsuario(usuarioId);
                cliente = Clientes.BuscarUnCliente(clienteId);
                // Cliente cliente = Usuarios.BuscarCliente(clienteId); //Hecho comentario por si acaso
                LLamada = new Llamadas(usuario,cliente, tema, llamada, cuando);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
                return e.Message;
            }
            catch (Excepciones.EmptyStringException e)
            {
                Console.WriteLine(e.Message);
                return e.Message;
            }
            catch (Excepciones.InvalidDateException e)
            {
                Console.WriteLine(e.Message);
                return e.Message;
            }

            if (usuario != null)
            {
                if (cliente != null)
                {
                    Interacciones.AgregarInteraccion(LLamada, usuario);
                    return "llamada registrada";

                }
            }
            return "El usuario o cliente no existen";
        }

        public string RegistarReunion(string clienteId, string reunion, string tema,
            string usuarioId, string cuando, string lugar)
        {
            Usuario usuario = null;
            Reunion Reunion = null; //Inicializando larailala
            Cliente cliente = null;
            try
            {
                usuario = this.Usuarios.BuscarUsuario(usuarioId);
                cliente = Clientes.BuscarUnCliente(clienteId);
                // Cliente cliente = Usuarios.BuscarCliente(clienteId); //Hecho comentario por si acaso
                Reunion = new Reunion(usuario,cliente, tema, lugar, reunion,cuando);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
                return e.Message;
            }
            catch (Excepciones.EmptyStringException e)
            {
                Console.WriteLine(e.Message);
                return e.Message;
            }
            catch (Excepciones.InvalidDateException e)
            {
                Console.WriteLine(e.Message);
                return e.Message;
            }

            if (usuario != null)
            {
                if (cliente != null)
                {
                    Interacciones.AgregarInteraccion(Reunion, usuario);
                    return "Reuion registrada";

                }
            }
            return "El usuario o cliente no existen";
        }

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
                Console.WriteLine(e.Message);
                return e.Message;
            }
            catch (Excepciones.EmptyStringException e)
            {
                Console.WriteLine(e.Message);
                return e.Message;
            }
            if (usuario != null)
            {
                if (interaccion != null)
                {
                    return "Nota agregada";
                }
            }

            return "El usuario o interaccion no existen";
        }

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
                Console.WriteLine(e.Message);
                return e.Message;
            }
            catch (Excepciones.EmptyStringException e)
            {
                Console.WriteLine(e.Message);
                return e.Message;
            }
            catch (Excepciones.InvalidDateException e)
            {
                Console.WriteLine(e.Message);
                return e.Message;
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

        public string InterraccionClienteAusente(string usuarioId)
        {
            Usuario usuario = null;
            try
            {
                usuario=this.Usuarios.BuscarUsuario(usuarioId);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
                return e.Message;
            }
            catch (Excepciones.EmptyStringException e)
            {
                Console.WriteLine(e.Message);
                return e.Message;
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

        public string Panel(string usuarioId)
        {
            Usuario usuario = null;
            try
            {
                usuario=this.Usuarios.BuscarUsuario(usuarioId);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Excepciones.EmptyStringException e)
            {
                Console.WriteLine(e.Message);
            }
            if (usuario == null)
            {
                return "No se reconoce el usuario";
            }

            string Panel = $"Los Clientes totales son los siguientes:\n";
            foreach (Cliente cliente in this.Clientes.Clientes2)
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
            foreach (Interaccion interaccion in this.Interacciones.Interacciones2)
            {
                if (interaccion.Tipo == Interaccion.TipoInterracion.Reunion && interaccion.Fecha >= DateTime.Now)
                {
                    Panel += $"Tema de la reunion: {interaccion.Tema}. Fecha: {interaccion.Fecha}\n";
                }
            }
            return Panel;
        }

        // public void AgregarEtiquetaCliente(string clienteId, string etiqueta, string usuarioId)
        // {
        //     Usuario usuario = Usuarios.BuscarUsuario(usuarioId);
        //     if (usuario != null)
        //     {
        //         Cliente cliente = Usuarios.BuscarCliente(clienteId);
        //         if (cliente != null)
        //         {
        //             if (Etiquetas.BuscarEtiqueta(etiqueta))
        //             {
        //                 cliente.Etiquetas.Add(etiqueta);
        //             }
        //         }
        //     }
        // }

        public void AgregarEtiquetaLista(string etiqueta, string usuarioId)
        {
            Usuario usuario = this.Usuarios.BuscarUsuario(usuarioId);
            if (usuario != null)
            {
            }
        }

        public void RegistrarVenta(string clienteId, string producto, string fecha,
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
        }

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

        //Cómo usuario quiero saber los clientes que hace cierto tiempo que no tengo ninguna interacción con ellos, para no peder contacto con ellos.
        // public void VerInteraccionesDeCliente(string clienteNombre, string clienteApellido, string usuarioId,
        //     string tipo = "")
        //
        // {
        //     Usuario usuario = this.Usuarios.BuscarUsuario(usuarioId);
        //     if (usuario != null)
        //     {
        //         // Cliente cliente = Clientes.BuscarUnCliente(idcliente);
        //         // if (cliente != null)
        //         // {
        //         //     Console.WriteLine($"Interacciones con {clienteNombre} {clienteApellido}:");
        //         //
        //         //     foreach (Interaccion interaccion in usuario.Interacciones)
        //         //     {
        //         //         // Verifica que la interacción sea del cliente buscado
        //         //         if (interaccion.Cliente == cliente)
        //         //         {
        //         //             // Si se pasa un tipo, solo muestra las que coincidan
        //         //             if (tipo == "" || interaccion.tipo == tipo)
        //         //             {
        //         //                 Console.WriteLine("-----------------------------------");
        //         //                 Console.WriteLine($"Tipo: {interaccion.tipo}");
        //         //                 Console.WriteLine($"Fecha: {interaccion.Fecha}");
        //         //                 Console.WriteLine($"Tema: {interaccion.Tema}");
        //         //                 Console.WriteLine($"Descripción: {interaccion.contenido}");
        //         //             }
        //         //         }
        //         //     }
        //         // }
        //         // else
        //         // {
        //         //     Console.WriteLine("Cliente no encontrado.");
        //         // }
        //     }
        //     else
        //     {
        //         Console.WriteLine("Usuario no encontrado.");
        //     }
        // }


        // Como administrador quiero crear, suspender o eliminar usuarios, para mantener control sobre los accesos.
       

        /// <summary>
        /// Crea un nuevo usuario si no existe otro con el mismo ID.
        /// </summary>
        public string CrearUsuario(string id, string nombre)
        {
            if (this.Usuarios.BuscarUsuario(id) != null)
            {
                return $"Ya existe un usuario con el ID '{id}'.";
            }
            

            Usuario nuevo = new Usuario(id, nombre);
            this.Usuarios.AgregarUsuario(nuevo);
            return $"Usuario '{nombre}' (ID: {id}) creado correctamente.";
        }

        /// <summary>
        /// Suspende a un usuario activo y lo mueve a la lista de suspendidos.
        /// </summary>
        public string SuspenderUsuario(string id)
        {
            Usuario usuario = this.Usuarios.BuscarUsuario(id);
            if (usuario == null)
            {
                return $"No se encontró un usuario con ID '{id}'.";
            }

            Usuarios.EliminarUsuario(usuario);
            UsuariosSuspendidos.Add(usuario);
            return $" El usuario '{usuario.Nombre}' ha sido suspendido correctamente.";
        }

        /// <summary>
        /// Elimina completamente a un usuario (activo o suspendido).
        /// </summary>
        public string EliminarUsuario(string id)
        {
            Usuario usuario = this.BuscarUsuario(id);
            bool eliminado = false;
            
            if (usuario != null)
            {
                Usuarios.EliminarUsuario(usuario);
                eliminado = true;
            }

            foreach (Usuario u in UsuariosSuspendidos)
            {
                if (u.ID == id)
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
                return $"🗑 El usuario '{usuario.Nombre}' ha sido eliminado del sistema.";
            }
            else
            {
                return $"No se encontró un usuario con ID '{id}'.";
            }
        }
        

    // Como vendedor, quiero poder asignar un cliente a otro vendedor para distribuir el trabajo en el equipo.
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
        
        public List<Llamadas> Llamadas = new List<Llamadas>();
        public List<Reunion> Reuniones = new List<Reunion>();

        public List<Cliente> BuscarClientesFachada(string atributo, string valorBusqueda)
        {
            return Clientes.BuscarCliente(atributo, valorBusqueda);
        }

        public Cliente CrearNuevoCliente(string id, string nombre, string apellido, string telefono, string correo)
        {
            this.Clientes.AgregaCliente(new Cliente(id, nombre, apellido, telefono, correo));
            return new Cliente(id, nombre, apellido, telefono, correo);
        }

        public void ModificarInfo(string id, string atributo, string nuevoValor)
        {
            Cliente cliente = Clientes.BuscarCliente("id", id)[0];

            string atributoNormalizado = atributo.Trim().ToLower();
            switch (atributoNormalizado)
            {
                case "nombre":
                    cliente.CambiarNombre(nuevoValor);
                    break;

                case "apellido":
                    cliente.CambiarApellido(nuevoValor);
                    break;

                case "telefono":
                    cliente.CambiarTelefono(nuevoValor);
                    break;

                case "correo":
                    cliente.CambiarCorreo(nuevoValor);
                    break;

                case "genero":
                    cliente.AsignarGenero(nuevoValor);
                    break;

                case "etiqueta":
                    cliente.AsignarEtiqueta(nuevoValor);
                    break;

                case "fechadenacimiento":
                    cliente.AsignarFechaDeNacimiento(nuevoValor);
                    break;

                default:
                    Console.WriteLine($"Atributo '{atributo}' no reconocido.");
                    break;
            }
        }

        public void EliminarClienteFachada(string id)
        {
            Cliente cliente = Clientes.BuscarCliente("id", id)[0];
            Clientes.EliminarCliente(cliente);
        }

        public RepoClientes VerClientes()
        {
            return Clientes;
        }

        // public void RegistrarLlamada(string id, string tema, string contenido)
        // {
        //     // Cliente cliente = Clientes.BuscarCliente("id", id)[0];
        //     // Llamadas llamada = new Llamadas(cliente, tema, contenido);
        //     // Llamadas.Add(llamada);
        // }

        // public void RegistrarReunion(string id, string tema, string ubicacion, string reunion, string cuando)
        // {
        //     Cliente cliente = Clientes.BuscarCliente("id", id)[0];
        //     Reunion Reunion = new Reunion(cliente, tema, ubicacion, reunion, cuando);
        //     Reuniones.Add(Reunion);
        // }

        public Usuario BuscarUsuario(string usuarioId)
        {
            return this.Usuarios.BuscarUsuario(usuarioId);
        }
        //=======================================================================================
        //                          Venta
        //=======================================================================================
        public string RegistrarVentaCliente(string clienteId, string producto, string fecha, string precio, string usuarioId)
        {
            Usuario usuario;
            Cliente cliente;

            // 1) Buscar usuario con manejo de errores propios
            try
            {
                usuario = this.Usuarios.BuscarUsuario(usuarioId);
            }
            catch (ArgumentNullException)
            {
                return "Error: faltan datos para registrar la venta.";
            }
            catch (Excepciones.EmptyStringException)
            {
                return "Error: uno o más campos están vacíos.";
            }

            if (usuario == null)
            {
                return $"Error: no se encontró un usuario con ID '{usuarioId}'.";
            }

            // 2) Buscar cliente con manejo de errores propios
            try
            {
                cliente = this.Clientes.BuscarUnCliente(clienteId);
            }
            catch (ArgumentNullException)
            {
                return "Error: faltan datos para registrar la venta.";
            }
            catch (Excepciones.EmptyStringException)
            {
                return "Error: uno o más campos están vacíos.";
            }

            if (cliente == null)
            {
                return $"Error: no se encontró un cliente con ID '{clienteId}'.";
            }

            // 3) Registrar venta con manejo de validaciones del repo
            try
            {
                this.Ventas.AgregarVenta(cliente, fecha, precio, producto, usuario);
                return $"Venta registrada: {cliente.Nombre} compró '{producto}' por ${precio} el {fecha}.";
            }
            catch (Excepciones.InvalidDateException)
            {
                return "Error: la fecha ingresada no es válida.";
            }
            catch (Excepciones.EmptyStringException)
            {
                return "Error: uno o más campos están vacíos.";
            }
            catch (ArgumentNullException)
            {
                return "Error: faltan datos para registrar la venta.";
            }
            catch (Exception)
            {
                return "Error: ocurrió un problema al registrar la venta.";
            }
        }
        
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
            catch (Excepciones.EmptyStringException)
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
            double total = 0.0;
            foreach (var venta in usuario.TotalVentas)
            {
                if (venta.Fecha >= fechaInicio && venta.Fecha <= fechaFin)
                {
                    double importe;
                    if (double.TryParse(venta.Importe, out importe))
                    {
                        total += importe;
                    }
                }
            }

            // 5) Respuesta formateada
            return $"Total de ventas desde {fechaInicio:dd/MM/yyyy} hasta {fechaFin:dd/MM/yyyy}: ${total:0.##}";
        }


        //==========================================================================================================
        
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
            catch (Excepciones.EmptyStringException)
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
            catch (Excepciones.EmptyStringException)
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
            catch (Excepciones.InvalidDateException)
            {
                return "Error: la fecha ingresada no es válida.";
            }
            catch (Excepciones.EmptyStringException)
            {
                return "Error: uno o más campos están vacíos.";
            }
            catch (ArgumentNullException)
            {
                return "Error: faltan datos para registrar la cotización.";
            }
            catch (Exception)
            {
                return "Error: ocurrió un problema al registrar la cotización.";
            }
        }


        
        // ------ YO ------
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
                    throw new Excepciones.EmptyStringException("El ID del vendedor no puede estar vacío");
                }
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    throw new Excepciones.EmptyStringException("El nombre del vendedor no puede estar vacío");
                }
                
                foreach (Vendedor v in Usuarios.Vendedores)
                {
                    if (v.Id == id)
                    {
                        throw new InvalidOperationException($"Ya existe un vendedor con el ID: {id}");
                    }
                }

                Vendedor vendedor = new Vendedor(id, nombre);
                Usuarios.Vendedores.Add(vendedor);
                return vendedor;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                throw;
            }
        }

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
                    throw new Excepciones.EmptyStringException("El ID del administrador no puede estar vacío");
                }
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    throw new Excepciones.EmptyStringException("El nombre del administrador no puede estar vacío");
                }

                foreach (Administrador a in Usuarios.Administradores)
                {
                    if (a.ID == id)
                    {
                        throw new InvalidOperationException($"Ya existe un administrador con el ID: {id}");
                    }
                }

                Administrador administrador = new Administrador(id, nombre);
                Usuarios.Administradores.Add(administrador);
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