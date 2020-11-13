using System.ComponentModel.DataAnnotations;
using Me.Pedidos.API.Models.Attributes;
using Me.Pedidos.Domain.Services;

namespace Me.Pedidos.API.Models.Commands
{
    public class AtualizarPedidoCommand
    {
        [Required(ErrorMessage="Informe um valor para status")]
        [PedidoStatus(AllowableStatus = new [] { "APROVADO", "REPROVADO" })]
        public string Status { get; set; }

        [Required(ErrorMessage="Informe um valor para itens aprovados")]
        public int ItensAprovados { get; set; }

        [Required(ErrorMessage="Informe um valor para valor aprovado")]
        [Range(0, int.MaxValue, ErrorMessage = "Informe um valor válido para o valor aprovado")]
        public decimal ValorAprovado { get; set; }

        [Required(ErrorMessage="Informe um valor para o codigo do pedido")]
        public string CodigoPedido { get; set; }

        public AtualizacaoPedido Map()
        {
            return new AtualizacaoPedido(Status, ItensAprovados, ValorAprovado, CodigoPedido);
        }
    }
}