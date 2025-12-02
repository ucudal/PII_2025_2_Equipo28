using NUnit.Framework;
using Library;

namespace Library.Tests
{
    [TestFixture]
    public class VendedorTests
    {
        private Fachada fachada;

        [SetUp]
        public void Setup()
        {
            
             fachada = Fachada.Instancia;
            
        }

        [Test]
        public void AsignarClienteAVendedor_VendedorNoExiste()
        {
            // Arrange
            string expected = "No se encontro un vendedor con ID 'V99'.";

            // Act
            string result = fachada.AsignarClienteAVendedor("C1", "V99");

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void AsignarClienteAVendedor_ClienteNoExiste()
        {
            // Arrange
            fachada.CrearVendedor("V1", "Apu");
            string expected = "No se encontro un cliente con ID 'C99'.";

            // Act
            string result = fachada.AsignarClienteAVendedor("C99", "V1");

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        

       
        public void AsignarClienteAVendedor_VendedorIdNull()
        {
            // Arrange
            // No importa si el cliente existe, la excepción sale antes de buscarlo
            string result = fachada.AsignarClienteAVendedor("C1", null);

            // Assert
         ;
            Assert.That(result, Does.Contain("datos de usuario null"));
        }

        [Test]
        public void AsignarClienteAVendedor_VendedorIdVacio()
        {
            // Arrange
            string result = fachada.AsignarClienteAVendedor("C1", "");

            // Assert
            // En RepoUsuarios tirás:
            // new ArgumentException("datos de usuario vacios");
            Assert.That(result, Does.Contain("datos de usuario vacios"));
        }

        [Test]
        public void AsignarClienteAVendedor_UsuarioEsAdministrador()
        {
            // Arrange
            // Creamos un admin y lo ponemos explícitamente en la lista de usuarios del repo
            // para que BuscarUsuario lo encuentre.
            var admin = new Administrador("A1", "Pepe");
            fachada.Usuarios.AgregarUsuario(admin);

            // Y creamos un cliente válido
            fachada.CrearCliente("C1", "Andres", "Pérez", "099 298 626", "andres@mail.com");

            string expected = "El usuario con ID 'A1' no es un vendedor.";

            // Act
            string result = fachada.AsignarClienteAVendedor("C1", "A1");

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
        
        [Test]
        
        public void CrearVendedor_IdNull()
        {
            // Arrange & Act
            string result = fachada.CrearVendedor(null, "Nombre");

            // Assert
            Assert.That(result, Does.Contain("El ID del vendedor no puede ser nulo."));
        }

        [Test]
        public void CrearVendedor_NombreNull()
        {
            // Arrange & Act
            string result = fachada.CrearVendedor("V3", null);

            // Assert
            Assert.That(result, Does.Contain("El nombre del vendedor no puede ser nulo."));
        }

        [Test]
        public void CrearVendedor_IdVacio()
        {
            // Arrange & Act
            string result = fachada.CrearVendedor("   ", "Apua");

            // Assert
            Assert.That(result, Does.Contain("El ID del vendedor no puede estar vacío."));
        }

        [Test]
        public void CrearVendedor_NombreVacio()
        {
            // Arrange & Act
            string result = fachada.CrearVendedor("V3", "   ");

            // Assert
            Assert.That(result, Does.Contain("El nombre del vendedor no puede estar vacío."));
        }

        [Test]
        public void CrearVendedor_IdDuplicado()
        {
            // Arrange
            fachada.CrearVendedor("V3", "Apua");

            // Act
            string result = fachada.CrearVendedor("V3", "Otro Nombre");

            // Assert
            Assert.That(result, Does.Contain("Ya existe un usuario con el ID: V3"));
        }
        [Test]
        public void AsignarCliente_ClienteValido_SeAgregaALaListaDeClientes()
        {
            // Arrange
            var vendedor = new Vendedor("V1", "Apu");
            var cliente = new Cliente("C1", "Andres", "Pérez", "099 000 000", "andres@mail.com");

            // Act
            vendedor.AsignarCliente(cliente);

            // Assert
            Assert.That(vendedor.Clientes.Count, Is.EqualTo(1));
            Assert.That(vendedor.Clientes[0], Is.EqualTo(cliente));
        }
    }
}