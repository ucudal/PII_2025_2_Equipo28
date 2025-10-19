
using System;
using System.Collections.Generic;
using Library;
using NUnit.Framework;

namespace LibraryTests
{
    public class AndresR_MetodosTest
    {
        private Fachada fachada = new Fachada();
        public Administrador administrador = new Administrador("0000001", "AR");
        
        [Test]

        public void RegistarMensaje()
        {
            Usuario usuario = administrador.CrearUsuario("000002","AR2");
            Cliente cliente = new Cliente("Luis", "Suarez", "098881777", "Lusitoarriba@cabezatermo.com");
            fachada.RegistarMensaje("Luis","Suarez","Tres triges comiendo trigal trigo nose","trigo","000002");
            
            List<string> esperado = new List<string>()
                {"Luis","Suarez", "Tres triges comiendo trigal trigo nose", "trigo" };
            Interaccion mensaje = usuario.BuscarInteraccion("mensaje", "trigo");
            List<string> resultado = new List<string>
                { mensaje.Cliente.Nombre, mensaje.Cliente.Apellido, mensaje.contenido, mensaje.Tema };
            Assert.AreEqual(esperado,resultado);
        }
    }
    }
