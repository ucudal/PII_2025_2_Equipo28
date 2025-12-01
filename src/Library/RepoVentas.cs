using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Library
{
    public class RepoVentas
    {
        private List<VentaFachada> ventas = new List<VentaFachada>();
        public IEnumerable<VentaFachada> Ventas
        {
            get { return ventas; }
        }

        public void AgregarVenta(Cliente cliente, string cuando, string precio, string producto, Usuario usuario)
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
            
            if (string.IsNullOrEmpty(producto))
            {
                throw new ArgumentException("El tema no puede estar vacío o nulo.", nameof(producto));
            }
            
            
            DateTime fecha;
            if (DateTime.TryParseExact(cuando, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out fecha))
            {
                this.ventas.Add(new VentaFachada(cliente,producto, fecha, precio));
                usuario.AgregarVenta(new VentaFachada(cliente,producto,fecha,precio));
            }
            else
            {
                
                throw new InvalidDateException("la fecha no es valida. Recuerda usar el formato dd/mm/yyyy");
            }
        }
        /// <summary>
        /// Metodo creado para los test
        /// </summary>
        public void EliminarDatos()
        {
            this.ventas.Clear();
        }
    }
}