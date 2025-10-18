namespace Library
{

    public class Correos : Interaccion
    {
        public string correo { get; set; }
        public Correos(Cliente cliente, string tema, string correo) : base(cliente, tema)
        {
            this.correo = correo;
            this.tipo = "correo";
        }
    }
}