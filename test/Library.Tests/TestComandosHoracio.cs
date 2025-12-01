using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using NUnit.Framework;

namespace Library.Tests
{
    public class TestComandosHoracio
    {
        private Fachada fachada;

        [SetUp]
        public void Setup()
        {
            fachada = Fachada.Instancia;
            fachada.UsuariosSuspendidos.Clear();
            fachada.Usuarios.EliminarDatos();
            fachada.Cotizaciones.EliminarDatos();
            fachada.Interacciones.EliminarDatos();
            fachada.Etiquetas.EliminarDatos();
            fachada.Clientes.EliminarDatos();
            fachada.ClientesContacto.Clear();
            fachada.CrearAdministrador("A1", "Juan Admin");
            fachada.CrearUsuario("U1", "Pepe Usuario", "A1");
        }

        [Test]
        public void Comando_nuevoCliente()
        {
            string resultado = fachada.CrearCliente("C1", "Juan", "Perez", "099123456", "juan@correo.com");
            Assert.That(resultado, Does.Contain("creado correctamente"));
            Assert.IsNotNull(fachada.BuscarCliente("id", "C1"));
        }

        [Test]
        public void Comando_modfInfo()
        {
            fachada.CrearCliente("C1", "Juan", "Perez", "099123456", "juan@correo.com");
            string resultado = fachada.ModificarInfo("C1", "nombre", "Carlos");
            Assert.That(resultado, Does.Contain("Se modificó la información"));
            var cliente = fachada.BuscarCliente("id", "C1")[0];
            Assert.That(cliente.Nombre, Is.EqualTo("Carlos"));
        }

        [Test]
        public void Comando_eliminarCliente()
        {
            fachada.CrearCliente("C1", "Juan", "Perez", "099123456", "juan@correo.com");
            string resultado = fachada.EliminarCliente("C1");
            Assert.That(resultado, Does.Contain("Se eliminó el cliente"));
            Assert.That(fachada.BuscarCliente("id", "C1").Count, Is.EqualTo(0));
        }

        [Test]
        public void Comando_buscarCliente()
        {
            fachada.CrearCliente("C1", "Juan", "Perez", "099123456", "juan@correo.com");
            var resultado = fachada.BuscarCliente("nombre", "Juan");
            Assert.That(resultado.Count, Is.EqualTo(1));
            Assert.That(resultado[0].Id, Is.EqualTo("C1"));
        }

        [Test]
        public void Comando_verClientes()
        {
            fachada.CrearCliente("C1", "Juan", "Perez", "099123456", "juan@correo.com");
            fachada.CrearCliente("C2", "Maria", "Gomez", "099654321", "maria@correo.com");
            string resultado = fachada.VerClientes();
            Assert.That(resultado, Does.Contain("Juan"));
            Assert.That(resultado, Does.Contain("Maria"));
        }

        [Test]
        public void Comando_crearEtiqueta()
        {
            string resultado = fachada.CrearEtiqueta("Comun", "U1");
            Assert.That(resultado, Does.Contain("Etiqueta creada correctamente"));
            Assert.IsTrue(fachada.Etiquetas.BuscarEtiqueta("Comun"));
        }

        [Test]
        public void Comando_agregarEtiqueta()
        {
            fachada.CrearCliente("C1", "Juan", "Perez", "099123456", "juan@correo.com");
            fachada.CrearEtiqueta("VIP", "U1");
            string resultado = fachada.AgregarEtiquetaCliente("C1", "VIP", "U1");
            Assert.That(resultado, Is.EqualTo("Etiqueta agregada"));
            var cliente = fachada.BuscarCliente("id", "C1")[0];
            Assert.IsTrue(cliente.Etiquetas.Contains("VIP"));
        }

        [Test]
        public void Comando_crearUsuario()
        {
            string resultado = fachada.CrearUsuario("U2", "Roberto", "A1");
            Assert.That(resultado, Does.Contain("creado correctamente"));
            Assert.IsNotNull(fachada.BuscarUsuario("U2"));
        }

        [Test]
        public void Comando_eliminarUsuario()
        {
            fachada.CrearUsuario("U2", "Roberto", "A1");
            string resultado = fachada.EliminarUsuario("U2", "A1");
            Assert.That(resultado, Does.Contain("eliminado del sistema"));
            Assert.IsNull(fachada.BuscarUsuario("U2"));
        }

        [Test]
        public void Comando_suspenderUsuario()
        {
            fachada.CrearUsuario("U2", "Roberto", "A1");
            string resultado = fachada.SuspenderUsuario("U2", "A1");
            Assert.That(resultado, Does.Contain("suspendido correctamente"));
            Assert.IsNull(fachada.BuscarUsuario("U2"));
        }
    }
}