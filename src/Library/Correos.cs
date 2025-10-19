namespace Library
{

    public class Correos : Interaccion
    {
        public Correos(Cliente cliente, string tema, string correo) : base(cliente, tema,correo)
        {
            this.tipo = "correo";
        }
    }
}