using System;
using System.Collections.Generic;

namespace Library
{
    // SRP 
    // Esta clase cumple SRP porque su única responsabilidad es representar una cotización:
    // contiene información del cliente, fecha e importe, y puede generar un resumen.
    //
    // Expert 
    // Cotizacion es la experta en manejar su propia información, ya que contiene todos
    // los datos necesarios sobre la cotización (cliente, fecha, importe).
    public class Cotizacion
    {
        public Cliente Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public string Importe { get; set; }
      

        public Cotizacion(Cliente cliente, DateTime fecha, string importe)
        {
            if (cliente == null || importe == null)
            {
                throw new ArgumentNullException();
            }

            if (importe == "")
            {
                throw new ArgumentException();
            }
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

