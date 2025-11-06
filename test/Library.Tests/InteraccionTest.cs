// using System;
// using System.Collections.Generic;
// using NUnit.Framework;
//
// namespace Library.Tests
// {
//     public class Testsinteracciones
//     {
//         private Cliente cliente1;
//
//         [SetUp]
//         public void setup()
//         {
//             cliente1 = new Cliente("SubZero", "Scorpion", "0972133", "Frozen@moralcomba.com");
//         }
//
//         [Test]
//         public void TestLlamada()
//         {
//             Administrador administrador = new Administrador("001", "Andres R");
//             Usuario usuario = administrador.aCrearUsuario("010", "Andres R");
//             Cliente cliente = new Cliente("Rosita", "pintada", "0987770100", "Rosame@Cabezatermo.com");
//             Llamadas llamada = new Llamadas(cliente, "Vegetta777", "Te llamo porque vegeta consiguio el SSJ3",
//                 "10/09/1000");
//             RepoInteracciones repoInteracciones = new RepoInteracciones();
//             repoInteracciones.AgregarInteraccion(llamada, usuario);
//             DateTime dateTime = new DateTime(1000, 9, 10);
//             List<Object> esperado = new List<Object>()
//                 { "Rosita", "Vegetta777", "Te llamo porque vegeta consiguio el SSJ3", dateTime };
//             Interaccion interaccion = repoInteracciones.BuscarInteraccion("llamada", "Vegetta777");
//             List<Object> resultado = new List<Object>()
//                 { interaccion.Cliente.Nombre, interaccion.Tema, interaccion.Contenido, interaccion.Fecha };
//             CollectionAssert.AreEqual(esperado, resultado);
//         }
//
//         [Test]
//         public void TestMensaje()
//         {
//             Administrador administrador = new Administrador("001", "Andres R");
//             Usuario usuario = administrador.CrearUsuario("010", "Andres R");
//             Cliente cliente = new Cliente("Rosita", "pintada", "0987770100", "Rosame@Cabezatermo.com");
//             Mensajes mensajes = new Mensajes(cliente, "Vegetta777", "Te mensajeo porque vegeta consiguio el SSJ3","10/09/1000");
//             RepoInteracciones repoInteracciones = new RepoInteracciones();
//             repoInteracciones.AgregarInteraccion(mensajes, usuario);
//             List<string> esperado = new List<string>()
//                 { "Rosita", "Vegetta777", "Te mensajeo porque vegeta consiguio el SSJ3" };
//             Interaccion interaccion = repoInteracciones.BuscarInteraccion("mensaje", "Vegetta777");
//             List<string> resultado = new List<string>()
//                 { interaccion.Cliente.Nombre, interaccion.Tema, interaccion.Contenido };
//             CollectionAssert.AreEqual(esperado, resultado);
//         }
//
//         [Test]
//         public void TestCorreo()
//         {
//             Administrador administrador = new Administrador("001", "Andres R");
//             Usuario usuario = administrador.CrearUsuario("010", "Andres R");
//             Cliente cliente = new Cliente("Rosita", "pintada", "0987770100", "Rosame@Cabezatermo.com");
//             Correos correo = new Correos(cliente, "Vegetta777", "Te correo porque vegeta consiguio el SSJ3","10/09/1000");
//             RepoInteracciones repoInteracciones = new RepoInteracciones();
//             repoInteracciones.AgregarInteraccion(correo, usuario);
//             List<string> esperado = new List<string>()
//                 { "Rosita", "Vegetta777", "Te correo porque vegeta consiguio el SSJ3" };
//             Interaccion interaccion = repoInteracciones.BuscarInteraccion("correo", "Vegetta777");
//             List<string> resultado = new List<string>()
//                 { interaccion.Cliente.Nombre, interaccion.Tema, interaccion.Contenido };
//             CollectionAssert.AreEqual(esperado, resultado);
//         }
//
//         [Test]
//         public void TestReunion()
//         {
//             Administrador administrador = new Administrador("001", "Andres R");
//             Usuario usuario = administrador.CrearUsuario("010", "Andres R");
//             Cliente cliente = new Cliente("Rosita", "pintada", "0987770100", "Rosame@Cabezatermo.com");
//             Reunion reunion = new Reunion(cliente, "Vegetta777", "El plantea x", "reunion para reunioniar",
//                 "10/10/2025");
//             RepoInteracciones repoInteracciones = new RepoInteracciones();
//             repoInteracciones.AgregarInteraccion(reunion, usuario);
//             DateTime fecha = new DateTime(2025, 10, 10);
//             List<Object> esperado = new List<Object>()
//                 { "Rosita", "Vegetta777", "El plantea x", "reunion para reunioniar", fecha };
//             Interaccion interaccion = repoInteracciones.BuscarInteraccion("reunion", "Vegetta777");
//             List<Object> resultado = new List<Object>()
//             {
//                 interaccion.Cliente.Nombre, interaccion.Tema, interaccion.Lugar, interaccion.Contenido,
//                 interaccion.Fecha
//             };
//             CollectionAssert.AreEqual(esperado, resultado);
//         }
//
//         [Test]
//         public void TestExceptionNullLlamada()
//         {
//             Assert.Multiple(() =>
//             {
//                 Assert.Throws<ArgumentNullException>(() => new Llamadas(null, "hello", "xd", "10/10/2050"));
//                 Assert.Throws<ArgumentNullException>(() => new Llamadas(cliente1, null, "xd", "10/10/2050"));
//                 Assert.Throws<ArgumentNullException>(() => new Llamadas(cliente1, "hello", null, "10/10/2050"));
//                 Assert.Throws<ArgumentNullException>(() => new Llamadas(cliente1, "null", "xd", null));
//             });
//         }
//         [Test]
//         public void TestExceptionEmptyLlamda()
//         {
//             Assert.Multiple(() =>
//             {
//                 Assert.Throws<Excepciones.EmptyStringException>(() => new Llamadas(cliente1, "", "xd", "10/10/2050"));
//                 Assert.Throws<Excepciones.EmptyStringException>(() => new Llamadas(cliente1, "null", "", "10/10/2050"));
//                 Assert.Throws<Excepciones.EmptyStringException>(() => new Llamadas(cliente1, "hello", "null", ""));
//             });
//         }
//         [Test]
//         public void TestExceptionInvalidDateLlamada()
//         {
//             Assert.Multiple(() =>
//             {
//                 Assert.Throws<Excepciones.InvalidDateException>(() => new Llamadas(cliente1, "hi", "xd", "50/10/2050"));
//                 Assert.Throws<Excepciones.InvalidDateException>(() => new Llamadas(cliente1, "null", "nel", "10/50/2050"));
//             });
//         }
//         [Test]
//         public void TestExceptionNullCorreo()
//         {
//             Assert.Multiple(() =>
//             {
//                 Assert.Throws<ArgumentNullException>(() => new Correos(null, "hello", "xd", "10/10/2050"));
//                 Assert.Throws<ArgumentNullException>(() => new Correos(cliente1, null, "xd", "10/10/2050"));
//                 Assert.Throws<ArgumentNullException>(() => new Correos(cliente1, "hello", null, "10/10/2050"));
//                 Assert.Throws<ArgumentNullException>(() => new Correos(cliente1, "null", "xd", null));
//             });
//         }
//         [Test]
//         public void TestExceptionEmptyCorreo()
//         {
//             Assert.Multiple(() =>
//             {
//                 Assert.Throws<Excepciones.EmptyStringException>(() => new Correos(cliente1, "", "xd", "10/10/2050"));
//                 Assert.Throws<Excepciones.EmptyStringException>(() => new Correos(cliente1, "null", "", "10/10/2050"));
//                 Assert.Throws<Excepciones.EmptyStringException>(() => new Correos(cliente1, "hello", "null", ""));
//             });
//         }
//         [Test]
//         public void TestExceptionInvalidDateCorreo()
//         {
//             Assert.Multiple(() =>
//             {
//                 Assert.Throws<Excepciones.InvalidDateException>(() => new Correos(cliente1, "hi", "xd", "50/10/2050"));
//                 Assert.Throws<Excepciones.InvalidDateException>(() => new Correos(cliente1, "null", "nel", "10/50/2050"));
//             });
//         }
//         [Test]
//         public void TestExceptionNullMensaje()
//         {
//             Assert.Multiple(() =>
//             {
//                 Assert.Throws<ArgumentNullException>(() => new Mensajes(null, "hello", "xd", "10/10/2050"));
//                 Assert.Throws<ArgumentNullException>(() => new Mensajes(cliente1, null, "xd", "10/10/2050"));
//                 Assert.Throws<ArgumentNullException>(() => new Mensajes(cliente1, "hello", null, "10/10/2050"));
//                 Assert.Throws<ArgumentNullException>(() => new Mensajes(cliente1, "null", "xd", null));
//             });
//         }
//         [Test]
//         public void TestExceptionEmptyMensaje()
//         {
//             Assert.Multiple(() =>
//             {
//                 Assert.Throws<Excepciones.EmptyStringException>(() => new Mensajes(cliente1, "", "xd", "10/10/2050"));
//                 Assert.Throws<Excepciones.EmptyStringException>(() => new Mensajes(cliente1, "null", "", "10/10/2050"));
//                 Assert.Throws<Excepciones.EmptyStringException>(() => new Mensajes(cliente1, "hello", "null", ""));
//             });
//         }
//         [Test]
//         public void TestExceptionInvalidDateMensaje()
//         {
//             Assert.Multiple(() =>
//             {
//                 Assert.Throws<Excepciones.InvalidDateException>(() => new Mensajes(cliente1, "hi", "xd", "50/10/2050"));
//                 Assert.Throws<Excepciones.InvalidDateException>(() => new Mensajes(cliente1, "null", "nel", "10/50/2050"));
//             });
//         }
//         [Test]
//         public void TestExceptionNullReunion()
//         {
//             Assert.Multiple(() =>
//             {
//                 Assert.Throws<ArgumentNullException>(() => new Reunion(null, "hello", "xd", "magic","10/10/2050"));
//                 Assert.Throws<ArgumentNullException>(() => new Reunion(cliente1, null, "xd", "magic","10/10/2050"));
//                 Assert.Throws<ArgumentNullException>(() => new Reunion(cliente1, "hello", null, "magic","10/10/2050"));
//                 Assert.Throws<ArgumentNullException>(() => new Reunion(cliente1, "null", "xd", null,"10/10/2050"));
//                 Assert.Throws<ArgumentNullException>(() => new Reunion(cliente1, "null", "xd", "null",null));
//
//             });
//         }
//         [Test]
//         public void TestExceptionEmptyReunion()
//         {
//             Assert.Multiple(() =>
//             {
//                 Assert.Throws<Excepciones.EmptyStringException>(() => new Reunion(cliente1, "", "xd","reunio", "10/10/2050"));
//                 Assert.Throws<Excepciones.EmptyStringException>(() => new Reunion(cliente1, "null", "","reunio", "10/10/2050"));
//                 Assert.Throws<Excepciones.EmptyStringException>(() => new Reunion(cliente1, "hello", "null", "","10/10/2050"));
//                 Assert.Throws<Excepciones.EmptyStringException>(() => new Reunion(cliente1, "hello", "null", "rrr",""));
//
//             });
//         }
//         [Test]
//         public void TestExceptionInvalidDateReunion()
//         {
//             Assert.Multiple(() =>
//             {
//                 Assert.Throws<Excepciones.InvalidDateException>(() => new Reunion(cliente1, "hi", "xd","n", "50/10/2050"));
//                 Assert.Throws<Excepciones.InvalidDateException>(() => new Reunion(cliente1, "null", "nel","n", "10/50/2050"));
//             });
//         }
//         
//
//     }
// }
//
//     