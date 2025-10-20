using System;
using System.ComponentModel;

namespace Library
{
    public class Fachada
    {
        private ClienteLista clienteLista = new ClienteLista();

        public void RegistarMensaje(string clienteNombre,string clienteApellido, string mensaje, string tema, string usuarioId)
        {
            Usuario usuario = Listas.BuscarUsuario(usuarioId);
            if (usuario != null)
            {
                Cliente cliente = clienteLista.BuscarUnCliente(clienteNombre,clienteApellido);
                if (cliente != null)
                {
                    Mensajes Mensaje = new Mensajes(cliente, tema, mensaje);
                    usuario.Interacciones.Add(Mensaje);
                }
            }
        }

        public void RegistrarCorreos(string clienteNombre, string clienteApellido, string correo, string tema, string usuarioId)
        {
            Usuario usuario = Listas.BuscarUsuario(usuarioId);
            if (usuario != null)
            {
                Cliente cliente = clienteLista.BuscarUnCliente(clienteNombre, clienteApellido);
                if (cliente != null)
                {
                    Correos Correo = new Correos(cliente, tema, correo);
                    usuario.Interacciones.Add(Correo);
                }
            }
        }

        public void AgregarNota(string nota, string tipointeraccion, string tema, string usuarioId)
        {
            Usuario usuario = Listas.BuscarUsuario(usuarioId);
            if (usuario != null)
            {
                Interaccion interaccion = usuario.BuscarInteraccion(tipointeraccion, tema);
                if (interaccion != null)
                {
                    interaccion.AgergarNotas(nota);
                }
            }
        }

        public void AgregarEtiqueta(string clienteNombre, string clienteApellido, string etiqueta, string usuarioId)
        {
            Usuario usuario = Listas.BuscarUsuario(usuarioId);
            if (usuario != null)
            {
                Cliente cliente = clienteLista.BuscarUnCliente(clienteNombre, clienteApellido);
                if (cliente != null)
                {
                    usuario.AgregarEtiqueta(cliente,etiqueta);
                }
            }
        }

        public void RegistrarVenta(string clienteNombre, string clienteApellido, string producto, string fecha,
            string precio,string usuarioId)
        {
            Usuario usuario = Listas.BuscarUsuario(usuarioId);
            if (usuario != null)
            {
                Cliente cliente = clienteLista.BuscarUnCliente(clienteNombre, clienteApellido);
                if (cliente != null)
                {
                    usuario.VentaClienteAdd(cliente,producto,fecha,precio);
                }
            }
        }

        public void RegistarCotizacion(string clienteNombre, string clienteApellido, string producto, string fecha,
            string precio, string usuarioId)
        {
            Usuario usuario = Listas.BuscarUsuario(usuarioId);
            if (usuario != null)
            {
                Cliente cliente = clienteLista.BuscarUnCliente(clienteNombre, clienteApellido);
                if (cliente != null)
                {
                    usuario.AgregarCotizacion(cliente,fecha,precio);
                }
            }
        }
        
        //Cómo usuario quiero saber los clientes que hace cierto tiempo que no tengo ninguna interacción con ellos, para no peder contacto con ellos.
        public void VerInteraccionesDeCliente(string clienteNombre, string clienteApellido, string usuarioId, string tipo = "")
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

       public void AsignarClienteAOtroVendedor(string idVendedorActual, string idVendedorNuevo, string nombreCliente, string apellidoCliente)
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
       private ClienteLista clienteLista = new ClienteLista();

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
                                         ((Reunion)inter).Ubicacion +
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


    } 
}
