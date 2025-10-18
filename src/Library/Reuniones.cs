namespace Library
{
    public class Reunion : Interaccion
    {
        public string Ubicacion { get; set; }
        public string reunion { get; set; }

        public Reunion(Cliente cliente, string tema, string ubicacion,string reunion) : base(cliente, tema)
        {
            this.Ubicacion = ubicacion;
            this.tipo = "reunion";
            this.reunion = reunion;
        }
    }
}