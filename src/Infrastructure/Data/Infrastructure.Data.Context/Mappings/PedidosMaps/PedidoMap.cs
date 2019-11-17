using Domain.AggregatesModels.PedidosAggregates;
using Infrastructure.Data.Context.Mappings.BaseMaps;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Context.Mappings.PedidosMaps
{
    public class PedidoMap : EntityBaseMap<Pedido>
    {
        public override void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder
                .Property(p => p.Valor)
                .IsRequired();

            builder
                .HasOne(h => h.Cliente)
                .WithMany(w => w.Pedidos)
                .IsRequired();

            builder
                .HasOne(h => h.Remessa)
                .WithMany(w => w.Pedidos)
                .IsRequired();

            builder
                .HasOne(h => h.FormaPagamento)
                .WithMany()
                .IsRequired();

            builder
                .ToTable("Pedidos");
        }
    }
}