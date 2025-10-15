namespace Library;

public class Reunion : Interaccion
{
    public string Ubicacion { get; set; }
    public Reunion(Cliente cliente, string tema, string fecha, string ubicacion) : base(cliente, tema, fecha)
    {
        this.Ubicacion = ubicacion;
    }
}