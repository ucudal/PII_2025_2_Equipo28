using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Library;


namespace Ucu.Poo.DiscordBot.Commands
{

    /// <summary>
    /// Esta clase registra una reunion.
    /// Devuele la confirmacion de si se creo o no.
    /// </summary>
// ReSharper disable once UnusedType.Global
    public class RegistrarReunionComando : ModuleBase<SocketCommandContext>
    {
        private Fachada fachada = Fachada.Instancia;
        /// <summary>
        /// Implementa el comando 'RegistraReunion' que registra una reunion. Este comando es para la historia 9.
        /// </summary>
        [Command("registrarReunion")]
        [Summary(
            "Registra la reunion y devuelve una confirmacion de la reunion creada en caso de que asi sea, en caso opuesto devuelve un error y su explicacion")]
        // ReSharper disable once UnusedMember.Global
        public async Task ExecuteAsync([Remainder][Summary("xxx")]string parametros)
        {
            string[] parte = parametros.Split(',');
            if (parte.Length != 6)
            {
                await ReplyAsync($"Se nececitan 6 parametros y en el siguiente orden: ClienteId, contenido, tema, usuarioid, fecha, lugar. Recurda separar los parametros por ','");

            }
            else
            {
                string mensaje = fachada.RegistrarReunion(parte[0], parte[1], parte[2], parte[3], parte[4],parte[5]);
                await ReplyAsync($"{mensaje}");

            }
        }
    }
}