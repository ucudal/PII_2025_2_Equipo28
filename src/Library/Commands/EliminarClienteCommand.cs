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
    public class EliminarClienteCommand : ModuleBase<SocketCommandContext>
    {
        private Fachada fachada = Fachada.Instancia;
        /// <summary>
        /// Implementa el comando 'RegistraMensaje' que registra un mensaje. Este comando es para la historia 6.
        /// </summary>
        [Command("eliminarCliente")]
        [Summary(
            "Elimina un cliente")]
        // ReSharper disable once UnusedMember.Global
        public async Task ExecuteAsync([Remainder][Summary("xxx")]string parametros)
        {
            string[] parte = parametros.Split(',');
            if (parte.Length != 1)
            {
                await ReplyAsync($"Se nececita 1 parametro: id. Recurda separar los parametros por ','");

            }
            else
            {
                string mensaje = fachada.EliminarCliente(parte[0]);
                await ReplyAsync($"{mensaje}");
            }
        }
    }
}