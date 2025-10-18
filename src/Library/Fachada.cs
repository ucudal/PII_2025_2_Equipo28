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
    }
}
