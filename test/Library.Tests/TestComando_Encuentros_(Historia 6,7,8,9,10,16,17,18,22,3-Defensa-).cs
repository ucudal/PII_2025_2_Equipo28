using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using NUnit.Framework;
namespace Library.Tests
{
    public class TetsComando_Encuentros_6_7_8_9_10_16_17_18_22_3Defensa
    {
        private Fachada fachada;
        private Usuario usuario;
        private Cliente cliente1;
        private Cliente cliente2;
        private Administrador administrador;


        [SetUp]
        public void Setup()
        {
            fachada = Fachada.Instancia;
            fachada.UsuariosSuspendidos.Clear();
            fachada.Usuarios.EliminarDatos();
            fachada.Cotizaciones.EliminarDatos();
            fachada.Interacciones.EliminarDatos();
            fachada.Etiquetas.EliminarDatos();
            fachada.Clientes.EliminarDatos();
            fachada.ClientesContacta.ElminarDatos();
            fachada.Ventas.EliminarDatos();
            fachada.CrearAdministrador("A1", "Lansaguisantes");
            fachada.CrearUsuario("U1", "Petaseta", "A1");
            fachada.CrearCliente("C1", "Harry", "ElSucioPotter", "099786435", "Harringy@cabezatermo.com");
            fachada.CrearCliente("C2", "Hermione", "Granger", "46872390", "Hermy@cabezatermo.com");
        }
        [Test]
        public void Comando_registarMensaje()
        {
            fachada.RegistrarMensaje("C1", "test de comando", "test", "U1", "29/11/2025");
            string resulatdo = fachada.InteraccionesCliente("C1", "U1", "mensaje", "29/11/2025");
            
            Assert.That(resulatdo, Does.Contain("test de comando"));
            Assert.That(resulatdo, Does.Contain("test"));

        }
        [Test]
        public void Comando_registarLlamada()
        {
            fachada.RegistrarLlamada("C1", "test de comando", "test", "U1", "29/11/2025");
            string resulatdo = fachada.InteraccionesCliente("C1", "U1", "llamada", "29/11/2025");
            
            Assert.That(resulatdo, Does.Contain("test de comando"));
            Assert.That(resulatdo, Does.Contain("test"));
        }
        [Test]
        public void Comando_registarCorreo()
        {
            fachada.RegistrarCorreo("C1", "test de comando", "test", "U1", "29/11/2025");
            string resulatdo = fachada.InteraccionesCliente("C1", "U1", "correo", "29/11/2025");
            
            Assert.That(resulatdo, Does.Contain("test de comando"));
            Assert.That(resulatdo, Does.Contain("test"));
        }
        [Test]
        public void Comando_registarReunion()
        {
            fachada.RegistrarReunion("C1", "test de comando", "test", "U1", "29/11/2025","Rider");
            string resulatdo = fachada.InteraccionesCliente("C1", "U1", "reunion", "29/11/2025");
            
            Assert.That(resulatdo, Does.Contain("test de comando"));
            Assert.That(resulatdo, Does.Contain("test"));
        }

        [Test]
        public void Comadando_AgregarNota()
        {
            fachada.RegistrarReunion("C1", "test de comando", "test", "U1", "29/11/2025","Rider");
            fachada.AgregarNota("test de nota", "reunion", "test", "U1");
            string resulatdo = fachada.InteraccionesCliente("C1", "U1", "reunion", "29/11/2025");
            Assert.That(resulatdo, Does.Contain("test de nota"));
        }

        [TestCase("", "")]
        [TestCase("mensaje", "")]
        [TestCase("","29/11/2025")]
        [TestCase("mensaje", "29/11/2025")]
        public void Comando_InteraccionCliente(string tipo, string fecha)
        {
            fachada.RegistrarMensaje("C1", "test de comando", "test", "U1", "29/11/2025");
            string resulatdo = fachada.InteraccionesCliente("C1", "U1", tipo, fecha);
            if (tipo=="menaje"|| tipo=="")
                Assert.That(resulatdo, Does.Contain("Mensaje"));
            Assert.That(resulatdo, Does.Contain("test de comando"));
            Assert.That(resulatdo, Does.Contain("test"));

        }

        [Test]
        //verfica si aparece el tema de las interacciones, para confirmar que aparecen las que se registaron. tanto las mas recientes, como las reuniones proximas.
        //Tambien verfica los nombres de los clientes, para ver si aparecen.
        public void Comando_VerPanel()
        {
            fachada.RegistrarCorreo("C2", "test de comando correo", "test correo", "U1", "29/11/2025");
            fachada.RegistrarMensaje("C1", "test de comando mensaje", "test mensaje", "U1", "29/11/2025");
            fachada.RegistrarReunion("C1", "test de comando reunion", "test reunion", "U1", "29/11/2050","Rider");
            fachada.RegistrarReunion("C2", "test de comando reunion 2", "test reunion 2", "U1", "29/11/2050","Rider");
            string resultado = fachada.Panel("U1");
            Assert.That(resultado, Does.Contain("test mensaje"));
            Assert.That(resultado, Does.Contain("Harry ElSucioPotter"));
            Assert.That(resultado, Does.Contain("Hermione Granger"));
            Assert.That(resultado, Does.Contain("test reunion"));
            Assert.That(resultado, Does.Contain("test correo"));
            Assert.That(resultado, Does.Contain("test reunion 2"));

        }

        [Test]
        public void Comando_ClienteContactaAgregar()
        {
            fachada.AgregarClienteContacto("U1", "C1");
            string resultado = fachada.VerClienteContacto("U1");
            Assert.That(resultado, Does.Contain("Harry ElSucioPotter"));
        }
        [Test]
        //Si. Es lo mismo
        public void Comando_ClienteContactaVer()
        {
            fachada.AgregarClienteContacto("U1", "C1");
            string resultado = fachada.VerClienteContacto("U1");
            Assert.That(resultado, Does.Contain("Harry ElSucioPotter"));
        }
        [Test]
        public void Comando_ClienteContactaEliminar()
        {
            fachada.AgregarClienteContacto("U1", "C1");
            fachada.EliminarClienteContacto("U1", "C1");
            string resultado = fachada.VerClienteContacto("U1");
            Assert.That(resultado, Does.Not.Contain("Harry ElSucioPotter"));
        }
        [Test]
        public void Comando_verClientesProducto_Correcto()
        {
            fachada.CrearAdministrador("A6", "Pepe");
            fachada.CrearUsuario("U6", "Juan", "A6");
            fachada.CrearCliente("C4", "Andres", "Perez", "099 298 626", "andres@mail.com");
            fachada.CrearCliente("C3", "Lucas", "Gonzales", "099 876 321", "Luca@mail.com");
            fachada.RegistrarVentaCliente("C4", "computadora", "10/11/2025", "300", "U6");
            fachada.RegistrarVentaCliente("C3", "computadora", "14/11/2025", "300", "U6");
            string resultado = fachada.VerClientesVentaProducto("computadora", "U6");
            Assert.That(resultado,Does.Contain("Andres Perez"));
            Assert.That(resultado,Does.Contain("Lucas Gonzales"));
        }

        [TestCase ("U9","El Id del usuario no es valido")]
        [TestCase ("","El Id del usuario no es valido")]
        public void Comando_verClientesProducto_UsuarioIncorrecto(string usuarioId,string esperado)
        {
            fachada.CrearAdministrador("A6", "Pepe");
            fachada.CrearUsuario("U6", "Juan", "A6");
            fachada.CrearCliente("C4", "Andres", "Perez", "099 298 626", "andres@mail.com");
            fachada.CrearCliente("C3", "Lucas", "Gonzales", "099 876 321", "Luca@mail.com");
            fachada.RegistrarVentaCliente("C4", "computadora", "10/11/2025", "300", "U6");
            fachada.RegistrarVentaCliente("C3", "computadora", "14/11/2025", "300", "U6");
            string resultado = fachada.VerClientesVentaProducto("computadora", "U9");
            Assert.That(resultado,Is.EqualTo(esperado));
        }
        [Test]
        public void Comando_verClientesProducto_prodcutoIncorrectoVacio()
        {
            fachada.CrearAdministrador("A6", "Pepe");
            fachada.CrearUsuario("U6", "Juan", "A6");
            fachada.CrearCliente("C4", "Andres", "Perez", "099 298 626", "andres@mail.com");
            fachada.CrearCliente("C3", "Lucas", "Gonzales", "099 876 321", "Luca@mail.com");
            fachada.RegistrarVentaCliente("C4", "computadora", "10/11/2025", "300", "U6");
            fachada.RegistrarVentaCliente("C3", "computadora", "14/11/2025", "300", "U6");
            string resultado = fachada.VerClientesVentaProducto("", "U6");
            string esperado = "El producto no puede ser vacio o null (Parameter 'producto') producto";
            Assert.That(resultado,Is.EqualTo(esperado));
        }
        [Test]
        public void Comando_verClientesProducto_productoIncorrectoDistinto()
        {
            fachada.CrearAdministrador("A6", "Pepe");
            fachada.CrearUsuario("U6", "Juan", "A6");
            fachada.CrearCliente("C4", "Andres", "Perez", "099 298 626", "andres@mail.com");
            fachada.CrearCliente("C3", "Lucas", "Gonzales", "099 876 321", "Luca@mail.com");
            fachada.RegistrarVentaCliente("C4", "computadora", "10/11/2025", "300", "U6");
            fachada.RegistrarVentaCliente("C3", "computadora", "14/11/2025", "300", "U6");
            string resultado = fachada.VerClientesVentaProducto("nada", "U6");
            Assert.That(resultado,Does.Not.Contain("Andres Perez"));
            Assert.That(resultado,Does.Not.Contain("Lucas Gonzales"));
        }
        [Test]
        public void Comando_verClientesProducto_ClienteDosveces()
        {
            fachada.CrearAdministrador("A6", "Pepe");
            fachada.CrearUsuario("U6", "Juan", "A6");
            fachada.CrearCliente("C4", "Andres", "Perez", "099 298 626", "andres@mail.com");
            fachada.RegistrarVentaCliente("C4", "computadora", "10/11/2025", "300", "U6");
            fachada.RegistrarVentaCliente("C4", "computadora", "14/11/2025", "300", "U6");
            string resultado = fachada.VerClientesVentaProducto("computadora", "U6");
            string esperado = "Los clientes con las ventas de el producto computadora son:\nAndres Perez\n";
            Assert.That(resultado,Is.EqualTo(esperado));
        }
    }
}