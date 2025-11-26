using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Library;


namespace Ucu.Poo.DiscordBot.Commands
{

    /// <summary>
    /// Esta clase crea una Etiqueta.
    /// Devuele una confirmación de si se creo o no.
    /// </summary>
// ReSharper disable once UnusedType.Global
    public class CrearEtiquetaComando : ModuleBase<SocketCommandContext>
    {
        private Fachada fachada = Fachada.Instancia;
        /// <summary>
        /// Implementa el comando 'crearEtiqueta' que crea una Etiqueta. Este comando es para la historia 12.
        /// </summary>
        [Command("crearEtiqueta")]
        [Summary(
            "Crea una etiqueta")]
        // ReSharper disable once UnusedMember.Global
        public async Task ExecuteAsync([Remainder][Summary("xxx")]string parametros)
        {
            string[] parte = parametros.Split(',');
            if (parte.Length != 2)
            {
                await ReplyAsync($"Se nececitan 2 parametros: etiqueta y usuarioId. Recuerda separar los parametros por ','");
            }
            else
            {
                string mensaje = fachada.CrearEtiqueta(parte[0], parte[1]);
                
                await ReplyAsync(mensaje);
            }
        }
    }
}