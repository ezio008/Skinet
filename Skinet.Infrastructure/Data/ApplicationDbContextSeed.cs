using Skinet.Core.Entities;
using System.Text.Json;

namespace Skinet.Infrastructure.Data
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext dbContext)
        {
            if (!dbContext.ProductBrands.Any())
            {
                var brandsData = File.ReadAllText("../Skinet.Infrastructure/Data/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                dbContext.ProductBrands.AddRange(brands);
            }

            if (!dbContext.ProductTypes.Any())
            {
                var typesData = File.ReadAllText("../Skinet.Infrastructure/Data/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                dbContext.ProductTypes.AddRange(types);
            }

            if (!dbContext.Products.Any())
            {
                var productsData = File.ReadAllText("../Skinet.Infrastructure/Data/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                dbContext.Products.AddRange(products);
            }

            if (dbContext.ChangeTracker.HasChanges())
            {
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
