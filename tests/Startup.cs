using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Me.Pedidos.Domain.Repositories;
using Me.Pedidos.Domain.Services;
using Me.Pedidos.Infra.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using tests.Fakes;

namespace tests
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var options = new DbContextOptionsBuilder<PedidosDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            services.AddSingleton(serviceProvider => 
            {
                var dbContext = new PedidosDbContext(options);
                
                return dbContext;
            });
            
            services.AddSingleton<IPedidoRepository, FakePedidoRepository>();
            services.AddSingleton<AtualizarPedidoService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
