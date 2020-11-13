using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Me.Pedidos.API.Models.Attributes;
using Me.Pedidos.Domain.DomainObjects;

namespace Me.Pedidos.API.Models.Commands
{
    public class CriarPedidoCommand
    {
        [Required(ErrorMessage = "Informe o código do pedido")]
        public string CodigoPedido { get; set; }

        [RequiredList(ErrorMessage = "Informe os itens do pedido")]
        public List<ItemPedidoCommand> Itens { get; set; }

        public Pedido Map() => new Pedido(CodigoPedido, Itens.Select(i => i.Map()).ToList());

        public class ItemPedidoCommand
        {
            [Required(ErrorMessage = "Informe a descrição do item")]
            public string Descricao { get; set; }

            [Required(ErrorMessage = "Informe o preço do item")]
            [Range(0, int.MaxValue, ErrorMessage = "Informe um valor válido para o preço")]
            public decimal PrecoUnitario { get; set; }

            [Required(ErrorMessage = "Informe a quantidade do item")]
            public int Quantidade { get; set; }

            public ItemPedido Map() => new ItemPedido(Descricao, PrecoUnitario, Quantidade);
        }
    }
}