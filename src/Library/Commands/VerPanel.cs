using System.Threading.Tasks;
using Discord.Commands;
using Library;

namespace Ucu.Poo.DiscordBot.Commands
{   /// <summary>
    /// Esta clase premite ver un panel con cierta informacion.
    /// devuelve esa informacion
    /// </summary>
    public class VerPanel : ModuleBase<SocketCommandContext>
    {
        private Fachada fachada = Fachada.Instancia;
        /// <summary>
        /// Implementa el comando 'VerPanel' que permite ver los clientes totales, las ineteracciones recientes, y reuniones proximas. Este comando es para la historia 22.
        /// </summary>
        [Command("VerPanel")]
        [Summary(
            "Muestra un string con la la siguiente informacion: Los clientes totales, las interacciones recientes del usuario, y usu reuniones proximas. En caso opuesto devuelve un error y su explicacion")]
        // ReSharper disable once UnusedMember.Global
        public async Task ExecuteAsync([Remainder][Summary("xxx")]string parametros)
        {
            string[] parte = parametros.Split(',');
            if (parte.Length != 1)
            {
                await ReplyAsync($"Se nececita 1 parametro: el usuarioId.");

            }
            else
            {
                string mensaje = fachada.Panel(parte[0]);
                await ReplyAsync($"{mensaje}");

            }
        }
    }
}
        
    
