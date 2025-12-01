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
    public class InicializadorComando : ModuleBase<SocketCommandContext>
    {
        private Fachada fachada = Fachada.Instancia;
        /// <summary>
        /// Implementa el comando 'init'.
        /// </summary>
        [Command("init")]
        [Summary(
            "Crea un administrador, un usuario, un cliente y un vendedor.")]
        // ReSharper disable once UnusedMember.Global
        public async Task ExecuteAsync()
        {
            fachada.CrearAdministrador("A1", "Pepe");
            fachada.CrearUsuario("U1", "Juan", "A1");
            fachada.CrearCliente("C1", "Andres", "Pérez", "099 298 626", "andres@mail.com");
            fachada.CrearVendedor("V1", "Apu");
            string respuesta =
                "Inicializado correctamente. \n\nEste comando creo: \nEl Administrador Pepe con el ID: A1\nEl Usuario Juan con el ID: U1\nEl Cliente Andres con el ID: C1\nEl Vendedor Apu con el ID: V1";
            
            await ReplyAsync(respuesta);
        }
    }
}