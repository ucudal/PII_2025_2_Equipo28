using System;
using System.Collections.Generic;
using System.Globalization;

namespace Library
{
    /// <summary>
    /// - Expert: porque es responsable de gestionar sus propias interacciones, ventas y cotizaciones.
    /// - SRP: tiene una única responsabilidad: representar un usuario del sistema.
    /// - Alta Cohesión: todos sus métodos y atributos pertenecen al propósito de representar un usuario.
    /// </summary>
    public class Usuario
    {
        public string ID { get; protected set; }
        public string Nombre { get; protected set; }
        private List<Interaccion> InteraccionesUsuario { get; set; } = new List<Interaccion>();
        private List<Venta> VentasUsuario { get; set; } = new List<Venta>();
        private List<Cotizacion> CotizacionesUsuario { get; set; } = new List<Cotizacion>();

        /// <summary>
        /// Constructor de Usuario
        /// </summary>
        /// <param name="id">ID del usuario</param>
        /// <param name="nombre">Nombre del usuario</param>
        public Usuario(string id,string nombre)
        {
            this.ID = id;
            this.Nombre = nombre;
        }
        
        /// <summary>
        /// Crea un recordatorio
        /// </summary>
        /// <param name="recordatorio">Qué recordatorio es</param>
        /// <param name="fecha">Cuándo es el recordatorio</param>
        public void Recordatorio(string recordatorio, string fecha)
        {
            Console.WriteLine($"Recordatorio creado: {recordatorio}, para {fecha}");
        }

        /// <summary>
        /// Agrega una venta al usuario
        /// </summary>
        /// <param name="venta">Venta a agregar</param>
        public void VentaClienteAdd(Venta venta)
        {
            VentasUsuario.Add(venta);
        }

        /// <summary>
        /// Agrega una cotizacion al usuario
        /// </summary>
        /// <param name="cotizacion">Cotizacion a agregar</param>
        public void AgregarCotizacion(Cotizacion cotizacion)
        {
            this.CotizacionesUsuario.Add(cotizacion);
        }

        /// <summary>
        /// Agrega una interaccion al usuario
        /// </summary>
        /// <param name="interaccion">Interaccion a agregar</param>
        public void AgregarInteraccion(Interaccion interaccion)
        {
            this.InteraccionesUsuario.Add(interaccion);
        }

        /// <summary>
        /// Agrega una venta al usuario
        /// </summary>
        /// <param name="venta">Venta a agregar</param>
        public void AgregarVenta(Venta venta)
        {
            this.VentasUsuario.Add(venta);
        }

        /// <summary>
        /// Suma los importes de las ventas en el rango [fechaInicio, fechaFin]
        /// </summary>
        /// <param name="fechaInicio">Fecha de inicio</param>
        /// <param name="fechaFin">Fecha de fin</param>
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
        
        /// <summary>
        /// Devuelve una representacion en string del usuario
        /// </summary>
        public override string ToString()
        {
            return $"{Nombre} - Id: {ID}";
        }
    }
}