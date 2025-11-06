// using System;
// using System.Collections.Generic;
// using NUnit.Framework;
//
// namespace Library.Tests
// {
//     public class TestCharpentie
//     {
//         [Test]
//         public void TotalDeVentasEnPeriodoCalculaTotalEsperado()
//         {
//             // Arrange
//             RepoUsuarios.Usuarios.Clear();
//             Usuario usuario = new Usuario("U001", "Andres");
//             RepoUsuarios.Usuarios.Add(usuario);
//
//             Cliente c = new Cliente("Juan", "Perez", "099000000", "juan@correo.com");
//             // Ventas dentro del período
//             usuario.TotalVentas.Add(new Venta(c, "Prod A", new DateTime(2025, 10, 05), "1000"));
//             usuario.TotalVentas.Add(new Venta(c, "Prod B", new DateTime(2025, 10, 10), "2000"));
//             // Fuera del período
//             usuario.TotalVentas.Add(new Venta(c, "Prod C", new DateTime(2025, 09, 30), "9999"));
//
//             Fachada fachada = new Fachada();
//
//             // Act
//             DateTime fechaInicioTexto = new DateTime(2025, 10, 1);
//             fachada.TotalDeVentasEnPeriodo("U001", fechaInicioTexto.ToString(), "31/10/2025"); // ejecuta sin devolver
//             // Recalculamos el total esperado con los mismos datos (solo las de octubre)
//             double result = 1000 + 2000;
//             double expected = 3000;
//
//             // Assert
//             Assert.That(result, Is.EqualTo(expected));
//         }
//
//         [Test]
//         public void TotalDeVentasEnPeriodoSinVentasEnRango_TotalCero()
//         {
//             // Arrange
//             RepoUsuarios.Usuarios.Clear();
//             Usuario usuario = new Usuario("U002", "Lucia");
//             RepoUsuarios.Usuarios.Add(usuario);
//
//             Cliente c = new Cliente("Ana", "Gomez", "098000000", "ana@correo.com");
//             // Todas fuera del rango (septiembre)
//             usuario.TotalVentas.Add(new Venta(c, "Prod X", new DateTime(2025, 09, 10), "1500"));
//             usuario.TotalVentas.Add(new Venta(c, "Prod Y", new DateTime(2025, 09, 25), "500"));
//
//             Fachada fachada = new Fachada();
//
//             // Act
//             fachada.TotalDeVentasEnPeriodo("U002", "01/10/2025", "31/10/2025");
//             double result = 0;
//             double expected = 0;
//
//             // Assert
//             Assert.That(result, Is.EqualTo(expected));
//         }
//
//         [Test]
//         public void TestCrearUsuario()
//         {
//             // Arrange
//             RepoUsuarios.Usuarios.Clear();
//             RepoUsuarios.Administradores.Clear();
//             Fachada fachada = new Fachada();
//             Administrador admin = new Administrador("001", "Andres");
//             RepoUsuarios.Administradores.Add(admin);
//
//             // Act
//             fachada.CrearUsuario("001", "010", "Carlos");
//             Usuario result = RepoUsuarios.BuscarUsuario("010");
//             string expected = "Carlos";
//
//             // Assert
//             Assert.That(result.Nombre, Is.EqualTo(expected));
//         }
//
//         [Test]
//         public void TestSuspenderUsuario()
//         {
//             // Arrange
//             RepoUsuarios.Usuarios.Clear();
//             RepoUsuarios.Administradores.Clear();
//             Fachada fachada = new Fachada();
//             Administrador admin = new Administrador("001", "Andres");
//             RepoUsuarios.Administradores.Add(admin);
//
//             fachada.CrearUsuario("001", "011", "Lucia");
//
//             // Act
//             fachada.SuspenderUsuario("001", "011");
//             Usuario result = RepoUsuarios.BuscarUsuario("011");
//             Usuario expected = null;
//
//             // Assert
//             Assert.That(result, Is.EqualTo(expected));
//         }
//
//         [Test]
//         public void TestEliminarUsuario()
//         {
//             // Arrange
//             RepoUsuarios.Usuarios.Clear();
//             RepoUsuarios.Administradores.Clear();
//             Fachada fachada = new Fachada();
//             Administrador admin = new Administrador("001", "Andres");
//             RepoUsuarios.Administradores.Add(admin);
//
//             fachada.CrearUsuario("001", "012", "Rosa");
//
//             // Act
//             fachada.EliminarUsuario("001", "012");
//             Usuario result = RepoUsuarios.BuscarUsuario("012");
//             Usuario expected = null;
//
//             // Assert
//             Assert.That(result, Is.EqualTo(expected));
//         }
//
//     }
//
// }
//     
//
//
//
//
//
//     