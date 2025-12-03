using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Library;


namespace Ucu.Poo.DiscordBot.Commands
{

    /// <summary>
    /// Esta clase muestra todos los usuarios que hay.
    /// Devuele una lista con todos los usuarios.
    /// </summary>
// ReSharper disable once UnusedType.Global
    public class VerUsuariosComando : ModuleBase<SocketCommandContext>
    {
        private Fachada fachada = Fachada.Instancia;
        /// <summary>
        /// Implementa el comando 'verUsuarios' que muestra una lista de todos los usuarios.
        /// </summary>
        [Command("verUsuarios")]
        [Summary(
            "Muestra todos los usuarios")]
        // ReSharper disable once UnusedMember.Global
        public async Task ExecuteAsync()
        {
            string[] usuarios = fachada.VerUsuarios().Split(',');
            bool hayClientes = false; 
            string resultado = "Usuarios totales son: \n";
                
            foreach (string usuario in usuarios)
            {
                hayClientes = true;
                resultado += usuario + "\n";
            }

            if (hayClientes == false)
            {
                resultado = "No hay usuarios.";
            }
                
            await ReplyAsync(resultado);
        }
    }
}