using Domain.AggregatesModels.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Context.Mappings.BaseMaps
{
    public class EntityBaseMap<T> : IEntityTypeConfiguration<T> where T : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder
                .Property(p => p.Id)
                .IsRequired()
                .UseIdentityColumn();

            builder
                .OwnsOne(o => o.Metadata, x =>
                {
                    x.Property(d => d.Criacao).IsRequired();
                    x.Property(d => d.Alteracao);
                    x.Property(d => d.Exclusao);

                    x.Ignore(p => p.Ativo);
                });

            builder
                .HasKey(h => h.Id);
        }
    }
}