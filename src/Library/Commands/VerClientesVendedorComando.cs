using System.Threading.Tasks;
using Discord.Commands;
using Library;

namespace Ucu.Poo.DiscordBot.Commands
{
    /// <summary>
    /// Esta clase muestra los clientes asignados a un vendedor.
    /// Principios que cumple:
    /// - SRP: Solo ejecuta el comando y envía el texto de la fachada.
    /// - EXPERT: Delega en la Fachada, que sabe cómo obtener y formatear los datos.
    /// - Bajo acoplamiento / Alta cohesión: No usa repositorios ni otras clases, solo Fachada.
    /// </summary>
    // ReSharper disable once UnusedType.Global
    public class VerClientesVendedorComando : ModuleBase<SocketCommandContext>
    {
        private Fachada fachada = Fachada.Instancia;

        /// <summary>
        /// Implementa el comando 'verClientesVendedor' que muestra los clientes de un vendedor.
        /// Uso: !verClientesVendedor V1
        /// </summary>
        [Command("verClientesVendedor")]
        [Summary("Muestra todos los clientes asignados a un vendedor por su ID.")]
        // ReSharper disable once UnusedMember.Global
        public async Task ExecuteAsync(string vendedorId)
        {
            string resultado = fachada.VerClientesDeVendedor(vendedorId);
            await ReplyAsync(resultado);
        }
    }
}