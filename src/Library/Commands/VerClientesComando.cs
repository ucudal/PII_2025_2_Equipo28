using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Library;


namespace Ucu.Poo.DiscordBot.Commands
{

    /// <summary>
    /// Esta clase muestra todos los clientes que hay.
    /// Devuele una lista con todos los clientes.
    /// </summary>
// ReSharper disable once UnusedType.Global
    public class VerClientesComando : ModuleBase<SocketCommandContext>
    {
        private Fachada fachada = Fachada.Instancia;
        /// <summary>
        /// Implementa el comando 'verClientes' que muestra una lista de todos los clientes. Este comando es para la historia 5.
        /// </summary>
        [Command("verClientes")]
        [Summary(
            "Muestra todos los clientes")]
        // ReSharper disable once UnusedMember.Global
        public async Task ExecuteAsync()
        {
            string[] clientes = fachada.VerClientes().Split(',');
            bool hayClientes = false; 
            string resultado = "Clientes totales son: \n";
                
            foreach (string cliente in clientes)
            {
                hayClientes = true;
                resultado += cliente.ToString() + "\n";
            }

            if (hayClientes == false)
            {
                resultado = "No hay clientes.";
            }
                
            await ReplyAsync(resultado);
        }
    }
}