//using Infrastructure.Data.Context.Mappings.BaseMaps;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infrastructure.Data.Context.Mappings.PagamentosMaps
//{
//    public class PagamentoMap : EntityBaseMap<Pagamento>
//    {
//        public override void Configure(EntityTypeBuilder<Pagamento> builder)
//        {
//            builder
//                .Property(p => p.Nome)
//                .HasMaxLength(255)
//                .IsRequired();

//            builder
//                .ToTable("FormasPagamento");
//        }
//    }
//}