using Domain.AggregatesModels.ClientesAggregates;
using Domain.AggregatesModels.PedidosAggregates;
using Domain.AggregatesModels.ProdutosAggregates;
using Domain.AggregatesModels.RemessasAggregates;
using Infrastructure.Data.Context.Mappings.ClientesMaps;
using Infrastructure.Data.Context.Mappings.PedidosMaps;
using Infrastructure.Data.Context.Mappings.ProdutosMaps;
using Infrastructure.Data.Context.Mappings.RemessasMaps;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Data.Context
{
    public class ComercianteContext : DbContext
    {
        public ComercianteContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; private set; }
        public DbSet<Pedido> Pedidos { get; private set; }
        public DbSet<ItemPedido> ItensPedidos { get; private set; }
        public DbSet<Produto> Produtos { get; private set; }
        public DbSet<Remessa> Remessas { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ComercianteDB");
            ConfigureTypes(modelBuilder);

            modelBuilder
                .ApplyConfiguration(new ClienteMap())
                .ApplyConfiguration(new PedidoMap())
                .ApplyConfiguration(new ItemPedidoMap())
                .ApplyConfiguration(new ProdutoMap())
                .ApplyConfiguration(new RemessaMap());
        }

        private void ConfigureTypes(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(string)))
            {
                property.SetIsUnicode(true);
            }
        }
    }
}