/*  using NUnit.Framework;

namespace Library.Tests
{
    [TestFixture]
    public class ClienteTests
    {
        private Cliente cliente;

        [SetUp]
        public void Setup()
        {
            cliente = new Cliente("1", "Juan", "Pérez", "099123456", "juan@example.com");
        }

        [Test]
        public void InicializarCamposCorrectamente()
        {
            Assert.That(cliente.Id, Is.EqualTo("1"));
            Assert.That(cliente.Nombre, Is.EqualTo("Juan"));
            Assert.That(cliente.Apellido, Is.EqualTo("Pérez"));
            Assert.That(cliente.Telefono, Is.EqualTo("099123456"));
            Assert.That(cliente.Correo, Is.EqualTo("juan@example.com"));
            Assert.That(cliente.Genero, Is.EqualTo(string.Empty));
            Assert.That(cliente.FechaDeNacimiento, Is.EqualTo(string.Empty));
            Assert.That(cliente.Etiquetas, Is.Empty);
        }

        [TestCase("nombre", "Carlos", "Carlos")]
        [TestCase("apellido", "García", "García")]
        [TestCase("telefono", "098765432", "098765432")]
        [TestCase("correo", "nuevo@correo.com", "nuevo@correo.com")]
        [TestCase("genero", "Masculino", "Masculino")]
        [TestCase("fechadenacimiento", "01/01/2000", "01/01/2000")]
        public void ModificarInformacion_ActualizaAtributoCorrectamente(string atributo, string valor, string esperado)
        {
            cliente.ModificarInformacion(atributo, valor);
            
            string valorActual = "";
            switch (atributo.ToLower())
            {
                case "nombre":
                    valorActual = cliente.Nombre;
                    break;
                case "apellido":
                    valorActual = cliente.Apellido;
                    break;
                case "telefono":
                    valorActual = cliente.Telefono;
                    break;
                case "correo":
                    valorActual = cliente.Correo;
                    break;
                case "genero":
                    valorActual = cliente.Genero;
                    break;
                case "fechadenacimiento":
                    valorActual = cliente.FechaDeNacimiento;
                    break;
            }

            Assert.That(valorActual, Is.EqualTo(esperado));
        }

        [Test]
        public void AsignarEtiqueta_AgregaEtiquetaDirectamente()
        {
            cliente.AsignarEtiqueta("etiquetaDePrueba");
            Assert.That(cliente.Etiquetas.Contains("etiquetaDePrueba"));
        }

        [Test]
        public void ToString_DevuelveFormatoCorrecto()
        {
            string esperado = "Juan Pérez (juan@example.com) - Id: 1";
            Assert.That(cliente.ToString(), Is.EqualTo(esperado));
        }
    }
}
 */