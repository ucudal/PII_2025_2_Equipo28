using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Library;


namespace Ucu.Poo.DiscordBot.Commands
{

    /// <summary>
    /// Esta clase registra una cotizacion.
    /// Devuele la confirmacion de si se creo o no.
    /// </summary>
// ReSharper disable once UnusedType.Global
    public class RegistrarCotizComando : ModuleBase<SocketCommandContext>
    {
        private Fachada fachada = Fachada.Instancia;
        /// <summary>
        /// Implementa el comando 'RegistrarCotizacionCliente' que registra una cotizacion.
        /// </summary>
        [Command("registrarCotiz")]
        [Summary(
            "Registra la Cotizacion y devuelve una confirmacion de la cotizacion creada en caso de que asi sea, en caso opuesto devuelve un error y su explicacion")]
        // ReSharper disable once UnusedMember.Global
        public async Task ExecuteAsync([Remainder][Summary("xxx")]string parametros)
        {
            string[] parte = parametros.Split(',');
            if (parte.Length != 4)
            {
                await ReplyAsync($"Se nececitan 4 parametros (clienteID,fecha,precio,usuarioID). Recurda separar los parametros por ','");

            }
            else
            {
                string mensaje = fachada.RegistrarCotizacionCliente( parte[0], parte[1], parte[2], parte[3]);
                await ReplyAsync($"{mensaje}");

            }
        }
    }
}