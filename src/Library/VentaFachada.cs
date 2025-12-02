using System;
using System.Collections.Generic;

namespace Library
{
    // SRP 
    // Esta clase cumple SRP porque su única responsabilidad es representar una venta:
    // contiene información sobre el cliente, el producto, la fecha y el importe.
    //
    // Expert 
    // VentaFachada es la experta en manejar su propia información, ya que contiene todos los datos
    // necesarios para describir la venta y generar un resumen.
    public class VentaFachada
    {
        public Cliente Cliente { get; set; }
        public string Producto { get; set; }
        public DateTime Fecha { get; set; }
        public string Importe { get; set; }

        public VentaFachada(Cliente cliente, string producto, DateTime fecha, string importe)
        {
            Cliente = cliente;
            Producto = producto;
            Fecha = fecha;
            Importe = importe;
        }

        public string Resumen()
        {
            return
                $"{Cliente.Nombre} {Cliente.Apellido} compró {Producto} el {Fecha.ToShortDateString()} por ${Importe}";
        }
    }
}