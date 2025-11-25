using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Library;


namespace Ucu.Poo.DiscordBot.Commands
{

    /// <summary>
    /// Esta clase registra un mensaje.
    /// Devuele la confirmacion de si se creo o no.
    /// </summary>
// ReSharper disable once UnusedType.Global
    public class NuevoClienteCommand : ModuleBase<SocketCommandContext>
    {
        private Fachada fachada = Fachada.Instancia;
        /// <summary>
        /// Implementa el comando 'RegistraMensaje' que registra un mensaje. Este comando es para la historia 6.
        /// </summary>
        [Command("nuevoCliente")]
        [Summary(
            "Crea un nuevo cliente")]
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
                Cliente cliente = fachada.CrearCliente(parte[0], parte[1], parte[2], parte[3], parte[4]);
                await ReplyAsync($"{cliente.ToString()}");
            }
        }
    }
}