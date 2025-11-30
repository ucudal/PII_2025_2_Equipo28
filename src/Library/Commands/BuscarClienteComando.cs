using System.Collections.Generic;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Library;


namespace Ucu.Poo.DiscordBot.Commands
{

    /// <summary>
    /// Esta clase busca clientes.
    /// Devuele una lista con todos los resultados de la busqueda.
    /// </summary>
    // ReSharper disable once UnusedType.Global
    public class BuscarClienteComando : ModuleBase<SocketCommandContext>
    {
        private Fachada fachada = Fachada.Instancia;
        /// <summary>
        /// Implementa el comando 'buscarCliente' que busca un cliente. Este comando es para la historia 4.
        /// </summary>
        [Command("buscarCliente")]
        [Summary(
            "Busca un cliente")]
        // ReSharper disable once UnusedMember.Global
        public async Task ExecuteAsync([Remainder][Summary("xxx")]string parametros)
        {
            string[] parte = parametros.Split(',');
            if (parte.Length != 2)
            {
                await ReplyAsync($"Se nececitan 2 parametros: atributo y valorBusqueda. Recurda separar los parametros por ','");
            }
            else
            {
                List<Cliente> clientes = fachada.BuscarCliente(parte[0], parte[1]);
                bool hayClientes = false; 
                string resultado = "Resultados de la búsqueda: \n";
                
                foreach (Cliente cliente in clientes)
                {
                    hayClientes = true;
                    resultado += cliente.ToString() + "\n";
                }

                if (hayClientes == false)
                {
                    resultado = "No se encontraron resultados para esa busqueda.";
                }
                
                await ReplyAsync(resultado);
            }
        }
    }
}