using NUnit.Framework;
using System;
using Library;

namespace Library.Tests
{
    [TestFixture]
    public class FachadaTests
    {
        private Fachada fachada;

        [SetUp]
        public void Setup()
        {
            fachada = Fachada.Instancia;

            // Limpiar estado de usuarios
            fachada.Usuarios.Usuarios.Clear();
            fachada.Usuarios.Administradores.Clear();
            fachada.Usuarios.Vendedores.Clear();
            fachada.Usuarios.ClientesTotales.Clear();
            fachada.UsuariosSuspendidos.Clear();

            // Reiniciar repos 
            fachada.Clientes = new RepoClientes(fachada.Etiquetas, fachada.Usuarios);
            fachada.Interacciones = new RepoInteracciones();
            fachada.Ventas = new RepoVentas();
            fachada.Cotizaciones = new RepoCotizaciones();
        }

        [Test]
        public void CrearVendedor_ConDatosValidos_DeberiaCrearVendedor()
        {
            string id = "V1";
            string nombre = "Juan Vendedor";

            Vendedor resultado = fachada.CrearVendedor(id, nombre);

            Assert.IsNotNull(resultado);
            Assert.That(resultado.Id, Is.EqualTo(id));
            Assert.That(resultado.NombreCompleto, Is.EqualTo(nombre));
        }

        [Test]
        public void CrearVendedor_ConIdNulo_DeberiaLanzarArgumentNullException()
        {
            string id = null;
            string nombre = "Juan Vendedor";
            Assert.Throws<ArgumentNullException>(() => fachada.CrearVendedor(id, nombre));
        }

        [Test]
        public void CrearVendedor_ConNombreNulo_DeberiaLanzarArgumentNullException()
        {
            string id = "V1";
            string nombre = null;
            Assert.Throws<ArgumentNullException>(() => fachada.CrearVendedor(id, nombre));
        }

        [Test]
        public void CrearVendedor_ConIdVacio_DeberiaLanzarEmptyStringException()
        {
            string id = "";
            string nombre = "Juan Vendedor";
            Assert.Throws<Excepciones.EmptyStringException>(() => fachada.CrearVendedor(id, nombre));
        }

        [Test]
        public void CrearVendedor_ConNombreVacio_DeberiaLanzarEmptyStringException()
        {
            string id = "V1";
            string nombre = "   ";
            Assert.Throws<Excepciones.EmptyStringException>(() => fachada.CrearVendedor(id, nombre));
        }

        [Test]
        public void CrearVendedor_ConIdDuplicado_DeberiaLanzarInvalidOperationException()
        {
            string id = "U1";
            string nombre1 = "Juan Vendedor";
            string nombre2 = "Pedro Vendedor";
            fachada.CrearVendedor(id, nombre1);
            Assert.Throws<InvalidOperationException>(() => fachada.CrearVendedor(id, nombre2));
        }
        
        [Test]
        public void CrearAdministrador_ConDatosValidos_DeberiaCrearAdministrador()
        {
            string id = "A1";       // ahora sí, SetUp no lo crea
            string nombre = "Juan Admin";

            Administrador resultado = fachada.CrearAdministrador(id, nombre);

            Assert.IsNotNull(resultado);
            Assert.That(resultado.ID, Is.EqualTo(id));
            Assert.That(resultado.Nombre, Is.EqualTo(nombre));
        }

        [Test]
        public void CrearAdministrador_ConIdNulo_DeberiaLanzarArgumentNullException()
        {
            string id = null;
            string nombre = "Juan Admin";
            Assert.Throws<ArgumentNullException>(() => fachada.CrearAdministrador(id, nombre));
        }

        [Test]
        public void CrearAdministrador_ConNombreNulo_DeberiaLanzarArgumentNullException()
        {
            string id = "A1";
            string nombre = null;
            Assert.Throws<ArgumentNullException>(() => fachada.CrearAdministrador(id, nombre));
        }

        [Test]
        public void CrearAdministrador_ConIdVacio_DeberiaLanzarEmptyStringException()
        {
            string id = "";
            string nombre = "Juan Admin";
            Assert.Throws<Excepciones.EmptyStringException>(() => fachada.CrearAdministrador(id, nombre));
        }

        [Test]
        public void CrearAdministrador_ConIdDuplicado_DeberiaLanzarInvalidOperationException()
        {
            string id = "B1";
            string nombre1 = "Juan Admin";
            string nombre2 = "Pepe Admin";
            fachada.CrearAdministrador(id, nombre1);
            Assert.Throws<InvalidOperationException>(() => fachada.CrearAdministrador(id, nombre2));
        }
        
        [Test]
        public void CrearUsuario_ConDatosValidos_DeberiaRetornarMensajeExito()
        {
            fachada.CrearAdministrador("A1", "Admin Base"); // necesita admin
            string id = "G1";
            string nombre = "Pepe Usuario";

            string resultado = fachada.CrearUsuario(id, nombre, "A1");

            Assert.IsTrue(resultado.Contains("creado correctamente"));
            Assert.IsNotNull(fachada.BuscarUsuario(id));
        }

        [Test]
        public void CrearUsuario_ConIdDuplicado_DeberiaRetornarMensajeError()
        {
            fachada.CrearAdministrador("A1", "Admin Base"); // necesita admin
            string id = "U1";
            string nombre1 = "Pepe Usuario";
            string nombre2 = "Manolo Usuario";
            fachada.CrearUsuario(id, nombre1, "A1");

            string resultado = fachada.CrearUsuario(id, nombre2, "A1");

            Assert.IsTrue(resultado.Contains("Ya existe un usuario"));
        }
        
        [Test]
        public void SuspenderUsuario_ConUsuarioExistente_DeberiaSuspenderCorrectamente()
        {
            fachada.CrearAdministrador("A1", "Admin Base"); // necesita admin
            string id = "U1";
            string nombre = "Pepe Usuario";
            fachada.CrearUsuario(id, nombre, "A1");

            string resultado = fachada.SuspenderUsuario(id, "A1");

            Assert.IsTrue(resultado.Contains("suspendido correctamente"));
            Assert.IsNull(fachada.BuscarUsuario(id));
            Assert.That(fachada.UsuariosSuspendidos.Count, Is.EqualTo(1)); // corregido
        }

        [Test]
        public void SuspenderUsuario_ConUsuarioNoExistente_DeberiaRetornarMensajeError()
        {
            fachada.CrearAdministrador("A1", "Admin Base"); // necesita admin
            string id = "U10";

            string resultado = fachada.SuspenderUsuario(id, "A1");

            Assert.IsTrue(resultado.Contains("No se encontró"));
        }
        
        [Test]
        public void EliminarUsuario_ConUsuarioActivo_DeberiaEliminarCorrectamente()
        {
            fachada.CrearAdministrador("A1", "Admin Base"); // necesita admin
            string id = "U1";
            string nombre = "Pepe Usuario";
            fachada.CrearUsuario(id, nombre, "A1");

            string resultado = fachada.EliminarUsuario(id, "A1");

            Assert.IsTrue(resultado.Contains("eliminado del sistema"));
            Assert.IsNull(fachada.BuscarUsuario(id));
        }

        [Test]
        public void EliminarUsuario_ConUsuarioSuspendido_DeberiaEliminarCorrectamente()
        {
            fachada.CrearAdministrador("A1", "Admin Base"); // necesita admin
            string id = "U1";
            string nombre = "Pepe Usuario";
            fachada.CrearUsuario(id, nombre, "A1");
            fachada.SuspenderUsuario(id, "A1");

            string resultado = fachada.EliminarUsuario(id, "A1");

            Assert.IsTrue(resultado.Contains("eliminado del sistema"));
            Assert.That(fachada.UsuariosSuspendidos.Count, Is.EqualTo(0)); // corregido
        }

        [Test]
        public void EliminarUsuario_ConUsuarioNoExistente_DeberiaRetornarMensajeError()
        {
            fachada.CrearAdministrador("A1", "Admin Base"); // necesita admin
            string id = "U100";

            string resultado = fachada.EliminarUsuario(id, "A1");

            Assert.IsTrue(resultado.Contains("No se encontró"));
        }
        
        [Test]
        public void CrearNuevoCliente_ConDatosValidos_DeberiaCrearCliente()
        {
            string id = "1";
            string nombre = "Pepe";
            string apellido = "Gómez";
            string telefono = "099123456";
            string correo = "pepe@correo.com";

            Cliente resultado = fachada.CrearNuevoCliente(id, nombre, apellido, telefono, correo);

            Assert.IsNotNull(resultado);
            Assert.That(resultado.Id, Is.EqualTo(id));
            Assert.That(resultado.Nombre, Is.EqualTo(nombre));
            Assert.That(resultado.Apellido, Is.EqualTo(apellido));
            Assert.That(resultado.Telefono, Is.EqualTo(telefono));
            Assert.That(resultado.Correo, Is.EqualTo(correo));
        }
        
        [Test]
        public void BuscarClientesFachada_PorNombre_DeberiaEncontrarClientes()
        {
            fachada.CrearNuevoCliente("1","Pepe", "Gómez", "099123456", "pepe@correo.com");
            fachada.CrearNuevoCliente("2","Pepe", "Díaz",  "099654321", "pepe2@correo.com");

            var resultado = fachada.BuscarClientesFachada("nombre", "Pepe");

            // Si esta aserción falla por acumulación, añadí un Clear() en RepoClientes.
            Assert.That(resultado.Count, Is.GreaterThanOrEqualTo(2));
        }

        [Test]
        public void BuscarClientesFachada_PorCorreo_DeberiaEncontrarUnCliente()
        {
            fachada.CrearNuevoCliente("1","Pepe", "Gómez", "099123456", "pepe@correo.com");

            var resultado = fachada.BuscarClientesFachada("correo", "pepe@correo.com");

            Assert.That(1, Is.EqualTo(resultado.Count));
            Assert.That("pepe@correo.com", Is.EqualTo(resultado[0].Correo));
        }
        
        [Test]
        public void ModificarInfo_CambiarNombre_DeberiaActualizarNombre()
        {
            fachada.CrearNuevoCliente("1","Pepe", "Gómez", "099123456", "pepe@correo.com");
            var clientes = fachada.BuscarClientesFachada("correo", "pepe@correo.com");
            string clienteId = clientes[0].Id;
            string nuevoNombre = "Carlos";

            fachada.ModificarInfo(clienteId, "nombre", nuevoNombre);

            var clienteModificado = fachada.BuscarClientesFachada("id", clienteId)[0];
            Assert.That(clienteModificado.Nombre, Is.EqualTo(nuevoNombre));
        }

        [Test]
        public void ModificarInfo_CambiarTelefono_DeberiaActualizarTelefono()
        {
            fachada.CrearNuevoCliente("1","Roberto", "Gómez", "099123456", "roberto@example.com");
            var clientes = fachada.BuscarClientesFachada("correo", "roberto@example.com");
            string clienteId = clientes[0].Id;
            string nuevoTelefono = "098765432";

            fachada.ModificarInfo(clienteId, "telefono", nuevoTelefono);

            var clienteModificado = fachada.BuscarClientesFachada("id", clienteId)[0];
            Assert.That(clienteModificado.Telefono, Is.EqualTo(nuevoTelefono));
        }
        
        [Test]
        public void EliminarClienteFachada_ConClienteExistente_DeberiaEliminar()
        {
            fachada.CrearNuevoCliente("1","Pepe", "Gómez", "099123456", "pepe@correo.com");
            var clientes = fachada.BuscarClientesFachada("correo", "pepe@correo.com");
            string clienteId = clientes[0].Id;

            fachada.EliminarClienteFachada(clienteId);

            var resultado = fachada.BuscarClientesFachada("id", clienteId);
            Assert.That(resultado.Count, Is.EqualTo(0));
        }
        
        [Test]
        public void BuscarUsuario_ConUsuarioExistente_DeberiaRetornarUsuario()
        {
            fachada.CrearAdministrador("A1", "Admin Base"); // necesita admin
            string id = "U1";
            string nombre = "Pepe Usuario";
            fachada.CrearUsuario(id, nombre, "A1");

            Usuario resultado = fachada.BuscarUsuario(id);

            Assert.IsNotNull(resultado);
            Assert.That(resultado.ID, Is.EqualTo(id));
            Assert.That(resultado.Nombre, Is.EqualTo(nombre));
        }

        [Test]
        public void BuscarUsuario_ConUsuarioNoExistente_DeberiaRetornarNull()
        {
            string id = "U1000";
            Usuario resultado = fachada.BuscarUsuario(id);
            Assert.IsNull(resultado);
        }
    }
}
