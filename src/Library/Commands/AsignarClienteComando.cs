using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Library;


namespace Ucu.Poo.DiscordBot.Commands
{

    /// <summary>
    /// Esta clase asigna un cliente a otro vendedor
    /// Devuele la confirmacion .
    /// </summary>
// ReSharper disable once UnusedType.Global
    public class AsignarClienteComando : ModuleBase<SocketCommandContext>
    {
        private Fachada fachada = Fachada.Instancia;
        /// <summary>
        /// Implementa el comando 'AsiganrClienteAVendedor' que asigna un cliente a un vendedor.
        /// </summary>
        [Command("asignarCliente")]
        [Summary(
            "Asigna el cliente y devuelve una confirmacion de la asigancion, en caso opuesto devuelve un error y su explicacion")]
        // ReSharper disable once UnusedMember.Global
        public async Task ExecuteAsync([Remainder][Summary("xxx")]string parametros)
        {
            string[] parte = parametros.Split(',');
            if (parte.Length != 2)
            {
                await ReplyAsync($"Se nececitan 2 parametros. Recurda separar los parametros por ','");

            }
            else
            {
                string mensaje = fachada.AsignarClienteAVendedor( parte[0], parte[1]);
                await ReplyAsync($"{mensaje}");

            }
        }
    }
}