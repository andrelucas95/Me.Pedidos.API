using System.Threading.Tasks;
using Me.Pedidos.Domain.Services;
using tests.Factories;
using tests.Fakes;
using Xunit;

namespace tests.Functional
{
    public sealed class AtualizacaoPedidoTest
    {
        private readonly FakeApiServer _server;

        public AtualizacaoPedidoTest()
        {
            _server = new FakeApiServer();
        }

        [Fact]
        public async Task DeveSerAprovado()
        {
            _server.pedidoRepository.Add(CreatePedidoFactory.Build());
            await _server.pedidoRepository.UnitOfWork.Commit();

            var pedidoService = new AtualizarPedidoService(_server.pedidoRepository);
            var resultado = await pedidoService.Process(new AtualizacaoPedido().Aprovado().Build());

            Assert.Equal(resultado, true);
            Assert.Equal(pedidoService.Pedido.ObterStatus().Contains("APROVADO"), true);
        }

        [Fact]
        public async Task DeveSerAprovadoValorAMenor()
        {
            _server.pedidoRepository.Add(CreatePedidoFactory.Build());
            await _server.pedidoRepository.UnitOfWork.Commit();

            var pedidoService = new AtualizarPedidoService(_server.pedidoRepository);
            var resultado = await pedidoService.Process(new AtualizacaoPedido().AprovadoValorAMenor().Build());

            Assert.Equal(resultado, true);
            Assert.Equal(pedidoService.Pedido.ObterStatus().Contains("APROVADO_VALOR_A_MENOR"), true);
        }

        [Fact]
        public async Task DeveSerAprovadoValorEQtdAMaior()
        {
            _server.pedidoRepository.Add(CreatePedidoFactory.Build());
            await _server.pedidoRepository.UnitOfWork.Commit();

            var pedidoService = new AtualizarPedidoService(_server.pedidoRepository);
            var resultado = await pedidoService.Process(new AtualizacaoPedido().AprovadoValorEQtdAMaior().Build());

            Assert.Equal(resultado, true);
            Assert.Equal(pedidoService.Pedido.ObterStatus().Contains("APROVADO_VALOR_A_MAIOR"), true);
            Assert.Equal(pedidoService.Pedido.ObterStatus().Contains("APROVADO_QTD_A_MAIOR"), true);
        }

        [Fact]
        public async Task DeveSerAprovadoQtdAMenor()
        {
            _server.pedidoRepository.Add(CreatePedidoFactory.Build());
            await _server.pedidoRepository.UnitOfWork.Commit();

            var pedidoService = new AtualizarPedidoService(_server.pedidoRepository);
            var resultado = await pedidoService.Process(new AtualizacaoPedido().AprovadoQtdAMenor().Build());

            Assert.Equal(resultado, true);
            Assert.Equal(pedidoService.Pedido.ObterStatus().Contains("APROVADO_QTD_A_MENOR"), true);
        }

        [Fact]
        public async Task DeveSerReprovado()
        {
            _server.pedidoRepository.Add(CreatePedidoFactory.Build());
            await _server.pedidoRepository.UnitOfWork.Commit();

            var pedidoService = new AtualizarPedidoService(_server.pedidoRepository);
            var resultado = await pedidoService.Process(new AtualizacaoPedido().Reprovado().Build());

            Assert.Equal(resultado, true);
            Assert.Equal(pedidoService.Pedido.ObterStatus().Contains("REPROVADO"), true);
        }

        [Fact]
        public async Task DeveSerInvalido()
        {
            _server.pedidoRepository.Add(CreatePedidoFactory.Build());
            await _server.pedidoRepository.UnitOfWork.Commit();

            var pedidoService = new AtualizarPedidoService(_server.pedidoRepository);
            var resultado = await pedidoService.Process(new AtualizacaoPedido().CodigoPedidoInvalido().Build());

            Assert.Equal(resultado, false);
            Assert.Equal(pedidoService.CodigoPedidoInvalido, true);
        }
    }
}