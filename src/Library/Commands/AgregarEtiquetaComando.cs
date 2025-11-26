using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Library;


namespace Ucu.Poo.DiscordBot.Commands
{

    /// <summary>
    /// Esta clase agrega una Etiqueta a un cliente.
    /// Devuele una confirmación de si se agrego o no.
    /// </summary>
// ReSharper disable once UnusedType.Global
    public class AgregarEtiquetaComando : ModuleBase<SocketCommandContext>
    {
        private Fachada fachada = Fachada.Instancia;
        /// <summary>
        /// Implementa el comando 'agregarEtiqueta' que agrega una Etiqueta a un cliente. Este comando es para la historia 13.
        /// </summary>
        [Command("agregarEtiqueta")]
        [Summary(
            "Agrega una etiqueta a un cliente")]
        // ReSharper disable once UnusedMember.Global
        public async Task ExecuteAsync([Remainder][Summary("xxx")]string parametros)
        {
            string[] parte = parametros.Split(',');
            if (parte.Length != 3)
            {
                await ReplyAsync($"Se nececitan 3 parametros: clienteId, etiqueta y usuarioId. Recuerda separar los parametros por ','");
            }
            else
            {
                string mensaje = fachada.AgregarEtiquetaCliente(parte[0], parte[1], parte[2]);
                
                await ReplyAsync(mensaje);
            }
        }
    }
}