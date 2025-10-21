using NUnit.Framework;
using System.Collections.Generic;
using Library;

namespace Library.Tests
{
    [TestFixture]
    public class ClienteListaTest
    {
        private ClienteLista lista;
        private Cliente cliente1;
        private Cliente cliente2;

        [SetUp]
        public void Setup()
        {
            lista = new ClienteLista();
            cliente1 = new Cliente("Juan", "Pérez", "099123456", "juan@example.com");
            cliente2 = new Cliente("María", "García", "098765432", "maria@example.com");
        }

        [Test]
        public void InicializarListaVacia()
        {
            Assert.That(lista.Clientes, Is.Empty);
        }

        [Test]
        public void AgregarClienteALaLista()
        {
            lista.AgregaCliente(cliente1);
            Assert.That(lista.Clientes.Count, Is.EqualTo(1));
            Assert.That(lista.Clientes[0], Is.EqualTo(cliente1));
        }

        [Test]
        public void NoDeberiaAgregarNada()
        {
            lista.AgregaCliente(null);
            Assert.That(lista.Clientes, Is.Empty);
        }

        [Test]
        public void EliminarClienteExistente()
        {
            lista.AgregaCliente(cliente1);
            lista.EliminarCliente(cliente1);
            Assert.That(lista.Clientes, Is.Empty);
        }

        [Test]
        public void EliminarClienteNoExistenteNoDeberiaEliminarNada()
        {
            lista.AgregaCliente(cliente1);
            lista.EliminarCliente(cliente2);
            Assert.That(lista.Clientes.Count, Is.EqualTo(1));
        }

        [Test]
        public void BuscarClientePorNombreDeberiaRetornarCoincidencias()
        {
            lista.AgregaCliente(cliente1);
            lista.AgregaCliente(cliente2);

            var resultados = lista.BuscarCliente("nombre", "Juan");

            Assert.That(resultados.Count, Is.EqualTo(1));
            Assert.That(resultados[0].Nombre, Is.EqualTo("Juan"));
        }

        [Test]
        public void BuscarCliente_PorCorreo_DeberiaRetornarCoincidencias()
        {
            lista.AgregaCliente(cliente1);
            var resultados = lista.BuscarCliente("correo", "juan@example.com");

            Assert.That(resultados.Count, Is.EqualTo(1));
            Assert.That(resultados[0], Is.EqualTo(cliente1));
        }

        [Test]
        public void BuscarCliente_AtributoInvalido_DeberiaRetornarListaVacia()
        {
            lista.AgregaCliente(cliente1);
            var resultados = lista.BuscarCliente("color", "rojo");
            Assert.That(resultados, Is.Empty);
        }

        [Test]
        public void BuscarUnCliente_DeberiaRetornarClienteCorrecto()
        {
            lista.AgregaCliente(cliente1);
            var encontrado = lista.BuscarUnCliente("Juan", "Pérez");

            Assert.That(encontrado, Is.Not.Null);
            Assert.That(encontrado.Nombre, Is.EqualTo("Juan"));
            Assert.That(encontrado.Apellido, Is.EqualTo("Pérez"));
        }

        [Test]
        public void BuscarUnCliente_NoExistente_DeberiaRetornarNull()
        {
            lista.AgregaCliente(cliente1);
            var resultado = lista.BuscarUnCliente("Pedro", "López");
            Assert.That(resultado, Is.Null);
        }
    }
}
