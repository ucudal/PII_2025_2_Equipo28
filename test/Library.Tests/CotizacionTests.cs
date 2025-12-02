using NUnit.Framework;
using Library;

namespace Library.Tests
{
    [TestFixture]
    public class CotizacionTests
    {
        private Fachada fachada;

        [SetUp]
        public void Setup()
        {
            // Usamos la fachada singleton
            fachada = Fachada.Instancia;

            // Al menos limpiamos usuarios para evitar IDs duplicados entre tests
            fachada.Usuarios.EliminarDatos();
        }

        [Test]
        public void RegistrarCotizacionCliente_DatosValidos_RetornaMensajeExito()
        {
            // Arrange
            fachada.CrearAdministrador("AC1", "Pepe");
            fachada.CrearUsuario("UC1", "Juan", "AC1");
            fachada.CrearCliente("CC1", "Andres", "Pérez", "099 123 456", "andres@mail.com");

            string clienteId = "CC1";
            string usuarioId = "UC1";
            string fecha = "01/12/2025";
            string precio = "1500";

            // Tomo el cliente REAL desde el repo (por si ya existía con otro nombre)
            Cliente cliente = fachada.Clientes.BuscarUnCliente(clienteId);

            string expected =
                $"Cotización registrada: se envió a {cliente.Nombre} por ${precio} el {fecha}.";

            // Act
            string result = fachada.RegistrarCotizacionCliente(clienteId, fecha, precio, usuarioId);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void RegistrarCotizacionCliente_UsuarioIdNull_RetornaErrorArgumentNull()
        {
            // Arrange
            string clienteId = "CC2";
            string fecha = "01/12/2025";
            string precio = "1000";

            // Act
            string result = fachada.RegistrarCotizacionCliente(clienteId, fecha, precio, null);

            // Assert
            // RepoUsuarios lanza: new ArgumentNullException("datos de usuario null");
            Assert.That(result, Does.Contain("datos de usuario null"));
        }

        [Test]
        public void RegistrarCotizacionCliente_UsuarioIdVacio_RetornaErrorArgumentException()
        {
            // Arrange
            string clienteId = "CC3";
            string fecha = "01/12/2025";
            string precio = "1000";

            // Act
            string result = fachada.RegistrarCotizacionCliente(clienteId, fecha, precio, "");

            // Assert
            // RepoUsuarios lanza: new ArgumentException("datos de usuario vacios");
            Assert.That(result, Does.Contain("datos de usuario vacios"));
        }

        [Test]
        public void RegistrarCotizacionCliente_FechaInvalida_RetornaErrorInvalidDate()
        {
            // Arrange
            fachada.CrearAdministrador("AC2", "Pepe");
            fachada.CrearUsuario("UC2", "Juan", "AC2");
            fachada.CrearCliente("CC4", "Andres", "Pérez", "099 999 999", "andres@mail.com");

            string clienteId = "CC4";
            string usuarioId = "UC2";
            string fechaInvalida = "fecha-mala";
            string precio = "2000";

            // Act
            string result = fachada.RegistrarCotizacionCliente(clienteId, fechaInvalida, precio, usuarioId);

            // Assert
            // InvalidDateException debería hablar de la fecha
            Assert.That(result, Does.Contain("fecha"));
        }

        [Test]
        public void RegistrarCotizacionCliente_ClienteNoExiste_RetornaErrorClienteNull()
        {
            // Arrange
            fachada.CrearAdministrador("AC3", "Pepe");
            fachada.CrearUsuario("UC3", "Juan", "AC3");
            // NO creo el cliente CC99
            string clienteIdInexistente = "CC99";
            string usuarioId = "UC3";
            string fecha = "01/12/2025";
            string precio = "2000";

            // Act
            string result = fachada.RegistrarCotizacionCliente(clienteIdInexistente, fecha, precio, usuarioId);

            // Assert
            // Cotizaciones.AgregarCotizacion probablemente lanza ArgumentNullException por cliente null
            Assert.That(result, Does.Contain("cliente"));
        }

        [Test]
        public void RegistrarCotizacionCliente_UsuarioNoExiste_RetornaErrorUsuarioNull()
        {
            // Arrange
            fachada.CrearCliente("CC5", "Andres", "Pérez", "099 555 555", "andres@mail.com");
            // NO creo el usuario UC99
            string clienteId = "CC5";
            string usuarioIdInexistente = "UC99";
            string fecha = "01/12/2025";
            string precio = "2000";

            // Act
            string result = fachada.RegistrarCotizacionCliente(clienteId, fecha, precio, usuarioIdInexistente);

            // Assert
            // Cotizaciones.AgregarCotizacion probablemente lanza ArgumentNullException por usuario null
            Assert.That(result, Does.Contain("usuario"));
        }
    }
}