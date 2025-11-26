using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Library;


namespace Ucu.Poo.DiscordBot.Commands
{

    /// <summary>
    /// Esta clase suspende un Usuario.
    /// Devuele una confirmación de si se elimino o no.
    /// </summary>
// ReSharper disable once UnusedType.Global
    public class SuspenderUsuarioComando : ModuleBase<SocketCommandContext>
    {
        private Fachada fachada = Fachada.Instancia;
        /// <summary>
        /// Implementa el comando 'suspenderUsuario' que suspende un Usuario. Este comando es para la historia 21.
        /// </summary>
        [Command("suspenderUsuario")]
        [Summary(
            "Suspende un Usuario")]
        // ReSharper disable once UnusedMember.Global
        public async Task ExecuteAsync([Remainder][Summary("xxx")]string parametros)
        {
            string[] parte = parametros.Split(',');
            if (parte.Length != 2)
            {
                await ReplyAsync($"Se nececitan 2 parametros: suspenderId y adminId. Recuerda separar los parametros por ','");
            }
            else
            {
                string mensaje = fachada.SuspenderUsuario(parte[0], parte[1]);
                
                await ReplyAsync(mensaje);
            }
        }
    }
}