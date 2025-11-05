using System;
using System.Collections.Generic;
using System.Globalization;

namespace Library
{
    // SRP 
    // Esta clase cumple SRP porque su única responsabilidad es representar un usuario del sistema:
    // almacenar sus datos, interacciones, ventas y cotizaciones, y permitir operaciones relacionadas con ellos.
    //
    // Expert
    // Usuario es la experta en manejar su propia información y la relación con clientes:
    // conoce sus interacciones, cotizaciones, ventas y etiquetas, y puede agregarlas.
    public class Usuario
    {
        public string ID { get; set; }
        public string Nombre { get; set; }
        public List<Interaccion> InteraccionesUsuario = new List<Interaccion>();
        public List<Venta> Total_Ventas { get; private set; } = new List<Venta>();
        public List<Venta> VentaCliente { get; private set; } = new List<Venta>();
        public List<Cotizacion> CotizacionesUsuario { get; private set; } = new List<Cotizacion>();

        // Métodos del diagrama
        public Usuario(string id,string nombre)
        {
            this.ID = id;
            this.Nombre = nombre;
        }
        public void Recordatorio(string que, string cuando)
        {
            Console.WriteLine($"Recordatorio creado: {que}, para {cuando}");
        }
        public void VentaClienteAdd(Venta venta)
        {
            Total_Ventas.Add(venta);
        }

        public void AgregarCotizacion(Cotizacion cotizacion)
        {
            CotizacionesUsuario.Add(cotizacion);
        }
        public void AgregarInteraccion(Interaccion interaccion)
        {
            InteraccionesUsuario.Add(interaccion);
        }
        //ghgh
    }
}