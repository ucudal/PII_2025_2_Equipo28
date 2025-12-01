using NUnit.Framework;
using Library;

namespace Library.Tests
{
    [TestFixture]
    public class VentaFachadaTests
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
        
        [Test]
        public void TotalDeVentasEnPeriodo_UsuarioIdNull()
        {
            // Arrange
            string fechaInicio = "01/12/2025";
            string fechaFin    = "31/12/2025";

            // Act
            string result = fachada.TotalDeVentasEnPeriodo(null, fechaInicio, fechaFin);

            // Assert
            // RepoUsuarios lanza: new ArgumentNullException("datos de usuario null");
            Assert.That(result, Does.Contain("datos de usuario null"));
        }

        [Test]
        public void TotalDeVentasEnPeriodo_UsuarioIdVacio()
        {
            // Arrange
            string fechaInicio = "01/12/2025";
            string fechaFin    = "31/12/2025";

            // Act
            string result = fachada.TotalDeVentasEnPeriodo("", fechaInicio, fechaFin);

            // Assert
            // RepoUsuarios lanza: new ArgumentException("datos de usuario vacios");
            Assert.That(result, Does.Contain("datos de usuario vacios"));
        }

        [Test]
        public void TotalDeVentasEnPeriodo_UsuarioNoExiste()
        {
            // Arrange
            string usuarioId   = "U99";
            string fechaInicio = "01/12/2025";
            string fechaFin    = "31/12/2025";

            // Act
            string result = fachada.TotalDeVentasEnPeriodo(usuarioId, fechaInicio, fechaFin);

            // Assert
            string expected = "No se encontró un usuario con ID 'U99'.";
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TotalDeVentasEnPeriodo_FechaInicioVacia()
        {
            // Arrange
            fachada.CrearAdministrador("A1", "Pepe");
            fachada.CrearUsuario("U1", "Juan", "A1");

            string usuarioId   = "U1";
            string fechaInicio = "";          // vacía
            string fechaFin    = "31/12/2025";

            // Act
            string result = fachada.TotalDeVentasEnPeriodo(usuarioId, fechaInicio, fechaFin);

            // Assert
            Assert.That(result, Is.EqualTo("La fecha de inicio no puede estar vacía."));
        }

        [Test]
        public void TotalDeVentasEnPeriodo_FechaFinVacia()
        {
            // Arrange
            fachada.CrearAdministrador("A2", "Pepe");
            fachada.CrearUsuario("U2", "Juan", "A2");

            string usuarioId   = "U2";
            string fechaInicio = "01/12/2025";
            string fechaFin    = "   ";       // solo espacios

            // Act
            string result = fachada.TotalDeVentasEnPeriodo(usuarioId, fechaInicio, fechaFin);

            // Assert
            Assert.That(result, Is.EqualTo("La fecha de fin no puede estar vacía."));
        }

        [Test]
        public void TotalDeVentasEnPeriodo_FechaInicioInvalida()
        {
            // Arrange
            fachada.CrearAdministrador("A3", "Pepe");
            fachada.CrearUsuario("U3", "Juan", "A3");

            string usuarioId   = "U3";
            string fechaInicio = "2025-12-01";   // formato malo
            string fechaFin    = "31/12/2025";

            // Act
            string result = fachada.TotalDeVentasEnPeriodo(usuarioId, fechaInicio, fechaFin);

            // Assert
            string expected = "Error: la fecha de inicio no es válida. Usa el formato dd/MM/yyyy.";
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TotalDeVentasEnPeriodo_FechaFinInvalida()
        {
            // Arrange
            fachada.CrearAdministrador("A4", "Pepe");
            fachada.CrearUsuario("U4", "Juan", "A4");

            string usuarioId   = "U4";
            string fechaInicio = "01/12/2025";
            string fechaFin    = "2025-12-31";   // formato malo

            // Act
            string result = fachada.TotalDeVentasEnPeriodo(usuarioId, fechaInicio, fechaFin);

            // Assert
            string expected = "Error: la fecha de fin no es válida. Usa el formato dd/MM/yyyy.";
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TotalDeVentasEnPeriodo_FechaInicioMayorQueFin()
        {
            // Arrange
            fachada.CrearAdministrador("A5", "Pepe");
            fachada.CrearUsuario("U5", "Juan", "A5");

            string usuarioId   = "U5";
            string fechaInicio = "10/12/2025";
            string fechaFin    = "01/12/2025";

            // Act
            string result = fachada.TotalDeVentasEnPeriodo(usuarioId, fechaInicio, fechaFin);

            // Assert
            string expected = "Error: la fecha de inicio no puede ser posterior a la fecha de fin.";
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TotalDeVentasEnPeriodo_DatosValidos()
        {
            // Arrange
            fachada.CrearAdministrador("A6", "Pepe");
            fachada.CrearUsuario("U6", "Juan", "A6");

            string usuarioId   = "U6";
            string fechaInicio = "01/12/2025";
            string fechaFin    = "31/12/2025";

            string expected = "Total de ventas desde 01/12/2025 hasta 31/12/2025: $0";

            // Act
            string result = fachada.TotalDeVentasEnPeriodo(usuarioId, fechaInicio, fechaFin);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
        
    }
}
    

