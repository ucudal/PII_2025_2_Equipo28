using NUnit.Framework;
using System;
using System.Collections.Generic;
using Library;

namespace Library.Tests
{
    [TestFixture]
    public class PanelTests
    {
        private Panel panel;
        private Cliente cliente;
        private Interaccion mensaje;
        private Reunion reunion;

        [SetUp]
        public void Setup()
        {
            panel = new Panel();
            cliente = new Cliente("Juan", "Pérez", "099123456", "juan@example.com");
            mensaje = new Interaccion(cliente, "Consulta", "Necesito info");
            reunion = new Reunion(cliente, "Reunión", "Oficina", "Presentación", "20/10/2025");
        }

        [Test]
        public void Constructor_DeberiaInicializarListasVacias()
        {
            Assert.That(panel.ClientesTotales, Is.Empty);
            Assert.That(panel.InteraccionesRecientes, Is.Empty);
            Assert.That(panel.ReunionesProximas, Is.Empty);
        }

        [Test]
        public void AgregarInteraccion_DeberiaAgregarInteraccionALaLista()
        {
            panel.AgregarInteraccion(mensaje);

            Assert.That(panel.InteraccionesRecientes.Count, Is.EqualTo(1));
            Assert.That(panel.InteraccionesRecientes[0], Is.EqualTo(mensaje));
        }

        [Test]
        public void ListasPublicas_DeberianPermitirAgregarElementosDirectamente()
        {
            panel.ClientesTotales.Add(cliente);
            panel.ReunionesProximas.Add(reunion);

            Assert.That(panel.ClientesTotales.Count, Is.EqualTo(1));
            Assert.That(panel.ClientesTotales[0], Is.EqualTo(cliente));

            Assert.That(panel.ReunionesProximas.Count, Is.EqualTo(1));
            Assert.That(panel.ReunionesProximas[0], Is.EqualTo(reunion));
            Assert.That(panel.ReunionesProximas[0].lugar, Is.EqualTo("Oficina"));
            Assert.That(panel.ReunionesProximas[0].Fecha, Is.EqualTo(new DateTime(2025, 10, 20)));
        }

        [Test]
        public void AgregarMultiplesInteracciones_DeberiaMantenerOrden()
        {
            var mensaje2 = new Interaccion(cliente, "Soporte", "Segundo mensaje");
            panel.AgregarInteraccion(mensaje);
            panel.AgregarInteraccion(mensaje2);

            Assert.That(panel.InteraccionesRecientes.Count, Is.EqualTo(2));
            Assert.That(panel.InteraccionesRecientes[0], Is.EqualTo(mensaje));
            Assert.That(panel.InteraccionesRecientes[1], Is.EqualTo(mensaje2));
        }
    }
}
