/* using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Library;

namespace Library.Tests
{
    [TestFixture]
    public class RepoClientesTest
    {
        private Fachada fachada;
        private RepoClientes clientes;
        private Cliente cliente1;
        private Cliente cliente2;

        [SetUp]
        public void Setup()
        {
            fachada = Fachada.Instancia;
            clientes = new RepoClientes(fachada.Etiquetas, fachada.Usuarios);
            cliente1 = new Cliente("C1","Juan", "Pérez", "099123456", "juan@example.com");
            cliente2 = new Cliente("C1","María", "García", "098765432", "maria@example.com");
        }

        [Test]
        public void InicializarListaVacia()
        {
            Assert.That(clientes.Clientes, Is.Empty);
        }

        [Test]
        public void AgregarClienteALaLista()
        {
            clientes.AgregaCliente(cliente1);
            Assert.That(clientes.Clientes.Count(), Is.EqualTo(1));
            Assert.That(clientes.Clientes.ElementAt(0), Is.EqualTo(cliente1));
        }

        [Test]
        public void NoDeberiaAgregarNada()
        {
            clientes.AgregaCliente(null);
            Assert.That(clientes.Clientes, Is.Empty);
        }

        [Test]
        public void EliminarClienteExistente()
        {
            clientes.AgregaCliente(cliente1);
            clientes.EliminarCliente(cliente1);
            Assert.That(clientes.Clientes, Is.Empty);
        }

        [Test]
        public void EliminarClienteNoExistenteNoDeberiaEliminarNada()
        {
            clientes.AgregaCliente(cliente1);
            clientes.EliminarCliente(cliente2);
            Assert.That(clientes.Clientes.Count, Is.EqualTo(1));
        }

        [Test]
        public void BuscarClientePorNombreDeberiaRetornarCoincidencias()
        {
            clientes.AgregaCliente(cliente1);
            clientes.AgregaCliente(cliente2);

            var resultados = clientes.BuscarCliente("nombre", "Juan");

            Assert.That(resultados.Count, Is.EqualTo(1));
            Assert.That(resultados[0].Nombre, Is.EqualTo("Juan"));
        }

        [Test]
        public void BuscarCliente_PorCorreo_DeberiaRetornarCoincidencias()
        {
            clientes.AgregaCliente(cliente1);
            var resultados = clientes.BuscarCliente("correo", "juan@example.com");

            Assert.That(resultados.Count, Is.EqualTo(1));
            Assert.That(resultados[0], Is.EqualTo(cliente1));
        }

        [Test]
        public void BuscarCliente_AtributoInvalido_DeberiaRetornarListaVacia()
        {
            clientes.AgregaCliente(cliente1);
            var resultados = clientes.BuscarCliente("color", "rojo");
            Assert.That(resultados, Is.Empty);
        }

        [Test]
        public void BuscarUnCliente_DeberiaRetornarClienteCorrecto()
        {
            clientes.AgregaCliente(cliente1);
            var encontrado = clientes.BuscarUnCliente("C1");

            Assert.That(encontrado, Is.Not.Null);
            Assert.That(encontrado.Nombre, Is.EqualTo("Juan"));
            Assert.That(encontrado.Apellido, Is.EqualTo("Pérez"));
        }

        [Test]
        public void BuscarUnCliente_NoExistente_DeberiaRetornarNull()
        {
            clientes.AgregaCliente(cliente1);
            var resultado = clientes.BuscarUnCliente("3");
            Assert.That(resultado, Is.Null);
        }
    }
}
 */