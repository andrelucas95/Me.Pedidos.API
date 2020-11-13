using System.Collections.Generic;
using System.Linq;
using Me.Pedidos.Domain.Core;

namespace Me.Pedidos.Domain.DomainObjects
{
    public class Pedido : Entity, IAggregateRoot
    {
        protected Pedido() { }

        public Pedido(string codigoPedido, List<ItemPedido> itens)
        {
            CodigoPedido = codigoPedido;
            _itens = itens;
            _status = new List<string>();
        }

        public string CodigoPedido { get; private set; }
        public decimal Total => _itens.Select(i => i.Quantidade * i.PrecoUnitario).Sum();
        public decimal? TotalPago { get; private set; }
        private readonly List<ItemPedido> _itens;
        public IReadOnlyCollection<ItemPedido> Itens => _itens;
        private readonly List<string> _status;
        public IReadOnlyCollection<string> Status => _status;
        public int QuantidadePedidos => _itens.Select(i => i.Quantidade).Sum();
        public int? QuantidadeItensAprovados { get; private set; }

        public void AtualizarStatus(decimal valorAprovado, int itensAprovados)
        {
            TotalPago = valorAprovado;
            QuantidadeItensAprovados = itensAprovados;
        }

        public bool EhAprovado() => (TotalPago == Total && QuantidadeItensAprovados == QuantidadePedidos);
        public bool EhAprovadoQtdAMenor() => (TotalPago == Total && QuantidadeItensAprovados < QuantidadePedidos);
        public bool EhAprovadoValorAMenor() => (TotalPago < Total && QuantidadeItensAprovados == QuantidadePedidos);
        public bool EhAprovadoValorAMaior() => (TotalPago > Total && QuantidadeItensAprovados > QuantidadePedidos);
        public bool EhAprovadoQtdAMaior() => (TotalPago > Total && QuantidadeItensAprovados > QuantidadePedidos);
        public bool EhReprovado() => (TotalPago == 0 && QuantidadeItensAprovados == 0);

        public List<string> ObterStatus()
        {
            if (EhAprovado()) _status.Add("APROVADO");
            if (EhAprovadoQtdAMenor()) _status.Add("APROVADO_QTD_A_MENOR");
            if (EhAprovadoValorAMenor()) _status.Add("APROVADO_VALOR_A_MENOR");
            if (EhAprovadoValorAMaior()) _status.Add("APROVADO_VALOR_A_MAIOR");
            if (EhAprovadoQtdAMaior()) _status.Add("APROVADO_QTD_A_MAIOR");
            if (EhReprovado()) _status.Add("REPROVADO");
            
            return Status.ToList();
        }
    }
}