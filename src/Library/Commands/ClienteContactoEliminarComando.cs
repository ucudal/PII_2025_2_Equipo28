using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Library;


namespace Ucu.Poo.DiscordBot.Commands
{

    /// <summary>
    /// Esta clase elimina de una lista al cliente el cual se puso en contacto con el usaurio y este ya le respondio.
    /// Devuele la confirmacion de si se hizo o no.
    /// </summary>
// ReSharper disable once UnusedType.Global
    public class ClienteContactoEliminar : ModuleBase<SocketCommandContext>
    {
        private Fachada fachada = Fachada.Instancia;
        /// <summary>
        /// Implementa el comando 'clienteContactoEliminar' que elimina al cliente de una lista de clientes que se pusieron en contacto. Este comando es para la historia 19.
        /// </summary>
        [Command("clienteContactaEliminar")]
        [Summary(
            "elimina de una lista al cliente el cual se puso en contacto con el usuario y este ya le respondio. En caso opuesto devuelve un error y su explicacion")]
        // ReSharper disable once UnusedMember.Global
        public async Task ExecuteAsync([Remainder][Summary("xxx")]string parametros)
        {
            string[] parte = parametros.Split(',');
            if (parte.Length != 2)
            {
                await ReplyAsync($"Se nececitan 2 parametros y en el siguiente orden: usuarioid, clienteid. Recurda separar los parametros por ','");

            }
            else
            {
                string mensaje = fachada.EliminarClienteContacto(parte[0], parte[1]);
                await ReplyAsync($"{mensaje}");

            }
        }
    }
}