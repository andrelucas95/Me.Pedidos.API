using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Me.Pedidos.Domain.DomainObjects;
using Microsoft.AspNetCore.Mvc;

namespace Me.Pedidos.API.Models.Results
{
    public class PedidoResultJson : IActionResult
    {
        public PedidoResultJson(Pedido pedido)
        {
            CodigoPedido = pedido.CodigoPedido;
            Itens = pedido.Itens.Select(i => new ItemResultJson(i)).ToList();    
        }

        public string CodigoPedido { get; set; }
        public List<ItemResultJson> Itens { get; set; }

        public Task ExecuteResultAsync(ActionContext context)
        {
            return new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}