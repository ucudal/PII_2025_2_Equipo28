using NUnit.Framework;
using Library;

namespace Library.Tests
{
    [TestFixture]
    public class TestPrueba1
    {
        private Fachada fachada;

        [SetUp]
        public void Setup()
        {

            fachada = Fachada.Instancia;
            fachada.Usuarios.EliminarDatos();
            fachada.Clientes.EliminarDatos();
            fachada.Ventas.EliminarDatos();
        }

        [Test]
        public void montomayor()
        {
            fachada.CrearVendedor("V1", "Vendedor 1");
     

            fachada.CrearCliente("C1", "Ana","Garcia", "000","ana@mail.com");
            fachada.CrearCliente("C2", "Luis","Perez", "000","ana@mail.com");
            fachada.CrearCliente("C3", "Marta","Lopez", "000","ana@mail.com");

            string fecha = "01/12/2025";

            fachada.RegistrarVentaCliente("C1", "Producto X", fecha, "100", "V1");
            fachada.RegistrarVentaCliente("C1", "Producto X", fecha, "150", "V1");
            
            fachada.RegistrarVentaCliente("C2", "Producto X", fecha, "50", "V1");
            
            fachada.RegistrarVentaCliente("C3", "Producto X", fecha, "500", "V1");

            string resultado = fachada.ListarClientesPorMontoDeVentas("200", "mayor");
            
            Assert.That(resultado, Does.Contain("Ana Garcia"));
            Assert.That(resultado, Does.Contain("Marta Lopez"));
        }

        [Test]
        public void montomenor()
        {
            fachada.CrearVendedor("V1", "Vendedor 1");
            
            fachada.CrearCliente("C1", "Ana","Garcia", "000","ana@mail.com");
            fachada.CrearCliente("C2", "Luis","Perez", "000","ana@mail.com");
            fachada.CrearCliente("C3", "Marta","Lopez", "000","ana@mail.com");

            string fecha = "01/12/2025";

            fachada.RegistrarVentaCliente("C1", "Producto X", fecha, "100", "V1");
            fachada.RegistrarVentaCliente("C1", "Producto X", fecha, "150", "V1");
            
            fachada.RegistrarVentaCliente("C2", "Producto X", fecha, "50", "V1");
            
            fachada.RegistrarVentaCliente("C3", "Producto X", fecha, "500", "V1");

            string resultado = fachada.ListarClientesPorMontoDeVentas("200", "menor");
            
            Assert.That(resultado, Does.Contain("Luis Perez"));
            
        }
    }
}