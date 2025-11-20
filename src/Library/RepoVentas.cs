using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Library
{
    public class RepoVentas
    {
        private List<Venta> ventas = new List<Venta>();
        public IEnumerable<Venta> Ventas
        {
            get { return ventas; }
        }

        public void AgregarVenta(Cliente cliente, string cuando, string precio, string producto, Usuario usuario)
        {
            if (cliente == null || cuando == null || precio == null||producto==null||usuario==null)
            {
                throw new ArgumentNullException();
            }
            if (cuando==""||precio==""||precio=="")
            {
                throw new ArgumentException();
            }
            DateTime fecha;
            if (DateTime.TryParseExact(cuando, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out fecha))
            {
                this.ventas.Add(new Venta(cliente,producto, fecha, precio));
                usuario.VentasUsuario.Add(new Venta(cliente,producto,fecha,precio));
            }
            else
            {
                Console.WriteLine("Fecha no valida");
                throw new InvalidDateException();
            }
        }
    }
}