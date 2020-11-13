using Me.Pedidos.Domain.Core;

namespace Me.Pedidos.Domain.DomainObjects
{
    public class ItemPedido : Entity
    {
        protected ItemPedido() { }

        public ItemPedido(string descricao, decimal precoUnitario, int quantidade)
        {
            Descricao = descricao;
            PrecoUnitario = precoUnitario;
            Quantidade = quantidade;
        }

        public int PedidoId { get; private set; }
        public string Descricao { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public int Quantidade { get; private set; }

        public Pedido Pedido { get; private set; }
    }
}