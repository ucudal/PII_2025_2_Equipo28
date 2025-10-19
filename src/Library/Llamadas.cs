using System.Runtime.CompilerServices;

namespace Library
{
    public class Llamadas : Interaccion
    {
        
        
        
        public Llamadas(Cliente cliente, string tema, string correo,string llamada) : base(cliente, tema,llamada)
        {
            this.tipo = "llamada";
           
        }
    }
}