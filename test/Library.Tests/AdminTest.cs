using NUnit.Framework;
using Library;

namespace Library.Tests
{
    public class AdminTest
    {
        private Fachada fachada;

        [SetUp]
        public void Setup()
        {
            fachada = Fachada.Instancia;
        }

        // ===========================================================
        // TESTS: CREAR USUARIO
        // ===========================================================

        [Test]
        public void CrearUsuario_NuevoUsuario_DevuelveMensajeExito()
        {
            // Arrange
            string id = "001";
            string nombre = "Matteo";
            string expected = $"Usuario '{nombre}' (ID: {id}) creado correctamente.";

            // Act
            string result = fachada.CrearUsuario(id, nombre);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void CrearUsuario_UsuarioYaExiste_DevuelveMensajeError()
        {
            // Arrange
            string id = "002";
            string nombre = "Greta";
            fachada.CrearUsuario(id, nombre);
            string expected = $"Ya existe un usuario con el ID '{id}'.";

            // Act
            string result = fachada.CrearUsuario(id, nombre);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        // ===========================================================
        // TESTS: SUSPENDER USUARIO
        // ===========================================================

        [Test]
        public void SuspenderUsuario_UsuarioExistente_DevuelveMensajeExito()
        {
            // Arrange
            string id = "003";
            string nombre = "Luca";
            fachada.CrearUsuario(id, nombre);
            string expected = $" El usuario '{nombre}' ha sido suspendido correctamente.";

            // Act
            string result = fachada.SuspenderUsuario(id);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void SuspenderUsuario_NoExiste_DevuelveMensajeError()
        {
            // Arrange
            string id = "999";
            string expected = $"No se encontró un usuario con ID '{id}'.";

            // Act
            string result = fachada.SuspenderUsuario(id);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        // ===========================================================
        // TESTS: ELIMINAR USUARIO
        // ===========================================================

        [Test]
        public void EliminarUsuario_Activo_DevuelveMensajeExito()
        {
            // Arrange
            string id = "004";
            string nombre = "Carlos";
            fachada.CrearUsuario(id, nombre);
            string expected = $"🗑 El usuario '{nombre}' ha sido eliminado del sistema.";

            // Act
            string result = fachada.EliminarUsuario(id);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void EliminarUsuario_Suspendido_DevuelveMensajeExito()
        {
            // Arrange
            string id = "005";
            string nombre = "Nina";
            fachada.CrearUsuario(id, nombre);
            fachada.SuspenderUsuario(id);
            string expected = $"🗑 El usuario '{nombre}' ha sido eliminado del sistema.";

            // Act
            string result = fachada.EliminarUsuario(id);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void EliminarUsuario_NoExiste_DevuelveMensajeError()
        {
            // Arrange
            string id = "888";
            string expected = $"No se encontró un usuario con ID '{id}'.";

            // Act
            string result = fachada.EliminarUsuario(id);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}

//         public void TestCrearUsuario()
//         {
//             // Arrange
//             RepoUsuarios.Usuarios.Clear();
//             Administrador admin = new Administrador("001", "Andres");
//
//             // Act
//             Usuario result = admin.CrearUsuario("010", "Carlos");
//             string expected = "Carlos";
//
//             // Assert
//             Assert.That(result.Nombre, Is.EqualTo(expected));
//         }
//
//         [Test]
//         public void TestCrearVendedor()
//         {
//             // Arrange
//             RepoUsuarios.Vendedores.Clear();
//             Administrador admin = new Administrador("001", "Andres");
//
//             // Act
//             Vendedor result = admin.CrearVendedor("V010", "Lucia");
//             string expected = "Lucia";
//
//             // Assert
//             Assert.That(result.NombreCompleto, Is.EqualTo(expected));
//         }
//
//         [Test]
//         public void TestCrearAdministrador()
//         {
//             // Arrange
//             RepoUsuarios.Administradores.Clear();
//             Administrador admin = new Administrador("001", "Andres");
//
//             // Act
//             Administrador result = admin.CrearAdministrador("002", "Marta");
//             string expected = "Marta";
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
//             Administrador admin = new Administrador("001", "Andres");
//             Usuario usuario = admin.CrearUsuario("011", "Rosa");
//
//             // Act
//             admin.SuspenderUsuario(usuario);
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
//             Administrador admin = new Administrador("001", "Andres");
//             Usuario usuario = admin.CrearUsuario("012", "Pedro");
//
//             // Act
//             admin.EliminarUsuario(usuario);
//             Usuario result = RepoUsuarios.BuscarUsuario("012");
//             Usuario expected = null;
//
//             // Assert
//             Assert.That(result, Is.EqualTo(expected));
//         }
//
//         [Test]
//         public void TestAgregarAdministrador()
//         {
//             // Arrange
//             RepoUsuarios.Administradores.Clear();
//             Administrador admin = new Administrador("001", "Andres");
//             Administrador otro = new Administrador("002", "Carla");
//
//             // Act
//             admin.AgregarAdministrador(otro);
//             bool result = RepoUsuarios.Administradores.Contains(otro);
//             bool expected = true;
//
//             // Assert
//             Assert.That(result, Is.EqualTo(expected));
//         }
//
//         [Test]
//         public void TestAgregarVendedor()
//         {
//             // Arrange
//             RepoUsuarios.Vendedores.Clear();
//             Administrador admin = new Administrador("001", "Andres");
//             Vendedor vendedor = new Vendedor("V001", "Tomas");
//
//             // Act
//             admin.AgregarVendedor(vendedor);
//             bool result = RepoUsuarios.Vendedores.Contains(vendedor);
//             bool expected = true;
//
//             // Assert
//             Assert.That(result, Is.EqualTo(expected));
//         }
//     }
// }
