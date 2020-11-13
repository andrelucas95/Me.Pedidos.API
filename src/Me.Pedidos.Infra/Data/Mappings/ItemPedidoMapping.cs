using Me.Pedidos.Domain.DomainObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Me.Pedidos.Infra.Data.Mappings
{
    public class ItemPedidoMapping : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Descricao)
                .HasMaxLength(150);
        }
    }
}