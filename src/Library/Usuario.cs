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
        private List<Interaccion> interaccionesUsuario { get; set; } = new List<Interaccion>();
        private List<VentaFachada> ventasUsuario { get; set; } = new List<VentaFachada>();
        private List<Cotizacion> cotizacionesUsuario { get; set; } = new List<Cotizacion>();
        private List<string> recordatorios = new List<string>();

        /// <summary>
        /// Constructor de Usuario
        /// </summary>
        /// <param name="id">ID del usuario</param>
        /// <param name="nombre">Nombre del usuario</param>
        public Usuario(string id,string nombre)
        {
            if (string.IsNullOrWhiteSpace(id)) {
                throw new ArgumentException("El ID no puede estar vacío.");
            }

            if (string.IsNullOrWhiteSpace(nombre)) {
                throw new ArgumentException("El nombre no puede estar vacío.");
            }

            this.ID = id;
            this.Nombre = nombre;
        }
        
        /// <summary>
        /// Crea un recordatorio
        /// </summary>
        /// <param name="recordatorio">Qué recordatorio es</param>
        /// <param name="fecha">Cuándo es el recordatorio</param>
        public string Recordatorio(string recordatorio, string fecha)
        {
            recordatorios.Add($"{recordatorio} - {fecha}");
            return $"Recordatorio creado: {recordatorio}, para {fecha}";
        }

        /// <summary>
        /// Agrega una ventaFachada al usuario
        /// </summary>
        /// <param name="ventaFachada">VentaFachada a agregar</param>
        public void VentaClienteAdd(VentaFachada ventaFachada)
        {
            ventasUsuario.Add(ventaFachada);
        }

        /// <summary>
        /// Agrega una cotizacion al usuario
        /// </summary>
        /// <param name="cotizacion">Cotizacion a agregar</param>
        public void AgregarCotizacion(Cotizacion cotizacion)
        {
            this.cotizacionesUsuario.Add(cotizacion);
        }

        /// <summary>
        /// Agrega una interaccion al usuario
        /// </summary>
        /// <param name="interaccion">Interaccion a agregar</param>
        public void AgregarInteraccion(Interaccion interaccion)
        {
            this.interaccionesUsuario.Add(interaccion);
        }

        /// <summary>
        /// Agrega una ventaFachada al usuario
        /// </summary>
        /// <param name="ventaFachada">VentaFachada a agregar</param>
        public void AgregarVenta(VentaFachada ventaFachada)
        {
            this.ventasUsuario.Add(ventaFachada);
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
            foreach (VentaFachada venta in this.ventasUsuario)
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