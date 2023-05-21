using Microsoft.EntityFrameworkCore;
using Skinet.Core.Entities;
using System.Reflection;

namespace Skinet.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                foreach (var entityTypes in modelBuilder.Model.GetEntityTypes())
                {
                    var propierties = entityTypes.ClrType
                        .GetProperties()
                        .Where(p => p.PropertyType == typeof(decimal));

                    foreach (var property in propierties)
                    {
                        modelBuilder.Entity(entityTypes.Name)
                            .Property(property.Name)
                            .HasConversion<double>();
                    }
                }
            }
        }
    }
}
