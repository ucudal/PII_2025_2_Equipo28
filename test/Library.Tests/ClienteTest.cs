using NUnit.Framework;

namespace Library.Tests
{
    [TestFixture]
    public class ClienteTests
    {
        [Test]
        public void InicializarCamposCorrectamente()
        {
            // Arrange
            string nombre = "Juan";
            string apellido = "Pérez";
            string telefono = "099123456";
            string correo = "juan@example.com";

            // Act
            Cliente cliente = new Cliente(nombre, apellido, telefono, correo);

            // Assert
            Assert.That(cliente.Nombre, Is.EqualTo(nombre));
            Assert.That(cliente.Apellido, Is.EqualTo(apellido));
            Assert.That(cliente.Telefono, Is.EqualTo(telefono));
            Assert.That(cliente.Correo, Is.EqualTo(correo));
            Assert.That(cliente.Genero, Is.EqualTo(string.Empty));
            // Assert.That(cliente.Etiqueta, Is.EqualTo(string.Empty));
            Assert.That(cliente.FechaDeNacimiento, Is.EqualTo(string.Empty));
        }

        [Test]
        public void ActualizarElNombre()
        {
            var cliente = new Cliente("Juan", "Pérez", "099", "correo");
            cliente.CambiarNombre("Carlos");
            Assert.That(cliente.Nombre, Is.EqualTo("Carlos"));
        }

        [Test]
        public void ActualizarElApellido()
        {
            var cliente = new Cliente("Juan", "Pérez", "099", "correo");
            cliente.CambiarApellido("García");
            Assert.That(cliente.Apellido, Is.EqualTo("García"));
        }

        [Test]
        public void ActualizarElTelefono()
        {
            var cliente = new Cliente("Juan", "Pérez", "099", "correo");
            cliente.CambiarTelefono("098765432");
            Assert.That(cliente.Telefono, Is.EqualTo("098765432"));
        }

        [Test]
        public void ActualizarElCorreo()
        {
            var cliente = new Cliente("Juan", "Pérez", "099", "correo@old.com");
            cliente.CambiarCorreo("nuevo@correo.com");
            Assert.That(cliente.Correo, Is.EqualTo("nuevo@correo.com"));
        }

        [Test]
        public void ActualizarGenero()
        {
            var cliente = new Cliente("Juan", "Pérez", "099", "correo");
            cliente.AsignarGenero("Masculino");
            Assert.That(cliente.Genero, Is.EqualTo("Masculino"));
        }

        // [Test]
        // public void ActualizarEtiqueta()
        // {
        //     var cliente = new Cliente("Juan", "Pérez", "099", "correo");
        //     cliente.AsignarEtiqueta("VIP");
        //     Assert.That(cliente.Etiqueta, Is.EqualTo("VIP"));
        // }

        [Test]
        public void ActualizarFecha()
        {
            var cliente = new Cliente("Juan", "Pérez", "099", "correo");
            cliente.AsignarFechaDeNacimiento("01/01/2000");
            Assert.That(cliente.FechaDeNacimiento, Is.EqualTo("01/01/2000"));
        }

        [Test]
        public void DevolverFormatoCorrecto()
        {
            var cliente = new Cliente("Juan", "Pérez", "099", "juan@example.com");
            string esperado = "Juan Pérez (juan@example.com)";
            Assert.That(cliente.ToString(), Is.EqualTo(esperado));
        }
    }
}
