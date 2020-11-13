using System.Threading.Tasks;
using Me.Pedidos.Domain.DomainObjects;
using Me.Pedidos.Domain.Repositories;

namespace Me.Pedidos.Domain.Services
{
    public class AtualizarPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public AtualizarPedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public AtualizacaoPedido AtualizacaoPedido { get; private set; }
        public Pedido Pedido { get; private set; }
        public bool CodigoPedidoInvalido { get; private set; }
        public bool Reprovado { get; private set; }
        public bool Aprovado { get; private set; }
        public bool AprovadoValorAMenor { get; private set; }
        public bool AprovadoQtdAMenor { get; private set; }
        public bool AprovadoValorAMaior { get; private set; }
        public bool AprovadoQtdAMaior { get; set; }

        public async Task<bool> Process(AtualizacaoPedido atualizacaoPedido)
        {
            AtualizacaoPedido = atualizacaoPedido;

            await ObterPedido();
            
            if (CodigoPedidoInvalido) return false;

            ObterStatusPedido();

            if (Reprovado) return false;
            if (Aprovado) return false;
            if (AprovadoValorAMenor) return false;
            if (AprovadoQtdAMenor) return false;
            if (AprovadoValorAMaior) return false;
            if (AprovadoQtdAMaior) return false;

            Pedido.AtualizarStatus(atualizacaoPedido.ValorAprovado, atualizacaoPedido.ItensAprovados);
            return await Save();
        }

        private async Task ObterPedido()
        {
            Pedido = await _pedidoRepository.BuscarPorCodigo(AtualizacaoPedido.CodigoPedido);
            if (Pedido == null) CodigoPedidoInvalido = true;
        }

        private void ObterStatusPedido()
        {
            Reprovado = Pedido.EhReprovado();
            Aprovado = Pedido.EhAprovado();
            AprovadoValorAMenor = Pedido.EhAprovadoValorAMenor();
            AprovadoQtdAMenor = Pedido.EhAprovadoQtdAMenor();
            AprovadoValorAMaior = Pedido.EhAprovadoValorAMaior();
            AprovadoQtdAMaior = Pedido.EhAprovadoValorAMaior();
        }

        private async Task<bool> Save()
        {
            return await _pedidoRepository.UnitOfWork.Commit();
        }
    }
}