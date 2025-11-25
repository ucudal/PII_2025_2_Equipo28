using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Library;


namespace Ucu.Poo.DiscordBot.Commands
{

    /// <summary>
    /// Esta clase muestra las interacciones de un cliente en base a las parametros.
    /// Devuele la informacion.
    /// </summary>
// ReSharper disable once UnusedType.Global
    public class InteracciondeClienteComando : ModuleBase<SocketCommandContext>
    {
        private Fachada fachada = Fachada.Instancia;
        /// <summary>
        /// Implementa el comando 'InteraccionesCliente' que muestra las interacciones de un cliente, en base al tipo, la fecha, ambos o ninguno. Este comando es para la historia ??.
        /// </summary>
        [Command("interaccionCliente")]
        [Summary(
            "Muestra las interacciones en base a los datos proporcionados, en caso opuesto devuelve un error y su explicacion")]
        // ReSharper disable once UnusedMember.Global
        public async Task ExecuteAsync([Remainder][Summary("xxx")]string parametros)
        {
            string[] parte = parametros.Split(',');
            if (parte.Length != 4)
            {
                await ReplyAsync($"Se nesecitan entre 4 y 2 parametros, en el siguinte orden: clienteid, usaurioid, tipo (opcional), fecha (opcional). Recurda separar los parametros por ','. En caso de no querer usar los parametros opcionales, no escriba nada en el lugar del parametro. Pero coloque las comas.");

            }
            else
            {
                string mensaje = fachada.InteraccionesCliente(parte[0], parte[1], parte[2], parte[3]);
                await ReplyAsync($"{mensaje}");

            }
        }
    }
}