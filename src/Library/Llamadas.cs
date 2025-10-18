using System.Runtime.CompilerServices;

namespace Library
{
    public class Llamadas : Interaccion
    {
        public string llamada { get; set; }
        
        
        public Llamadas(Cliente cliente, string tema, string correo) : base(cliente, tema)
        {
            this.tipo = "llamada";
            this.llamada = llamada;
        }
    }
}