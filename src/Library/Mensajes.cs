namespace Library
{
    public class Mensajes : Interaccion
    {
        public Mensajes(Cliente cliente, string tema, string mensaje) : base(cliente, tema,mensaje)
        {
            this.tipo = "mensaje";
        }
    }
}