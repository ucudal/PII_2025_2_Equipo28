using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Representa una cotización realizada a un cliente, con sus datos principales y un resumen textual.
    /// Principios que cumple:
    /// - SRP: Se enfoca en modelar la cotización y validar/representar sus datos.
    /// - EXPERT : Posee toda la información necesaria (cliente, fecha, importe) para construir el resumen.
    /// - Bajo acoplamiento : Solo depende de la interfaz pública de Cliente para obtener nombre y apellido.
    /// - Alta cohesión : Sus miembros giran en torno a la cotización y su representación.
    /// -Demeter: Resumen() accede solo al colaborador directo Cliente y sus propiedades públicas.
    /// </summary>
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

