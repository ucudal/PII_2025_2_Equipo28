using System.Threading.Tasks;
using Discord.Commands;
using Library;

namespace Ucu.Poo.DiscordBot.Commands
{
    /// <summary>
    /// Esta clase muestra todas las cotizaciones registradas.
    /// Devuelve un listado de cotizaciones o un mensaje si no hay ninguna.
    /// - SRP: Solo se encarga de ejecutar el comando y enviar el texto de la fachada.
    /// - EXPERT: Delega en la Fachada, que conoce cómo obtener y formatear las cotizaciones.
    /// - Bajo acoplamiento: No accede a repositorios ni a otras clases, solo usa Fachada.
    /// - Alta cohesión: Todo el método está orientado a mostrar cotizaciones.
    /// </summary>
    // ReSharper disable once UnusedType.Global
    public class VerCotizacionesComando : ModuleBase<SocketCommandContext>
    {
        private Fachada fachada = Fachada.Instancia;

        /// <summary>
        /// Implementa el comando 'verCotizaciones' que muestra todas las cotizaciones registradas.
        /// </summary>
        [Command("verCotizaciones")]
        [Summary("Muestra todas las cotizaciones registradas en el sistema.")]
      
        public async Task ExecuteAsync()
        {
            string resultado = fachada.VerCotizaciones();
            await ReplyAsync(resultado);
        }
    }
}