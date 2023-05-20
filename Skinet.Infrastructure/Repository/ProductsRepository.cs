using Microsoft.EntityFrameworkCore;
using Skinet.Core.Entities;
using Skinet.Core.Interfaces.IRepository;

namespace Skinet.Infrastructure.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _dbContext.Products
                .Include(p => p.ProductType)
                .Include(p => p.ProductBrand)
                .AsSplitQuery()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _dbContext.Products
                .Include(p => p.ProductType)
                .Include(p => p.ProductBrand)
                .AsSplitQuery()
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _dbContext.ProductBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _dbContext.ProductTypes.ToListAsync();
        }
    }
}
