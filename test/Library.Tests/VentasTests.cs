using System.Linq;
using NUnit.Framework;
using Library;

namespace Library.Tests
{
    [TestFixture]
    public class VentasTests
    {
        private RepoVentas repo;
        private Cliente cliente;
        private Vendedor vendedor;

        [SetUp]
        public void Setup()
        {
            repo = new RepoVentas();

            // Cliente y vendedor mínimos para poder crear una venta
            cliente = new Cliente("C1", "Andres", "Pérez", "099 000 000", "andres@mail.com");
            vendedor = new Vendedor("V1", "Apu");
        }

        [Test]
        public void AgregarVenta_LuegoVentasGet_ContieneUnaVenta()
        {
            // Arrange
            string fecha = "01/12/2025";
            string precio = "1000";
            string producto = "Mouse gamer";

            // Act
            repo.AgregarVenta(cliente, fecha, precio, producto, vendedor);

            // Assert
            // Usamos el get Ventas y contamos los elementos
            Assert.That(repo.Ventas.Count(), Is.EqualTo(1));
        }

        [Test]
        public void EliminarDatos_LimpiaLaListaDeVentas()
        {
            // Arrange
            repo.AgregarVenta(cliente, "01/12/2025", "1000", "Mouse gamer", vendedor);
            Assert.That(repo.Ventas.Count(), Is.EqualTo(1)); // sanity check

            // Act
            repo.EliminarDatos();

            // Assert
            Assert.That(repo.Ventas.Count(), Is.EqualTo(0));
        }
        
    }
}