using System;
using System.Collections.Generic;

namespace Library
{
    public class RepoInteracciones
    {
        public List<Interaccion> Interacciones = new List<Interaccion>();
        public Interaccion BuscarInteraccion(string tipo, string tema)
        {
            tipo = tipo.ToLower();
            Interaccion.TipoInterracion tipo1 = Interaccion.TipoInterracion.Nada; //para inicializarlo
            switch (tipo)
            {
                case "mensaje":
                    tipo1 = Interaccion.TipoInterracion.Mensaje;
                    break;
                case "reunion":
                    tipo1 = Interaccion.TipoInterracion.Reunion;
                    break;
                case "llamada":
                    tipo1 = Interaccion.TipoInterracion.Llamada;
                    break;
                case "correo":
                    tipo1 = Interaccion.TipoInterracion.Correo;
                    break;
            }

            foreach (Interaccion interaccion in Interacciones)
            {
                if (interaccion.Tipo == tipo1 && interaccion.Tema == tema)
                {
                    return interaccion;
                }
            }

            Console.WriteLine("No se encontro la interaccion");
            return null;
        }

        public void AgregarInteraccion(Interaccion interaccion,Usuario usuario)
        {
            if (interaccion == null || usuario == null)
            {
                throw new ArgumentNullException();
            }
            Interacciones.Add(interaccion);
            usuario.AgregarInteraccion(interaccion);
        }
}
}