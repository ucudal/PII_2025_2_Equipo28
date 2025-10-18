namespace Library
{
    public class Mensajes : Interaccion
    {
        public string mensaje { get; set; }
        public Mensajes(Cliente cliente, string tema, string mensaje) : base(cliente, tema)
        {
            this.mensaje = mensaje;
            this.tipo = "mensaje";
        }
    }
}