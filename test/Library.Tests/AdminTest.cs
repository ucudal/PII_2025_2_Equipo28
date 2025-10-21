using NUnit.Framework;
using System;

namespace Library.Tests
{

public class AdminTest
    {
        [Test]
        public void TestCrearUsuario()
        {
            // Arrange
            Listas.Usuarios.Clear();
            Administrador admin = new Administrador("001", "Andres");

            // Act
            Usuario result = admin.CrearUsuario("010", "Carlos");
            string expected = "Carlos";

            // Assert
            Assert.That(result.Nombre, Is.EqualTo(expected));
        }

        [Test]
        public void TestCrearVendedor()
        {
            // Arrange
            Listas.Vendedores.Clear();
            Administrador admin = new Administrador("001", "Andres");

            // Act
            Vendedor result = admin.CrearVendedor("V010", "Lucia");
            string expected = "Lucia";

            // Assert
            Assert.That(result.NombreCompleto, Is.EqualTo(expected));
        }

        [Test]
        public void TestCrearAdministrador()
        {
            // Arrange
            Listas.Administradores.Clear();
            Administrador admin = new Administrador("001", "Andres");

            // Act
            Administrador result = admin.CrearAdministrador("002", "Marta");
            string expected = "Marta";

            // Assert
            Assert.That(result.Nombre, Is.EqualTo(expected));
        }

        [Test]
        public void TestSuspenderUsuario()
        {
            // Arrange
            Listas.Usuarios.Clear();
            Administrador admin = new Administrador("001", "Andres");
            Usuario usuario = admin.CrearUsuario("011", "Rosa");

            // Act
            admin.SuspenderUsuario(usuario);
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
            Administrador admin = new Administrador("001", "Andres");
            Usuario usuario = admin.CrearUsuario("012", "Pedro");

            // Act
            admin.EliminarUsuario(usuario);
            Usuario result = Listas.BuscarUsuario("012");
            Usuario expected = null;

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestAgregarAdministrador()
        {
            // Arrange
            Listas.Administradores.Clear();
            Administrador admin = new Administrador("001", "Andres");
            Administrador otro = new Administrador("002", "Carla");

            // Act
            admin.AgregarAdministrador(otro);
            bool result = Listas.Administradores.Contains(otro);
            bool expected = true;

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestAgregarVendedor()
        {
            // Arrange
            Listas.Vendedores.Clear();
            Administrador admin = new Administrador("001", "Andres");
            Vendedor vendedor = new Vendedor("V001", "Tomas");

            // Act
            admin.AgregarVendedor(vendedor);
            bool result = Listas.Vendedores.Contains(vendedor);
            bool expected = true;

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
