using Domain.AggregatesModels.ClientesAggregates;
using Infrastructure.Data.Context.Mappings.BaseMaps;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Context.Mappings.ClientesMaps
{
    public class ClienteMap : EntityBaseMap<Cliente>
    {
        public override void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder
                .Property(p => p.Nome)
                .HasMaxLength(255)
                .IsRequired();

            builder
                .ToTable("Clientes");
        }
    }
}