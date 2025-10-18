using System;
using System.ComponentModel;

namespace Library
{
    public class Fachada
    {
        private Listas listas = new Listas();
        private ClienteLista clienteLista = new ClienteLista();
        
        public void RegistarMensaje(string clienteNombre,string mensaje, string tema, string usuarioId)
        {
            Usuario usuario = listas.BuscarUsuario(usuarioId);
            if (usuario!=null)
            {
                Cliente cliente = clienteLista.BuscarUnCliente(clienteNombre);
                if (cliente!= null)
                {
                    Mensajes Mensaje = new Mensajes(cliente, tema, mensaje);
                    usuario.Interacciones.Add(Mensaje);
                }
            }
            return;
        }

        /*public void RegistrarCorreos(Cliente cliente,string correo, string tema, string fecha, Usuario usuario)
        {
            Correos Correo = new Correos(cliente, tema, fecha, correo);
            usuario.Interacciones.Add(Correo);
        }

        public void AgregarNota(string nota, Interaccion interaccion)
        {
            interaccion.AgergarNotas(nota);
        }
    }
}