using System;

namespace Library
{
    public class Reunion : Interaccion
    {
        public string Ubicacion { get; set; }

        public Reunion(Cliente cliente, string tema, string ubicacion, string reunion, string cuando = "00/00/0000") :
            base(cliente, tema, reunion)
        {
            this.Ubicacion = ubicacion;
            this.tipo = "reunion";
            if (cuando != "00/00/0000")
            {
                DateTime fecha;
                if (DateTime.TryParseExact(cuando, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None,
                        out fecha))
                {
                    this.Fecha = fecha;
                }
                else
                {
                    Console.WriteLine("Fecha no valida");
                }
            }
        }
    }
}
        
    
