using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Context
{
    public class ComercianteContext : DbContext
    {
        public ComercianteContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ComercianteDB");
            ConfigureTypes(modelBuilder);
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