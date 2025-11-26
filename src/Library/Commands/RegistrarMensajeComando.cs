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
    public class RegistrarMensajeComando : ModuleBase<SocketCommandContext>
    {
        private Fachada fachada = Fachada.Instancia;
        /// <summary>
        /// Implementa el comando 'RegistraMensaje' que registra un mensaje. Este comando es para la historia 6.
        /// </summary>
        [Command("registrarMensaje")]
        [Summary(
            "Registra el mensaje y devuelve una confirmacion del mensaje creado en caso de que asi sea, en caso opuesto devuelve un error y su explicacion")]
        // ReSharper disable once UnusedMember.Global
        public async Task ExecuteAsync([Remainder][Summary("xxx")]string parametros)
        {
            string[] parte = parametros.Split(',');
            if (parte.Length != 5)
            {
                await ReplyAsync($"Se nececitan 5 parametros y en el siguiente orden: ClienteId, contenido, tema, usuarioid, fecha. Recurda separar los parametros por ','");

            }
            else
            {
                string mensaje = fachada.RegistrarMensaje(parte[0], parte[1], parte[2], parte[3], parte[4]);
                await ReplyAsync($"{mensaje}");

            }
        }
    }
}