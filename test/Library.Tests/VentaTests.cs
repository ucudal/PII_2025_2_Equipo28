using NUnit.Framework;
using Library;

namespace Library.Tests
{
    [TestFixture]
    public class VentaTests
    {
        private Fachada fachada;

        [SetUp]
        public void Setup()
        {
            
            fachada = Fachada.Instancia;
            fachada.Usuarios.EliminarDatos();
        }

        [Test]
        public void RegistrarVentaCliente_DatosValidos()
        {
            // Arrange
            fachada.CrearAdministrador("A1", "Pepe");
            fachada.CrearUsuario("U1", "Juan", "A1");
            fachada.CrearCliente("C1", "Andres", "Pérez", "099 298 626", "andres@mail.com");

            string clienteId = "C1";
            string usuarioId = "U1";
            string producto  = "Mouse gamer";
            string fecha     = "01/12/2025";
            string precio    = "1000";

            
            Cliente cliente = fachada.Clientes.BuscarUnCliente(clienteId);

            string expected = $"Venta registrada: {cliente.Nombre} compró '{producto}' por ${precio} el {fecha}.";

            // Act
            string result = fachada.RegistrarVentaCliente(clienteId, producto, fecha, precio, usuarioId);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void RegistrarVentaCliente_UsuarioIdNull()
        {
            // Arrange
            string clienteId = "C2";
            string producto  = "Producto";
            string fecha     = "01/12/2025";
            string precio    = "100";

            // Act
            string result = fachada.RegistrarVentaCliente(clienteId, producto, fecha, precio, null);

            // Assert
           
            Assert.That(result, Does.Contain("datos de usuario null"));
        }

        [Test]
        public void RegistrarVentaCliente_UsuarioIdVacio()
        {
            // Arrange
            string clienteId = "C3";
            string producto  = "Producto";
            string fecha     = "01/12/2025";
            string precio    = "100";

            // Act
            string result = fachada.RegistrarVentaCliente(clienteId, producto, fecha, precio, "");

            // Assert
           
            Assert.That(result, Does.Contain("datos de usuario vacios"));
        }

        [Test]
        public void RegistrarVentaCliente_FechaInvalida()
        {
            // Arrange
            fachada.CrearAdministrador("A2", "Pepe");
            fachada.CrearUsuario("U2", "Juan", "A2");
            fachada.CrearCliente("C4", "Andres", "Pérez", "099 298 626", "andres@mail.com");

            string clienteId = "C4";
            string usuarioId = "U2";
            string producto  = "Mouse gamer";
            string fechaInvalida = "fecha-mala";
            string precio    = "1000";

            // Act
            string result = fachada.RegistrarVentaCliente(clienteId, producto, fechaInvalida, precio, usuarioId);

            // Assert
           
            Assert.That(result, Does.Contain("fecha"));
        }

        [Test]
        public void RegistrarVentaCliente_ClienteNoExiste()
        {
            // Arrange
            fachada.CrearAdministrador("A3", "Pepe");
            fachada.CrearUsuario("U3", "Juan", "A3");
            // No creo el cliente C99
            string clienteIdInexistente = "C99";
            string usuarioId = "U3";
            string producto  = "Mouse gamer";
            string fecha     = "01/12/2025";
            string precio    = "1000";

            // Act
            string result = fachada.RegistrarVentaCliente(clienteIdInexistente, producto, fecha, precio, usuarioId);

            // Assert
           
           
            Assert.That(result, Does.Contain("El cliente no puede ser null."));
        }

        [Test]
        public void RegistrarVentaCliente_UsuarioNoExiste()
        {
            // Arrange
           
            fachada.CrearCliente("C5", "Andres", "Pérez", "099 298 626", "andres@mail.com");

            string clienteId = "C5";
            string usuarioIdInexistente = "U99";
            string producto  = "Mouse gamer";
            string fecha     = "01/12/2025";
            string precio    = "1000";

            // Act
            string result = fachada.RegistrarVentaCliente(clienteId, producto, fecha, precio, usuarioIdInexistente);

            // Assert
            
            Assert.That(result, Does.Contain("El usuario no puede ser null."));
        }
    }
}
