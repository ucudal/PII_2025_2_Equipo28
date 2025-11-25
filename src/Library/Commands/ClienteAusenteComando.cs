using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Library;


namespace Ucu.Poo.DiscordBot.Commands
{

    /// <summary>
    /// Esta clase mustra los clientes con los que hace mucho no tiene una interaccion.
    /// Devuelve el nombre de los clientes.
    /// </summary>
// ReSharper disable once UnusedType.Global
    public class ClienteAusente : ModuleBase<SocketCommandContext>
    {
        private Fachada fachada = Fachada.Instancia;
        /// <summary>
        /// Implementa el comando 'clienteAusente' que devuelbe los nombres de los clientes con los que no interactua hace mas de un mes.
        /// </summary>
        [Command("clienteAusente")]
        [Summary(
            "devuelve los nombres de los clientes con los que no interactua hace mas de un mes. En caso opuesto devuelve un error y su explicacion")]
        // ReSharper disable once UnusedMember.Global
        public async Task ExecuteAsync([Remainder][Summary("xxx")]string parametros)
        {
            string[] parte = parametros.Split(',');
            if (parte.Length != 2)
            {
                await ReplyAsync($"Se nececitan 1 parametro usuarioid. Recurda separar los parametros por ','");

            }
            else
            {
                string mensaje = fachada.InterraccionClienteAusente(parte[0]);
                await ReplyAsync($"{mensaje}");

            }
        }
    }
}