using System;
using System.Collections.Generic;

namespace Library
{
    // SRP 
    // Esta clase cumple SRP porque su única responsabilidad es representar un usuario del sistema:
    // almacenar sus datos, interacciones, ventas y cotizaciones, y permitir operaciones relacionadas con ellos.
    //
    // Expert
    // Usuario es la experta en manejar su propia información y la relación con clientes:
    // conoce sus interacciones, cotizaciones, ventas y etiquetas, y puede agregarlas.
    public class Usuario
    {
        public string ID { get; set; }
        public string Nombre { get; set; }
        public List<string> Etiqueteas = new List<string>();
        public List<Interaccion> Interacciones { get; private set; } = new List<Interaccion>();
        public List<Venta> Total_Ventas { get; private set; } = new List<Venta>();
        public List<Venta> VentaCliente { get; private set; } = new List<Venta>();
        public List<Cotizacion> Cotizaciones { get; private set; } = new List<Cotizacion>();

        // Métodos del diagrama
        public Usuario(string id,string nombre)
        {
            this.ID = id;
            this.Nombre = nombre;
        }
        public void Recordatorio(string que, string cuando)
        {
            Console.WriteLine($"Recordatorio creado: {que}, para {cuando}");
        }

        public void AgregarEtiqueta(Cliente cliente, string etiqueta)
        {
            cliente.Etiqueta = etiqueta;
            if (!(Etiqueteas.Contains(etiqueta)))
            {
                Etiqueteas.Add(etiqueta);
            }
        }

        public void VentaClienteAdd(Cliente cliente, string producto, string cuando, string precio)
        {
            DateTime fecha;
            if (DateTime.TryParseExact(cuando, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fecha))
            {
                this.Total_Ventas.Add(new Venta(cliente,producto,fecha,precio));
                this.VentaCliente.Add(new Venta(cliente,producto,fecha,precio));
            }
            else
            {
                Console.WriteLine("Fecha no valida");
            }
        }

        public void AgregarCotizacion(Cliente cliente,string cuando, string precio)
        {
            DateTime fecha;
            if (DateTime.TryParseExact(cuando, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fecha))
            {
                this.Cotizaciones.Add(new Cotizacion(cliente,fecha,precio));
            }
            else
            {
                Console.WriteLine("Fecha no valida");
            }
        }

        public Interaccion BuscarInteraccion(string tipo, string tema)
        {
            foreach (Interaccion interaccion in Interacciones)
            {
                if (interaccion.tipo == tipo && interaccion.Tema == tema)
                {
                    return interaccion;
                }
            }
            Console.WriteLine("No se encontro la interaccion");
            return null;
        }
    }
}