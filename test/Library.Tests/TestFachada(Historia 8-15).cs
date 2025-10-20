using System;
using System.Collections.Generic;
using NUnit.Framework;
using Library; // Asegúrate de que el namespace sea correcto

namespace Library.Tests
{
    [TestFixture] // Es una buena práctica agregar esto
    public class TestFachada_Historia_8_15_
    {
        private Fachada fachada;
        private Usuario usuario;
        private Administrador admin;
        private Cliente cliente;

        [SetUp]
        public void Setup()
        {
            // 1. LIMPIAR EL ESTADO ESTÁTICO
            // Asumo que tu clase 'Listas' tiene listas estáticas públicas.
            // Si no es así, debes crear un método estático 'Listas.Limpiar()' y llamarlo aquí.
            Listas.Usuarios.Clear();
            Listas.Administradores.Clear();
            Listas.Vendedores.Clear(); // Limpiamos todas las listas que Fachada usa

            // 2. CREAR INSTANCIAS BASE
            fachada = new Fachada();
            admin = new Administrador("100", "AR");
            
            // 3. REGISTRAR ESTADO GLOBAL
            // Agregamos el admin a la lista estática para que la Fachada pueda encontrarlo
            Listas.Administradores.Add(admin); 
            
            // Creamos el usuario. Asumimos que 'admin.CrearUsuario' 
            // AÑADE AUTOMÁTICAMENTE el nuevo usuario a 'Listas.Usuarios'.
            // Si no lo hace, debes añadirlo manualmente: Listas.Usuarios.Add(usuario);
            usuario = admin.CrearUsuario("010", "AR");

            // 4. CREAR EL CLIENTE DE PRUEBA
            // Creamos un cliente y lo añadimos a la lista PÚBLICA de la fachada.
            // Esto funciona asumiendo que arreglaste la Fachada para usar 'listaClientes' internamente.
            cliente = new Cliente("Alfredo", "Rosquilla", "099007100", "AlfedoGamer@cabezatermo.com");
            fachada.clienteLista.AgregaCliente(cliente);
        }

        [Test]
        public void RegistarMensajeTest()
        {
            // 'fachada', 'usuario' y 'cliente' ya existen gracias al [SetUp]

            // Ejecución
            fachada.RegistarMensaje(cliente.Nombre, cliente.Apellido, "Hello holui", "saludo", usuario.ID);

            // Verificación
            Interaccion interaccion = usuario.BuscarInteraccion("mensaje", "saludo");
            Assert.IsNotNull(interaccion, "La interacción no debería ser nula."); // Mensaje de error útil
            Assert.AreEqual(cliente.Nombre, interaccion.Cliente.Nombre);
            Assert.AreEqual(cliente.Apellido, interaccion.Cliente.Apellido);
            Assert.AreEqual("Hello holui", interaccion.contenido);
            Assert.AreEqual("saludo", interaccion.Tema);
        }

        [Test]
        public void RegistrarCorreoTest()
        {
            // Ejecución
            fachada.RegistrarCorreo(cliente.Nombre, cliente.Apellido, "Hello holui", "saludo", usuario.ID);

            // Verificación
            Interaccion interaccion = usuario.BuscarInteraccion("correo", "saludo");
            Assert.IsNotNull(interaccion, "La interacción no debería ser nula.");
            Assert.AreEqual(cliente.Nombre, interaccion.Cliente.Nombre);
            Assert.AreEqual(cliente.Apellido, interaccion.Cliente.Apellido);
            Assert.AreEqual("Hello holui", interaccion.contenido);
            Assert.AreEqual("saludo", interaccion.Tema);
        }

        [Test]
        public void AgregarNotaTest()
        {
            // Setup (necesitamos una interacción a la cual agregarle la nota)
            fachada.RegistarMensaje(cliente.Nombre, cliente.Apellido, "Hello holui", "saludo", usuario.ID);
            
            // Ejecución
            fachada.AgregarNota("Me olvide del chau", "mensaje", "saludo", usuario.ID);

            // Verificación
            Interaccion interaccion = usuario.BuscarInteraccion("mensaje", "saludo");
            Assert.IsNotNull(interaccion, "La interacción base no se encontró.");
            Assert.AreEqual("Me olvide del chau", interaccion.Notas);
        }

        [Test]
        public void AgregarEtiqueta_GuardarEtiquetaTest()
        {
            // Ejecución
            fachada.AgregarEtiqueta(cliente.Nombre, cliente.Apellido, "Pastelero", usuario.ID);

            // Verificación
            Assert.AreEqual("Pastelero", cliente.Etiqueta);
            Assert.AreEqual("Pastelero", usuario.Etiqueteas[0]);
        }

        [Test]
        public void RegistarVentaTest()
        {
            // Ejecución
            fachada.RegistrarVenta(cliente.Nombre, cliente.Apellido, "SillaGamer", "11/8/2023", "250$", usuario.ID);

            // Verificación
            Assert.IsNotEmpty(usuario.Total_Ventas, "La lista de ventas no debería estar vacía.");
            
            Venta venta = usuario.Total_Ventas[0];
            DateTime fecha = DateTime.Parse("11/8/2023");

            Assert.AreEqual(cliente.Nombre, venta.Cliente.Nombre);
            Assert.AreEqual(cliente.Apellido, venta.Cliente.Apellido);
            Assert.AreEqual("SillaGamer", venta.Producto);
            Assert.AreEqual(fecha, venta.Fecha);
            Assert.AreEqual("250$", venta.Importe);
        }

        [Test]
        public void RegistarCotizacionTest()
        {
            // Ejecución
            fachada.RegistarCotizacion(cliente.Nombre, cliente.Apellido, "11/8/2023", "250$", usuario.ID);

            // Verificación
            Assert.IsNotEmpty(usuario.Cotizaciones, "La lista de cotizaciones no debería estar vacía.");

            Cotizacion cotizacion = usuario.Cotizaciones[0];
            DateTime fecha = DateTime.Parse("11/8/2023");

            Assert.AreEqual(cliente.Nombre, cotizacion.Cliente.Nombre);
            Assert.AreEqual(cliente.Apellido, cotizacion.Cliente.Apellido);
            Assert.AreEqual(fecha, cotizacion.Fecha);
            Assert.AreEqual("250$", cotizacion.Importe);
        }
    }
}