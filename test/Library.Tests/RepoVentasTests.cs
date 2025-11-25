/*
using NUnit.Framework;
using System;
using Library;

namespace Library.Tests
{
    [TestFixture]
    public class RepoVentasTests
    {
        private RepoVentas repo;
        private Usuario usuario;
        private Cliente cliente;

        [SetUp]
        public void Setup()
        {
            repo = new RepoVentas();
            usuario = new Usuario("U1", "Vendedor Uno");
            cliente = new Cliente("C1", "Juan", "Pérez", "099123123", "juan@mail.com");
        }

        [Test]
        public void AgregarVenta_DatosValidos_AgregaEnTotalVentasDelUsuario()
        {
            // Arrange
            string fecha = "10/11/2025";
            string precio = "250";
            string producto = "Monitor";

            // Act
            repo.AgregarVenta(cliente, fecha, precio, producto, usuario);

            // Assert
            Assert.That(usuario.TotalVentas.Count, Is.EqualTo(1));
            var v = usuario.TotalVentas[0];
            Assert.That(v.Cliente, Is.EqualTo(cliente));
            Assert.That(v.Producto, Is.EqualTo(producto));
            Assert.That(v.Importe, Is.EqualTo(precio));
            Assert.That(v.Fecha, Is.EqualTo(new DateTime(2025, 11, 10)));
        }

        [Test]
        public void AgregarVenta_ClienteNull_LanzaArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                repo.AgregarVenta(null, "10/11/2025", "100", "Teclado", usuario));
        }

        [Test]
        public void AgregarVenta_UsuarioNull_LanzaArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                repo.AgregarVenta(cliente, "10/11/2025", "100", "Teclado", null));
        }

        [Test]
        public void AgregarVenta_PrecioVacio_LanzaEmptyStringException()
        {
            Assert.Throws<Excepciones.EmptyStringException>(() =>
                repo.AgregarVenta(cliente, "10/11/2025", "", "Mouse", usuario));
        }

        [Test]
        public void AgregarVenta_FechaInvalida_LanzaInvalidDateException()
        {
            Assert.Throws<Excepciones.InvalidDateException>(() =>
                repo.AgregarVenta(cliente, "99/99/9999", "100", "Mouse", usuario));
        }
    }
}
*/
