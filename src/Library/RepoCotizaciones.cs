using System;
using System.Collections.Generic;
using System.Globalization;

namespace Library
{
    public class RepoCotizaciones
    {
        private List<Cotizacion> cotizaciones = new List<Cotizacion>();

        public IEnumerable<Cotizacion> Cotizaciones
        {
            get { return cotizaciones; }
        }

        public void AgregarCotizacion(Cliente cliente, string cuando, string precio, Usuario usuario)
        {
            if (cliente == null || cuando == null || precio == null||usuario==null)
            {
                throw new ArgumentNullException();
            }
            if (cuando==""||precio=="")
            {
                throw new AggregateException();
            }
            DateTime fecha;
            if (DateTime.TryParseExact(cuando, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out fecha))
            {
                this.cotizaciones.Add(new Cotizacion(cliente, fecha, precio));
                // usuario.AgregarCotizacion(new Cotizacion(cliente,fecha,precio));
            }
            else
            {
                Console.WriteLine("Fecha no valida");
                throw new InvalidDateException();
            }
            
        }
        /// <summary>
        /// para los test
        /// </summary>
        public void EliminarDatos()
        {
            this.cotizaciones.Clear();
        }
    }
}