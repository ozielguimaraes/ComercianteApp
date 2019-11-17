using Domain.AggregatesModels.ProdutosAggregates;
using Infrastructure.Data.Context.Mappings.BaseMaps;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Context.Mappings.ProdutosMaps
{
    public class ProdutoMap : EntityBaseMap<Produto>
    {
        public override void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder
                .Property(p => p.IdFornecedor)
                .IsRequired();

            builder
                .Property(p => p.Descricao)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(p => p.Quantidade)
                .IsRequired();

            builder
                .Property(p => p.UnidadeMedida)
                .IsRequired();

            builder
                .Property(p => p.PrecoCusto)
                .IsRequired();

            builder
                .Property(p => p.PrecoVenda)
                .IsRequired();

            builder
                .HasAlternateKey(h => h.IdFornecedor);

            builder
                .ToTable("Produtos");
        }
    }
}