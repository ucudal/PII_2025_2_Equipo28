using System;
using System.Collections.Generic;

namespace Library
{
    public class Panel
    {
        public List<Cliente> ClientesTotales { get; private set; }
        public List<Interaccion> InteraccionesRecientes { get; private set; }
        public List<Reunion> ReunionesProximas { get; private set; }

        public Panel()
        {
            ClientesTotales = new List<Cliente>();
            InteraccionesRecientes = new List<Interaccion>();
            ReunionesProximas = new List<Reunion>();
        }

        public void AgregarInteraccion(Interaccion interaccion)
        {
            InteraccionesRecientes.Add(interaccion);
        }
    }
}