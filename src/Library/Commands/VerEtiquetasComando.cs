using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Library;


namespace Ucu.Poo.DiscordBot.Commands
{

    /// <summary>
    /// Esta clase muestra todas las Etiquetas que hay.
    /// Devuele una lista con todos las Etiquetas.
    /// </summary>
// ReSharper disable once UnusedType.Global
    public class VerEtiquetasComando : ModuleBase<SocketCommandContext>
    {
        private Fachada fachada = Fachada.Instancia;
        /// <summary>
        /// Implementa el comando 'verEtiquetas' que muestra una lista de todas las Etiquetas.
        /// </summary>
        [Command("verEtiquetas")]
        [Summary(
            "Muestra todas las Etiquetas")]
        // ReSharper disable once UnusedMember.Global
        public async Task ExecuteAsync()
        {
            string[] etiquetas = fachada.VerEtiquetas().Split(',');
            string resultado = "Etiquetas totales son: \n\n";
                
            foreach (string etiqueta in etiquetas)
            {
                resultado += $"{etiqueta}\n";
            }

            if (etiquetas.Length == 1 && etiquetas[0] == "")
            {
                resultado = "No hay etiquetas.";
            }
                
            await ReplyAsync(resultado);
        }
    }
}