using NUnit.Framework;
using System;
using Library;

namespace Library.Tests
{
    [TestFixture]
    public class FachadaTests
    {
        private Fachada fachada;

        [SetUp]
        public void Setup()
        {
            fachada = new Fachada();
        }
        
        [Test]
        public void CrearVendedor_ConDatosValidos_DeberiaCrearVendedor()
        {
            // Arrange
            string id = "V1";
            string nombre = "Juan Vendedor";

            // Act
            Vendedor resultado = fachada.CrearVendedor(id, nombre);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.That(id, Is.EqualTo(resultado.Id));
            Assert.That(nombre, Is.EqualTo(resultado.Nombre));
        }

        [Test]
        public void CrearVendedor_ConIdNulo_DeberiaLanzarArgumentNullException()
        {
            // Arrange
            string id = null;
            string nombre = "Juan Vendedor";

            // Assert
            Assert.Throws<ArgumentNullException>(() => fachada.CrearVendedor(id, nombre));
        }

        [Test]
        public void CrearVendedor_ConNombreNulo_DeberiaLanzarArgumentNullException()
        {
            // Arrange
            string id = "V1";
            string nombre = null;

            // Assert
            Assert.Throws<ArgumentNullException>(() => fachada.CrearVendedor(id, nombre));
        }

        [Test]
        public void CrearVendedor_ConIdVacio_DeberiaLanzarEmptyStringException()
        {
            // Arrange
            string id = "";
            string nombre = "Juan Vendedor";

            // Assert
            Assert.Throws<Excepciones.EmptyStringException>(() => fachada.CrearVendedor(id, nombre));
        }

        [Test]
        public void CrearVendedor_ConNombreVacio_DeberiaLanzarEmptyStringException()
        {
            // Arrange
            string id = "V1";
            string nombre = "   ";

            // Assert
            Assert.Throws<Excepciones.EmptyStringException>(() => fachada.CrearVendedor(id, nombre));
        }

        [Test]
        public void CrearVendedor_ConIdDuplicado_DeberiaLanzarInvalidOperationException()
        {
            // Arrange
            string id = "V1";
            string nombre1 = "Juan Vendedor";
            string nombre2 = "Pedro Vendedor";
            fachada.CrearVendedor(id, nombre1);

            // Assert
            Assert.Throws<InvalidOperationException>(() => fachada.CrearVendedor(id, nombre2));
        }
        
        [Test]
        public void CrearAdministrador_ConDatosValidos_DeberiaCrearAdministrador()
        {
            // Arrange
            string id = "A1";
            string nombre = "Juan Admin";

            // Act
            Administrador resultado = fachada.CrearAdministrador(id, nombre);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.That(id, Is.EqualTo(resultado.ID));
            Assert.That(nombre, Is.EqualTo(resultado.Nombre));
        }

        [Test]
        public void CrearAdministrador_ConIdNulo_DeberiaLanzarArgumentNullException()
        {
            // Arrange
            string id = null;
            string nombre = "Juan Admin";

            // Assert
            Assert.Throws<ArgumentNullException>(() => fachada.CrearAdministrador(id, nombre));
        }

        [Test]
        public void CrearAdministrador_ConNombreNulo_DeberiaLanzarArgumentNullException()
        {
            // Arrange
            string id = "A1";
            string nombre = null;

            // Assert
            Assert.Throws<ArgumentNullException>(() => fachada.CrearAdministrador(id, nombre));
        }

        [Test]
        public void CrearAdministrador_ConIdVacio_DeberiaLanzarEmptyStringException()
        {
            // Arrange
            string id = "";
            string nombre = "Juan Admin";

            // Assert
            Assert.Throws<Excepciones.EmptyStringException>(() => fachada.CrearAdministrador(id, nombre));
        }

        [Test]
        public void CrearAdministrador_ConIdDuplicado_DeberiaLanzarInvalidOperationException()
        {
            // Arrange
            string id = "A1";
            string nombre1 = "Juan Admin";
            string nombre2 = "Pepe Admin";
            fachada.CrearAdministrador(id, nombre1);

            // Assert
            Assert.Throws<InvalidOperationException>(() => fachada.CrearAdministrador(id, nombre2));
        }
        
        [Test]
        public void CrearUsuario_ConDatosValidos_DeberiaRetornarMensajeExito()
        {
            // Arrange
            string id = "U1";
            string nombre = "Pepe Usuario";

            // Act
            string resultado = fachada.CrearUsuario(id, nombre);

            // Assert
            Assert.IsTrue(resultado.Contains("creado correctamente"));
            Assert.IsNotNull(fachada.BuscarUsuario(id));
        }

        [Test]
        public void CrearUsuario_ConIdDuplicado_DeberiaRetornarMensajeError()
        {
            // Arrange
            string id = "U1";
            string nombre1 = "Pepe Usuario";
            string nombre2 = "Manolo Usuario";
            fachada.CrearUsuario(id, nombre1);

            // Act
            string resultado = fachada.CrearUsuario(id, nombre2);

            // Assert
            Assert.IsTrue(resultado.Contains("Ya existe un usuario"));
        }
        
        [Test]
        public void SuspenderUsuario_ConUsuarioExistente_DeberiaSuspenderCorrectamente()
        {
            // Arrange
            string id = "U1";
            string nombre = "Pepe Usuario";
            fachada.CrearUsuario(id, nombre);

            // Act
            string resultado = fachada.SuspenderUsuario(id);

            // Assert
            Assert.IsTrue(resultado.Contains("suspendido correctamente"));
            Assert.IsNull(fachada.BuscarUsuario(id));
            Assert.That(1, Is.EqualTo(fachada.UsuariosSuspendidos.Count));
        }

        [Test]
        public void SuspenderUsuario_ConUsuarioNoExistente_DeberiaRetornarMensajeError()
        {
            // Arrange
            string id = "U10";

            // Act
            string resultado = fachada.SuspenderUsuario(id);

            // Assert
            Assert.IsTrue(resultado.Contains("No se encontró"));
        }
        
        [Test]
        public void EliminarUsuario_ConUsuarioActivo_DeberiaEliminarCorrectamente()
        {
            // Arrange
            string id = "U1";
            string nombre = "Pepe Usuario";
            fachada.CrearUsuario(id, nombre);

            // Act
            string resultado = fachada.EliminarUsuario(id);

            // Assert
            Assert.IsTrue(resultado.Contains("eliminado del sistema"));
            Assert.IsNull(fachada.BuscarUsuario(id));
        }

        [Test]
        public void EliminarUsuario_ConUsuarioSuspendido_DeberiaEliminarCorrectamente()
        {
            // Arrange
            string id = "U1";
            string nombre = "Pepe Usuario";
            fachada.CrearUsuario(id, nombre);
            fachada.SuspenderUsuario(id);

            // Act
            string resultado = fachada.EliminarUsuario(id);

            // Assert
            Assert.IsTrue(resultado.Contains("eliminado del sistema"));
            Assert.That(0, Is.EqualTo(fachada.UsuariosSuspendidos.Count));
        }

        [Test]
        public void EliminarUsuario_ConUsuarioNoExistente_DeberiaRetornarMensajeError()
        {
            // Arrange
            string id = "U100";

            // Act
            string resultado = fachada.EliminarUsuario(id);

            // Assert
            Assert.IsTrue(resultado.Contains("No se encontró"));
        }
        
        [Test]
        public void CrearNuevoCliente_ConDatosValidos_DeberiaCrearCliente()
        {
            // Arrange
            string id = "1";
            string nombre = "Pepe";
            string apellido = "Gómez";
            string telefono = "099123456";
            string correo = "pepe@correo.com";

            // Act
            Cliente resultado = fachada.CrearNuevoCliente(id, nombre, apellido, telefono, correo);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.That(id, Is.EqualTo(resultado.Id));
            Assert.That(nombre, Is.EqualTo(resultado.Nombre));
            Assert.That(apellido, Is.EqualTo(resultado.Apellido));
            Assert.That(telefono, Is.EqualTo(resultado.Telefono));
            Assert.That(correo, Is.EqualTo(resultado.Correo));
        }
        
        [Test]
        public void BuscarClientesFachada_PorNombre_DeberiaEncontrarClientes()
        {
            // Arrange
            fachada.CrearNuevoCliente("1","Pepe", "Gómez", "099123456", "pepe@correo.com");
            fachada.CrearNuevoCliente("1","Pepe", "Díaz", "099654321", "pepe2@correo.com");

            // Act
            var resultado = fachada.BuscarClientesFachada("nombre", "Pepe");

            // Assert
            Assert.That(2, Is.EqualTo(resultado.Count));
        }

        [Test]
        public void BuscarClientesFachada_PorCorreo_DeberiaEncontrarUnCliente()
        {
            // Arrange
            fachada.CrearNuevoCliente("1","Pepe", "Gómez", "099123456", "pepe@correo.com");

            // Act
            var resultado = fachada.BuscarClientesFachada("correo", "pepe@correo.com");

            // Assert
            Assert.That(1, Is.EqualTo(resultado.Count));
            Assert.That("pepe@correo.com", Is.EqualTo(resultado[0].Correo));
        }
        
        [Test]
        public void ModificarInfo_CambiarNombre_DeberiaActualizarNombre()
        {
            // Arrange
            fachada.CrearNuevoCliente("1","Pepe", "Gómez", "099123456", "pepe@correo.com");
            var clientes = fachada.BuscarClientesFachada("correo", "pepe@correo.com");
            string clienteId = clientes[0].Id;
            string nuevoNombre = "Carlos";

            // Act
            fachada.ModificarInfo(clienteId, "nombre", nuevoNombre);

            // Assert
            var clienteModificado = fachada.BuscarClientesFachada("id", clienteId)[0];
            Assert.That(clienteModificado.Nombre, Is.EqualTo(nuevoNombre));
        }

        [Test]
        public void ModificarInfo_CambiarTelefono_DeberiaActualizarTelefono()
        {
            // Arrange
            fachada.CrearNuevoCliente("1","Roberto", "Gómez", "099123456", "roberto@example.com");
            var clientes = fachada.BuscarClientesFachada("correo", "roberto@example.com");
            string clienteId = clientes[0].Id;
            string nuevoTelefono = "098765432";

            // Act
            fachada.ModificarInfo(clienteId, "telefono", nuevoTelefono);

            // Assert
            var clienteModificado = fachada.BuscarClientesFachada("id", clienteId)[0];
            Assert.That(clienteModificado.Telefono, Is.EqualTo(nuevoTelefono));
        }
        
        [Test]
        public void EliminarClienteFachada_ConClienteExistente_DeberiaEliminar()
        {
            // Arrange
            fachada.CrearNuevoCliente("1","Pepe", "Gómez", "099123456", "pepe@correo.com");
            var clientes = fachada.BuscarClientesFachada("correo", "pepe@correo.com");
            string clienteId = clientes[0].Id;

            // Act
            fachada.EliminarClienteFachada(clienteId);

            // Assert
            var resultado = fachada.BuscarClientesFachada("id", clienteId);
            Assert.That(resultado.Count, Is.EqualTo(0));
        }
        
        [Test]
        public void BuscarUsuario_ConUsuarioExistente_DeberiaRetornarUsuario()
        {
            // Arrange
            string id = "U1";
            string nombre = "Pepe Usuario";
            fachada.CrearUsuario(id, nombre);

            // Act
            Usuario resultado = fachada.BuscarUsuario(id);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.That(id, Is.EqualTo(resultado.ID));
            Assert.That(nombre, Is.EqualTo(resultado.Nombre));
        }

        [Test]
        public void BuscarUsuario_ConUsuarioNoExistente_DeberiaRetornarNull()
        {
            // Arrange
            string id = "U1000";

            // Act
            Usuario resultado = fachada.BuscarUsuario(id);

            // Assert
            Assert.IsNull(resultado);
        }
    }
}