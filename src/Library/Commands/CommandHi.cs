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
    public class CommandHi : ModuleBase<SocketCommandContext>
    {
        /// <summary>
        /// Implementa el comando 'Hi'.
        /// </summary>
        [Command("Hi")]
        [Summary(
            "Devuelve 'Un saldudo'.")]
        // ReSharper disable once UnusedMember.Global
        public async Task ExecuteAsync([Remainder][Summary("xxx")]string param)
        {
            string[] parts = param.Split(',');
            await ReplyAsync($"Todo bien gato jajaja {parts[0]}, {parts[1]}");
        }
    }
}