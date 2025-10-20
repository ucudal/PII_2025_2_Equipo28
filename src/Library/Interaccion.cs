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
private ClienteLista clienteLista = new ClienteLista();

public void VerPanelResumen(string usuarioId)
{
    Usuario usuario = Listas.BuscarUsuario(usuarioId);
    if (usuario != null)
    {
        Console.WriteLine("===== PANEL DE RESUMEN =====");

        // Clientes totales
        Console.WriteLine("Clientes totales: " + clienteLista.Clientes.Count);

        // Interacciones recientes (últimos 7 días)
        DateTime limite = DateTime.Now.AddDays(-7);
        Console.WriteLine("\nInteracciones recientes (últimos 7 días):");
        foreach (Interaccion inter in usuario.Interacciones)
        {
            if (inter.Fecha >= limite)
            {
                Console.WriteLine(inter.Cliente.Nombre + " " + inter.Cliente.Apellido +
                                  " - " + inter.tipo + " (" + inter.Fecha.ToShortDateString() + ")");
            }
        }

        // Reuniones próximas (próximos 7 días)
        DateTime hoy = DateTime.Now;
        DateTime futuro = hoy.AddDays(7);
        Console.WriteLine("\nReuniones próximas (próximos 7 días):");
        foreach (Interaccion inter in usuario.Interacciones)
        {
            if (inter.tipo == "reunion" && inter.Fecha >= hoy && inter.Fecha <= futuro)
            {
                Console.WriteLine(inter.Cliente.Nombre + " " + inter.Cliente.Apellido +
                                  " - " + inter.Tema + " en " +
                                  ((Reunion)inter).Ubicacion +
                                  " (" + inter.Fecha.ToShortDateString() + ")");
            }
        }

        Console.WriteLine("=============================");
    }
    else
    {
        Console.WriteLine("Usuario no encontrado.");
    }
}

    }
}