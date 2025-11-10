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
        private string adminId;

        [SetUp]
        public void Setup()
        {
            fachada = Fachada.Instancia;

            // Usuario válido
            usuarioId = "U001";
            adminId = "A1";
            if (fachada.Usuarios.BuscarAdministrador(adminId) == null)
            {
                fachada.CrearAdministrador(adminId, "Pepe");
            }
            fachada.CrearUsuario(usuarioId, "Matteo", "A1");

            // Cliente válido con Id asignado 
            cliente = new Cliente("1", "Juan", "Pérez", "099123123", "jperez@mail.com");
            cliente.Id = "C001";                
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
       [Test]
        public void TotalDeVentasEnPeriodo_RangoValido_SumaCorrecta()
        {
            // Arrange
            var fachada = Fachada.Instancia;
            var usuarioId = "U001";
            fachada.CrearUsuario(usuarioId, "Matteo", "A1");

            // Limpiar ventas previas del mismo usuario (singleton)
            fachada.BuscarUsuario(usuarioId).TotalVentas.Clear();

            var cliente = new Cliente("C001", "Juan", "Pérez", "099123123", "jperez@mail.com");
            fachada.Clientes.AgregaCliente(cliente);

            fachada.RegistrarVentaCliente(cliente.Id, "Monitor", "10/11/2025", "250", usuarioId);
            fachada.RegistrarVentaCliente(cliente.Id, "Mouse",   "11/11/2025", "150", usuarioId);
            fachada.RegistrarVentaCliente(cliente.Id, "Silla",   "15/11/2025", "300", usuarioId); // fuera de rango

            string expected = "Total de ventas desde 10/11/2025 hasta 12/11/2025: $400";

            // Act
            string result = fachada.TotalDeVentasEnPeriodo(usuarioId, "10/11/2025", "12/11/2025");

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TotalDeVentasEnPeriodo_UsuarioNoExiste_Error()
        {
            // Arrange
            var fachada = Fachada.Instancia;
            string expected = "Error: no se encontró un usuario con ID 'U999'.";

            // Act
            string result = fachada.TotalDeVentasEnPeriodo("U999", "10/11/2025", "12/11/2025");

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TotalDeVentasEnPeriodo_FechaInvalida_Error()
        {
            // Arrange
            var fachada = Fachada.Instancia;
            var usuarioId = "U002";
            fachada.CrearUsuario(usuarioId, "Matteo", "A1");
            fachada.BuscarUsuario(usuarioId).TotalVentas.Clear();

            var cliente = new Cliente("C002", "Juan", "Pérez", "099123123", "jperez@mail.com");
            fachada.Clientes.AgregaCliente(cliente);

            string expected = "Error: la fecha ingresada no es válida.";

            // Act
            string result = fachada.TotalDeVentasEnPeriodo(usuarioId, "99/99/9999", "12/11/2025");

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TotalDeVentasEnPeriodo_CamposVacios_Error()
        {
            // Arrange
            var fachada = Fachada.Instancia;
            var usuarioId = "U003";
            fachada.CrearUsuario(usuarioId, "Matteo", "A1");
            fachada.BuscarUsuario(usuarioId).TotalVentas.Clear();

            string expected = "Error: uno o más campos están vacíos.";

            // Act
            string result = fachada.TotalDeVentasEnPeriodo(usuarioId, "", "12/11/2025");

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TotalDeVentasEnPeriodo_Nulos_Error()
        {
            // Arrange
            var fachada = Fachada.Instancia;
            string expected = "Error: faltan datos para registrar la venta.";

            // Act
            string result = fachada.TotalDeVentasEnPeriodo(null, null, null);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TotalDeVentasEnPeriodo_RangoInvertido_TotalCero()
        {
            // Arrange 
            var fachada = Fachada.Instancia;
            var usuarioId = "U004";
            fachada.CrearUsuario(usuarioId, "Matteo", "A1");
            fachada.BuscarUsuario(usuarioId).TotalVentas.Clear();

            var cliente = new Cliente("C004", "Juan", "Pérez", "099123123", "jperez@mail.com");
            fachada.Clientes.AgregaCliente(cliente);

            fachada.RegistrarVentaCliente(cliente.Id, "Monitor", "10/11/2025", "250", usuarioId);
            fachada.RegistrarVentaCliente(cliente.Id, "Mouse",   "11/11/2025", "150", usuarioId);

            string expected = "Total de ventas desde 12/11/2025 hasta 10/11/2025: $0";

            // Act
            string result = fachada.TotalDeVentasEnPeriodo(usuarioId, "12/11/2025", "10/11/2025");

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}

