using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Library;


namespace Ucu.Poo.DiscordBot.Commands
{

    /// <summary>
    /// Esta clase registra una llamada.
    /// Devuele la confirmacion de si se creo o no.
    /// </summary>
// ReSharper disable once UnusedType.Global
    public class RegistrarVenta : ModuleBase<SocketCommandContext>
    {
        private Fachada fachada = Fachada.Instancia;
        /// <summary>
        /// Implementa el comando 'RegistraLlamada' que registra una llamada. Este comando es para la historia 7.
        /// </summary>
        [Command("registrarVenta")]
        [Summary(
            "Registra la venta y devuelve una confirmacion de la venta creada en caso de que asi sea, en caso opuesto devuelve un error y su explicacion")]
        // ReSharper disable once UnusedMember.Global
        public async Task ExecuteAsync([Remainder][Summary("xxx")]string parametros)
        {
            string[] parte = parametros.Split(',');
            if (parte.Length != 5)
            {
                await ReplyAsync($"Se nececitan 5 parametros. Recurda separar los parametros por ','");

            }
            else
            {
                string mensaje = fachada.RegistrarVentaCliente(parte[0], parte[1], parte[2], parte[3], parte[4]);
                await ReplyAsync($"{mensaje}");

            }
        }
    }
}