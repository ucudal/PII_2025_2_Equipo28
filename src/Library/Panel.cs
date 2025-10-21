using System;
using System.Collections.Generic;

namespace Library
{
    // SRP 
    // Esta clase cumple SRP porque su única responsabilidad es mantener un panel de información:
    // lista de clientes, interacciones recientes y reuniones próximas.
    //
    // Expert 
    // Panel es la experta en manejar estas colecciones de manera centralizada y puede agregar
    // interacciones al registro, ya que conoce todos los datos necesarios para ello.
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