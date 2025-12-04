using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Library;


namespace Ucu.Poo.DiscordBot.Commands
{

    /// <summary>
    /// Esta clase muestra los clientes cuyas ventas hayan sido de un producto en esoecifico.
    /// Devuele los nombres de los clientes que tengan una venta de ese producto.
    /// </summary>
// ReSharper disable once UnusedType.Global
    public class VerClientesProducto : ModuleBase<SocketCommandContext>
    {
        private Fachada fachada = Fachada.Instancia;
        /// <summary>
        /// Implementa el comando 'verClientesProducto' que muestar el nombre de los clientes con una venta de tal producto. Este comando es para la historia 3 de la Defensa.
        /// </summary>
        [Command("verClientesProducto")]
        [Summary(
            "Muestra los clientes con ese producto en especifico en caso de que asi sea, en caso opuesto devuelve un error y su explicacion")]
        // ReSharper disable once UnusedMember.Global
        public async Task ExecuteAsync([Remainder][Summary("xxx")]string parametros)
        {
            string[] parte = parametros.Split(',');
            if (parte.Length != 2)
            {
                await ReplyAsync($"Se nececitan 2 parametros y en el siguiente orden: prodcuto, usuarioId. Recurda separar los parametros por ','");

            }
            else
            {
                string mensaje = fachada.VerClientesVentaProducto(parte[0], parte[1]);
                await ReplyAsync($"{mensaje}");

            }
        }
    }
}