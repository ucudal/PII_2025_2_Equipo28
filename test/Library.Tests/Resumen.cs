using System;
using NUnit.Framework;
using Library;

namespace Library.Tests
{
    [TestFixture]
    public class Resumen
    {
        [Test]
        public void Cotizacion_Resumen_DatosValidos()
        {
            // Arrange
            var cliente = new Cliente("C2", "Harry", "Potter", "098 111 111", "harry@mail.com");
            DateTime fecha = new DateTime(2025, 12, 1);
            string importe = "2000";

            var cotizacion = new Cotizacion(cliente, fecha, importe);

            string expected =
                $"Cotización a {cliente.Nombre} {cliente.Apellido}: importe: {importe}, Fecha: {fecha.ToShortDateString()}";

            // Act
            string result = cotizacion.Resumen();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void VentaFachada_Resumen_DatosValidos_RetornaMensajeEsperado()
        {
            // Arrange
            var cliente = new Cliente("C1", "Harry", "Potter", "098 111 111", "harry@mail.com");
            string producto = "Varita mágica";
            DateTime fecha = new DateTime(2025, 12, 1);
            string importe = "2000";

            var venta = new VentaFachada(cliente, producto, fecha, importe);

            string expected =
                $"{cliente.Nombre} {cliente.Apellido} compró {producto} el {fecha.ToShortDateString()} por ${importe}";

            // Act
            string result = venta.Resumen();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}