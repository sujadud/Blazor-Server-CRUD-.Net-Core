using BlazorServerCRUD.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerCRUD
{
    public class ProductService
    {
        private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

        public ProductService(IDbContextFactory<AppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.products.ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product?> UpdateProductAsync(Product updateProduct)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            var existingProduct = await context.products
                .FirstOrDefaultAsync(x => x.Id == updateProduct.Id);

            if (existingProduct is not null)
            {
                existingProduct.Name = updateProduct.Name;
                existingProduct.Price = updateProduct.Price;
                await context.SaveChangesAsync();
                return existingProduct;
            }
            return null;
        }


    }
}
