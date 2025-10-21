using NUnit.Framework;

namespace Library.Tests
{
    [TestFixture]
    public class VendedorTests
    {
        private Vendedor vendedor1;
        private Vendedor vendedor2;
        private Cliente cliente;

        [SetUp]
        public void Setup()
        {
            vendedor1 = new Vendedor("1", "Juan Pérez");
            vendedor2 = new Vendedor("2", "María García");
            cliente = new Cliente("Pedro", "López", "099123456", "pedro@example.com");
        }

        [Test]
        public void Constructor_DeberiaInicializarPropiedades()
        {
            Assert.That(vendedor1.Id, Is.EqualTo("1"));
            Assert.That(vendedor1.NombreCompleto, Is.EqualTo("Juan Pérez"));
            Assert.That(vendedor1.Clientes, Is.Empty);
        }

        [Test]
        public void AsignarCliente_DeberiaAgregarClienteALaListaDelOtroVendedor()
        {
            vendedor1.AsignarCliente(cliente, vendedor2);

            Assert.That(vendedor2.Clientes.Count, Is.EqualTo(1));
            Assert.That(vendedor2.Clientes[0], Is.EqualTo(cliente));
        }

        [Test]
        public void AsignarCliente_Null_NoDeberiaAgregarNada()
        {
            vendedor1.AsignarCliente(null, vendedor2);

            Assert.That(vendedor2.Clientes, Is.Empty);
        }

        [Test]
        public void Clientes_PuedenAgregarDirectamente()
        {
            vendedor1.Clientes.Add(cliente);

            Assert.That(vendedor1.Clientes.Count, Is.EqualTo(1));
            Assert.That(vendedor1.Clientes[0], Is.EqualTo(cliente));
        }
    }
}