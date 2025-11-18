using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;

namespace Ucu.Poo.DiscordBot.Commands
{

    /// <summary>
    /// Esta clase implementa el comando 'ping' del bot.
    /// Este comando retorna 'pong'.
    /// </summary>
// ReSharper disable once UnusedType.Global
    public class Test : ModuleBase<SocketCommandContext>
    {
        /// <summary>
        /// Implementa el comando 'ping'.
        /// </summary>
        [Command("nuevoCliente")]
        [Summary(
            "Crea un nuevo cliente dada la información sobre el mismo.")]
        // ReSharper disable once UnusedMember.Global
        public async Task ExecuteAsync([Remainder][Summary("xxx")]string param)
        {
            string[] parts = param.Split(',');
            
            await ReplyAsync("pong");
        }
    }
}