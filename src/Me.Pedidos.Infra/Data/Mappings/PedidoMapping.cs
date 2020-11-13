using Me.Pedidos.Domain.DomainObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Me.Pedidos.Infra.Data.Mappings
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasMany(p => p.Itens)
                .WithOne(i => i.Pedido)
                .HasForeignKey(i => i.PedidoId);
        }
    }
}