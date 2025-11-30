using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Library;


namespace Ucu.Poo.DiscordBot.Commands
{

    /// <summary>
    /// Esta clase agrega a una lista al cliente el cual se puso en contacto con el usaurio y este aun no le responde.
    /// Devuele la confirmacion de si se hizo o no.
    /// </summary>
// ReSharper disable once UnusedType.Global
    public class ClienteContactaAgregarComando : ModuleBase<SocketCommandContext>
    {
        private Fachada fachada = Fachada.Instancia;
        /// <summary>
        /// Implementa el comando 'clienteContactoAgregar' que agrega al cliente a una lista de cleintes que se pusieron en contacto. Este comando es para la historia 19.
        /// </summary>
        [Command("clienteContactaAgregar")]
        [Summary(
            "agrega a una lista al cliente el cual se puso en contacto con el usuario y este aun no le responde. En caso opuesto devuelve un error y su explicacion")]
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
                string mensaje = fachada.AgregarClienteContacto(parte[0], parte[1]);
                await ReplyAsync($"{mensaje}");

            }
        }
    }
}