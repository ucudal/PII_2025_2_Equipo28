using NUnit.Framework;
using Library;

namespace Library.Tests
{
    [TestFixture]
    public class VentaTests
    {
        private Fachada fachada;
        private Cliente cliente;
        private string usuarioId;

        [SetUp]
        public void Setup()
        {
            fachada = new Fachada();

            // Usuario válido
            usuarioId = "U001";
            fachada.CrearUsuario(usuarioId, "Matteo");

            // Cliente válido con Id asignado 
            cliente = new Cliente("Juan", "Pérez", "099123123", "jperez@mail.com");
            cliente.Id = "C001";                   // <<< asignar Id
            fachada.Clientes.AgregaCliente(cliente);
        }

        [Test]
        public void RegistrarVentaCliente_DatosValidos_RetornaMensajeDeExito()
        {
            // Arrange
            string expected = "Venta registrada: Juan compró 'Monitor' por $250 el 10/11/2025.";

            // Act
            string result = fachada.RegistrarVentaCliente(cliente.Id, "Monitor", "10/11/2025", "250", usuarioId);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void RegistrarVentaCliente_UsuarioNoExiste_RetornaError()
        {
            // Arrange
            string expected = "Error: no se encontró un usuario con ID 'U999'.";

            // Act
            string result = fachada.RegistrarVentaCliente(cliente.Id, "Teclado", "10/11/2025", "100", "U999");

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void RegistrarVentaCliente_ClienteNoExiste_RetornaError()
        {
            // Arrange
            string expected = "Error: no se encontró un cliente con ID 'C999'.";

            // Act
            string result = fachada.RegistrarVentaCliente("C999", "Mouse", "10/11/2025", "50", usuarioId);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void RegistrarVentaCliente_FechaInvalida_RetornaError()
        {
            // Arrange
            string expected = "Error: la fecha ingresada no es válida.";

            // Act
            string result = fachada.RegistrarVentaCliente(cliente.Id, "Silla gamer", "99/99/9999", "300", usuarioId);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void RegistrarVentaCliente_PrecioVacio_RetornaError()
        {
            // Arrange
            string expected = "Error: uno o más campos están vacíos.";

            // Act
            string result = fachada.RegistrarVentaCliente(cliente.Id, "Auriculares", "10/11/2025", "", usuarioId);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void RegistrarVentaCliente_DatosNulos_RetornaError()
        {
            // Arrange
            string expected = "Error: faltan datos para registrar la venta.";

            // Act
            string result = fachada.RegistrarVentaCliente(null, null, null, null, null);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
