using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using NUnit.Framework;

namespace Library.Tests
{
    public class TestFachada_Historia_8_15_
    {
        private Fachada fachada;
        private Usuario usuario;
        private Cliente cliente1;
        private Cliente cliente2;
        private Administrador administrador;


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
            fachada.CrearAdministrador("A1", "Lansaguisantes");
            fachada.CrearUsuario("U1", "Petaseta", "A1");
            fachada.CrearCliente("C1", "Harry", "ElSucioPotter", "099786435", "Harringy@cabezatermo.com");
            fachada.CrearCliente("C2", "Hermione", "Granger", "46872390", "Hermy@cabezatermo.com");
            usuario = fachada.Usuarios.BuscarUsuario("U1");
            cliente1 = fachada.Clientes.BuscarUnCliente("C1");
            cliente2 = fachada.Clientes.BuscarUnCliente("C2");
        }

         [Test]
         ///Verifica que el mensaje que se encuentra en el repointeraccion de fachada sea el mismo que registro.
         public void RegistarMensajeCorrectoTest()
         {
             fachada.RegistrarMensaje("C1", "este.... hola", "saludo", "U1", "10/11/2024");
             Interaccion interaccion = fachada.Interacciones.BuscarInteraccion(usuario, "mensaje", "saludo");
             List<object> esperado = new List<object>()
             {
                 cliente1, usuario, Interaccion.TipoInterracion.Mensaje, "saludo", "este.... hola",
                 new DateTime(2024, 11, 10)
             };
             List<object> resultado = new List<object>()
             {
                 interaccion.Cliente, interaccion.Usuario, interaccion.Tipo, interaccion.Tema, interaccion.Contenido,
                 interaccion.Fecha
             };
             Assert.That(resultado, Is.EqualTo(esperado));
         }
         
//
         [TestCase("C1", "", "lol", "U1", "10/11/2024", "El contenido no puede estar vacío. (Parameter 'contenido') contenido")]
         [TestCase("C1", "f", "", "U1", "10/11/2024", "El tema no puede estar vacío. (Parameter 'tema') tema")]
         [TestCase("C1", "f", "lol", "U1", "", "La fecha no puede estar vacía. (Parameter 'fecha') fecha")]
         public void RegistraMensajeIncorrectoTextoVacio(string a, string b, string c, string d, string e,
             string esperado)
         {
             string resultado = fachada.RegistrarMensaje(a, b, c, d, e);
             Assert.That(resultado, Is.EqualTo(esperado));
         }
//
         [TestCase(null, "f", "lol", "U1", "10/11/2024", "Value cannot be null. (Parameter 'Datos de cliente null') Datos de cliente null")]
         [TestCase("C1", null, "f", "U1", "10/11/2024", "El contenido no puede ser null. (Parameter 'contenido') contenido")]
         [TestCase("C1", "f", null, "U1", "10/11/2024", "El tema no puede ser null. (Parameter 'tema') tema")]
         [TestCase("C1", "f", "lol", null, "10/11/2024", "Value cannot be null. (Parameter 'datos de usuario null') datos de usuario null")]
         [TestCase("C1", "f", "lol", "U1", null, "La fecha no puede ser null. (Parameter 'fecha') fecha")]
         public void RegistarMensajeIncorrectoContenidoNull(string a, string b, string c, string d, string e,
             string esperado)
         {
             string resultado = fachada.RegistrarMensaje(a, b, c, d, e);
             Assert.That(resultado, Is.EqualTo(esperado));
         }
//
         [TestCase("C1", "f", "lol", "U1", "10/11/2027", "La fecha no es valida. Escriba una fecha anterior o igual a la fecha actual (Parameter 'fecha') fecha")]
         [TestCase("C1", "f", "lol", "U1", "10/17/2024", "la fecha no es valida. Recuerda escribir una fecha anterior o identica a la fecha actual, y usar el fomranto dd/mm/yyyy (Parameter 'fecha') fecha")]
         [TestCase("C1", "f", "lol", "U1", "50/11/2024", "la fecha no es valida. Recuerda escribir una fecha anterior o identica a la fecha actual, y usar el fomranto dd/mm/yyyy (Parameter 'fecha') fecha")]
         public void RegistarMensajeIncorrectoFechaNovalida(string a, string b, string c, string d, string e,
             string esperado)
         {
             string resultado = fachada.RegistrarMensaje(a, b, c, d, e);
             Assert.That(resultado, Is.EqualTo(esperado));
         }
         [Test]
         /// Verifica que la llamada registrada en fachada sea la misma que se encuentra en el repositorio.
         public void RegistrarLlamadaCorrectoTest()
         {
             fachada.RegistrarLlamada("C1", "contenido llamada", "consulta", "U1", "10/11/2024");
             Interaccion interaccion = fachada.Interacciones.BuscarInteraccion(usuario, "llamada", "consulta");

             List<object> esperado = new List<object>()
             {
                 cliente1, usuario, Interaccion.TipoInterracion.Llamada, "consulta", "contenido llamada",
                 new DateTime(2024, 11, 10)
             };

             List<object> resultado = new List<object>()
             {
                 interaccion.Cliente, interaccion.Usuario, interaccion.Tipo, interaccion.Tema,
                 interaccion.Contenido, interaccion.Fecha
             };

             Assert.That(resultado, Is.EqualTo(esperado));
         }
         [TestCase("C1", "", "temaX", "U1", "10/11/2024",
             "El contenido no puede estar vacío. (Parameter 'contenido') contenido")]
         [TestCase("C1", "hola", "", "U1", "10/11/2024",
             "El tema no puede estar vacío. (Parameter 'tema') tema")]
         [TestCase("C1", "hola", "temaX", "U1", "",
             "La fecha no puede estar vacía. (Parameter 'fecha') fecha")]
         public void RegistrarLlamadaIncorrectoTextoVacio(string a, string b, string c, string d, string e, string esperado)
         {
             string resultado = fachada.RegistrarLlamada(a, b, c, d, e);
             Assert.That(resultado, Is.EqualTo(esperado));
         }
         [TestCase(null, "hola", "temaX", "U1", "10/11/2024",
             "Value cannot be null. (Parameter 'Datos de cliente null') Datos de cliente null")]
         [TestCase("C1", null, "temaX", "U1", "10/11/2024",
             "El contenido no puede ser null. (Parameter 'contenido') contenido")]
         [TestCase("C1", "hola", null, "U1", "10/11/2024",
             "El tema no puede ser null. (Parameter 'tema') tema")]
         [TestCase("C1", "hola", "temaX", null, "10/11/2024",
             "Value cannot be null. (Parameter 'datos de usuario null') datos de usuario null")]
         [TestCase("C1", "hola", "temaX", "U1", null,
             "La fecha no puede ser null. (Parameter 'fecha') fecha")]
         public void RegistrarLlamadaIncorrectoContenidoNull(string a, string b, string c, string d, string e, string esperado)
         {
             string resultado = fachada.RegistrarLlamada(a, b, c, d, e);
             Assert.That(resultado, Is.EqualTo(esperado));
         }
         [TestCase("C1", "hola", "temaX", "U1", "10/11/2027",
             "La fecha no es valida. Escriba una fecha anterior o igual a la fecha actual (Parameter 'fecha') fecha")]
         [TestCase("C1", "hola", "temaX", "U1", "10/17/2024",
             "la fecha no es valida. Recuerda escribir una fecha anterior o identica a la fecha actual, y usar el fomranto dd/mm/yyyy (Parameter 'fecha') fecha")]
         [TestCase("C1", "hola", "temaX", "U1", "50/11/2024",
             "la fecha no es valida. Recuerda escribir una fecha anterior o identica a la fecha actual, y usar el fomranto dd/mm/yyyy (Parameter 'fecha') fecha")]
         public void RegistrarLlamadaIncorrectoFechaNovalida(string a, string b, string c, string d, string e, string esperado)
         {
             string resultado = fachada.RegistrarLlamada(a, b, c, d, e);
             Assert.That(resultado, Is.EqualTo(esperado));
         }
         [Test]
         /// Verifica que el correo registrado en fachada sea el mismo que aparece en el repositorio.
         public void RegistrarCorreoCorrectoTest()
         {
             fachada.RegistrarCorreo("C1", "contenido correo", "consulta", "U1", "10/11/2024");
             Interaccion interaccion = fachada.Interacciones.BuscarInteraccion(usuario, "correo", "consulta");

             List<object> esperado = new List<object>()
             {
                 cliente1, usuario, Interaccion.TipoInterracion.Correo, "consulta", "contenido correo",
                 new DateTime(2024, 11, 10)
             };

             List<object> resultado = new List<object>()
             {
                 interaccion.Cliente, interaccion.Usuario, interaccion.Tipo, interaccion.Tema,
                 interaccion.Contenido, interaccion.Fecha
             };

             Assert.That(resultado, Is.EqualTo(esperado));
         }
         [TestCase("C1", "", "temaX", "U1", "10/11/2024",
             "El contenido no puede estar vacío. (Parameter 'contenido') contenido")]
         [TestCase("C1", "hola", "", "U1", "10/11/2024",
             "El tema no puede estar vacío. (Parameter 'tema') tema")]
         [TestCase("C1", "hola", "temaX", "U1", "",
             "La fecha no puede estar vacía. (Parameter 'fecha') fecha")]
         public void RegistrarCorreoIncorrectoTextoVacio(string a, string b, string c, string d, string e, string esperado)
         {
             string resultado = fachada.RegistrarCorreo(a, b, c, d, e);
             Assert.That(resultado, Is.EqualTo(esperado));
         }
         [TestCase(null, "hola", "temaX", "U1", "10/11/2024",
             "Value cannot be null. (Parameter 'Datos de cliente null') Datos de cliente null")]
         [TestCase("C1", null, "temaX", "U1", "10/11/2024",
             "El contenido no puede ser null. (Parameter 'contenido') contenido")]
         [TestCase("C1", "hola", null, "U1", "10/11/2024",
             "El tema no puede ser null. (Parameter 'tema') tema")]
         [TestCase("C1", "hola", "temaX", null, "10/11/2024",
             "Value cannot be null. (Parameter 'datos de usuario null') datos de usuario null")]
         [TestCase("C1", "hola", "temaX", "U1", null,
             "La fecha no puede ser null. (Parameter 'fecha') fecha")]
         public void RegistrarCorreoIncorrectoContenidoNull(string a, string b, string c, string d, string e, string esperado)
         {
             string resultado = fachada.RegistrarCorreo(a, b, c, d, e);
             Assert.That(resultado, Is.EqualTo(esperado));
         }
         [TestCase("C1", "hola", "temaX", "U1", "10/11/2027",
             "La fecha no es valida. Escriba una fecha anterior o igual a la fecha actual (Parameter 'fecha') fecha")]
         [TestCase("C1", "hola", "temaX", "U1", "10/17/2024",
             "la fecha no es valida. Recuerda escribir una fecha anterior o identica a la fecha actual, y usar el fomranto dd/mm/yyyy (Parameter 'fecha') fecha")]
         [TestCase("C1", "hola", "temaX", "U1", "50/11/2024",
             "la fecha no es valida. Recuerda escribir una fecha anterior o identica a la fecha actual, y usar el fomranto dd/mm/yyyy (Parameter 'fecha') fecha")]
         public void RegistrarCorreoIncorrectoFechaNovalida(string a, string b, string c, string d, string e, string esperado)
         {
             string resultado = fachada.RegistrarCorreo(a, b, c, d, e);
             Assert.That(resultado, Is.EqualTo(esperado));
         }
         [Test]
         /// Verifica que la reunión registrada sea la misma que aparece en el repositorio.
         public void RegistrarReunionCorrectoTest()
         {
             fachada.RegistrarReunion("C1", "charla presencial", "negocio", "U1", "10/11/2024", "Oficina 3B");
             Interaccion interaccion = fachada.Interacciones.BuscarInteraccion(usuario, "reunion", "negocio");

             List<object> esperado = new List<object>()
             {
                 cliente1, usuario, Interaccion.TipoInterracion.Reunion, "negocio", "charla presencial",
                 new DateTime(2024, 11, 10), "Oficina 3B"
             };

             List<object> resultado = new List<object>()
             {
                 interaccion.Cliente, interaccion.Usuario, interaccion.Tipo, interaccion.Tema,
                 interaccion.Contenido, interaccion.Fecha, ((Reunion)interaccion).Lugar
             };

             Assert.That(resultado, Is.EqualTo(esperado));
         }
         [TestCase("C1", "", "temaX", "U1", "10/11/2024", "Oficina",
             "El contenido no puede estar vacío. (Parameter 'contenido') contenido")]

         [TestCase("C1", "info", "", "U1", "10/11/2024", "Oficina",
             "El tema no puede estar vacío. (Parameter 'tema') tema")]

         [TestCase("C1", "info", "temaX", "U1", "", "Oficina",
             "La fecha no puede estar vacía. (Parameter 'fecha') fecha")]

         [TestCase("C1", "info", "temaX", "U1", "10/11/2024", "",
             "El lugar no puede estar vacio. (Parameter 'lugar') lugar")]
         public void RegistrarReunionIncorrectoTextoVacio(
             string a, string b, string c, string d, string e, string f, string esperado)
         {
             string resultado = fachada.RegistrarReunion(a, b, c, d, e, f);
             Assert.That(resultado, Is.EqualTo(esperado));
         }
         [TestCase(null, "info", "temaX", "U1", "10/11/2024", "Oficina",
             "Value cannot be null. (Parameter 'Datos de cliente null') Datos de cliente null")]

         [TestCase("C1", null, "temaX", "U1", "10/11/2024", "Oficina",
             "El contenido no puede ser null. (Parameter 'contenido') contenido")]

         [TestCase("C1", "info", null, "U1", "10/11/2024", "Oficina",
             "El tema no puede ser null. (Parameter 'tema') tema")]

         [TestCase("C1", "info", "temaX", null, "10/11/2024", "Oficina",
             "Value cannot be null. (Parameter 'datos de usuario null') datos de usuario null")]

         [TestCase("C1", "info", "temaX", "U1", null, "Oficina",
             "La fecha no puede ser null. (Parameter 'fecha') fecha")]

         [TestCase("C1", "info", "temaX", "U1", "10/11/2024", null,
             "El lugar no puede ser null. (Parameter 'lugar') lugar")]
         public void RegistrarReunionIncorrectoContenidoNull(
             string a, string b, string c, string d, string e, string f, string esperado)
         {
             string resultado = fachada.RegistrarReunion(a, b, c, d, e, f);
             Assert.That(resultado, Is.EqualTo(esperado));
         }
         [TestCase("C1", "info", "temaX", "U1", "10/17/2024", "Oficina",
             "la fecha no es valida. Recuerda escribir una fecha anterior o identica a la fecha actual, y usar el fomranto dd/mm/yyyy (Parameter 'fecha') fecha")]

         [TestCase("C1", "info", "temaX", "U1", "50/11/2024", "Oficina",
             "la fecha no es valida. Recuerda escribir una fecha anterior o identica a la fecha actual, y usar el fomranto dd/mm/yyyy (Parameter 'fecha') fecha")]
         public void RegistrarReunionIncorrectoFechaNovalida(
             string a, string b, string c, string d, string e, string f, string esperado)
         {
             string resultado = fachada.RegistrarReunion(a, b, c, d, e, f);
             Assert.That(resultado, Is.EqualTo(esperado));
         }
         [Test]
         public void AgregarNotaTest()
         {
             fachada.RegistrarMensaje("C1", "este.... hola", "saludo", "U1", "10/11/2024");
             fachada.AgregarNota("hi", "mensaje", "saludo", "U1");
             Interaccion interaccion = fachada.Interacciones.BuscarInteraccion(usuario, "mensaje", "saludo");
             string esperado = "hi";
             string resultado = interaccion.Notas;
             Assert.That(resultado, Is.EqualTo(esperado));
         }
         [TestCase("", "mensaje", "saludo", "U1",
             "el contenido de la nota esta vacio (Parameter 'nota') nota")]
         public void AgregarNotaIncorrectoNotaVacia(string nota, string tipo, string tema, string usuarioId, string esperado)
         {
             fachada.RegistrarMensaje("C1", "queso", "saludo", "U1", "10/10/2022");
             string resultado = fachada.AgregarNota(nota, tipo, tema, usuarioId);
             Assert.That(resultado, Is.EqualTo(esperado));
         }
         [TestCase(null, "mensaje", "saludo", "U1",
             "El contenido de la nota es null (Parameter 'nota') nota")]

         [TestCase("hola", null, "saludo", "U1",
             "El tipo no puede ser null (Parameter 'tipo') tipo")]

         [TestCase("hola", "mensaje", null, "U1",
             "El tema no puede ser null (Parameter 'tema') tema")]

         [TestCase("hola", "mensaje", "saludo", null,
             "Value cannot be null. (Parameter 'datos de usuario null') datos de usuario null")]
         public void AgregarNotaIncorrectoNull(string nota, string tipo, string tema, string usuarioId, string esperado)
         {
             fachada.RegistrarMensaje("C1", "queso", "saludo", "U1", "10/10/2022");
             string resultado = fachada.AgregarNota(nota, tipo, tema, usuarioId);
             Assert.That(resultado, Is.EqualTo(esperado));
         }
         [TestCase("hola", "whatsapp", "saludo", "U1",
             "el tipo de interaccion no es valido (Parameter 'tipo') tipo")]

         [TestCase("hola", "email", "saludo", "U1",
             "el tipo de interaccion no es valido (Parameter 'tipo') tipo")]
         public void AgregarNotaIncorrectoTipoNoValido(string nota, string tipo, string tema, string usuarioId, string esperado)
         {
             fachada.RegistrarMensaje("C1", "queso", "saludo", "U1", "10/10/2022");
             string resultado = fachada.AgregarNota(nota, tipo, tema, usuarioId);
             Assert.That(resultado, Is.EqualTo(esperado));
         }
         [TestCase ("C1","U1","mensaje","10/11/2024","las interaccion de Harry ElSucioPotter del tipo mensaje de la fecha fe son las siguientes:\n\ndespedida:\nchau\n")]
         [TestCase ("C1","U1","mensaje","","las interaccion de Harry ElSucioPotter del tipo mensaje son las siguientes:\nFecha10/11/2024 0:00:00\ndespedida:\nchau\nFecha10/9/2024 0:00:00\nsaludo:\neste.... hola\n")]
         [TestCase ("C1","U1","","10/11/2024","las interaccion de Harry ElSucioPotter de la fecha 10/11/2024 son las siguientes:\nTipoCorreo\ncorreando:\ngta6\nTipoMensaje\ndespedida:\nchau\n")]
         [TestCase ("C1","U1","","","Las interacciones de Harry ElSucioPotter son:\n\nCorreo del 10/11/2024 0:00:00\ncorreando:\ngta6\n\nMensaje del 10/11/2024 0:00:00\ndespedida:\nchau\n\nMensaje del 10/9/2024 0:00:00\nsaludo:\neste.... hola\n")]
         
         
         //Verifica que devuelva correctamente las interacciones de un cliente con tipo y fecha especificados.
         public void InteraccionesClienteCorrectoTest(string a,string b,string c,string d,string e)
         {
             fachada.RegistrarCorreo("C1", "gta6", "correando", "U1", "10/11/2024");
             fachada.RegistrarMensaje("C1", "chau", "despedida", "U1", "10/11/2024");
             fachada.RegistrarMensaje("C1", "este.... hola", "saludo", "U1", "10/09/2024");
             string resultado = fachada.InteraccionesCliente(a, b, c, d);
             DateTime fecha = new DateTime(2024, 11, 10);
             DateTime fecha1 = new DateTime(2024, 9, 10);
             string esperado = e;
             if (c == "mensaje" && d == "10/11/2024")
             {
                 esperado =
                     $"las interaccion de Harry ElSucioPotter del tipo mensaje de la fecha {fecha.ToString("dd/MM/yyyy")} son las siguientes:\n\ndespedida:\nchau\n";
             }
             else if (c == "" && d == "10/11/2024")
             {
                 esperado =
                     $"las interaccion de Harry ElSucioPotter de la fecha {fecha.ToString("dd/MM/yyyy")} son las siguientes:\n\nTipo: Correo\ncorreando:\ngta6\n\nTipo: Mensaje\ndespedida:\nchau\n";
             }
             else if (c == "mensaje" && d == "")
             {
                 esperado =
                     $"las interaccion de Harry ElSucioPotter del tipo mensaje son las siguientes:\n\nFecha: {fecha}\ndespedida:\nchau\n\nFecha: {fecha1}\nsaludo:\neste.... hola\n";
             }
             else
             {
                 esperado =
                     $"Las interacciones de Harry ElSucioPotter son:\n\nCorreo del {fecha}\ncorreando:\ngta6\n\nMensaje del {fecha}\ndespedida:\nchau\n\nMensaje del {fecha1}\nsaludo:\neste.... hola\n";
             }
             // if (d != "")
             // {
             //     DateTime fecha;
             //     if (DateTime.TryParseExact(d, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
             //             out fecha));
             //
             //     d = d.Replace(d, fecha.ToShortDateString());
             //
             // }
             Assert.AreEqual(esperado,resultado);

         }

         // [TestCase(null, "1", "mensaje", "10/11/2024", "Value cannot be null. (Parameter 'Datos de cliente null')")]
         // [TestCase("0", null, "mensaje", "10/11/2024", "Value cannot be null. (Parameter 'datos de usuario null')")]
         // public void InteraccionesClienteNull(string a, string b, string c, string d, string esperado)
         // {
         //     string resultado = fachada.InteraccionesCliente(a, b, c, d);
         //     Assert.That(resultado, Is.EqualTo(esperado));
         // }
//
//         [TestCase("", "1", "mensaje", "10/11/2024", "Datos de cliente vacios")]
//         [TestCase("0", "", "mensaje", "10/11/2024", "datos de usuario vacios")]
//         public void InteraccionesClienteVacio(string a, string b, string c, string d, string esperado)
//         {
//             string resultado = fachada.InteraccionesCliente(a, b, c, d);
//             Assert.That(resultado, Is.EqualTo(esperado));
//         }
//
//         [TestCase("0", "1", "mensaje", "15/25/2024", "Fecha no valida")]
//         [TestCase("0", "1", "mensaje", "50/11/2024", "Fecha no valida")]
//         public void InteraccionesClienteFechaNoValida(string a, string b, string c, string d, string esperado)
//         {
//             string resultado = fachada.InteraccionesCliente(a, b, c, d);
//             Assert.That(resultado, Is.EqualTo(esperado));
//         }
//
        [Test]
//Verifica que el método devuelva correctamente los clientes con los que no se interactúa hace un mes o más.
        public void InterraccionClienteAusenteCorrectoTest()
        {
            fachada.RegistrarMensaje("C1", "mensaje viejo", "seguimiento", "U1", "10/09/2024");
            fachada.RegistrarMensaje("C1", "mensaje reciente", "seguimiento", "U1", "05/11/2024");

            string resultado = fachada.InterraccionClienteAusente("U1");

            string esperado = "Los clientes con los que no interactua hace un mes o mas son:\nHarry ElSucioPotter (Harringy@cabezatermo.com)";
            Assert.That(resultado, Is.EqualTo(esperado));
        }
        [TestCase ("","datos de usuario vacios ")]
        [TestCase (null,"Value cannot be null. (Parameter 'datos de usuario null') datos de usuario null")]
        //Verifica que el método devuelva correctamente los clientes con los que no se interactúa hace un mes o más.
        public void InterraccionClienteAusenteIncorrectoTest(string a,string b)
        {
            string resultado = fachada.InterraccionClienteAusente(a);

            Assert.AreEqual(resultado,b);
        }

        [Test]
        public void PanelCorrectoTest()
        {
           fachada.RegistrarCorreo("C1", "kaca", "maincra", "U1", DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy"));
           fachada.RegistrarReunion("C1", "keso", "este", "U1", "12/10/2050", "nunca");
           Interaccion interaccion = fachada.Interacciones.BuscarInteraccion(usuario, "correo", "maincra");
           string resultado = fachada.Panel("U1");
           string esperado =
               "Los Clientes totales son los siguientes:\nHarry ElSucioPotter\nHermione Granger\nSus interacciones mas recientes son:\nHarry ElSucioPotter. Interaccion de tipo Correo. Tema: maincra\nSus reuniones proximas son:\nTema de la reunion: este. Fecha: 12/10/2050 0:00:00\n";
           Assert.That(resultado, Is.EqualTo(esperado));
        }

//         [TestCase(null, "Value cannot be null. (Parameter 'datos de usuario null')")]
//         public void InterraccionClienteAusenteNull(string a, string esperado)
//         {
//             string resultado = fachada.InterraccionClienteAusente(a);
//             Assert.That(resultado, Is.EqualTo(esperado));
//         }
//
//         [TestCase("", "datos de usuario vacios")]
//         public void InterraccionClienteAusenteVacio(string a, string esperado)
//         {
//             string resultado = fachada.InterraccionClienteAusente(a);
//             Assert.That(resultado, Is.EqualTo(esperado));
//         }
//
//         [TestCase("999", "No se reconoce el usuario")]
//         public void InterraccionClienteAusenteUsuarioInexistente(string a, string esperado)
//         {
//             string resultado = fachada.InterraccionClienteAusente(a);
//             Assert.That(resultado, Is.EqualTo(esperado));
//         }
//
//           // [Test]
//           //   // Tiene problemas por el tema singleton, pero solo por el resultado, al cambiar con cada agregado de test:
//           // //Verifica que el panel muestre correctamente los clientes, interacciones recientes y reuniones próximas.
//           // public void PanelCorrectoTest()
//           // {
//           //     fachada.CrearUsuario("1", "El petizo", "A1");
//           //     usuario = fachada.BuscarUsuario("1");
//           //     fachada.RegistrarCorreo("0", "k", "e", "1", "10/12/2000");
//           //     fachada.RegistarReunion("0", "k", "e", "1", "12/10/2050", "n");
//           //     Interaccion interaccion = fachada.Interacciones.BuscarInteraccion(usuario, "correo", "e");
//           //     interaccion.Fecha = DateTime.Now.AddDays(-2);
//           //     string resultado = fachada.Panel("1");
//           //     string esperado =
//           //         "Los Clientes totales son los siguientes:\nSape 099872521\nSus interacciones mas recientes son:\nSape 099872521. Interaccion de tipo Correo. Tema: e\nSus reuniones proximas son:\nTema de la reunion: e. Fecha: 12/10/2050 0:00:00\n";
//           //     Assert.That(resultado, Is.EqualTo(esperado));
//           // }
//
          [Test]
          public void AgregarClienteContactoTest()
          {
              fachada.AgregarClienteContacto("U1", "C1");
              Cliente esperado = fachada.ClientesContacto[usuario][0];
              Assert.That(cliente1,Is.EqualTo(esperado));
          }
         [Test]
          public void VerClienteContactoTest()
          {
              fachada.AgregarClienteContacto("U1", "C1");
              fachada.AgregarClienteContacto("U1", "C2");
              string resultado = fachada.VerClienteContacto("U1");
              string esperado = "Los clientes que se pusieron en contacto contigo son:\nHarry ElSucioPotter\nHermione Granger\n";
              Assert.That(resultado, Is.EqualTo(esperado));
          }

          [Test]
          public void EliminarClienteCorrectoTest()
          {
              fachada.AgregarClienteContacto("U1", "C1");
              fachada.AgregarClienteContacto("U1", "C2");
              fachada.EliminarClienteContacto("U1", "C1");
              int resultado = fachada.ClientesContacto[usuario].Count;
              Assert.That(resultado, Is.EqualTo(1));
          }
//
         [TestCase(null, "C1", "Value cannot be null. (Parameter 'datos de usuario null') datos de usuario null")]
         [TestCase("1", null, "Value cannot be null. (Parameter 'Datos de cliente null') Datos de cliente null")]
         [TestCase("", "C1", "datos de usuario vacios ")]
         [TestCase("U1", "", "Datos de cliente vacios ")]
         public void AgregarClienteContactoIncorrectoTest(string usuarioId, string clienteId, string esperado)
         {
             string resultado = fachada.AgregarClienteContacto(usuarioId, clienteId);
             Assert.That(resultado, Is.EqualTo(esperado));
         }

         [TestCase(null, "Value cannot be null. (Parameter 'datos de usuario null') datos de usuario null")]
         [TestCase("", "datos de usuario vacios ")]
         public void VerClienteContactoIncorrectoTest(string usuarioId, string esperado)
         {
             string resultado = fachada.VerClienteContacto(usuarioId);
             Assert.That(resultado, Is.EqualTo(esperado));
         }
    }
}

