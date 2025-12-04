using NUnit.Framework;

namespace Library.Tests
{
    public class TestComandoHistoria3Defensa
    {
        private Fachada fachada;
        
        [SetUp]
        public void Setup()
        {
            fachada = Fachada.Instancia;
            fachada.UsuariosSuspendidos.Clear();
            fachada.Usuarios.EliminarDatos();
            fachada.Cotizaciones.EliminarDatos();
            fachada.Interacciones.EliminarDatos();
            fachada.Etiquetas.EliminarDatos();
            fachada.Clientes.EliminarDatos();
            fachada.ClientesContacta.ElminarDatos();
        }

        [Test]
        public void Comando_verClientesProducto_Correcto()
        {
            fachada.CrearAdministrador("A6", "Pepe");
            fachada.CrearUsuario("U6", "Juan", "A6");
            fachada.CrearCliente("C4", "Andres", "Perez", "099 298 626", "andres@mail.com");
            fachada.CrearCliente("C3", "Lucas", "Gonzales", "099 876 321", "Luca@mail.com");
            fachada.RegistrarVentaCliente("C4", "computadora", "10/11/2025", "300", "U6");
            fachada.RegistrarVentaCliente("C3", "computadora", "14/11/2025", "300", "U6");
            string resultado = fachada.VerClientesVentaProducto("computadora", "U6");
            Assert.That(resultado,Does.Contain("Andres Perez"));
            Assert.That(resultado,Does.Contain("Lucas Gonzales"));
        }

        [TestCase ("U9","El usuario no puede ser null (Parameter 'usuario') usuario")]
        [TestCase ("","El usuario no puede ser null (Parameter 'usuario') usuario")]
        public void Comando_verClientesProducto_UsuarioIncorrecto(string usuarioId,string esperado)
        {
            fachada.CrearAdministrador("A6", "Pepe");
            fachada.CrearUsuario("U6", "Juan", "A6");
            fachada.CrearCliente("C4", "Andres", "Perez", "099 298 626", "andres@mail.com");
            fachada.CrearCliente("C3", "Lucas", "Gonzales", "099 876 321", "Luca@mail.com");
            fachada.RegistrarVentaCliente("C4", "computadora", "10/11/2025", "300", "U6");
            fachada.RegistrarVentaCliente("C3", "computadora", "14/11/2025", "300", "U6");
            string resultado = fachada.VerClientesVentaProducto("computadora", "U9");
            Assert.That(resultado,Is.EqualTo(esperado));
        }
        [Test]
        public void Comando_verClientesProducto_prodcutoIncorrecto()
        {
            fachada.CrearAdministrador("A6", "Pepe");
            fachada.CrearUsuario("U6", "Juan", "A6");
            fachada.CrearCliente("C4", "Andres", "Perez", "099 298 626", "andres@mail.com");
            fachada.CrearCliente("C3", "Lucas", "Gonzales", "099 876 321", "Luca@mail.com");
            fachada.RegistrarVentaCliente("C4", "computadora", "10/11/2025", "300", "U6");
            fachada.RegistrarVentaCliente("C3", "computadora", "14/11/2025", "300", "U6");
            string resultado = fachada.VerClientesVentaProducto("", "U6");
            string esperado = "El producto no puede ser vacio o null (Parameter 'producto') producto";
            Assert.That(resultado,Is.EqualTo(esperado));
        }
        [Test]
        public void Comando_verClientesProducto_productoIncorrecto()
        {
            fachada.CrearAdministrador("A6", "Pepe");
            fachada.CrearUsuario("U6", "Juan", "A6");
            fachada.CrearCliente("C4", "Andres", "Perez", "099 298 626", "andres@mail.com");
            fachada.CrearCliente("C3", "Lucas", "Gonzales", "099 876 321", "Luca@mail.com");
            fachada.RegistrarVentaCliente("C4", "computadora", "10/11/2025", "300", "U6");
            fachada.RegistrarVentaCliente("C3", "computadora", "14/11/2025", "300", "U6");
            string resultado = fachada.VerClientesVentaProducto("nada", "U6");
            Assert.That(resultado,Does.Not.Contain("Andres Perez"));
            Assert.That(resultado,Does.Not.Contain("Lucas Gonzales"));
        }
        [Test]
        public void Comando_verClientesProducto_ClienteDosveces()
        {
            fachada.CrearAdministrador("A6", "Pepe");
            fachada.CrearUsuario("U6", "Juan", "A6");
            fachada.CrearCliente("C4", "Andres", "Perez", "099 298 626", "andres@mail.com");
            fachada.RegistrarVentaCliente("C4", "computadora", "10/11/2025", "300", "U6");
            fachada.RegistrarVentaCliente("C4", "computadora", "14/11/2025", "300", "U6");
            string resultado = fachada.VerClientesVentaProducto("computadora", "U6");
            string esperado = "Los clientes con las ventas de el producto computadora son:\nAndres Perez\n";
            Assert.That(resultado,Is.EqualTo(esperado));
        }
        
    }
}