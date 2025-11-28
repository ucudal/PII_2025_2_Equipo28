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
            if (cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente), "El cliente no puede ser null.");
            }

            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario), "El usuario no puede ser null.");
            }

            if (string.IsNullOrEmpty(cuando))
            {
                throw new ArgumentException("El tema no puede estar vacío o nulo.", nameof(cuando));
            }

            if (string.IsNullOrEmpty(precio))
            {
                throw new ArgumentException("El tema no puede estar vacío o nulo.", nameof(precio));
            }


            DateTime fecha;
            if (DateTime.TryParseExact(cuando, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out fecha))
            {
                this.cotizaciones.Add(new Cotizacion(cliente, fecha, precio));
                usuario.AgregarCotizacion(new Cotizacion(cliente, fecha, precio));
            }
            else
            {

                throw new InvalidDateException("la fecha no es valida. Recuerda usar el formato dd/mm/yyyy");
            }
        }

        public void EliminarDatos()
        {
            this.cotizaciones.Clear();
        }
    }
}
/*if (cliente == null || cuando == null || precio == null||usuario==null)
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
/*
public void EliminarDatos()
{
this.cotizaciones.Clear();
}
}#1#
*/

