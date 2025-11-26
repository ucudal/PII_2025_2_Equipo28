using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Library;


namespace Ucu.Poo.DiscordBot.Commands
{

    /// <summary>
    /// Esta clase implementa el comando 'init' del bot.
    /// Este comando crea una fachada con un administrador, un usuario y un cliente. Esto para facilitar probar el resto de comandos.
    /// </summary>
// ReSharper disable once UnusedType.Global
    public class InicializadorComando : ModuleBase<SocketCommandContext>
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

            string respuesta =
                "Inicializado correctamente. \n\nEste comando creo: \nEl Administrador Pepe con el ID: A1\nEl Usuario Juan con el ID: U1\nEl Cliente Andres con el ID: C1";
            
            await ReplyAsync(respuesta);
        }
    }
}