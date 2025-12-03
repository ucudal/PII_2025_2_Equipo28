using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Library;


namespace Ucu.Poo.DiscordBot.Commands
{

    /// <summary>
    /// Esta clase muestra todos los Administradores que hay.
    /// Devuele una lista con todos las Administradores.
    /// </summary>
// ReSharper disable once UnusedType.Global
    public class VerAdministradoresComando : ModuleBase<SocketCommandContext>
    {
        private Fachada fachada = Fachada.Instancia;
        /// <summary>
        /// Implementa el comando 'verAdministradores' que muestra una lista de todos los Administradores.
        /// </summary>
        [Command("verAdministradores")]
        [Summary(
            "Muestra todas las Administradores")]
        // ReSharper disable once UnusedMember.Global
        public async Task ExecuteAsync()
        {
            string[] administradores = fachada.VerAdministradores().Split(',');
            string resultado = "Administradores totales son: \n\n";
                
            foreach (string administrador in administradores)
            {
                resultado += administrador + "\n";
            }

            if (administradores.Length == 0)
            {
                resultado = "No hay administradores.";
            }
                
            await ReplyAsync(resultado);
        }
    }
}