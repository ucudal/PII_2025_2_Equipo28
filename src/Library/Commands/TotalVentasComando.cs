using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Library;


namespace Ucu.Poo.DiscordBot.Commands
{

    /// <summary>
    /// Esta clase registra una total de ventas en un peridodo dado.
    /// Devuele la confirmacion de si se creo o no.
    /// </summary>
// ReSharper disable once UnusedType.Global
    public class TotalVentasComando: ModuleBase<SocketCommandContext>
    {
        private Fachada fachada = Fachada.Instancia;
        /// <summary>
        /// Implementa el comando 'totalVentas' que registra una llamada. Este comando es para la historia 7.
        /// </summary>
        [Command("totalVentas")]
        [Summary(
            "Registra el total de ventas en el peridodo dado y devuelve una confirmacion de la venta creada en caso de que asi sea, en caso opuesto devuelve un error y su explicacion")]
        // ReSharper disable once UnusedMember.Global
        public async Task ExecuteAsync([Remainder][Summary("xxx")]string parametros)
        {
            string[] parte = parametros.Split(',');
            if (parte.Length != 3)
            {
                await ReplyAsync($"Se nececitan 5 parametros. Recurda separar los parametros por ','");

            }
            else
            {
                string mensaje = fachada.TotalDeVentasEnPeriodo(parte[0], parte[1], parte[2]);
                await ReplyAsync($"{mensaje}");

            }
        }
    }
}