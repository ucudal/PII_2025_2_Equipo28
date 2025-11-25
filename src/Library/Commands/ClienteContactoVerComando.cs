using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Library;


namespace Ucu.Poo.DiscordBot.Commands
{

    /// <summary>
    /// Esta clase permite veruna lista de cleintes que se pusieron en conmtacto con el usuario y este aun no les haya respondio.
    /// Devuele la lista de nombres.
    /// </summary>
// ReSharper disable once UnusedType.Global
    public class ClienteContactoVerComando : ModuleBase<SocketCommandContext>
    {
        private Fachada fachada = Fachada.Instancia;
        /// <summary>
        /// Implementa el comando 'clienteContactoVer' que permite ver los clientes que se psuieron en contacto. Este comando es para la historia ??.
        /// </summary>
        [Command("clienteContactoVer")]
        [Summary(
            "muetsra una lista de los nombres de los clientes que se pusieron en contacto con el usuario y este aun no le responde. En caso opuesto devuelve un error y su explicacion")]
        // ReSharper disable once UnusedMember.Global
        public async Task ExecuteAsync([Remainder][Summary("xxx")]string parametros)
        {
            string[] parte = parametros.Split(',');
            if (parte.Length != 1)
            {
                await ReplyAsync($"Se nececita 1 parametro: usuarioid. Recurda separar los parametros por ','");

            }
            else
            {
                string mensaje = fachada.VerClienteContacto(parte[0]);
                await ReplyAsync($"{mensaje}");

            }
        }
    }
}