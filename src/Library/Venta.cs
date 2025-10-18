using System;
using System.Collections.Generic;

namespace Library
{
    public class Venta
    {
        public Cliente Cliente { get; set; }
        public string Producto { get; set; }
        public DateTime Fecha { get; set; }
        public string Importe { get; set; }

        public Venta(Cliente cliente, string producto, DateTime fecha, string importe)
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