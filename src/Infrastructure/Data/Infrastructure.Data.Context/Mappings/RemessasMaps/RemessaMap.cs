using Domain.AggregatesModels.RemessasAggregates;
using Infrastructure.Data.Context.Mappings.BaseMaps;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Context.Mappings.RemessasMaps
{
    public class RemessaMap : EntityBaseMap<Remessa>
    {
        public override void Configure(EntityTypeBuilder<Remessa> builder)
        {
            builder
                .Property(p => p.DataPedido)
                .IsRequired();

            builder
                .Property(p => p.DataEntrega);

            builder
                .Property(p => p.Valor)
                .IsRequired();

            builder
                .Property(p => p.Desconto)
                .IsRequired();

            builder
                .Property(p => p.ValorFinal)
                .IsRequired();

            builder
                .ToTable("Remessas");
        }
    }
}