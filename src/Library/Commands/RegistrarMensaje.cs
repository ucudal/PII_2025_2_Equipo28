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
    public class RegistrarMensaje : ModuleBase<SocketCommandContext>
    {
        /// <summary>
        /// Implementa el comando 'RegistraMensaje' que registra un mensaje.
        /// </summary>
        [Command("registrarMensaje")]
        [Summary(
            "Devuelve 'pong'.")]
        // ReSharper disable once UnusedMember.Global
        public async Task ExecuteAsync()
        {
            await ReplyAsync("pong");
        }
    }
}