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
            Interaccion interaccion = usuario.BuscarInteraccion("mensaje", "saludo");
        }

        [Test]
        public void RegistrarCorreoTest()
        {
            Interaccion interaccion = usuario.BuscarInteraccion("correo", "saludo");
        }

        [Test]
        public void AgregarNotaTest()
        {
            Interaccion interaccion = usuario.BuscarInteraccion("mensaje", "saludo");
        }

        [Test]
        public void AgregarEtiqueta_GuardarEtiquetaTest()
        {
        }

        [Test]
        public void RegistarVentaTest()
        {
            Venta venta = usuario.Total_Ventas[0];
        }

        [Test]
        public void RegistarCotizacionTest()
        {

            Cotizacion cotizacion = usuario.Cotizaciones[0];

        }
    }
}