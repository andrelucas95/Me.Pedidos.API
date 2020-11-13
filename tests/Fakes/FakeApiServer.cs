using Me.Pedidos.Domain.Repositories;
using Me.Pedidos.Infra.Data;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace tests.Fakes
{
    public class FakeApiServer : TestServer
    {
        public FakeApiServer() : base(new Program().CreateWebHostBuilder()) { }

        public PedidosDbContext Database => Host.Services.GetService<PedidosDbContext>();
        public FakePedidoRepository pedidoRepository => Host.Services.GetService<IPedidoRepository>() as FakePedidoRepository;
    }
}