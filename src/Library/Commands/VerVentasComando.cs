using System.Threading.Tasks;
using Discord.Commands;
using Library;

namespace Ucu.Poo.DiscordBot.Commands
{
    /// <summary>
    /// Esta clase muestra todas las ventas registradas.
    /// Devuelve un listado de ventas o un mensaje si no hay ninguna.
    /// Principios que cumple:
    /// - SRP: Solo se encarga de ejecutar el comando y enviar el texto de la fachada.
    /// - EXPERT: Delega en la Fachada, que conoce cómo obtener y formatear las ventas.
    /// - Bajo acoplamiento: No accede a repositorios ni a otras clases, solo usa Fachada.
    /// - Alta cohesión: Todo el método está orientado a mostrar ventas.
    /// </summary>
    // ReSharper disable once UnusedType.Global
    public class VerVentasComando : ModuleBase<SocketCommandContext>
    {
        private Fachada fachada = Fachada.Instancia;

        /// <summary>
        /// Implementa el comando 'verVentas' que muestra todas las ventas registradas.
        /// </summary>
        [Command("verVentas")]
        [Summary("Muestra todas las ventas registradas en el sistema.")]
       
        public async Task ExecuteAsync()
        {
           
            string resultado = fachada.VerVentas();
            await ReplyAsync(resultado);
        }
    }
}