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
            
            fachada.Etiquetas = new RepoEtiquetas();
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
            fachada.CrearCliente("1", "Pepe", "Gómez", "099123456", "pepe@correo.com");
            fachada.CrearCliente("2", "Pepe", "Díaz", "099654321", "pepe2@correo.com");

            var cliente = fachada.BuscarCliente("nombre", "Pepe");

            Assert.That(cliente.Count, Is.EqualTo(2));
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
        public void EliminarCliente_ClienteNoExiste_DeberiaRetornarMensajeError()
        {
            string resultado = fachada.EliminarCliente("ClienteInexistente99");
            
            Assert.That(resultado, Does.Contain("El cliente no se encuentra en la lista."));
        }

        [Test]
        public void EliminarCliente_ClienteYaEliminado_DeberiaRetornarMensajeError()
        {
            fachada.CrearCliente("C1", "Pedro", "Martinez", "099777888", "pedro@correo.com");
            
            fachada.EliminarCliente("C1");
            string resultadoSegundaEliminacion = fachada.EliminarCliente("C1");
            
            Assert.That(resultadoSegundaEliminacion, Does.Contain("El cliente no se encuentra en la lista."));
        }

        [Test]
        public void EliminarCliente_VerificarMensajeExito_DeberiaContenerInfoCliente()
        {
            fachada.CrearCliente("C1", "Ana", "Ruiz", "099444555", "ana@correo.com");
            
            string resultado = fachada.EliminarCliente("C1");
            
            Assert.That(resultado, Does.Contain("Se eliminó el cliente"));
            Assert.That(resultado, Does.Contain("Ana Ruiz"));
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
            Assert.That(resultado, Is.EqualTo("No existe el Usuario"));
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
        public void CrearEtiqueta_EtiquetaVacia_DeberiaRetornarMensajeError()
        {
            fachada.CrearAdministrador("A1", "Admin Base");
            string idUsuario = "U1";
            fachada.CrearUsuario(idUsuario, "Pepe Usuario", "A1");

            string resultado = fachada.CrearEtiqueta("", idUsuario);
            
            Assert.That(resultado, Does.Contain("no puede ser null o vacia"));
        }

        [Test]
        public void CrearEtiqueta_EtiquetaConEspacios_DeberiaCrearCorrectamente()
        {
            fachada.CrearAdministrador("A1", "Admin Base");
            string idUsuario = "U1";
            fachada.CrearUsuario(idUsuario, "Pepe Usuario", "A1");

            string resultado = fachada.CrearEtiqueta("  Cliente VIP  ", idUsuario);
            
            Assert.That(resultado, Is.EqualTo("Etiqueta creada correctamente."));
            Assert.IsTrue(fachada.Etiquetas.BuscarEtiqueta("Cliente VIP"));
        }

        [Test]
        public void CrearEtiqueta_VariasEtiquetas_DeberianCrearseCorrectamente()
        {
            fachada.CrearAdministrador("A1", "Admin Base");
            string idUsuario = "U1";
            fachada.CrearUsuario(idUsuario, "Pepe Usuario", "A1");

            fachada.CrearEtiqueta("Premium", idUsuario);
            fachada.CrearEtiqueta("VIP", idUsuario);
            fachada.CrearEtiqueta("Standard", idUsuario);
            
            Assert.IsTrue(fachada.Etiquetas.BuscarEtiqueta("Premium"));
            Assert.IsTrue(fachada.Etiquetas.BuscarEtiqueta("VIP"));
            Assert.IsTrue(fachada.Etiquetas.BuscarEtiqueta("Standard"));
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

        [TestCase("nombre", "Carlos")]
        [TestCase("apellido", "Rodríguez")]
        [TestCase("telefono", "098765432")]
        [TestCase("correo", "nuevo@email.com")]
        [TestCase("genero", "M")]
        [TestCase("fechadenacimiento", "15/05/1990")]
        public void ModificarInfo_CambiarAtributo_DeberiaActualizarCorrectamente(string atributo, string nuevoValor)
        {
            // Arrange - Crear cliente
            fachada.CrearCliente("C1", "Pepe", "Gómez", "099123456", "pepe@correo.com");
            
            // Act - Modificar el atributo
            string resultado = fachada.ModificarInfo("C1", atributo, nuevoValor);
            
            // Assert - Verificar que el resultado contiene el mensaje de éxito
            Assert.That(resultado, Does.Contain("Se modificó la información"));
            Assert.That(resultado, Does.Contain(nuevoValor));
            
            // Verificar que el valor realmente cambió
            var cliente = fachada.BuscarCliente("id", "C1")[0];
            
            switch (atributo.ToLower())
            {
                case "nombre":
                    Assert.That(cliente.Nombre, Is.EqualTo(nuevoValor));
                    break;
                case "apellido":
                    Assert.That(cliente.Apellido, Is.EqualTo(nuevoValor));
                    break;
                case "telefono":
                    Assert.That(cliente.Telefono, Is.EqualTo(nuevoValor));
                    break;
                case "correo":
                    Assert.That(cliente.Correo, Is.EqualTo(nuevoValor));
                    break;
                case "genero":
                    Assert.That(cliente.Genero, Is.EqualTo(nuevoValor));
                    break;
                case "fechadenacimiento":
                    Assert.That(cliente.FechaDeNacimiento, Is.EqualTo(nuevoValor));
                    break;
            }
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
        
        [TestCase("apellido", "Gómez")]
        [TestCase("telefono", "099123456")]
        [TestCase("correo", "pepe@correo.com")]
        public void BuscarCliente_PorDiferentesAtributos_DeberiaEncontrarCliente(string atributo, string valor)
        {
            fachada.CrearCliente("C1", "Pepe", "Gómez", "099123456", "pepe@correo.com");
            
            var resultado = fachada.BuscarCliente(atributo, valor);
            
            Assert.That(resultado.Count, Is.EqualTo(1));
            Assert.That(resultado[0].Id, Is.EqualTo("C1"));
        }

        [Test]
        public void BuscarCliente_PorGenero_DeberiaEncontrarClientes()
        {
            fachada.CrearCliente("C1", "Juan", "Perez", "099111222", "juan@correo.com");
            fachada.CrearCliente("C2", "Maria", "Lopez", "099333444", "maria@correo.com");
            
            fachada.ModificarInfo("C1", "genero", "M");
            fachada.ModificarInfo("C2", "genero", "F");
            
            var resultadoMasculino = fachada.BuscarCliente("genero", "M");
            var resultadoFemenino = fachada.BuscarCliente("genero", "F");
            
            Assert.That(resultadoMasculino.Count, Is.EqualTo(1));
            Assert.That(resultadoFemenino.Count, Is.EqualTo(1));
            Assert.That(resultadoMasculino[0].Id, Is.EqualTo("C1"));
            Assert.That(resultadoFemenino[0].Id, Is.EqualTo("C2"));
        }

        [Test]
        public void BuscarCliente_PorFechaDeNacimiento_DeberiaEncontrarCliente()
        {
            fachada.CrearCliente("C1", "Pedro", "Martinez", "099555666", "pedro@correo.com");
            fachada.ModificarInfo("C1", "fechadenacimiento", "20/03/1985");
            
            var resultado = fachada.BuscarCliente("fechadenacimiento", "20/03/1985");
            
            Assert.That(resultado.Count, Is.EqualTo(1));
            Assert.That(resultado[0].Id, Is.EqualTo("C1"));
        }

        [Test]
        public void BuscarCliente_ClienteNoExiste_DeberiaRetornarListaVacia()
        {
            var resultado = fachada.BuscarCliente("id", "ClienteInexistente");
            
            Assert.That(resultado.Count, Is.EqualTo(0));
        }

        [Test]
        public void BuscarCliente_VariosClientesConMismoNombre_DeberiaRetornarTodos()
        {
            fachada.CrearCliente("C1", "Carlos", "Perez", "099111111", "carlos1@correo.com");
            fachada.CrearCliente("C2", "Carlos", "Gomez", "099222222", "carlos2@correo.com");
            fachada.CrearCliente("C3", "Carlos", "Lopez", "099333333", "carlos3@correo.com");
            
            var resultado = fachada.BuscarCliente("nombre", "Carlos");
            
            Assert.That(resultado.Count, Is.EqualTo(3));
        }
    }
}
