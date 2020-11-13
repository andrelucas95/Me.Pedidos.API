using System.Threading.Tasks;
using Me.Pedidos.Domain.Core;
using Me.Pedidos.Domain.DomainObjects;
using Microsoft.EntityFrameworkCore;

namespace Me.Pedidos.Infra.Data
{
    public class PedidosDbContext : DbContext, IUnitOfWork
    {
        public PedidosDbContext(DbContextOptions<PedidosDbContext> options) : base(options) { }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> itemPedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PedidosDbContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}