using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using NUnit.Framework;

namespace Library.Tests
{
    public class TestFachada_Historia_8_15_
    {
        private Fachada fachada;
        private Usuario usuario;
        private Cliente cliente;
        private Administrador administrador;
        
        [SetUp]
        public void Setup()
        {
            fachada = Fachada.Instancia;
            fachada.CrearUsuario("1", "El petizo", "A1");
            usuario = fachada.BuscarUsuario("1");
            fachada.CrearNuevoCliente("El peluca", "Sape", "099872521", "099818378172","Peluca@cabezatermo.com");
            List<Cliente> clientes = fachada.BuscarClientesFachada("correo", "Peluca@cabezatermo.com");
            cliente = clientes[0];
            cliente.Id = "0";
            fachada.Interacciones.eliminarinteraciones();

        }

        [Test]
        //Verifica que el mensaje que se encuentra en el repointeraccion de fachada sea el mismo que registro.
        public void RegistarMensajeCorrectoTest()
        {
            fachada.RegistarMensaje("0", "este.... hola", "saludo", "1", "10/11/2024");
            Interaccion interaccion = fachada.Interacciones.BuscarInteraccion(usuario, "mensaje", "saludo");
            List<object> esperado = new List<object>()
            {
                cliente, usuario, Interaccion.TipoInterracion.Mensaje, "saludo", "este.... hola",
                new DateTime(2024, 11, 10)
            };
            List<object> resultado = new List<object>()
            {
                interaccion.Cliente, interaccion.Usuario, interaccion.Tipo, interaccion.Tema, interaccion.Contenido,
                interaccion.Fecha
            };
            Assert.That(resultado, Is.EqualTo(esperado));
        }

        [TestCase("0", "", "lol", "1", "10/11/2024", "datos de interaccion vacios")]
        [TestCase("0", "f", "", "1", "10/11/2024", "datos de interaccion vacios")]
        [TestCase("0", "f", "lol", "1", "", "datos de interaccion vacios")]
        public void RegistraMensajeIncorrectoTextoVacio(string a, string b, string c, string d, string e,
            string esperado)
        {
            string resultado = fachada.RegistarMensaje(a, b, c, d, e);
            Assert.That(resultado, Is.EqualTo(esperado));
        }

        [TestCase(null, "f", "lol", "1", "10/11/2024", "Value cannot be null. (Parameter 'Datos de cliente null')")]
        [TestCase("0", null, "f", "1", "10/11/2024", "Value cannot be null. (Parameter 'datos de interaccion null')")]
        [TestCase("0", "f", null, "1", "10/11/2024", "Value cannot be null. (Parameter 'datos de interaccion null')")]
        [TestCase("0", "f", "lol", null, "10/11/2024", "Value cannot be null. (Parameter 'datos de usuario null')")]
        [TestCase("0", "f", "lol", "1", null, "Value cannot be null. (Parameter 'datos de interaccion null')")]
        public void RegistarMensajeIncorrectoContenidoNull(string a, string b, string c, string d, string e,
            string esperado)
        {
            string resultado = fachada.RegistarMensaje(a, b, c, d, e);
            Assert.That(resultado, Is.EqualTo(esperado));
        }

        [TestCase("0", "f", "lol", "1", "10/11/2027", "Fecha no valida")]
        [TestCase("0", "f", "lol", "1", "10/17/2024", "Fecha no valida")]
        [TestCase("0", "f", "lol", "1", "50/11/2024", "Fecha no valida")]
        public void RegistarMensajeIncorrectoFechaNovalida(string a, string b, string c, string d, string e,
            string esperado)
        {
            string resultado = fachada.RegistarMensaje(a, b, c, d, e);
            Assert.That(resultado, Is.EqualTo(esperado));
        }

        [Test]
        //Verifica que el registro de llamada se almacene correctamente en el repo correspondiente.
        public void RegistarLlamadaCorrectaTest()
        {
            fachada.RegistarLlamada("0", "llamada de prueba", "seguimiento", "1", "10/11/2024");
            Interaccion interaccion = fachada.Interacciones.BuscarInteraccion(usuario, "llamada", "seguimiento");
            List<object> esperado = new List<object>()
            {
                cliente, usuario, Interaccion.TipoInterracion.Llamada, "seguimiento", "llamada de prueba",
                new DateTime(2024, 11, 10)
            };
            List<object> resultado = new List<object>()
            {
                interaccion.Cliente, interaccion.Usuario, interaccion.Tipo, interaccion.Tema, interaccion.Contenido,
                interaccion.Fecha
            };
            Assert.That(resultado, Is.EqualTo(esperado));
        }

        [TestCase("0", "", "lol", "1", "10/11/2024", "datos de interaccion vacios")]
        [TestCase("0", "f", "", "1", "10/11/2024", "datos de interaccion vacios")]
        [TestCase("0", "f", "lol", "1", "", "datos de interaccion vacios")]
        public void RegistarLlamadaIncorrectoTextoVacio(string a, string b, string c, string d, string e,
            string esperado)
        {
            string resultado = fachada.RegistarLlamada(a, b, c, d, e);
            Assert.That(resultado, Is.EqualTo(esperado));
        }

        [TestCase(null, "f", "lol", "1", "10/11/2024", "Value cannot be null. (Parameter 'Datos de cliente null')")]
        [TestCase("0", null, "f", "1", "10/11/2024", "Value cannot be null. (Parameter 'datos de interaccion null')")]
        [TestCase("0", "f", null, "1", "10/11/2024", "Value cannot be null. (Parameter 'datos de interaccion null')")]
        [TestCase("0", "f", "lol", null, "10/11/2024", "Value cannot be null. (Parameter 'datos de usuario null')")]
        [TestCase("0", "f", "lol", "1", null, "Value cannot be null. (Parameter 'datos de interaccion null')")]
        public void RegistarLlamadaIncorrectoContenidoNull(string a, string b, string c, string d, string e,
            string esperado)
        {
            string resultado = fachada.RegistarLlamada(a, b, c, d, e);
            Assert.That(resultado, Is.EqualTo(esperado));
        }

        [TestCase("0", "f", "lol", "1", "10/11/2027", "Fecha no valida")]
        [TestCase("0", "f", "lol", "1", "10/17/2024", "Fecha no valida")]
        [TestCase("0", "f", "lol", "1", "50/11/2024", "Fecha no valida")]
        public void RegistarLlamadaIncorrectoFechaNovalida(string a, string b, string c, string d, string e,
            string esperado)
        {
            string resultado = fachada.RegistarLlamada(a, b, c, d, e);
            Assert.That(resultado, Is.EqualTo(esperado));
        }

        [Test]
        //Verifica que el registro de correo se almacene correctamente en el repo correspondiente.
        public void RegistarCorreoCorrectoTest()
        {
            fachada.RegistrarCorreo("0", "mensaje de correo", "consulta", "1", "10/11/2024");
            Interaccion interaccion = fachada.Interacciones.BuscarInteraccion(usuario, "correo", "consulta");
            List<object> esperado = new List<object>()
            {
                cliente, usuario, Interaccion.TipoInterracion.Correo, "consulta", "mensaje de correo",
                new DateTime(2024, 11, 10)
            };
            List<object> resultado = new List<object>()
            {
                interaccion.Cliente, interaccion.Usuario, interaccion.Tipo, interaccion.Tema, interaccion.Contenido,
                interaccion.Fecha
            };
            Assert.That(resultado, Is.EqualTo(esperado));
        }

        [TestCase("0", "", "lol", "1", "10/11/2024", "datos de interaccion vacios")]
        [TestCase("0", "f", "", "1", "10/11/2024", "datos de interaccion vacios")]
        [TestCase("0", "f", "lol", "1", "", "datos de interaccion vacios")]
        public void RegistarCorreoIncorrectoTextoVacio(string a, string b, string c, string d, string e,
            string esperado)
        {
            string resultado = fachada.RegistrarCorreo(a, b, c, d, e);
            Assert.That(resultado, Is.EqualTo(esperado));
        }

        [TestCase(null, "f", "lol", "1", "10/11/2024", "Value cannot be null. (Parameter 'Datos de cliente null')")]
        [TestCase("0", null, "f", "1", "10/11/2024", "Value cannot be null. (Parameter 'datos de interaccion null')")]
        [TestCase("0", "f", null, "1", "10/11/2024", "Value cannot be null. (Parameter 'datos de interaccion null')")]
        [TestCase("0", "f", "lol", null, "10/11/2024", "Value cannot be null. (Parameter 'datos de usuario null')")]
        [TestCase("0", "f", "lol", "1", null, "Value cannot be null. (Parameter 'datos de interaccion null')")]
        public void RegistarCorreoIncorrectoContenidoNull(string a, string b, string c, string d, string e,
            string esperado)
        {
            string resultado = fachada.RegistrarCorreo(a, b, c, d, e);
            Assert.That(resultado, Is.EqualTo(esperado));
        }

        [TestCase("0", "f", "lol", "1", "10/11/2027", "Fecha no valida")]
        [TestCase("0", "f", "lol", "1", "10/17/2024", "Fecha no valida")]
        [TestCase("0", "f", "lol", "1", "50/11/2024", "Fecha no valida")]
        public void RegistarCorreoIncorrectoFechaNovalida(string a, string b, string c, string d, string e,
            string esperado)
        {
            string resultado = fachada.RegistrarCorreo(a, b, c, d, e);
            Assert.That(resultado, Is.EqualTo(esperado));
        }

        [Test]
//Verifica que el registro de reunión se almacene correctamente en el repo correspondiente.
        public void RegistarReunionCorrectaTest()
        {
            fachada.RegistarReunion("0", "reunion con cliente", "presentacion", "1", "10/11/2024", "aca");
            Interaccion interaccion = fachada.Interacciones.BuscarInteraccion(usuario, "reunion", "presentacion");
            List<object> esperado = new List<object>()
            {
                cliente, usuario, Interaccion.TipoInterracion.Reunion, "presentacion", "reunion con cliente",
                new DateTime(2024, 11, 10), "aca"
            };
            List<object> resultado = new List<object>()
            {
                interaccion.Cliente, interaccion.Usuario, interaccion.Tipo, interaccion.Tema, interaccion.Contenido,
                interaccion.Fecha, interaccion.Lugar
            };
            Assert.That(resultado, Is.EqualTo(esperado));
        }

        [Test]
        //Para poder agendar reuniones
        public void RegistarReunionCorrectaFechaFuturaTest()
        {
            fachada.RegistarReunion("0", "reunion con cliente", "presenta", "1", "10/11/2028", "aca");
            Interaccion interaccion = fachada.Interacciones.BuscarInteraccion(usuario, "reunion", "presenta");
            List<object> esperado = new List<object>()
            {
                cliente, usuario, Interaccion.TipoInterracion.Reunion, "presenta", "reunion con cliente",
                new DateTime(2028, 11, 10), "aca"
            };
            List<object> resultado = new List<object>()
            {
                interaccion.Cliente, interaccion.Usuario, interaccion.Tipo, interaccion.Tema, interaccion.Contenido,
                interaccion.Fecha, interaccion.Lugar
            };
            Assert.That(resultado, Is.EqualTo(esperado));
        }

        [TestCase("0", "", "lol", "1", "10/11/2024", "aca", "datos de interaccion vacios")]
        [TestCase("0", "f", "", "1", "10/11/2024", "aca", "datos de interaccion vacios")]
        [TestCase("0", "f", "lol", "1", "", "aca", "datos de interaccion vacios")]
        [TestCase("0", "f", "lol", "1", "10/11/2024", "", "datos de interaccion vacios")]

        public void RegistarReunionIncorrectoTextoVacio(string a, string b, string c, string d, string e, string f,
            string esperado)
        {
            string resultado = fachada.RegistarReunion(a, b, c, d, e, f);
            Assert.That(resultado, Is.EqualTo(esperado));
        }

        [TestCase(null, "f", "lol", "1", "10/11/2024", "aca",
            "Value cannot be null. (Parameter 'Datos de cliente null')")]
        [TestCase("0", null, "f", "1", "10/11/2024", "aca",
            "Value cannot be null. (Parameter 'datos de interaccion null')")]
        [TestCase("0", "f", null, "1", "10/11/2024", "aca",
            "Value cannot be null. (Parameter 'datos de interaccion null')")]
        [TestCase("0", "f", "lol", null, "10/11/2024", "aca",
            "Value cannot be null. (Parameter 'datos de usuario null')")]
        [TestCase("0", "f", "lol", "1", null, "aca", "Value cannot be null. (Parameter 'datos de interaccion null')")]
        [TestCase("0", "f", null, "1", "10/11/2024", null,
            "Value cannot be null. (Parameter 'datos de interaccion null')")]

        public void RegistarReunionIncorrectoContenidoNull(string a, string b, string c, string d, string e, string f,
            string esperado)
        {
            string resultado = fachada.RegistarReunion(a, b, c, d, e, f);
            Assert.That(resultado, Is.EqualTo(esperado));
        }

        [TestCase("0", "f", "lol", "1", "10/17/2024", "aca", "Fecha no valida")]
        [TestCase("0", "f", "lol", "1", "50/11/2024", "aca", "Fecha no valida")]
        public void RegistarReunionIncorrectoFechaNovalida(string a, string b, string c, string d, string e, string f,
            string esperado)
        {
            string resultado = fachada.RegistarReunion(a, b, c, d, e, f);
            Assert.That(resultado, Is.EqualTo(esperado));
        }

        [Test]
        public void AgregarNotaTest()
        {
            fachada.RegistarMensaje("0", "este.... hola", "saludo", "1", "10/11/2024");
            fachada.AgregarNota("hi", "mensaje", "saludo", "1");
            Interaccion interaccion = fachada.Interacciones.BuscarInteraccion(usuario, "mensaje", "saludo");
            string esperado = "hi";
            string resultado = interaccion.Notas;
            Assert.That(resultado, Is.EqualTo(esperado));
        }

        [TestCase("", "mensaje", "saludo", "1", "el contenido de la nota esta vacio")]
        [TestCase("hi", "", "saludo", "1", "datos vacios")]
        [TestCase("hi", "mensaje", "", "1", "datos vacios")]
        [TestCase("hi", "mensaje", "saludo", "", "datos de usuario vacios")]
        public void AgregarNotaStringVacio(string a, string b, string c, string d, string esperado)
        {
            fachada.RegistarMensaje("0", "este.... hola", "saludo", "1", "10/11/2024");
            string resultado = fachada.AgregarNota(a, b, c, d);
            Assert.That(resultado, Is.EqualTo(esperado));
        }

        [TestCase(null, "mensaje", "saludo", "1",
            "Value cannot be null. (Parameter 'El contenido de la nota es null')")]
        [TestCase("hi", null, "saludo", "1", "Value cannot be null. (Parameter 'el usuario es null')")]
        [TestCase("hi", "mensaje", null, "1", "Value cannot be null. (Parameter 'el usuario es null')")]
        [TestCase("hi", "mensaje", "saludo", null, "Value cannot be null. (Parameter 'datos de usuario null')")]
        public void AgregarNotaNull(string a, string b, string c, string d, string esperado)
        {
            fachada.RegistarMensaje("0", "este.... hola", "saludo", "1", "10/11/2024");
            string resultado = fachada.AgregarNota(a, b, c, d);
            Assert.That(resultado, Is.EqualTo(esperado));
        }

        [Test]
        //Verifica que devuelva correctamente las interacciones de un cliente con tipo y fecha especificados.
        public void InteraccionesClienteCorrectoTest()
        {
            fachada.RegistarMensaje("0", "este.... hola", "saludo", "1", "10/11/2024");
            string resultado = fachada.InteraccionesCliente("0", "1", "mensaje", "10/11/2024");

            string esperado = "las interaccion de " + cliente.Nombre + " " + cliente.Apellido +
                              " del tipo mensaje de la fecha 10/11/2024 son las siguientes:\n" +
                              "\n" + "saludo:\neste.... hola\n";

            Assert.That(resultado, Is.EqualTo(esperado));
        }

        [TestCase(null, "1", "mensaje", "10/11/2024", "Value cannot be null. (Parameter 'Datos de cliente null')")]
        [TestCase("0", null, "mensaje", "10/11/2024", "Value cannot be null. (Parameter 'datos de usuario null')")]
        public void InteraccionesClienteNull(string a, string b, string c, string d, string esperado)
        {
            string resultado = fachada.InteraccionesCliente(a, b, c, d);
            Assert.That(resultado, Is.EqualTo(esperado));
        }

        [TestCase("", "1", "mensaje", "10/11/2024", "Datos de cliente vacios")]
        [TestCase("0", "", "mensaje", "10/11/2024", "datos de usuario vacios")]
        public void InteraccionesClienteVacio(string a, string b, string c, string d, string esperado)
        {
            string resultado = fachada.InteraccionesCliente(a, b, c, d);
            Assert.That(resultado, Is.EqualTo(esperado));
        }

        [TestCase("0", "1", "mensaje", "15/25/2024", "Fecha no valida")]
        [TestCase("0", "1", "mensaje", "50/11/2024", "Fecha no valida")]
        public void InteraccionesClienteFechaNoValida(string a, string b, string c, string d, string esperado)
        {
            string resultado = fachada.InteraccionesCliente(a, b, c, d);
            Assert.That(resultado, Is.EqualTo(esperado));
        }

        [Test]
//Verifica que el método devuelva correctamente los clientes con los que no se interactúa hace un mes o más.
        public void InterraccionClienteAusenteCorrectoTest()
        {
            fachada.RegistarMensaje("0", "mensaje viejo", "seguimiento", "1", "10/09/2024");
            fachada.RegistarMensaje("0", "mensaje reciente", "seguimiento", "1", "05/11/2024");

            string resultado = fachada.InterraccionClienteAusente("1");

            string esperado = "Los clientes con los que no interactua hace un mes o mas son:\n" + cliente.ToString();
            Assert.That(resultado, Is.EqualTo(esperado));
        }

        [TestCase(null, "Value cannot be null. (Parameter 'datos de usuario null')")]
        public void InterraccionClienteAusenteNull(string a, string esperado)
        {
            string resultado = fachada.InterraccionClienteAusente(a);
            Assert.That(resultado, Is.EqualTo(esperado));
        }

        [TestCase("", "datos de usuario vacios")]
        public void InterraccionClienteAusenteVacio(string a, string esperado)
        {
            string resultado = fachada.InterraccionClienteAusente(a);
            Assert.That(resultado, Is.EqualTo(esperado));
        }

        [TestCase("999", "No se reconoce el usuario")]
        public void InterraccionClienteAusenteUsuarioInexistente(string a, string esperado)
        {
            string resultado = fachada.InterraccionClienteAusente(a);
            Assert.That(resultado, Is.EqualTo(esperado));
        }

          // [Test]
          //   // Tiene problemas por el tema singleton, pero solo por el resultado, al cambiar con cada agregado de test:
          // //Verifica que el panel muestre correctamente los clientes, interacciones recientes y reuniones próximas.
          // public void PanelCorrectoTest()
          // {
          //     fachada.CrearUsuario("1", "El petizo", "A1");
          //     usuario = fachada.BuscarUsuario("1");
          //     fachada.RegistrarCorreo("0", "k", "e", "1", "10/12/2000");
          //     fachada.RegistarReunion("0", "k", "e", "1", "12/10/2050", "n");
          //     Interaccion interaccion = fachada.Interacciones.BuscarInteraccion(usuario, "correo", "e");
          //     interaccion.Fecha = DateTime.Now.AddDays(-2);
          //     string resultado = fachada.Panel("1");
          //     string esperado =
          //         "Los Clientes totales son los siguientes:\nSape 099872521\nSus interacciones mas recientes son:\nSape 099872521. Interaccion de tipo Correo. Tema: e\nSus reuniones proximas son:\nTema de la reunion: e. Fecha: 12/10/2050 0:00:00\n";
          //     Assert.That(resultado, Is.EqualTo(esperado));
          // }

         [Test]
         public void AgregarClienteContactoTest()
         {
             fachada.AgregarClienteContacto("1", "0");
             Cliente esperado = fachada.ClientesContacto[usuario][0];
             Assert.That(cliente,Is.EqualTo(esperado));
         }
        [Test]
         public void VerClienteContactoTest()
         {
             string resultado = fachada.VerClienteContacto("1");
             string esperado = "Los clientes que se pusieron en contacto contigo son:\nSape 099872521\n";
             Assert.That(resultado, Is.EqualTo(esperado));
         }

        [TestCase(null, "0", "Value cannot be null. (Parameter 'datos de usuario null')")]
        [TestCase("1", null, "Value cannot be null. (Parameter 'Datos de cliente null')")]
        [TestCase("", "0", "datos de usuario vacios")]
        [TestCase("1", "", "Datos de cliente vacios")]
        public void AgregarClienteContactoIncorrectoTest(string usuarioId, string clienteId, string esperado)
        {
            string resultado = fachada.AgregarClienteContacto(usuarioId, clienteId);
            Assert.That(resultado, Is.EqualTo(esperado));
        }
        [TestCase(null, "Value cannot be null. (Parameter 'datos de usuario null')")]
        [TestCase("", "datos de usuario vacios")]
        public void VerClienteContactoIncorrectoTest(string usuarioId, string esperado)
        {
            string resultado = fachada.VerClienteContacto(usuarioId);
            Assert.That(resultado, Is.EqualTo(esperado));
        }
    }
}
