using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using NUnit.Framework;
namespace Library.Tests
{
    public class TestFachada_Historia_8_15_
    {
        [Test]
        public void RegistarMensajeTest()
        {
            ClienteLista clienteLista = new ClienteLista();
            Fachada fachada = new Fachada();
            Administrador admin = new Administrador("100", "AR");
            Usuario usuario = admin.CrearUsuario("010", "AR");
            Cliente cliente = new Cliente("Alfredo", "Rosquilla", "099007100", "AlfedoGamer@cabezatermo.com");
            cliente.Id = "0";
            clienteLista.AgregaCliente(cliente);
            fachada.RegistarMensaje("0","Hello holui","saludo","010");
            List<string> esperado = new List<string>() { "Alfredo", "Rosquilla", "Hello holui", "saludo", "010" };
            Interaccion interaccion = usuario.BuscarInteraccion("mensaje", "saludo");
            Assert.That("Alfredo",Is.EqualTo(usuario.Interacciones[0].Cliente.Nombre));
        }
        [Test]
        public void RegistrarCorreoTest()
        {
            ClienteLista clienteLista = new ClienteLista();
            Fachada fachada = new Fachada();
            Administrador admin = new Administrador("100", "AR");
            Usuario usuario = admin.CrearUsuario("010", "AR");
            Cliente cliente = new Cliente("Alfredo", "Rosquilla", "099007100", "AlfedoGamer@cabezatermo.com");
            clienteLista.AgregaCliente(cliente);
            cliente.Id = "0";
            fachada.RegistrarCorreo("0","Hello holui","saludo","010");
            List<Object> esperado = new List<object>() { "Alfredo", "Rosquilla", "Hello holui", "saludo", "010" };
            Interaccion interaccion = usuario.BuscarInteraccion("correo", "saludo");
            List<Object> resultado = new List<object>()
                { interaccion.Cliente.Nombre, interaccion.Cliente.Apellido, interaccion.contenido, interaccion.Tema };
            CollectionAssert.AreEqual(esperado,resultado);
        }
        [Test]
        public void AgregarNotaTest()
        {
            ClienteLista clienteLista = new ClienteLista();
            Fachada fachada = new Fachada();
            Administrador admin = new Administrador("100", "AR");
            Usuario usuario = admin.CrearUsuario("010", "AR");
            Cliente cliente = new Cliente("Alfredo", "Rosquilla", "099007100", "AlfedoGamer@cabezatermo.com");
            cliente.Id = "0";
            clienteLista.AgregaCliente(cliente);
            fachada.RegistarMensaje("0","Hello holui","saludo","010");
            fachada.AgregarNota("Me olvide del chau", "mensaje","saludo", "010");
            Interaccion interaccion = usuario.BuscarInteraccion("mensaje", "saludo");
            string esperado = "Me olvide del chau";
            string resultado = interaccion.Notas;
            Assert.That(resultado,Is.EqualTo(esperado));
        }

        [Test]
        public void AgregarEtiqueta_GuardarEtiquetaTest()
        {
            ClienteLista clienteLista = new ClienteLista();
            Fachada fachada = new Fachada();
            Administrador admin = new Administrador("100", "AR");
            Usuario usuario = admin.CrearUsuario("010", "AR");
            Cliente cliente = new Cliente("Alfredo", "Rosquilla", "099007100", "AlfedoGamer@cabezatermo.com");
            cliente.Id = "0";
            clienteLista.AgregaCliente(cliente);
            fachada.AgregarEtiqueta("0", "Pastelero","010");
            string esperado = "Pastelero";
            string resultado = cliente.Etiqueta;
            Assert.That(resultado,Is.EqualTo(esperado));
            string resultado2 = usuario.Etiqueteas[0];
            Assert.That(resultado2,Is.EqualTo(esperado));
        }

        [Test]
        public void RegistarVentaTest()
        {
            ClienteLista clienteLista = new ClienteLista();
            Fachada fachada = new Fachada();
            Administrador admin = new Administrador("100", "AR");
            Usuario usuario = admin.CrearUsuario("010", "AR");
            Cliente cliente = new Cliente("Alfredo", "Rosquilla", "099007100", "AlfedoGamer@cabezatermo.com");
            cliente.Id = "0";
            clienteLista.AgregaCliente(cliente);
            fachada.RegistrarVenta("0","SillaGamer","10/12/2011","250$","010");
            Venta venta = usuario.Total_Ventas[0];
            DateTime fecha = new DateTime(2023, 8, 10);
            List<Object> esperado = new List<object>() { "Alfredo", "Rosquilla", "SillaGamer", fecha, "250$"};
            List<Object> resultado = new List<object>()
                { venta.Cliente.Nombre, venta.Cliente.Apellido, venta.Producto, venta.Fecha, venta.Importe };
            CollectionAssert.AreEqual(resultado,esperado);
        }

        [Test]
        public void RegistarCotizacionTest()
        {
            ClienteLista clienteLista = new ClienteLista();
            
            Fachada fachada = new Fachada();
            Administrador admin = new Administrador("100", "AR");
            Usuario usuario = admin.CrearUsuario("010", "AR");
            Cliente cliente = new Cliente("Alfredo", "Rosquilla", "099007100", "AlfedoGamer@cabezatermo.com");
            cliente.Id = "0";
            clienteLista.AgregaCliente(cliente);
            fachada.RegistarCotizacion("0", "11/8/2023","250$","010");
            Cotizacion cotizacion = usuario.Cotizaciones[0];
            DateTime fecha = new DateTime(2023, 8, 10);
            List<Object> esperado = new List<object>() { "Alfredo", "Rosquilla", fecha, "250$"};
            List<Object> resultado = new List<object>()
                { cotizacion.Cliente.Nombre, cotizacion.Cliente.Apellido,cotizacion.Fecha, cotizacion.Importe };
            CollectionAssert.AreEqual(resultado,esperado);
        }
        
    }
    
}