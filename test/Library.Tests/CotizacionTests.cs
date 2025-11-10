using NUnit.Framework;
using Library;

namespace Library.Tests
{
    [TestFixture]
    public class CotizacionTests
    {
        private Fachada fachada;
        private Cliente cliente;
        private string usuarioId;
        private string adminId;

        [SetUp]
        public void Setup()
        {
            fachada = Fachada.Instancia;
            
            fachada.Usuarios.Usuarios.Clear();
            fachada.Usuarios.Administradores.Clear();
            fachada.Usuarios.Vendedores.Clear();
            fachada.Usuarios.ClientesTotales.Clear();
            
            usuarioId = "U001";
            adminId = "A1";
            fachada.CrearUsuario(usuarioId, "Matteo", "A1");
            
            cliente = new Cliente("C001", "Juan", "Pérez", "099123123", "jperez@mail.com");
            fachada.Clientes.AgregaCliente(cliente);
        }

        [Test]
        public void RegistrarCotizacionCliente_DatosValidos_RetornaMensajeExito()
        {
            // Arrange
            string expected = "Cotización registrada: se envió a Juan por $250 el 10/11/2025.";

            // Act
            string result = fachada.RegistrarCotizacionCliente(cliente.Id, "10/11/2025", "250", usuarioId);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void RegistrarCotizacionCliente_UsuarioNoExiste_RetornaError()
        {
            // Arrange
            string expected = "Error: no se encontró un usuario con ID 'U999'.";

            // Act
            string result = fachada.RegistrarCotizacionCliente(cliente.Id, "10/11/2025", "250", "U999");

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void RegistrarCotizacionCliente_ClienteNoExiste_RetornaError()
        {
            // Arrange
            string expected = "Error: no se encontró un cliente con ID 'U001'.";

            // Act
            string result = fachada.RegistrarCotizacionCliente("C999", "10/11/2025", "250",usuarioId);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void RegistrarCotizacionCliente_FechaInvalida_RetornaError()
        {
            // Arrange
            string expected = "Error: la fecha ingresada no es válida.";

            // Act
            string result = fachada.RegistrarCotizacionCliente(cliente.Id, "99/99/9999", "250", usuarioId);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void RegistrarCotizacionCliente_PrecioVacio_RetornaError()
        {
            // Arrange
            string expected = "Error: uno o más campos están vacíos.";

            // Act
            string result = fachada.RegistrarCotizacionCliente(cliente.Id, "10/11/2025", "", usuarioId);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void RegistrarCotizacionCliente_DatosNulos_RetornaError()
        {
            // Arrange
            string expected = "Error: faltan datos para registrar la cotización.";

            // Act
            string result = fachada.RegistrarCotizacionCliente(null, null, null, null);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
