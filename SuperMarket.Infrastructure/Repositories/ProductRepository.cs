using Microsoft.EntityFrameworkCore;
using SuperMarkerAPI.Data;
using SuperMarkerAPI.Models;
using SuperMarket.Core.Interfaces;

namespace SuperMarket.Infrastructure.Repositories
{
    public class ProductRepository(ApplicationDbContext dbContext) : IProductRepository
    {   
        public async Task<IEnumerable<ProductEntity>> GetProductByNameAndTypeAsync(string Name = "", string Type = "")
        {
            var query = dbContext.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(Name))
            {
                var lowerName = Name.ToLower();
                query = query.Where(p => p.NameProduct.ToLower().Contains(lowerName));
            }

            if (!string.IsNullOrWhiteSpace(Type))
            {
                var lowerType = Type.ToLower();
                query = query.Where(p => p.productType != null &&
                                         p.productType.TypeName.ToLower().Contains(lowerType));
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<ProductEntity>> GetProductByPriceAsync(Decimal? maxPrice = null, Decimal? minPrice = null)
        {
            var query = dbContext.Products.AsQueryable();
            if (minPrice.HasValue)
            {
                query = query.Where(p => p.ProductPrice >= minPrice.Value);
            }
            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.ProductPrice <= maxPrice.Value);
            }
            return await query.ToListAsync();
        }
        public async Task<ProductEntity> AddProductAsync(ProductEntity product)
        {
            dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync();
            return product;
        }
        public async Task<ProductEntity> UpdateProductAsync(ProductEntity product)
        {
            dbContext.Products.Update(product);
            await dbContext.SaveChangesAsync();
            return product;
        }
        public async Task<bool> DeleteProductAsync(ProductEntity product)
        {
            dbContext.Products.Remove(product);
            return await dbContext.SaveChangesAsync() > 0;
          
        }
        public async Task<ProductEntity?> GetByIDAsync(Guid ProductID)
        {
            return await dbContext.Products.FindAsync(ProductID);
        }
    }
}
