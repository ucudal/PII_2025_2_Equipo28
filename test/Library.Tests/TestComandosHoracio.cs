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
            fachada.ClientesContacta.ElminarDatos();
            //fachada.CrearAdministrador("A1", "Juan Admin");
            //fachada.CrearUsuario("U1", "Pepe Usuario", "A1");
        }

        [Test]
        public void Comando_nuevoCliente()
        {
            string resultado = fachada.CrearCliente("C1", "Juan", "Perez", "099123456", "juan@correo.com");
            Cliente busquedaCliente = fachada.BuscarCliente("Id", "C1")[0];
            string verClientes = fachada.VerClientes();
            Assert.That(verClientes.Contains(busquedaCliente.ToString()));
        }

        [Test]
        public void Comando_modfInfo()
        {
            fachada.CrearCliente("C1", "Juan", "Perez", "099123456", "juan@correo.com");
            fachada.ModificarInfo("C1", "nombre", "Carlos");
            Assert.That(fachada.VerClientes().Contains("Carlos"));
        }

        [Test]
        public void Comando_eliminarCliente()
        {
            fachada.CrearCliente("C1", "Juan", "Perez", "099123456", "juan@correo.com");
            Assert.That(fachada.VerClientes().Contains("Juan"));
            fachada.EliminarCliente("C1");
            Assert.That(fachada.VerClientes().Contains("Juan"), Is.False);
        }

        [Test]
        public void Comando_buscarCliente()
        {
            fachada.CrearCliente("C1", "Juan", "Perez", "099123456", "juan@correo.com");
            string resultado = fachada.BuscarCliente("nombre", "Juan")[0].ToString();
            Assert.That(fachada.VerClientes().Contains(resultado));
        }

        [Test]
        public void Comando_verClientes()
        {
            fachada.CrearCliente("C1", "Juan", "Perez", "099123456", "juan@correo.com");
            fachada.CrearCliente("C2", "Maria", "Gomez", "099654321", "maria@correo.com");
            
            string juan = fachada.BuscarCliente("nombre", "Juan")[0].ToString();
            string maria = fachada.BuscarCliente("nombre", "Juan")[0].ToString();

            Assert.That(fachada.VerClientes().Contains(juan));
            Assert.That(fachada.VerClientes().Contains(maria));
        }

        [Test]
        public void Comando_crearEtiqueta()
        {
            fachada.CrearAdministrador("A1", "Pepe");
            fachada.CrearUsuario("U1", "Franco", "A1");
            fachada.CrearEtiqueta("etiquetaDePrueba", "U1");
            Assert.That(fachada.VerEtiquetas().Contains("etiquetaDePrueba"));
        }
        
        [Test]
        public void Comando_agregarEtiqueta()
        {
            fachada.CrearAdministrador("A32", "Liliana");
            fachada.CrearCliente("C6", "Edmundo", "Gutierrez", "0982827315", "edmundoguti@correo.com");
            fachada.CrearUsuario("U1", "Alejando", "A32");
            fachada.CrearEtiqueta("etiquetaDePrueba", "U1");
            Assert.That(fachada.VerEtiquetas().Contains("etiquetaDePrueba"));
            fachada.AgregarEtiquetaCliente("C6", "etiquetaDePrueba", "U1");
            Assert.That(fachada.VerClientes().Contains("Etiquetas: etiquetaDePrueba,"));
        }

        [Test]
        public void Comando_crearUsuario()
        {
            fachada.CrearAdministrador("A1", "Pepe");
            fachada.CrearUsuario("U1", "Ezequiel", "A1");
            Assert.That(fachada.VerUsuarios().Contains("Ezequiel"));
        }

        [Test]
        public void Comando_eliminarUsuario()
        {
            fachada.CrearAdministrador("A1", "Andres");
            fachada.CrearUsuario("U2", "Peter", "A1");
            Assert.That(fachada.VerUsuarios().Contains("Peter - Id: U2"));
            fachada.EliminarUsuario("U2", "A1");
            Assert.That(fachada.VerUsuarios().Contains("Peter - Id: U2"), Is.False);
        }

        [Test]
        public void Comando_suspenderUsuario()
        {
            fachada.CrearAdministrador("A3", "Juan");
            fachada.CrearUsuario("U3", "Nahuel", "A3");
            fachada.SuspenderUsuario("U3", "A3");
            Assert.That(fachada.VerUsuarios().Contains("Usuarios suspendidos"));
            Assert.That(fachada.VerUsuarios().Contains("Nahuel"));
        }

        [Test]
        public void Comando_crearAdministrador()
        {
            fachada.CrearAdministrador("A1", "Pepe");
            Assert.That(fachada.VerAdministradores().Contains("Pepe - Id: A1"));
        }

        [Test]
        public void Comando_verEtiquetas()
        {
            fachada.CrearAdministrador("A30", "Aureliano");
            fachada.CrearUsuario("U12", "Guillermo", "A30");
            fachada.CrearEtiqueta("etiquetaDePrueba", "U12");
            Assert.That(fachada.VerEtiquetas().Contains("etiquetaDePrueba"));
        }

        [Test]
        public void Comando_verAdministradores()
        {
            fachada.CrearAdministrador("A39", "Wario");
            Assert.That(fachada.VerAdministradores().Contains("Wario - Id: A39"));
        }
    }
}