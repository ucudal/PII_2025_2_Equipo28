using System;
using System.Collections.Generic;

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
        
        public ClienteLista listaClientes = new ClienteLista();
        public List<Llamadas> Llamadas = new List<Llamadas>();
        public List<Reunion> Reuniones = new List<Reunion>();
        
        public List<Cliente> BuscarClientesFachada(string atributo, string valorBusqueda)
        {
            return listaClientes.BuscarCliente(atributo, valorBusqueda);
        }
        public Cliente CrearNuevoCliente(string nombre, string apellido, string telefono, string correo)
        {
            return new Cliente(nombre, apellido, telefono, correo);
        }

        public void ModificarInfo(string id, string atributo, string nuevoValor)
        {
            Cliente cliente = listaClientes.BuscarCliente("id", id)[0];
            
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
            Cliente cliente = listaClientes.BuscarCliente("id", id)[0];
            listaClientes.EliminarCliente(cliente);
        }

        public ClienteLista VerClientes()
        {
            return listaClientes;
        }
        
        public void RegistrarLlamada(string id, string tema, string correo, string fecha)
        {
            Cliente cliente = listaClientes.BuscarCliente("id", id)[0];
            Llamadas llamada = new Llamadas(cliente, tema, correo, fecha);
            Llamadas.Add(llamada);
        }

        public void RegistrarReunion(string id, string tema, string fecha, string ubicacion)
        {
            Cliente cliente = listaClientes.BuscarCliente("id", id)[0];
            Reunion reunion = new Reunion(cliente, tema, fecha, ubicacion);
            Reuniones.Add(reunion);
        }
    }
}