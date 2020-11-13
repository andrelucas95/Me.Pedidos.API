using System.Threading.Tasks;
using Me.Pedidos.Domain.DomainObjects;
using Microsoft.AspNetCore.Mvc;

namespace Me.Pedidos.API.Models.Results
{
    public class ItemResultJson : IActionResult
    {
        public ItemResultJson(ItemPedido itemPedido)
        {
            Descricao = itemPedido.Descricao;
            PrecoUnitario = itemPedido.PrecoUnitario;
            Quantidade = itemPedido.Quantidade;
        }

        public string Descricao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }

        public Task ExecuteResultAsync(ActionContext context)
        {
            return new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}