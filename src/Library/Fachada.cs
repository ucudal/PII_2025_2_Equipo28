using System;
using System.Collections.Generic;

namespace Library
{
    public class Fachada
    {
        public ClienteLista clienteLista = new ClienteLista();
        public RepoInteracciones Interacciones = new RepoInteracciones();
        public RepoEtiquetas Etiquetas = new RepoEtiquetas();
        public RepoCotizaciones Cotizaciones = new RepoCotizaciones();
        public RepoVentas Ventas = new RepoVentas();

        public void RegistarMensaje(string clienteId, string mensaje, string tema,
            string usuarioId, string cuando)
        {
            Usuario usuario=null;
            Mensajes Mensaje=null; //Inicializando larailala
            Cliente cliente=null;
            try
            {
                usuario = Listas.BuscarUsuario(usuarioId);
                cliente = clienteLista.BuscarUnCliente(clienteId);
                // Cliente cliente = Listas.BuscarCliente(clienteId); //Hecho comentario por si acaso
                Mensaje = new Mensajes(cliente, tema, mensaje, cuando);

            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Excepciones.EmptyStringException e)
            {
                Console.WriteLine(e.Message);
            }
            if (usuario != null)
            {
                if (cliente != null)
                {
                    Interacciones.AgregarInteraccion(Mensaje, usuario);
                }
            }
        }

        public void RegistrarCorreo(string clienteId, string correo, string tema,
            string usuarioId, string cuando)
        {
            Usuario usuario=null;
            Correos Correo=null; //Inicializando larailala
            Cliente cliente=null;
            try
            {
                usuario = Listas.BuscarUsuario(usuarioId);
                cliente = clienteLista.BuscarUnCliente(clienteId);
                // Cliente cliente = Listas.BuscarCliente(clienteId); //Hecho comentario por si acaso
                Correo = new Correos(cliente, tema, correo, cuando);

            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Excepciones.EmptyStringException e)
            {
                Console.WriteLine(e.Message);
            }
            if (usuario != null)
            {
                if (cliente != null)
                {
                    Interacciones.AgregarInteraccion(Correo, usuario);
                }
            }
        }

        public void AgregarNota(string nota, string tipointeraccion, string tema, string usuarioId)
        {
            Usuario usuario = Listas.BuscarUsuario(usuarioId);
            if (usuario != null)
            {
                Interaccion interaccion = Interacciones.BuscarInteraccion(tipointeraccion, tema);
                if (interaccion != null)
                {
                    interaccion.AgergarNotas(nota);
                }
            }
        }

        public void AgregarEtiquetaCliente(string clienteId, string etiqueta, string usuarioId)
        {
            Usuario usuario = Listas.BuscarUsuario(usuarioId);
            if (usuario != null)
            {
                Cliente cliente = Listas.BuscarCliente(clienteId);
                if (cliente != null)
                {
                    if (Etiquetas.BuscarEtiqueta(etiqueta))
                    {
                        cliente.Etiquetas.Add(etiqueta);
                    }
                }
            }
        }

        public void AgregarEtiquetaLista(string etiqueta, string usuarioId)
        {
            Usuario usuario = Listas.BuscarUsuario(usuarioId);
            if (usuario != null)
            {
                
            }
        }

        public void RegistrarVenta(string clienteId, string producto, string fecha,
            string precio, string usuarioId)
        {
            Usuario usuario = Listas.BuscarUsuario(usuarioId);
            if (usuario != null)
            {
                Cliente cliente = Listas.BuscarCliente(clienteId);
                if (cliente != null)
                {
                    Ventas.AgregarVenta(cliente, fecha, precio, producto,usuario);
                }
            }
        }

        public void RegistarCotizacion(string clienteId, string fecha,
            string precio, string usuarioId)
        {
            Usuario usuario = Listas.BuscarUsuario(usuarioId);
            if (usuario != null)
            {
                Cliente cliente = Listas.BuscarCliente(clienteId);
                if (cliente != null)
                {
                    Cotizaciones.AgregarCotizacion(cliente, fecha, precio, usuario);
                }
            }
        }

        //Cómo usuario quiero saber los clientes que hace cierto tiempo que no tengo ninguna interacción con ellos, para no peder contacto con ellos.
        public void VerInteraccionesDeCliente(string clienteNombre, string clienteApellido, string usuarioId,
            string tipo = "")
            {
                Usuario usuario = Listas.BuscarUsuario(usuarioId);
                if (usuario != null)
                {
                    Cliente cliente = clienteLista.BuscarUnCliente(clienteNombre, clienteApellido);
                    if (cliente != null)
                    {
                        Console.WriteLine($"Interacciones con {clienteNombre} {clienteApellido}:");

                        foreach (Interaccion interaccion in usuario.Interacciones)
                        {
                            // Verifica que la interacción sea del cliente buscado
                            if (interaccion.Cliente == cliente)
                            {
                                // Si se pasa un tipo, solo muestra las que coincidan
                                if (tipo == "" || interaccion.tipo == tipo)
                                {
                                    Console.WriteLine("-----------------------------------");
                                    Console.WriteLine($"Tipo: {interaccion.tipo}");
                                    Console.WriteLine($"Fecha: {interaccion.Fecha}");
                                    Console.WriteLine($"Tema: {interaccion.Tema}");
                                    Console.WriteLine($"Descripción: {interaccion.contenido}");
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Cliente no encontrado.");
                    }
                }
                else
                {
                    Console.WriteLine("Usuario no encontrado.");
                }
            }

            // Como administrador quiero crear, suspender o eliminar usuarios, para mantener control sobre los accesos.

            public void CrearUsuario(string adminId, string nuevoId, string nuevoNombre)
            {
                Administrador admin = Listas.BuscarAdministrador(adminId);
                if (admin != null)
                {
                    Usuario nuevo = admin.CrearUsuario(nuevoId, nuevoNombre);
                    Console.WriteLine("Usuario creado correctamente: " + nuevo.Nombre);
                }
                else
                {
                    Console.WriteLine("Administrador no encontrado.");
                }
            }

            public void SuspenderUsuario(string adminId, string usuarioId)
            {
                Administrador admin = Listas.BuscarAdministrador(adminId);
                if (admin != null)
                {
                    Usuario usuario = Listas.BuscarUsuario(usuarioId);
                    if (usuario != null)
                    {
                        admin.SuspenderUsuario(usuario);
                        Console.WriteLine("Usuario suspendido: " + usuario.Nombre);
                    }
                    else
                    {
                        Console.WriteLine("Usuario no encontrado.");
                    }
                }
                else
                {
                    Console.WriteLine("Administrador no encontrado.");
                }
            }

            public void EliminarUsuario(string adminId, string usuarioId)
            {
                Administrador admin = Listas.BuscarAdministrador(adminId);
                if (admin != null)
                {
                    Usuario usuario = Listas.BuscarUsuario(usuarioId);
                    if (usuario != null)
                    {
                        admin.EliminarUsuario(usuario);
                        Console.WriteLine("Usuario eliminado: " + usuario.Nombre);
                    }
                    else
                    {
                        Console.WriteLine("Usuario no encontrado.");
                    }
                }
                else
                {
                    Console.WriteLine("Administrador no encontrado.");
                }
            }

            // Como vendedor, quiero poder asignar un cliente a otro vendedor para distribuir el trabajo en el equipo.

            public void AsignarClienteAOtroVendedor(string idVendedorActual, string idVendedorNuevo, string nombreCliente,
                string apellidoCliente)
            {
                Vendedor vendedorActual = Listas.BuscarVendedor(idVendedorActual);
                Vendedor vendedorNuevo = Listas.BuscarVendedor(idVendedorNuevo);
                Cliente cliente = clienteLista.BuscarUnCliente(nombreCliente, apellidoCliente);

                if (vendedorActual != null && vendedorNuevo != null && cliente != null)
                {
                    vendedorActual.Clientes.Remove(cliente);
                    vendedorNuevo.Clientes.Add(cliente);
                    Console.WriteLine("Cliente reasignado correctamente.");
                }
                else
                {
                    Console.WriteLine("Error: vendedor o cliente no encontrado.");
                }
            }

            //Como usuario quiero saber el total de ventas de un periodo dado, para analizar en rendimiento de mi negocio.

            public void TotalDeVentasEnPeriodo(string usuarioId, string fechaInicioTexto, string fechaFinTexto)
            {
                Usuario usuario = Listas.BuscarUsuario(usuarioId);

                if (usuario != null)
                {
                    DateTime fechaInicio = DateTime.Parse(fechaInicioTexto);
                    DateTime fechaFin = DateTime.Parse(fechaFinTexto);
                    double total = 0;

                    foreach (Venta venta in usuario.Total_Ventas)
                    {
                        if (venta.Fecha >= fechaInicio && venta.Fecha <= fechaFin)
                        {
                            double importe;
                            if (double.TryParse(venta.Importe, out importe))
                            {
                                total = total + importe;
                            }
                        }
                    }

                    Console.WriteLine("Total de ventas desde " + fechaInicio.ToShortDateString() +
                                      " hasta " + fechaFin.ToShortDateString() + ": $" + total);
                }
                else
                {
                    Console.WriteLine("Usuario no encontrado.");
                }
            }

            //Como usuario quiero ver un panel con clientes totales, interacciones recientes y reuniones próximas, para tener un resumen rápido.

            public void VerPanelResumen(string usuarioId)
            {
                Usuario usuario = Listas.BuscarUsuario(usuarioId);
                if (usuario != null)
                {
                    Console.WriteLine("===== PANEL DE RESUMEN =====");

                    // Clientes totales
                    Console.WriteLine("Clientes totales: " + clienteLista.Clientes.Count);

                    // Interacciones recientes (últimos 7 días)
                    DateTime limite = DateTime.Now.AddDays(-7);
                    Console.WriteLine("\nInteracciones recientes (últimos 7 días):");
                    foreach (Interaccion inter in usuario.Interacciones)
                    {
                        if (inter.Fecha >= limite)
                        {
                            Console.WriteLine(inter.Cliente.Nombre + " " + inter.Cliente.Apellido +
                                              " - " + inter.tipo + " (" + inter.Fecha.ToShortDateString() + ")");
                        }
                    }

                    // Reuniones próximas (próximos 7 días)
                    DateTime hoy = DateTime.Now;
                    DateTime futuro = hoy.AddDays(7);
                    Console.WriteLine("\nReuniones próximas (próximos 7 días):");
                    foreach (Interaccion inter in usuario.Interacciones)
                    {
                        if (inter.tipo == "reunion" && inter.Fecha >= hoy && inter.Fecha <= futuro)
                        {
                            Console.WriteLine(inter.Cliente.Nombre + " " + inter.Cliente.Apellido +
                                              " - " + inter.Tema + " en " +
                                              ((Reunion)inter).lugar +
                                              " (" + inter.Fecha.ToShortDateString() + ")");
                        }
                    }

                    Console.WriteLine("=============================");
                }
                else
                {
                    Console.WriteLine("Usuario no encontrado.");
                }
            }

            public List<Llamadas> Llamadas = new List<Llamadas>();
            public List<Reunion> Reuniones = new List<Reunion>();

            public List<Cliente> BuscarClientesFachada(string atributo, string valorBusqueda)
            {
                return clienteLista.BuscarCliente(atributo, valorBusqueda);
            }

            public Cliente CrearNuevoCliente(string nombre, string apellido, string telefono, string correo)
            {
                return new Cliente(nombre, apellido, telefono, correo);
            }

            public void ModificarInfo(string id, string atributo, string nuevoValor)
            {
                Cliente cliente = clienteLista.BuscarCliente("id", id)[0];

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
                Cliente cliente = clienteLista.BuscarCliente("id", id)[0];
                clienteLista.EliminarCliente(cliente);
            }

            public ClienteLista VerClientes()
            {
                return clienteLista;
            }

            public void RegistrarLlamada(string id, string tema, string contenido)
            {
                Cliente cliente = clienteLista.BuscarCliente("id", id)[0];
                Llamadas llamada = new Llamadas(cliente, tema, contenido);
                Llamadas.Add(llamada);
            }

            public void RegistrarReunion(string id, string tema, string ubicacion, string reunion, string cuando)
            {
                Cliente cliente = clienteLista.BuscarCliente("id", id)[0];
                Reunion Reunion = new Reunion(cliente, tema, ubicacion, reunion, cuando);
                Reuniones.Add(Reunion);
            }
        }
    }

