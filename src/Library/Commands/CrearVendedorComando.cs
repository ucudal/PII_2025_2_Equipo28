using System.Threading.Tasks;
using Discord.Commands;
using Library;

namespace Ucu.Poo.DiscordBot.Commands
{
    /// <summary>
    /// Esta clase crea un Vendedor.
    /// Devuele una confirmación de si se creó o no.
    /// </summary>
    // ReSharper disable once UnusedType.Global
    public class CrearVendedorComando : ModuleBase<SocketCommandContext>
    {
        private Fachada fachada = Fachada.Instancia;

        /// <summary>
        /// Implementa el comando 'crearVendedor' que crea un Vendedor.
        /// </summary>
        [Command("crearVendedor")]
        [Summary("Crea un Vendedor")]
        
        public async Task ExecuteAsync([Remainder][Summary("xxx")] string parametros)
        {
            string[] parte = parametros.Split(',');
            if (parte.Length != 2)
            {
                await ReplyAsync("Se nececitan 2 parametros: vendedorId y nombre. Recuerda separar los parametros por ','");
            }
            else
            {
                string mensaje = fachada.CrearVendedor(parte[0], parte[1]);
                await ReplyAsync(mensaje);
            }
        }
    }
}