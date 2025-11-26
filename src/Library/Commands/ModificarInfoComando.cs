using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Library;


namespace Ucu.Poo.DiscordBot.Commands
{

    /// <summary>
    /// Esta clase modifica la información de un cliente.
    /// Devuele la confirmacion de si se modificó o no.
    /// </summary>
// ReSharper disable once UnusedType.Global
    public class ModificarInfoComando : ModuleBase<SocketCommandContext>
    {
        private Fachada fachada = Fachada.Instancia;
        /// <summary>
        /// Implementa el comando 'modfInfo' que modifica la información de un cliente. Este comando es para la historia 2.
        /// </summary>
        [Command("modfInfo")]
        [Summary(
            "Modifica la información de un cliente")]
        // ReSharper disable once UnusedMember.Global
        // !modfInfo id atributo nuevoValor
        public async Task ExecuteAsync([Remainder][Summary("xxx")]string parametros)
        {
            string[] parte = parametros.Split(',');
            if (parte.Length != 3)
            {
                await ReplyAsync($"Se nececitan 3 parametros: id, atributo y nuevoValor. Recurda separar los parametros por ','");
            }
            else
            {
                string mensaje = fachada.ModificarInfo(parte[0], parte[1], parte[2]);
                await ReplyAsync($"{mensaje}");
            }
        }
    }
}