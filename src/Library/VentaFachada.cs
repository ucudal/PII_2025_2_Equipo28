using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Representa una venta simplificada (fachada) con los datos principales y su resumen textual.
    /// Principios que cumple:
    /// - SRP (Single Responsibility Principle): La clase se enfoca en modelar una venta resumida y generar su resumen en texto.
    /// - EXPERT (Information Expert - GRASP): Tiene toda la información necesaria (cliente, producto, fecha, importe) para construir el resumen.
    /// - Alta cohesión (High Cohesion - GRASP): Todas sus propiedades y métodos giran en torno a describir la venta y su resumen.
    /// Demeter: Resumen() solo accede a los datos públicos de Cliente, su colaborador directo.
    /// </summary>
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