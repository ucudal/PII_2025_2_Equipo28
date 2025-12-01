using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Library;


namespace Ucu.Poo.DiscordBot.Commands
{

    /// <summary>
    /// Esta clase agrega una nota a una interaccion.
    /// Devuele la confirmacion de si se hizo o no.
    /// </summary>
// ReSharper disable once UnusedType.Global
    public class AgregarNotaComando : ModuleBase<SocketCommandContext>
    {
        private Fachada fachada = Fachada.Instancia;
        /// <summary>
        /// Implementa el comando 'AgregarNota' que agrega una nota a una interaccion. Este comando es para la historia 10.
        /// </summary>
        [Command("agregarNota")]
        [Summary(
            "Agrega una nota a una interaccion y devuelve una confirmacion de si se hizo en caso de que asi sea, en caso opuesto devuelve un error y su explicacion")]
        // ReSharper disable once UnusedMember.Global
        public async Task ExecuteAsync([Remainder][Summary("xxx")]string parametros)
        {
            string[] parte = parametros.Split(',');
            if (parte.Length != 4)
            {
                await ReplyAsync($"Se nececitan 4 parametros. Recurda separar los parametros por ','");

            }
            else
            {
                string mensaje = fachada.AgregarNota(parte[0], parte[1], parte[2], parte[3]);
                await ReplyAsync($"{mensaje}");

            }
        }
    }
}