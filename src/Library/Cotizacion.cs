using System;
using System.Collections.Generic;

namespace Library
{
    public class Cotizacion
    {
        public Cliente Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public string Importe { get; set; }
      

        public Cotizacion(Cliente cliente, DateTime fecha, string importe)
        {
            Cliente = cliente;
            Fecha = fecha;
            Importe = importe;
        }

        public string Resumen()
        {
            return $"Cotización a {Cliente.Nombre} {Cliente.Apellido}: importe: {Importe}, Fecha: {Fecha.ToShortDateString()}";
        }
    }
}

