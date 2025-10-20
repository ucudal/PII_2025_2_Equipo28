using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Library.Tests
{
    public class TestFachadaHistoria815
    {
        [Test]
        public void RegistarMensajeTest()
        {
            Interaccion interaccion = Usuario.BuscarInteraccion("mensaje", "saludo");
        }

        [Test]
        public void RegistrarCorreoTest()
        {
            Interaccion interaccion = Usuario.BuscarInteraccion("correo", "saludo");
        }

        [Test]
        public void AgregarNotaTest()
        {
            Interaccion interaccion = Usuario.BuscarInteraccion("mensaje", "saludo");
        }

        [Test]
        public void AgregarEtiqueta_GuardarEtiquetaTest()
        {
        }

        [Test]
        public void RegistarVentaTest()
        {
            Venta venta = Usuario.Total_Ventas[0];
        }

        [Test]
        public void RegistarCotizacionTest()
        {

            Cotizacion cotizacion = Usuario.Cotizaciones[0];

        }
    }
}