using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Library;


namespace Ucu.Poo.DiscordBot.Commands
{

    /// <summary>
    /// Esta clase implementa el comando 'init' del bot.
    /// Este comando crea un administrador, un usuario, un cliente y un vendedor. Esto para facilitar probar y/o utilizar el resto de comandos.
    /// </summary>
// ReSharper disable once UnusedType.Global
    public class CREARADMIN : ModuleBase<SocketCommandContext>
    {
        private Fachada fachada = Fachada.Instancia;
        /// <summary>
        /// Implementa el comando 'init'.
        /// </summary>
        [Command("admin")]
        [Summary(
            "Crea un administrador, un usuario, un cliente y un vendedor.")]
        // ReSharper disable once UnusedMember.Global
        public async Task ExecuteAsync()
        {
            fachada.CrearAdministrador("A1", "Pepe");
            string respuesta = "admin A1";
            await ReplyAsync(respuesta);
        }
    }
}