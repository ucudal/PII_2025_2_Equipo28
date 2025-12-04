using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Library;


namespace Ucu.Poo.DiscordBot.Commands
{

    /// <summary>
    /// Este comando devuelve una lista con los clientes de un usuario cuyo total de ventas están dentro de un rango de montos
    /// Devuele una lista con cliente y su información correspondiente
    /// </summary>
// ReSharper disable once UnusedType.Global
    public class VerClientesConVentasEnRangoDeMontosComando : ModuleBase<SocketCommandContext>
    {
        private Fachada fachada = Fachada.Instancia;
        /// <summary>
        /// Implementa el comando 'verClientesConVentasEnMonto' que devuelve una lista con los clientes con ventas dentro de un rango de montos. Este comando es para la defensa del Proyecto.
        /// </summary>
        [Command("verClientesConVentasEnRangoDeMontos")]
        [Summary(
            "Devuelve una lista de Clientes con ventas dentro de cierto rango de montos.")]
        // ReSharper disable once UnusedMember.Global
        public async Task ExecuteAsync([Remainder][Summary("xxx")]string parametros)
        {
            string[] parte = parametros.Split(',');
            if (parte.Length != 3)
            {
                await ReplyAsync($"Se nececitan 2 parametros: usuarioId, montoInicial y montoFinal. Recuerda separar los parametros por ','");
            }
            else
            {
                string resultado = fachada.ClientesConVentasDentroDeRangoDeMontos(parte[0], parte[1], parte[2]);
                string[] clientes = resultado.Split(',');

                string mensaje = "Los clientes con su total de ventas dentro del rango de montos son: \n\n";
                foreach (string cliente in clientes)
                {
                    mensaje += $"{cliente}\n\n";
                }

                if (clientes.Length == 1 && string.IsNullOrEmpty(clientes[0]))
                {
                    mensaje = "No hay clientes con ventas totales dentro de ese rango de montos";
                } 
                await ReplyAsync(mensaje);
            }
        }
    }
}