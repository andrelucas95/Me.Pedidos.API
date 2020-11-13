using System;
using Me.Pedidos.Domain.Repositories;
using Me.Pedidos.Domain.Services;
using Me.Pedidos.Infra.Data;
using Me.Pedidos.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Me.Pedidos.API.Configuration
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //Context
            var options = new DbContextOptionsBuilder<PedidosDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            services.AddSingleton(serviceProvider => 
            {
                var dbContext = new PedidosDbContext(options);
                
                return dbContext;
            });

            //Repositorios
            services.AddSingleton<IPedidoRepository, PedidoRepository>();

            //Servicos
            services.AddSingleton<AtualizarPedidoService>();
        }
    }
}