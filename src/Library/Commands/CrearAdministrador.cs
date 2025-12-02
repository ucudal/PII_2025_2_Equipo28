using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Library;


namespace Ucu.Poo.DiscordBot.Commands
{

    /// <summary>
    /// Esta clase crea un nuevo Administrador.
    /// Devuele la confirmacion de si se creo o no.
    /// </summary>
// ReSharper disable once UnusedType.Global
    public class CrearAdministradorComando : ModuleBase<SocketCommandContext>
    {
        private Fachada fachada = Fachada.Instancia;
        /// <summary>
        /// Implementa el comando 'crearAdministrador' que crea un nuevo Administrador.
        /// </summary>
        [Command("crearAdministrador")]
        [Summary(
            "Crea un nuevo Administrador")]
        // ReSharper disable once UnusedMember.Global
        public async Task ExecuteAsync([Remainder][Summary("xxx")]string parametros)
        {
            string[] parte = parametros.Split(',');
            if (parte.Length != 2)
            {
                await ReplyAsync($"Se nececitan 2 parametros: adminId y nombre. Recurda separar los parametros por ','");
            }
            else
            {
                string mensaje = fachada.CrearAdministrador(parte[0], parte[1]);
                await ReplyAsync(mensaje);
            }
        }
    }
}