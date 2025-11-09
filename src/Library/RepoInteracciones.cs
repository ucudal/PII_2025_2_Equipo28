using System;
using System.Collections.Generic;
using System.Globalization;

namespace Library
{
    public class RepoInteracciones
    {
        private List<Interaccion> Interacciones = new List<Interaccion>();
        public IEnumerable<Interaccion> Interacciones2
        {
            get { return Interacciones; } 
        }
        public Interaccion BuscarInteraccion(Usuario usuario, string tipo, string tema)
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
                if (interaccion.Tipo == tipo1 && interaccion.Tema == tema && interaccion.Usuario == usuario)
                {
                    return interaccion;
                }
            }

            Console.WriteLine("No se encontro la interaccion");
            return null;
        }

        public List<Interaccion> BuscarInteraccion(Usuario usuario, Cliente cliente, string tipo = "", string fecha1 = "")
        {
            if (cliente == null||usuario==null)
            {
                throw new ArgumentNullException("el cliente o usuario no pude ser null");
            }

            if (tipo == null || fecha1 == null)
            {
                tipo = "";
                fecha1 = "";
            }

            DateTime fecha;
            if (DateTime.TryParseExact(fecha1, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out fecha))
            {
                //en blanco a posta 
            }
            else
            {
                Console.WriteLine("Fecha no valida");
                throw new Excepciones.InvalidDateException();
            }

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

            List<Interaccion> interaccionesCliente = new List<Interaccion>();
            if (tipo != "" && fecha1 != "")
            {
                // string informacion =
                //     $"las interaccion de {cliente.Nombre} {cliente.Apellido} del tipo {tipo1} de la fecha {fecha} son las siguientes:\n";
                foreach (Interaccion interaccion in Interacciones)
                {
                    if (interaccion.Tipo == tipo1 && interaccion.Fecha == fecha && interaccion.Usuario==usuario)
                    {
                        interaccionesCliente.Add(interaccion);
                        // informacion += $"\n{interaccion.Tema}:\n{interaccion.Contenido}\n";
                    }
                }

            }
            else 
            {
                // string informacion = $"Las interacciones de {cliente.Nombre} {cliente.Apellido} son:\n";
                foreach (Interaccion interaccion in Interacciones)
                {
                    if (interaccion.Usuario==usuario)
                        interaccionesCliente.Add(interaccion);
                    // informacion +=$"\n{interaccion.Tipo} del {interaccion.Fecha}\n{interaccion.Tema}:\n{interaccion.Contenido}\n"
                }
            }

            return interaccionesCliente;
        } 
        public void AgregarInteraccion(Interaccion interaccion, Usuario usuario)
        {
                if (interaccion == null || usuario == null)
                {
                    throw new ArgumentNullException();
                }

                Interacciones.Add(interaccion);
                usuario.AgregarInteraccion(interaccion);
        }

        public Dictionary<Cliente,Interaccion> UltimasInteraccionesClientes(Usuario usuario)
        {
            if (usuario==null)
            {
                throw new ArgumentNullException("el usuario no pude ser null");
            }
            Dictionary<Cliente, Interaccion> UltimaInterracion = new Dictionary<Cliente, Interaccion>();
            foreach (Interaccion interaccion in Interacciones)
            {
                if (UltimaInterracion.ContainsKey(interaccion.Cliente))
                {
                    if (UltimaInterracion[interaccion.Cliente].Fecha <= interaccion.Fecha)
                    {
                        UltimaInterracion[interaccion.Cliente] = interaccion;
                    }
                }
                else
                {
                    UltimaInterracion[interaccion.Cliente] = interaccion;
                }
            }

            return UltimaInterracion;
        }
    }
}