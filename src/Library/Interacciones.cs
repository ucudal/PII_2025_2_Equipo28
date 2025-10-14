namespace Library;

public class Interacciones
{
    public string Notas { get; set; }
    public Cliente Cliente { get; set; }
    public string Tema { get; set; }
    public string Fecha { get; set; }

    public Interacciones(Cliente cliente, string tema, string fecha)
    {
        this.Cliente = cliente;
        this.Tema = tema;
        this.Fecha = fecha;
    }

    public void AgergarNotas(string notas)
    {
        this.Notas = notas;
    }
    
}
