using System.Collections.Generic;
using System.Threading.Tasks;
using Me.Pedidos.Domain.DomainObjects;
using Microsoft.AspNetCore.Mvc;

namespace Me.Pedidos.API.Models.Results
{
    public class PedidoAtualizadoResult : IActionResult
    {

        public PedidoAtualizadoResult(Pedido pedido)
        {
            CodigoPedido = pedido.CodigoPedido;
            Status = pedido.ObterStatus();
        }
        
        public string CodigoPedido { get; set; }
        public List<string> Status { get; set; }
        public Task ExecuteResultAsync(ActionContext context)
        {
            return new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}