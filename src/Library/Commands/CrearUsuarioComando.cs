using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Library;


namespace Ucu.Poo.DiscordBot.Commands
{

    /// <summary>
    /// Esta clase crea un Usuario.
    /// Devuele una confirmación de si se creo o no.
    /// </summary>
// ReSharper disable once UnusedType.Global
    public class CrearUsuarioComando : ModuleBase<SocketCommandContext>
    {
        private Fachada fachada = Fachada.Instancia;
        /// <summary>
        /// Implementa el comando 'crearUsuario' que crea un Usuario. Este comando es para la historia 19.
        /// </summary>
        [Command("crearUsuario")]
        [Summary(
            "Crea un Usuario")]
        // ReSharper disable once UnusedMember.Global
        public async Task ExecuteAsync([Remainder][Summary("xxx")]string parametros)
        {
            string[] parte = parametros.Split(',');
            if (parte.Length != 3)
            {
                await ReplyAsync($"Se nececitan 3 parametros: usuarioId, nombre y adminId. Recuerda separar los parametros por ','");
            }
            else
            {
                string mensaje = fachada.CrearUsuario(parte[0], parte[1], parte[2]);
                
                await ReplyAsync(mensaje);
            }
        }
    }
}