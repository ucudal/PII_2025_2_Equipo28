using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Library.Tests
{
    public class Testsinteracciones
    {
        private Usuario usuario;
        private Cliente cliente;

        [SetUp]
        public void setup()
        {
            usuario = new Usuario("1", "CJ");
            cliente = new Cliente("1","Vela", "La sopla vela", "099878655", "VelySape@cabezatermo.com");
        }


        [Test]
        public void TestLlamada()
        {
            Llamadas llamada = new Llamadas(usuario, cliente, "Albondigas", "Albondiga al plato o al pan?",
                "10/11/2000");
            List<object> esperado = new List<object>(){usuario, cliente, "Albondigas", "Albondiga al plato o al pan?",
                new DateTime(2000, 11, 10),Interaccion.TipoInterracion.Llamada};
            List<object> resultado = new List<object>()
                { llamada.Usuario, llamada.Cliente, llamada.Tema, llamada.Contenido, llamada.Fecha, llamada.Tipo };
            Assert.That(resultado,Is.EqualTo(esperado));

        }
        [Test]
        public void TestMensaje()
        {
            Mensajes mensaje = new Mensajes(usuario, cliente, "Pedido", "Confirmación de pedido pendiente",
                "15/03/2021");
            List<object> esperado = new List<object>(){usuario, cliente, "Pedido", "Confirmación de pedido pendiente",
                new DateTime(2021, 3, 15),Interaccion.TipoInterracion.Mensaje};
            List<object> resultado = new List<object>()
                { mensaje.Usuario, mensaje.Cliente, mensaje.Tema, mensaje.Contenido, mensaje.Fecha, mensaje.Tipo };
            Assert.That(resultado,Is.EqualTo(esperado));
        }
        [Test]
        public void TestCorreo()
        {
            Correos correo = new Correos(usuario, cliente, "Factura", "Envío de factura electrónica",
                "20/07/2022");
            List<object> esperado = new List<object>(){usuario, cliente, "Factura", "Envío de factura electrónica",
                new DateTime(2022, 7, 20),Interaccion.TipoInterracion.Correo};
            List<object> resultado = new List<object>()
                { correo.Usuario, correo.Cliente, correo.Tema, correo.Contenido, correo.Fecha, correo.Tipo };
            Assert.That(resultado,Is.EqualTo(esperado));
        }
        [Test]
        public void TestReunion()
        {
            Reunion reunion = new Reunion(usuario, cliente, "Proyecto X", "La esquina del McDonals","Revisión de avances",
                "05/09/2023");
            List<object> esperado = new List<object>(){usuario, cliente, "Proyecto X","La esquina del McDonals", "Revisión de avances",
                new DateTime(2023, 9, 5),Interaccion.TipoInterracion.Reunion};
            List<object> resultado = new List<object>()
                { reunion.Usuario, reunion.Cliente, reunion.Tema,reunion.Lugar, reunion.Contenido, reunion.Fecha, reunion.Tipo };
            Assert.That(resultado,Is.EqualTo(esperado));
        }

        [Test]
        public void AgregarNota()
        {
            Llamadas llamada = new Llamadas(usuario, cliente, "Albondigas", "Albondiga al plato o al pan?",
                "10/11/2000");
            Mensajes mensaje = new Mensajes(usuario, cliente, "Pedido", "Confirmación de pedido pendiente",
                "15/03/2021");
            Correos correo = new Correos(usuario, cliente, "Factura", "Envío de factura electrónica",
                "20/07/2022");
            Reunion reunion = new Reunion(usuario, cliente, "Proyecto X", "La esquina del McDonals","Revisión de avances",
                "05/09/2023");
            llamada.AgergarNotas("Hellouda");
            mensaje.AgergarNotas("Esquere");
            correo.AgergarNotas("No no pude ser");
            reunion.AgergarNotas("Cinhgawhat");
            Assert.Multiple(() =>
            {
                Assert.That("Hellouda", Is.EqualTo(llamada.Notas));
                Assert.That("Esquere", Is.EqualTo(mensaje.Notas));
                Assert.That("No no pude ser", Is.EqualTo(correo.Notas));
                Assert.That("Cinhgawhat", Is.EqualTo(reunion.Notas));
            });

        }
        [Test]
        public void TestExceptionNullLlamada()
        {
            Assert.Multiple(() =>
            {
                Assert.Throws<ArgumentNullException>(() => new Llamadas(usuario,null, "hello", "xd", "10/10/2023"));
                Assert.Throws<ArgumentNullException>(() => new Llamadas(usuario,cliente, null, "xd", "10/10/2023"));
                Assert.Throws<ArgumentNullException>(() => new Llamadas(usuario,cliente, "hello", null, "10/10/2023"));
                Assert.Throws<ArgumentNullException>(() => new Llamadas(usuario,cliente, "null", "xd", null));
                Assert.Throws<ArgumentNullException>(() => new Llamadas(null,cliente, "null", "xd", "10/10/2023"));
            });
        }
        [Test]
        public void TestExceptionEmptyLlamda()
        {
            Assert.Multiple(() =>
            {
                Assert.Throws<Excepciones.EmptyStringException>(() => new Llamadas(usuario,cliente, "", "xd", "10/10/2023"));
                Assert.Throws<Excepciones.EmptyStringException>(() => new Llamadas(usuario,cliente, "null", "", "10/10/2023"));
                Assert.Throws<Excepciones.EmptyStringException>(() => new Llamadas(usuario,cliente, "hello", "null", ""));
            });
        }
    [Test]
    public void TestExceptionInvalidDateLlamada()
    {
        Assert.Multiple(() =>
        {
            Assert.Throws<Excepciones.InvalidDateException>(() => new Llamadas(usuario,cliente, "hi", "xd", "50/10/2020"));
            Assert.Throws<Excepciones.InvalidDateException>(() => new Llamadas(usuario,cliente, "null", "nel", "10/50/2020"));
            Assert.Throws<Excepciones.InvalidDateException>(() => new Llamadas(usuario,cliente, "null", "nel", "10/10/2070"));
        });
    }
    [Test]
    public void TestExceptionNullMensaje()
    {
        Assert.Multiple(() =>
        {
            Assert.Throws<ArgumentNullException>(() => new Mensajes(usuario,null, "hello", "xd", "10/10/2023"));
            Assert.Throws<ArgumentNullException>(() => new Mensajes(usuario,cliente, null, "xd", "10/10/2023"));
            Assert.Throws<ArgumentNullException>(() => new Mensajes(usuario,cliente, "hello", null, "10/10/2023"));
            Assert.Throws<ArgumentNullException>(() => new Mensajes(usuario,cliente, "null", "xd", null));
            Assert.Throws<ArgumentNullException>(() => new Mensajes(null,cliente, "null", "xd", "10/10/2023"));
        });
    }

    [Test]
    public void TestExceptionEmptyMensaje()
    {
        Assert.Multiple(() =>
        {
            Assert.Throws<Excepciones.EmptyStringException>(() => new Mensajes(usuario,cliente, "", "xd", "10/10/2023"));
            Assert.Throws<Excepciones.EmptyStringException>(() => new Mensajes(usuario,cliente, "null", "", "10/10/2023"));
            Assert.Throws<Excepciones.EmptyStringException>(() => new Mensajes(usuario,cliente, "hello", "null", ""));
        });
    }

    [Test]
    public void TestExceptionInvalidDateMensaje()
    {
        Assert.Multiple(() =>
        {
            Assert.Throws<Excepciones.InvalidDateException>(() => new Mensajes(usuario,cliente, "hi", "xd", "50/10/2020"));
            Assert.Throws<Excepciones.InvalidDateException>(() => new Mensajes(usuario,cliente, "null", "nel", "10/50/2020"));
            Assert.Throws<Excepciones.InvalidDateException>(() => new Mensajes(usuario,cliente, "null", "nel", "10/08/2050"));
        });
    }
    [Test]
    public void TestExceptionNullCorreo()
    {
        Assert.Multiple(() =>
        {
            Assert.Throws<ArgumentNullException>(() => new Correos(usuario,null, "hello", "xd", "10/10/2021"));
            Assert.Throws<ArgumentNullException>(() => new Correos(usuario,cliente, null, "xd", "05/05/2022"));
            Assert.Throws<ArgumentNullException>(() => new Correos(usuario,cliente, "hello", null, "01/01/2023"));
            Assert.Throws<ArgumentNullException>(() => new Correos(usuario,cliente, "null", "xd", null));
            Assert.Throws<ArgumentNullException>(() => new Correos(null,cliente, "null", "xd", "10/10/2010"));
        });
    }

    [Test]
    public void TestExceptionEmptyCorreo()
    {
        Assert.Multiple(() =>
        {
            Assert.Throws<Excepciones.EmptyStringException>(() => new Correos(usuario,cliente, "", "xd", "10/10/2021"));
            Assert.Throws<Excepciones.EmptyStringException>(() => new Correos(usuario,cliente, "null", "", "05/05/2022"));
            Assert.Throws<Excepciones.EmptyStringException>(() => new Correos(usuario,cliente, "hello", "null", ""));
        });
    }

    [Test]
    public void TestExceptionInvalidDateCorreo()
    {
        Assert.Multiple(() =>
        {
            Assert.Throws<Excepciones.InvalidDateException>(() => new Correos(usuario,cliente, "hi", "xd", "50/10/2020"));
            Assert.Throws<Excepciones.InvalidDateException>(() => new Correos(usuario,cliente, "null", "nel", "10/50/2020"));
            Assert.Throws<Excepciones.InvalidDateException>(() => new Correos(usuario,cliente, "null", "nel", "10/10/2050"));
        });
    }
    [Test]
    public void TestExceptionNullReunion()
    {
        Assert.Multiple(() =>
        {
            Assert.Throws<ArgumentNullException>(() => new Reunion(usuario,null, "tema", "lugar", "contenido", "10/10/2019"));
            Assert.Throws<ArgumentNullException>(() => new Reunion(usuario,cliente, null, "lugar", "contenido", "05/05/2040"));
            Assert.Throws<ArgumentNullException>(() => new Reunion(usuario,cliente, "tema", null, "contenido", "01/01/2021"));
            Assert.Throws<ArgumentNullException>(() => new Reunion(usuario,cliente, "tema", "lugar", null, "01/01/2022"));
            Assert.Throws<ArgumentNullException>(() => new Reunion(usuario,cliente, "tema", "lugar", "contenido", null));
            Assert.Throws<ArgumentNullException>(() => new Reunion(null,cliente, "tema", "lugar", "contenido", "10/10/2050"));
        });
    }

    [Test]
    public void TestExceptionEmptyReuniones()
    {
        Assert.Multiple(() =>
        {
            Assert.Throws<Excepciones.EmptyStringException>(() => new Reunion(usuario,cliente, "", "lugar", "contenido", "10/10/2019"));
            Assert.Throws<Excepciones.EmptyStringException>(() => new Reunion(usuario,cliente, "tema", "", "contenido", "05/05/2050"));
            Assert.Throws<Excepciones.EmptyStringException>(() => new Reunion(usuario,cliente, "tema", "lugar", "", "01/01/2021"));
            Assert.Throws<Excepciones.EmptyStringException>(() => new Reunion(usuario,cliente, "tema", "lugar", "contenido", ""));
        });
    }

    [Test]
    public void TestExceptionInvalidDateReunion()

    {
        Reunion reunion = new Reunion(usuario, cliente, "tema", "lugar", "contenido", "10/10/2050");
        Assert.Multiple(() =>
        {
            Assert.Throws<Excepciones.InvalidDateException>(() => new Reunion(usuario,cliente, "tema", "lugar", "contenido", "50/10/2020"));
            Assert.Throws<Excepciones.InvalidDateException>(() => new Reunion(usuario,cliente, "tema", "lugar", "contenido", "10/50/2020"));
        });
    }
    //     [Test]
    //     public void TestExceptionNullReunion()
    //     {
    //         Assert.Multiple(() =>
    //         {
    //             Assert.Throws<ArgumentNullException>(() => new Reunion(null, "hello", "xd", "magic","10/10/2050"));
    //             Assert.Throws<ArgumentNullException>(() => new Reunion(cliente1, null, "xd", "magic","10/10/2050"));
    //             Assert.Throws<ArgumentNullException>(() => new Reunion(cliente1, "hello", null, "magic","10/10/2050"));
    //             Assert.Throws<ArgumentNullException>(() => new Reunion(cliente1, "null", "xd", null,"10/10/2050"));
    //             Assert.Throws<ArgumentNullException>(() => new Reunion(cliente1, "null", "xd", "null",null));
    //     
    //         });
    //     }
    //     [Test]
    //     public void TestExceptionEmptyReunion()
    //     {
    //         Assert.Multiple(() =>
    //         {
    //             Assert.Throws<Excepciones.EmptyStringException>(() => new Reunion(cliente1, "", "xd","reunio", "10/10/2050"));
    //             Assert.Throws<Excepciones.EmptyStringException>(() => new Reunion(cliente1, "null", "","reunio", "10/10/2050"));
    //             Assert.Throws<Excepciones.EmptyStringException>(() => new Reunion(cliente1, "hello", "null", "","10/10/2050"));
    //             Assert.Throws<Excepciones.EmptyStringException>(() => new Reunion(cliente1, "hello", "null", "rrr",""));
    //     
    //         });
    //     }
    //     [Test]
    //     public void TestExceptionInvalidDateReunion()
    //     {
    //         Assert.Multiple(() =>
    //         {
    //             Assert.Throws<Excepciones.InvalidDateException>(() => new Reunion(cliente1, "hi", "xd","n", "50/10/2050"));
    //             Assert.Throws<Excepciones.InvalidDateException>(() => new Reunion(cliente1, "null", "nel","n", "10/50/2050"));
    //         });
    //     }
    }
}

    