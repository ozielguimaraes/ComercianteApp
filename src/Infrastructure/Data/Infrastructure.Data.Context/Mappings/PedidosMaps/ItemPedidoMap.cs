using Domain.AggregatesModels.PedidosAggregates;
using Infrastructure.Data.Context.Mappings.BaseMaps;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Context.Mappings.PedidosMaps
{
    public class ItemPedidoMap : EntityBaseMap<ItemPedido>
    {
        public override void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder
                .HasOne(h => h.Pedido)
                .WithMany(w => w.ItensPedido)
                .IsRequired();

            builder
                .HasOne(h => h.Produto)
                .WithMany()
                .IsRequired();

            builder
                .ToTable("ItensPedido");
        }
    }
}