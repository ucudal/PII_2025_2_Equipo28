namespace Library;

public class Reuniones : Interacciones
{
    public string Ubicacion { get; set; }
    public Reuniones(Cliente cliente, string tema, string fecha, string ubicacion) : base(cliente, tema, fecha)
    {
        this.Ubicacion = ubicacion;
    }
}