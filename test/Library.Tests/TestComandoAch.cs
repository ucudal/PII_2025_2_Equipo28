using NUnit.Framework;
using Library;

namespace Library.Tests
{
    public class TetsComando_Ventas_Cotizaciones_23_24_25_26_
    {
        private Fachada fachada;

        [SetUp]
        public void Setup()
        {
            fachada = Fachada.Instancia;

            // Limpiar todo como en tu ejemplo
            fachada.UsuariosSuspendidos.Clear();
            fachada.Usuarios.EliminarDatos();
            fachada.Cotizaciones.EliminarDatos();
            fachada.Interacciones.EliminarDatos();
            fachada.Etiquetas.EliminarDatos();
            fachada.Clientes.EliminarDatos();
            fachada.ClientesContacto.Clear();
            fachada.Ventas.EliminarDatos();   // para que no queden ventas viejas

            // Datos base para las pruebas
            fachada.CrearAdministrador("A1", "Costanzia");
            fachada.CrearUsuario("U1", "Paola", "A1");
            fachada.CrearCliente("C1", "Diego", "Gimenez", "099786435", "diego@hola.com");
        }

        [Test]
        public void Comando_crearVendedor()
        {
            // Act
            string resultado = fachada.CrearVendedor("V1", "Apu");

            // Assert: mensaje del comando
            Assert.That(resultado, Is.EqualTo("Vendedor Apu con ID V1 creado correctamente."));

            // 
            var vendedor = fachada.Usuarios.BuscarVendedor("V1");
            Assert.That(vendedor, Is.Not.Null);
            Assert.That(vendedor.NombreCompleto, Is.EqualTo("Apu"));
        }

        [Test]
        public void Comando_registrarCotizacion()
        {
            // Act
            string resultado = fachada.RegistrarCotizacionCliente("C1", "29/11/2025", "1500", "U1");

            // Assert: 
            Assert.That(resultado, Is.EqualTo(
                "Cotización registrada: se envió a Diego por $1500 el 29/11/2025."));
        }

        [Test]
        public void Comando_registrarVenta()
        {
            // Act
            string resultado = fachada.RegistrarVentaCliente("C1", "Mouse gamer", "29/11/2025", "1000", "U1");

            // Assert: 
            Assert.That(resultado, Is.EqualTo("Venta registrada: Diego compró 'Mouse gamer' por $1000 el 29/11/2025."));
        }

        [Test]
        public void Comando_totalVentas()
        {
            // Arrange: 
            fachada.RegistrarVentaCliente("C1", "Mouse gamer", "29/11/2025", "1000", "U1");
            fachada.RegistrarVentaCliente("C1", "Teclado", "29/11/2025", "500", "U1");

            // Act
            string resultado = fachada.TotalDeVentasEnPeriodo("U1", "29/11/2025", "29/11/2025");

            // Assert:
            string expected = "Total de ventas desde 29/11/2025 hasta 29/11/2025: $1500";
            Assert.That(resultado, Is.EqualTo(expected));
        }
    }
}