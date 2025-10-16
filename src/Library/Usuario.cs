namespace Library;

public class Usuario
{
    public List<Interaccion> Interacciones { get; private set; } = new List<Interaccion>();
    public List<string> Total_Ventas { get; private set; } = new List<string>();
    public List<string> VentaCliente { get; private set; } = new List<string>();
    public List<string> Cotizaciones { get; private set; } = new List<string>();

    // Métodos del diagrama
    public void Recordatorio(string que, string cuando)
    {
        Console.WriteLine($"Recordatorio creado: {que}, para {cuando}");
    }

    public void AgregarEtiqueta(Cliente cliente, string etiqueta)
    {
        cliente.Etiqueta = etiqueta;
    }

    public void VentaClienteAdd(string que, string cuando, string precio)
    {
        string venta = $"Producto: {que}, Fecha: {cuando}, Precio: {precio}";
        VentaCliente.Add(venta);
        Total_Ventas.Add(venta);
    }

    public void AgregarCotizacion(string cuando, string porque)
    {
        string cotizacion = $"Fecha: {cuando}, Motivo: {porque}";
        Cotizaciones.Add(cotizacion);
    }
}
