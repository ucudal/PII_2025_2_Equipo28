using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Library;


namespace Ucu.Poo.DiscordBot.Commands
{

    /// <summary>
    /// Esta clase elimina un Usuario.
    /// Devuele una confirmación de si se elimino o no.
    /// </summary>
// ReSharper disable once UnusedType.Global
    public class EliminarUsuarioComando : ModuleBase<SocketCommandContext>
    {
        private Fachada fachada = Fachada.Instancia;
        /// <summary>
        /// Implementa el comando 'eliminarUsuario' que elimina un Usuario. Este comando es para la historia 20.
        /// </summary>
        [Command("eliminarUsuario")]
        [Summary(
            "Elimina un Usuario")]
        // ReSharper disable once UnusedMember.Global
        public async Task ExecuteAsync([Remainder][Summary("xxx")]string parametros)
        {
            string[] parte = parametros.Split(',');
            if (parte.Length != 2)
            {
                await ReplyAsync($"Se nececitan 2 parametros: usuarioId y adminId. Recuerda separar los parametros por ','");
            }
            else
            {
                string mensaje = fachada.EliminarUsuario(parte[0], parte[1]);
                
                await ReplyAsync(mensaje);
            }
        }
    }
}

// !eliminarUsuario usuarioId adminId