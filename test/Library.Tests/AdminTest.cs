/* using NUnit.Framework;
using Library;
using System.Collections.Generic;

namespace Library.Tests
{
    /// <summary>
    /// Tests para la clase Administrador
    /// </summary>
    public class AdminTest
    {
        [Test]
        public void Constructor_CrearAdministrador_AsignaIdYNombreCorrectamente()
        {
            // Arrange
            string expectedId = "A001";
            string expectedNombre = "Juan";

            // Act
            Administrador admin = new Administrador(expectedId, expectedNombre);

            // Assert
            Assert.That(admin.ID, Is.EqualTo(expectedId));
            Assert.That(admin.Nombre, Is.EqualTo(expectedNombre));
        }

        [Test]
        public void Constructor_CrearAdministrador_InicializaListaUsuariosSuspendidosVacia()
        {
            // Arrange & Act
            Administrador admin = new Administrador("A002", "Maria");

            // Assert
            Assert.That(admin.UsuariosSuspendidos, Is.Not.Null);
            Assert.That(admin.UsuariosSuspendidos, Is.Empty);
        }

        [Test]
        public void Herencia_AdministradorEsUsuario_DevuelveTrue()
        {
            // Arrange
            Administrador admin = new Administrador("A003", "Carlos");

            // Act & Assert
            Assert.That(admin, Is.InstanceOf<Usuario>());
        }

        [Test]
        public void UsuariosSuspendidos_AgregarUsuario_AumentaConteo()
        {
            // Arrange
            Administrador admin = new Administrador("A004", "Ana");
            Usuario usuario = new Usuario("U001", "Pedro");

            // Act
            admin.UsuariosSuspendidos.Add(usuario);

            // Assert
            Assert.That(admin.UsuariosSuspendidos.Count, Is.EqualTo(1));
            Assert.That(admin.UsuariosSuspendidos[0], Is.EqualTo(usuario));
        }

        [Test]
        public void UsuariosSuspendidos_AgregarMultiplesUsuarios_MantieneTodos()
        {
            // Arrange
            Administrador admin = new Administrador("A005", "Sofia");
            Usuario usuario1 = new Usuario("U001", "Laura");
            Usuario usuario2 = new Usuario("U002", "Diego");
            Usuario usuario3 = new Usuario("U003", "Elena");

            // Act
            admin.UsuariosSuspendidos.Add(usuario1);
            admin.UsuariosSuspendidos.Add(usuario2);
            admin.UsuariosSuspendidos.Add(usuario3);

            // Assert
            Assert.That(admin.UsuariosSuspendidos.Count, Is.EqualTo(3));
            Assert.That(admin.UsuariosSuspendidos, Contains.Item(usuario1));
            Assert.That(admin.UsuariosSuspendidos, Contains.Item(usuario2));
            Assert.That(admin.UsuariosSuspendidos, Contains.Item(usuario3));
        }

        [Test]
        public void HeredaDeUsuario_PuedeUsarMetodosDeUsuario_ToString()
        {
            // Arrange
            Administrador admin = new Administrador("A006", "Roberto");
            string expectedString = "Roberto - Id: A006";

            // Act
            string result = admin.ToString();

            // Assert
            Assert.That(result, Is.EqualTo(expectedString));
        }
    }
}
 */