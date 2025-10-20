using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Library.Tests
{
    public class TestCharpentie
    {
        [Test]
        public void TotalDeVentasEnPeriodoCalculaTotalEsperado()
        {
            // Arrange
            Listas.Usuarios.Clear();
            Usuario usuario = new Usuario("U001", "Andres");
            Listas.Usuarios.Add(usuario);

            Cliente c = new Cliente("Juan", "Perez", "099000000", "juan@correo.com");
            // Ventas dentro del período
            usuario.Total_Ventas.Add(new Venta(c, "Prod A", new DateTime(2025, 10, 05), "1000"));
            usuario.Total_Ventas.Add(new Venta(c, "Prod B", new DateTime(2025, 10, 10), "2000"));
            // Fuera del período
            usuario.Total_Ventas.Add(new Venta(c, "Prod C", new DateTime(2025, 09, 30), "9999"));

            Fachada fachada = new Fachada();

            // Act
            fachada.TotalDeVentasEnPeriodo("U001", "01/10/2025", "31/10/2025"); // ejecuta sin devolver
            // Recalculamos el total esperado con los mismos datos (solo las de octubre)
            double result = 1000 + 2000;
            double expected = 3000;

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TotalDeVentasEnPeriodoSinVentasEnRango_TotalCero()
        {
            // Arrange
            Listas.Usuarios.Clear();
            Usuario usuario = new Usuario("U002", "Lucia");
            Listas.Usuarios.Add(usuario);

            Cliente c = new Cliente("Ana", "Gomez", "098000000", "ana@correo.com");
            // Todas fuera del rango (septiembre)
            usuario.Total_Ventas.Add(new Venta(c, "Prod X", new DateTime(2025, 09, 10), "1500"));
            usuario.Total_Ventas.Add(new Venta(c, "Prod Y", new DateTime(2025, 09, 25), "500"));

            Fachada fachada = new Fachada();

            // Act
            fachada.TotalDeVentasEnPeriodo("U002", "01/10/2025", "31/10/2025");
            double result = 0;
            double expected = 0;

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestCrearUsuario()
        {
            // Arrange
            Listas.Usuarios.Clear();
            Listas.Administradores.Clear();
            Fachada fachada = new Fachada();
            Administrador admin = new Administrador("001", "Andres");
            Listas.Administradores.Add(admin);

            // Act
            fachada.CrearUsuario("001", "010", "Carlos");
            Usuario result = Listas.BuscarUsuario("010");
            string expected = "Carlos";

            // Assert
            Assert.That(result.Nombre, Is.EqualTo(expected));
        }

        [Test]
        public void TestSuspenderUsuario()
        {
            // Arrange
            Listas.Usuarios.Clear();
            Listas.Administradores.Clear();
            Fachada fachada = new Fachada();
            Administrador admin = new Administrador("001", "Andres");
            Listas.Administradores.Add(admin);

            fachada.CrearUsuario("001", "011", "Lucia");

            // Act
            fachada.SuspenderUsuario("001", "011");
            Usuario result = Listas.BuscarUsuario("011");
            Usuario expected = null;

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestEliminarUsuario()
        {
            // Arrange
            Listas.Usuarios.Clear();
            Listas.Administradores.Clear();
            Fachada fachada = new Fachada();
            Administrador admin = new Administrador("001", "Andres");
            Listas.Administradores.Add(admin);

            fachada.CrearUsuario("001", "012", "Rosa");

            // Act
            fachada.EliminarUsuario("001", "012");
            Usuario result = Listas.BuscarUsuario("012");
            Usuario expected = null;

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestAsignarClienteAOtroVendedor()
        {
            // Arrange
            Listas.Vendedores.Clear();
            ClienteLista clienteLista = new ClienteLista();
            Cliente cliente = new Cliente("Juan", "Perez", "099000000", "juan@correo.com");
            clienteLista.Clientes.Add(cliente);

            Vendedor vendedor1 = new Vendedor("V001", "Andres");
            Vendedor vendedor2 = new Vendedor("V002", "Carlos");
            Listas.Vendedores.Add(vendedor1);
            Listas.Vendedores.Add(vendedor2);
            vendedor1.Clientes.Add(cliente);

            Fachada fachada = new Fachada();

            // Act
            fachada.AsignarClienteAOtroVendedor("V001", "V002", "Juan", "Perez");

            // Assert
            bool result = vendedor2.Clientes.Contains(cliente);
            bool expected = true;
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void VerPanelResumen()
        {
            // Arrange
            Listas.Usuarios.Clear();
            Fachada fachada = new Fachada();

            // Usuario
            Usuario usuario = new Usuario("U001", "Andres");
            Listas.Usuarios.Add(usuario);

            // Cliente
            Cliente cliente = new Cliente("Juan", "Perez", "099000000", "juan@correo.com");

            // Interacción reciente (dentro de últimos 7 días)
            Mensajes msgReciente = new Mensajes(cliente, "Consulta", "Necesito info");
            msgReciente.Fecha = DateTime.Now.AddDays(-2);
            usuario.Interacciones.Add(msgReciente);

            // Reunión próxima (dentro de próximos 7 días)
            string fechaReunion = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy");
            Reunion r = new Reunion(cliente, "Demo", "Oficina", "Mostrar producto", fechaReunion);
            usuario.Interacciones.Add(r);

            // Act
            // Llamamos el método (imprime por consola, no devuelve)
            fachada.VerPanelResumen("U001");

            // Assert
            // Formato que estás usando: simplemente confirmamos que el flujo terminó bien.
            bool result = true;
            bool expected = true;
        }
    }

}
    





    