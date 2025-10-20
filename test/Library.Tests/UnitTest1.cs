using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Library.Tests
{
    [TestFixture]
    public class Testsinteracciones
    {
        [Test]
        public void TestLlamada()
        {
            Administrador administrador = new Administrador("001", "Andres R");
            Usuario usuario = administrador.CrearUsuario("010", "Andres R");
            Cliente cliente = new Cliente("Rosita", "pintada", "0987770100", "Rosame@Cabezatermo.com");
            Llamadas llamada = new Llamadas(cliente, "Vegetta777", "Te llamo porque vegeta consiguio el SSJ3");
            usuario.Interacciones.Add(llamada);
            List<string> esperado = new List<string>()
                { "Rosita", "Vegetta777", "Te llamo porque vegeta consiguio el SSJ3" };
            Interaccion interaccion = usuario.BuscarInteraccion("llamada", "Vegetta777");
            List<string> resultado = new List<string>()
                { interaccion.Cliente.Nombre, interaccion.Tema, interaccion.contenido };
            CollectionAssert.AreEqual(esperado, resultado);
        }

        [Test]
        public void TestMensaje()
        {
            Administrador administrador = new Administrador("001", "Andres R");
            Usuario usuario = administrador.CrearUsuario("010", "Andres R");
            Cliente cliente = new Cliente("Rosita", "pintada", "0987770100", "Rosame@Cabezatermo.com");
            Mensajes mensajes = new Mensajes(cliente, "Vegetta777", "Te mensajeo porque vegeta consiguio el SSJ3");
            usuario.Interacciones.Add(mensajes);
            List<string> esperado = new List<string>()
                { "Rosita", "Vegetta777", "Te mensajeo porque vegeta consiguio el SSJ3" };
            Interaccion interaccion = usuario.BuscarInteraccion("mensaje", "Vegetta777");
            List<string> resultado = new List<string>()
                { interaccion.Cliente.Nombre, interaccion.Tema, interaccion.contenido };
            CollectionAssert.AreEqual(esperado, resultado);
        }

        [Test]
        public void TestCorreo()
        {
            Administrador administrador = new Administrador("001", "Andres R");
            Usuario usuario = administrador.CrearUsuario("010", "Andres R");
            Cliente cliente = new Cliente("Rosita", "pintada", "0987770100", "Rosame@Cabezatermo.com");
            Correos correo = new Correos(cliente, "Vegetta777", "Te correo porque vegeta consiguio el SSJ3");
            usuario.Interacciones.Add(correo);
            List<string> esperado = new List<string>()
                { "Rosita", "Vegetta777", "Te llamo correo vegeta consiguio el SSJ3" };
            Interaccion interaccion = usuario.BuscarInteraccion("correo", "Vegetta777");
            List<string> resultado = new List<string>()
                { interaccion.Cliente.Nombre, interaccion.Tema, interaccion.contenido };
            CollectionAssert.AreEqual(esperado, resultado);
        }

        [Test]
        public void TestReunion()
        {
            Administrador administrador = new Administrador("001", "Andres R");
            Usuario usuario = administrador.CrearUsuario("010", "Andres R");
            Cliente cliente = new Cliente("Rosita", "pintada", "0987770100", "Rosame@Cabezatermo.com");
            Reunion reunion = new Reunion(cliente, "Vegetta777", "El plantea x", "reunion para reunioniar",
                "10/10/2025");
            usuario.Interacciones.Add(reunion);
            DateTime fecha = new DateTime(2025, 10, 10);
            List<Object> esperado = new List<Object>()
                { "Rosita", "Vegetta777", "El plantea x", "reunion para reunioniar", fecha };
            Interaccion interaccion = usuario.BuscarInteraccion("reunion", "Vegetta777");
            List<Object> resultado = new List<Object>()
                { interaccion.Cliente.Nombre, interaccion.Tema, interaccion.lugar, interaccion.Fecha };
            CollectionAssert.AreEqual(esperado, resultado);
        }
    }
}
    