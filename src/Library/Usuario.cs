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
        public string ID { get; protected set; }
        public string Nombre { get; protected set; }
        private List<Interaccion> InteraccionesUsuario { get; set; } = new List<Interaccion>();
        private List<Venta> VentasUsuario { get; set; } = new List<Venta>();
        private List<Cotizacion> CotizacionesUsuario { get; set; } = new List<Cotizacion>();

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
            VentasUsuario.Add(venta);
        }

        // public void AgregarCotizacion(Cotizacion cotizacion)
        // {
        //     CotizacionesUsuario.Add(cotizacion);
        // }
        // public void AgregarInteraccion(Interaccion interaccion)
        // {
        //     InteraccionesUsuario.Add(interaccion);
        // }

        public void AgregarCotizacion(Cotizacion cotizacion)
        {
            this.CotizacionesUsuario.Add(cotizacion);
        }
        public void AgregarInteraccion(Interaccion interaccion)
        {
            this.InteraccionesUsuario.Add(interaccion);
        }

        public void AgregarVenta(Venta venta)
        {
            this.VentasUsuario.Add(venta);
        }

        public double SumarImportes(DateTime fechaInicio, DateTime fechaFin)
        {
            //Suma importes en el rango [inicio, fin] 
            double total = 0.0;
            foreach (Venta venta in this.VentasUsuario)
            {
                if (venta.Fecha >= fechaInicio && venta.Fecha <= fechaFin)
                {
                    double importe;
                    if (double.TryParse(venta.Importe, out importe))
                    {
                        total += importe;
                    }
                }
            }

            return total;
        }
    }
}