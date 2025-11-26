using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Library;


namespace Ucu.Poo.DiscordBot.Commands
{

    /// <summary>
    /// Esta clase crea un nuevo cliente.
    /// Devuele la confirmacion de si se creo o no.
    /// </summary>
// ReSharper disable once UnusedType.Global
    public class NuevoClienteComando : ModuleBase<SocketCommandContext>
    {
        private Fachada fachada = Fachada.Instancia;
        /// <summary>
        /// Implementa el comando 'nuevoCliente' que crea un nuevo cliente. Este comando es para la historia 1.
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
                string mensaje = fachada.CrearCliente(parte[0], parte[1], parte[2], parte[3], parte[4]);
                await ReplyAsync(mensaje);
            }
        }
    }
}