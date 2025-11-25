using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Library;


namespace Ucu.Poo.DiscordBot.Commands
{

    /// <summary>
    /// Esta clase implementa el comando 'ping' del bot.
    /// Este comando retorna 'pong'.
    /// </summary>
// ReSharper disable once UnusedType.Global
    public class Inicializador : ModuleBase<SocketCommandContext>
    {
        private Fachada fachada = Fachada.Instancia;
        /// <summary>
        /// Implementa el comando 'ping'.
        /// </summary>
        [Command("init")]
        [Summary(
            "Devuelve 'pong'.")]
        // ReSharper disable once UnusedMember.Global
        public async Task ExecuteAsync()
        {
            fachada.CrearAdministrador("A1", "Pepe");
            fachada.CrearUsuario("U1", "Juan", "A1");
            fachada.CrearCliente("C1", "Andres", "Pérez", "099 298 626", "andres@mail.com");
            
            await ReplyAsync("Inicializado");
        }
    }
}