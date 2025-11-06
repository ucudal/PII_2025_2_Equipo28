// using System;
// using System.Collections.Generic;
// using System.Runtime.InteropServices;
// using NUnit.Framework;
//
// namespace Library.Tests
// {
//     public class TestFachada_Historia_8_15_
//     {
//         private Fachada fachada;
//         private Usuario usuario;
//         private Cliente cliente;
//         private Administrador administrador;
//         
//         
//             [SetUp]
//             public void Setup()
//             {
//                 RepoUsuarios.Usuarios = new List<Usuario>();
//                 RepoUsuarios.Administradores = new List<Administrador>();
//                 RepoUsuarios.Vendedores = new List<Vendedor>();
//                 RepoUsuarios.ClientesTotales = new List<Cliente>();
//                 fachada = new Fachada();
//                 administrador = new Administrador("001", "Don Tomasino");
//                 administrador.CrearUsuario("1", "Argonauta");
//                 usuario = RepoUsuarios.BuscarUsuario("1");
//                 cliente = new Cliente("Di", "Caprio", "09781764", "Oscar@cabezatermo.com");
//                 cliente.Id = "01";
//                 fachada.RepoClientes.AgregaCliente(cliente);
//
//             }
//             
//             [Test]
//             public void RegistarMensajeTest()
//             {
//                 fachada.RegistarMensaje("01","Mensajeo","UltraMensaje","1","20/12/1998");
//                 List<object> esperado = new List<object>()
//                     { cliente, "Mensajeo", "UltraMensaje", new DateTime(1998, 12, 20) };
//                 Interaccion mensaje = fachada.Interacciones.BuscarInteraccion("mensaje", "UltraMensaje");
//                 List<object> resultado = new List<object>()
//                     { mensaje.Cliente, mensaje.Contenido, mensaje.Tema, mensaje.Fecha };
//                 Assert.AreEqual(esperado,resultado);
//             }
//             [Test]
//             public void RegistrarCorreoTest()
//             {
//                 fachada.RegistrarCorreo("01", "correando", "cococoreo", "1", "20/12/1998");
//                 List<object> esperado = new List<object>()
//                     { cliente, "correando", "cococoreo", new DateTime(1998, 12, 20) };
//                 Interaccion correo = fachada.Interacciones.BuscarInteraccion("correo", "cococoreo");
//                 List<object> resultado = new List<object>()
//                     { correo.Cliente, correo.Contenido, correo.Tema, correo.Fecha };
//                 Assert.AreEqual(esperado,resultado);
//             }
//         //     [Test]
//         //     public void AgregarNotaTest()
//         //     {
//         //         ClienteLista clienteLista = new ClienteLista();
//         //         Fachada fachada = new Fachada();
//         //         Administrador admin = new Administrador("100", "AR");
//         //         Usuario usuario = admin.CrearUsuario("010", "AR");
//         //         Cliente cliente = new Cliente("Alfredo", "Rosquilla", "099007100", "AlfedoGamer@cabezatermo.com");
//         //         cliente.Id = "0";
//         //         clienteLista.AgregaCliente(cliente);
//         //         fachada.RegistarMensaje("0","Hello holui","saludo","010");
//         //         fachada.AgregarNota("Me olvide del chau", "mensaje","saludo", "010");
//         //         Interaccion interaccion = usuario.BuscarInteraccion("mensaje", "saludo");
//         //         string esperado = "Me olvide del chau";
//         //         string resultado = interaccion.Notas;
//         //         Assert.That(resultado,Is.EqualTo(esperado));
//         //     }
//         //     
//         //     [Test]
//         //     public void AgregarEtiqueta_GuardarEtiquetaTest()
//         //     {
//         //         ClienteLista clienteLista = new ClienteLista();
//         //         Fachada fachada = new Fachada();
//         //         Administrador admin = new Administrador("100", "AR");
//         //         Usuario usuario = admin.CrearUsuario("010", "AR");
//         //         Cliente cliente = new Cliente("Alfredo", "Rosquilla", "099007100", "AlfedoGamer@cabezatermo.com");
//         //         cliente.Id = "0";
//         //         clienteLista.AgregaCliente(cliente);
//         //         fachada.AgregarEtiqueta("0", "Pastelero","010");
//         //         string esperado = "Pastelero";
//         //         string resultado = cliente.Etiqueta;
//         //         Assert.That(resultado,Is.EqualTo(esperado));
//         //         string resultado2 = usuario.Etiqueteas[0];
//         //         Assert.That(resultado2,Is.EqualTo(esperado));
//         //     }
//         //     
//         //     [Test]
//         //     public void RegistarVentaTest()
//         //     {
//         //         ClienteLista clienteLista = new ClienteLista();
//         //         Fachada fachada = new Fachada();
//         //         Administrador admin = new Administrador("100", "AR");
//         //         Usuario usuario = admin.CrearUsuario("010", "AR");
//         //         Cliente cliente = new Cliente("Alfredo", "Rosquilla", "099007100", "AlfedoGamer@cabezatermo.com");
//         //         cliente.Id = "0";
//         //         clienteLista.AgregaCliente(cliente);
//         //         fachada.RegistrarVenta("0","SillaGamer","15/08/2023","250$","010");
//         //         Venta venta = usuario.Total_Ventas[0];
//         //         DateTime fecha = new DateTime(2023, 8, 10);
//         //         List<Object> esperado = new List<object>() { "Alfredo", "Rosquilla", "SillaGamer", fecha, "250$"};
//         //         List<Object> resultado = new List<object>()
//         //             { venta.Cliente.Nombre, venta.Cliente.Apellido, venta.Producto, venta.Fecha, venta.Importe };
//         //         CollectionAssert.AreEqual(resultado,esperado);
//         //     }
//         //     
//         //     [Test]
//         //     public void RegistarCotizacionTest()
//         //     {
//         //         ClienteLista clienteLista = new ClienteLista();
//         //         
//         //         Fachada fachada = new Fachada();
//         //         Administrador admin = new Administrador("100", "AR");
//         //         Usuario usuario = admin.CrearUsuario("010", "AR");
//         //         Cliente cliente = new Cliente("Alfredo", "Rosquilla", "099007100", "AlfedoGamer@cabezatermo.com");
//         //         cliente.Id = "0";
//         //         clienteLista.AgregaCliente(cliente);
//         //         fachada.RegistarCotizacion("0", "11/08/2023","250$","010");
//         //         Cotizacion cotizacion = usuario.Cotizaciones[0];
//         //         DateTime fecha = new DateTime(2023, 8, 11);
//         //         List<Object> esperado = new List<object>() { "Alfredo", "Rosquilla", fecha, "250$"};
//         //         List<Object> resultado = new List<object>()
//         //             { cotizacion.Cliente.Nombre, cotizacion.Cliente.Apellido,cotizacion.Fecha, cotizacion.Importe };
//         //         CollectionAssert.AreEqual(resultado,esperado);
//         //     }
//         //     
//         // }
//
//     }
// }
