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
        /// <summary>
        /// Este metodo busca los clientes, cuya venta hay sido del producto desdeado.
        /// 
        /// SRP: El metodo tiene la unica obligacion de buscar y devolver clientes con el mismo producto vendido.
        /// Expert: Cumple expert porque la clase repoVentas es la experta en la informacion de las ventas, por ende de a quien se vendio y que.
        /// Bajo Acoplamiento: Tiene bajo acomplamiento ya que unicamnete necesita de usaurio, para verificar si no es null
        /// Alta Cohesion: Tiena alta Cohecion, porque el metodo se enfoca precisamente en la busqueda de clientes con venta de mismo producto.
        /// </summary>
        /// <param name="producto">El producto a buscar</param>
        /// <returns>devuelve una lista con los clientes cuya venta, haya sido ese producto</returns>
        public List<Cliente> ClientesProducto(string producto)
        {
           
            if (string.IsNullOrEmpty(producto))
            {
                throw new ArgumentNullException(nameof(producto), "El producto no puede ser vacio o null");
            }
            
            List<Cliente> clientes = new List<Cliente>();
            foreach (VentaFachada venta in this.ventas)
            {
                if (venta.Producto == producto && (!clientes.Contains(venta.Cliente)))
                {
                    clientes.Add(venta.Cliente);
                }
            }
            return clientes;
        }
    }
}