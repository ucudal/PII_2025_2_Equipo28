using System;

namespace Library
{
    public class Interaccion
    {
        public string Notas { get; set; }
        public Cliente Cliente { get; set; }
        public string Tema { get; set; }
        public DateTime Fecha { get; set; }
        public string tipo { get; set; }
        public string contenido { get; set; }
        public string lugar { get; set; }

        public Interaccion(Cliente cliente, string tema, string contenido)
        {
            this.Cliente = cliente;
            this.Tema = tema;
            this.Fecha = DateTime.Today;
            this.contenido = contenido;
        }

        public void AgergarNotas(string notas)
        {
            this.Notas = notas;
        }

    }
}