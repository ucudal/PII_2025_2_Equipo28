using NUnit.Framework;
using System;

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
            
            fachada.Usuarios.EliminarDatos();
            fachada.UsuariosSuspendidos.Clear();
            
            fachada.Clientes = new RepoClientes(fachada.Etiquetas, fachada.Usuarios);
            fachada.Interacciones = new RepoInteracciones();
            fachada.Ventas = new RepoVentas();
            fachada.Cotizaciones = new RepoCotizaciones();
        }
        
        [Test]
        public void CrearAdministrador_ConDatosValidos_DeberiaCrearAdministrador()
        {
            string id = "A1";     
            string nombre = "Juan Admin";

            string resultado = fachada.CrearAdministrador(id, nombre);

            Assert.That(resultado.Contains("creado correctamente"));
        }

        [Test]
        public void CrearAdministrador_ConIdNulo_DeberiaRetornarMensajeError()
        {
            string id = null;
            string nombre = "Juan Admin";
            
            string resultado = fachada.CrearAdministrador(id, nombre);
            
            Assert.That(resultado, Does.Contain("El ID no puede estar vacío."));
        }

        [Test]
        public void CrearAdministrador_ConNombreNulo_DeberiaRetornarMensajeError()
        {
            string id = "A1";
            string nombre = null;
            
            string resultado = fachada.CrearAdministrador(id, nombre);
            
            Assert.That(resultado, Does.Contain("El nombre no puede estar vacío."));
        }

        [Test]
        public void CrearAdministrador_ConIdVacio_DeberiaRetornarMensajeError()
        {
            string id = "";
            string nombre = "Juan Admin";
            
            string resultado = fachada.CrearAdministrador(id, nombre);
            
            Assert.That(resultado, Does.Contain("El ID no puede estar vacío."));
        }

        [Test]
        public void CrearAdministrador_ConIdDuplicado_DeberiaRetornarMensajeError()
        {
            string id = "B1";
            string nombre1 = "Juan Admin";
            string nombre2 = "Pepe Admin";
            fachada.CrearAdministrador(id, nombre1);
            
            string resultado = fachada.CrearAdministrador(id, nombre2);
            
            Assert.That(resultado, Does.Contain("Ya existe un administrador"));
        }
        
        [Test]
        public void CrearUsuario_ConDatosValidos_DeberiaRetornarMensajeExito()
        {
            fachada.CrearAdministrador("A1", "Admin Base"); 
            string id = "G1";
            string nombre = "Pepe Usuario";

            string resultado = fachada.CrearUsuario(id, nombre, "A1");

            Assert.IsTrue(resultado.Contains("creado correctamente"));
            Assert.IsNotNull(fachada.BuscarUsuario(id));
        }

        [Test]
        public void CrearUsuario_ConIdDuplicado_DeberiaRetornarMensajeError()
        {
            fachada.CrearAdministrador("A1", "Admin Base"); 
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
            fachada.CrearAdministrador("A1", "Admin Base"); 
            string id = "U1";
            string nombre = "Pepe Usuario";
            fachada.CrearUsuario(id, nombre, "A1");

            string resultado = fachada.SuspenderUsuario(id, "A1");

            Assert.IsTrue(resultado.Contains("suspendido correctamente"));
            Assert.IsNull(fachada.BuscarUsuario(id));
            Assert.That(fachada.UsuariosSuspendidos.Count, Is.EqualTo(1)); 
        }
        
        [Test]
        public void EliminarUsuario_ConUsuarioActivo_DeberiaEliminarCorrectamente()
        {
            fachada.CrearAdministrador("A1", "Admin Base"); 
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
            fachada.CrearAdministrador("A1", "Admin Base"); 
            string id = "U1";
            string nombre = "Pepe Usuario";
            fachada.CrearUsuario(id, nombre, "A1");
            fachada.SuspenderUsuario(id, "A1");

            string resultado = fachada.EliminarUsuario(id, "A1");

            Assert.IsTrue(resultado.Contains("eliminado del sistema"));
            Assert.That(fachada.UsuariosSuspendidos.Count, Is.EqualTo(0)); 
        }

        [Test]
        public void EliminarUsuario_ConUsuarioNoExistente_DeberiaRetornarMensajeError()
        {
            fachada.CrearAdministrador("A1", "Admin Base"); 
            string id = "U100";

            string resultado = fachada.EliminarUsuario(id, "A1");

            Assert.IsTrue(resultado.Contains("No se encontró"));
        }
        
        [Test]
        public void CrearCliente_ConDatosValidos_DeberiaCrearCliente()
        {
            string id = "1";
            string nombre = "Pepe";
            string apellido = "Gómez";
            string telefono = "099123456";
            string correo = "pepe@correo.com";

            string resultado = fachada.CrearCliente(id, nombre, apellido, telefono, correo);
            Cliente cliente = fachada.BuscarCliente("id", "1")[0];

            Assert.IsNotNull(cliente);
            Assert.That(cliente.Id, Is.EqualTo(id));
            Assert.That(cliente.Nombre, Is.EqualTo(nombre));
            Assert.That(cliente.Apellido, Is.EqualTo(apellido));
            Assert.That(cliente.Telefono, Is.EqualTo(telefono));
            Assert.That(cliente.Correo, Is.EqualTo(correo));
        }
        
        [Test]
        public void BuscarClientesFachada_PorNombre_DeberiaEncontrarClientes()
        {
            fachada.CrearCliente("1","Pepe", "Gómez", "099123456", "pepe@correo.com");
            fachada.CrearCliente("2","Pepe", "Díaz",  "099654321", "pepe2@correo.com");

            var cliente = fachada.BuscarCliente("nombre", "Pepe");
                
            Assert.That(cliente.Count, Is.EqualTo(2));
        }
        
        [Test]
        public void ModificarInfo_CambiarNombre_DeberiaActualizarNombre()
        {
            fachada.CrearCliente("1","Pepe", "Gómez", "099123456", "pepe@correo.com");
            var clientes = fachada.BuscarCliente("correo", "pepe@correo.com");
            string clienteId = clientes[0].Id;
            string nuevoNombre = "Carlos";

            fachada.ModificarInfo(clienteId, "nombre", nuevoNombre);

            var clienteModificado = fachada.BuscarCliente("id", clienteId)[0];
            Assert.That(clienteModificado.Nombre, Is.EqualTo(nuevoNombre));
        }

        [Test]
        public void ModificarInfo_CambiarTelefono_DeberiaActualizarTelefono()
        {
            fachada.CrearCliente("1","Roberto", "Gómez", "099123456", "roberto@example.com");
            var clientes = fachada.BuscarCliente("correo", "roberto@example.com");
            string clienteId = clientes[0].Id;
            string nuevoTelefono = "098765432";

            fachada.ModificarInfo(clienteId, "telefono", nuevoTelefono);

            var clienteModificado = fachada.BuscarCliente("id", clienteId)[0];
            Assert.That(clienteModificado.Telefono, Is.EqualTo(nuevoTelefono));
        }
        
        [Test]
        public void EliminarClienteFachada_ConClienteExistente_DeberiaEliminar()
        {
            fachada.CrearCliente("1","Pepe", "Gómez", "099123456", "pepe@correo.com");
            var clientes = fachada.BuscarCliente("correo", "pepe@correo.com");
            string clienteId = clientes[0].Id;

            fachada.EliminarCliente(clienteId);

            var resultado = fachada.BuscarCliente("id", clienteId);
            Assert.That(resultado.Count, Is.EqualTo(0));
        }
        
        [Test]
        public void BuscarUsuario_ConUsuarioExistente_DeberiaRetornarUsuario()
        {
            fachada.CrearAdministrador("A1", "Admin Base"); 
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
        
        [Test]
        public void AgregarClienteContacto_ConDatosValidos_DeberiaAgregarCliente()
        {
            fachada.CrearAdministrador("A1", "Admin Base");
            string idUsuario = "U1";
            fachada.CrearUsuario(idUsuario, "Pepe Usuario", "A1");
            
            string idCliente = "C1";
            fachada.CrearCliente(idCliente, "Juan", "Perez", "099111222", "juan@correo.com");

            string resultado = fachada.AgregarClienteContacto(idUsuario, idCliente);

            Assert.That(resultado, Is.EqualTo("cliente agregado"));
            
            string contactos = fachada.VerClienteContacto(idUsuario);
            Assert.IsTrue(contactos.Contains("Juan Perez"));
        }

        [Test]
        public void AgregarClienteContacto_ClienteYaExistente_DeberiaNoDuplicarOManjarlo()
        {
            fachada.CrearAdministrador("A1", "Admin Base");
            string idUsuario = "U1";
            fachada.CrearUsuario(idUsuario, "Pepe Usuario", "A1");
            
            string idCliente = "C1";
            fachada.CrearCliente(idCliente, "Juan", "Perez", "099111222", "juan@correo.com");

            fachada.AgregarClienteContacto(idUsuario, idCliente);
            string resultado = fachada.AgregarClienteContacto(idUsuario, idCliente);
            
            Assert.That(resultado, Is.EqualTo("cliente agregado"));
        }

        [Test]
        public void VerClienteContacto_ConDatos_DeberiaRetornarLista()
        {
            fachada.CrearAdministrador("A1", "Admin Base");
            string idUsuario = "U1";
            fachada.CrearUsuario(idUsuario, "Pepe Usuario", "A1");
            
            string idCliente = "C1";
            fachada.CrearCliente(idCliente, "Juan", "Perez", "099111222", "juan@correo.com");
            fachada.AgregarClienteContacto(idUsuario, idCliente);

            string resultado = fachada.VerClienteContacto(idUsuario);

            Assert.IsTrue(resultado.Contains("Juan Perez"));
        }

        [Test]
        public void EliminarClienteContacto_ConDatosValidos_DeberiaEliminar()
        {
            fachada.CrearAdministrador("A1", "Admin Base");
            string idUsuario = "U1";
            fachada.CrearUsuario(idUsuario, "Pepe Usuario", "A1");
            
            string idCliente = "C1";
            fachada.CrearCliente(idCliente, "Juan", "Perez", "099111222", "juan@correo.com");
            fachada.AgregarClienteContacto(idUsuario, idCliente);

            string resultado = fachada.EliminarClienteContacto(idUsuario, idCliente);

            Assert.That(resultado, Is.EqualTo("cliente eliminado de la lista"));
            string contactos = fachada.VerClienteContacto(idUsuario);
            Assert.IsFalse(contactos.Contains("Juan Perez"));
        }

        [Test]
        public void CrearEtiqueta_ConDatosValidos_DeberiaCrearEtiqueta()
        {
            fachada.CrearAdministrador("A1", "Admin Base");
            string idUsuario = "U1";
            fachada.CrearUsuario(idUsuario, "Pepe Usuario", "A1");

            string resultado = fachada.CrearEtiqueta("Importante", idUsuario);

            Assert.That(resultado, Is.EqualTo("Etiqueta creada correctamente."));
            Assert.IsTrue(fachada.Etiquetas.BuscarEtiqueta("Importante"));
        }

        [Test]
        public void CrearEtiqueta_UsuarioNoExistente_DeberiaRetornarError()
        {
            string resultado = fachada.CrearEtiqueta("Importante", "U_NO_EXISTE");
            Assert.That(resultado, Is.EqualTo("Solo Usuarios pueden crear Etiquetas."));
        }

        [Test]
        public void AgregarEtiquetaCliente_ConDatosValidos_DeberiaAgregarEtiqueta()
        {
            fachada.CrearAdministrador("A1", "Admin Base");
            string idUsuario = "U1";
            fachada.CrearUsuario(idUsuario, "Pepe Usuario", "A1");
            
            string idCliente = "C1";
            fachada.CrearCliente(idCliente, "Juan", "Perez", "099111222", "juan@correo.com");
            
            fachada.CrearEtiqueta("VIP", idUsuario);

            string resultado = fachada.AgregarEtiquetaCliente(idCliente, "VIP", idUsuario);

            Assert.That(resultado, Is.EqualTo("Etiqueta agregada"));
            var cliente = fachada.BuscarCliente("id", idCliente)[0];
            Assert.IsTrue(cliente.Etiquetas.Contains("VIP"));
        }

        [Test]
        public void AgregarEtiquetaCliente_UsuarioNoAutorizado_DeberiaRetornarError()
        {
             string idCliente = "C1";
            fachada.CrearCliente(idCliente, "Juan", "Perez", "099111222", "juan@correo.com");
            
            string resultado = fachada.AgregarEtiquetaCliente(idCliente, "VIP", "U_NO_EXISTE");

            Assert.That(resultado, Is.EqualTo("Solo Usuarios pueden agregar etiquetas a los clientes"));
        }

        [Test]
        public void VerClientes_ConClientes_DeberiaRetornarListaString()
        {
            fachada.CrearCliente("C1", "Juan", "Perez", "099111222", "juan@correo.com");
            fachada.CrearCliente("C2", "Maria", "Lopez", "099333444", "maria@correo.com");

            string resultado = fachada.VerClientes();

            Assert.IsTrue(resultado.Contains("Juan"));
            Assert.IsTrue(resultado.Contains("Maria"));
        }

        [Test]
        public void ModificarInfo_AgregarEtiqueta_DeberiaAgregarEtiqueta()
        {
            fachada.CrearCliente("C1", "Juan", "Perez", "099111222", "juan@correo.com");
            
            string resultado = fachada.ModificarInfo("C1", "etiqueta", "VIP");

            Assert.IsTrue(resultado.Contains("Se modificó la información")); 
            
            var cliente = fachada.BuscarCliente("id", "C1")[0];
            Assert.IsTrue(cliente.Etiquetas.Contains("VIP"));
        }

        [Test]
        public void Cliente_ToString_DeberiaRetornarFormatoCorrecto()
        {
            fachada.CrearCliente("C1", "Juan", "Perez", "099111222", "juan@correo.com");
            var cliente = fachada.BuscarCliente("id", "C1")[0];

            string resultado = cliente.ToString();

            Assert.That(resultado, Is.EqualTo("Juan Perez (juan@correo.com) - Id: C1"));
        }

        [Test]
        public void Usuario_Recordatorio_DeberiaImprimirEnConsola()
        {
            fachada.CrearAdministrador("A1", "Admin");
            fachada.CrearUsuario("U1", "User", "A1");
            Usuario usuario = fachada.BuscarUsuario("U1");
            
            Assert.DoesNotThrow(() => usuario.Recordatorio("Reunion", "01/01/2025"));
        }

        [Test]
        public void Usuario_ToString_DeberiaRetornarFormatoCorrecto()
        {
            fachada.CrearAdministrador("A1", "Admin");
            fachada.CrearUsuario("U1", "User", "A1");
            Usuario usuario = fachada.BuscarUsuario("U1");

            string resultado = usuario.ToString();

            Assert.That(resultado, Is.EqualTo("User - Id: U1"));
        }
    }
}
