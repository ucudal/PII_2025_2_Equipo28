using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Library;


namespace Ucu.Poo.DiscordBot.Commands
{

    /// <summary>
    /// Esta clase comprueba si un monto es mayor o menor
    /// </summary>
// ReSharper disable once UnusedType.Global
    public class MontoMayorOMenorComando: ModuleBase<SocketCommandContext>
    {
        private Fachada fachada = Fachada.Instancia;
        /// <summary>
        /// Implementa el comando 'mayormenor' que elimina ve los usuarios con una venta registrada mayor o menor a un monto dado.
        /// </summary>
        [Command("mayormenor")]
        [Summary(
            "montomayoromenor")]
        // ReSharper disable once UnusedMember.Global
        public async Task ExecuteAsync([Remainder][Summary("xxx")]string parametros)
        {
            string[] parte = parametros.Split(',');
            if (parte.Length != 2)
            {
                await ReplyAsync($"Se nececita 2 parametro: monto,filtro. Recurda separar los parametros por ','");

            }
            else
            {
                string mensaje = fachada.ListarClientesPorMontoDeVentas(parte[0], parte[1]);
                await ReplyAsync($"{mensaje}");
            }
        }
    }
}