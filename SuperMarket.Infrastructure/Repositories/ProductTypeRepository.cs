using Microsoft.EntityFrameworkCore;
using SuperMarkerAPI.Data;
using SuperMarkerAPI.Models;
using SuperMarket.Core.Interfaces;

namespace SuperMarket.Infrastructure.Repositories
{
    public class ProductTypeRepository(ApplicationDbContext dbContext) : IProductTypeRepository
    {
        public async Task<ProductTypeEntity> AddProductTypeAsync(ProductTypeEntity productTypeEntity)
        {
            productTypeEntity.IDType = Guid.NewGuid();
            dbContext.ProductTypes.Add(productTypeEntity);
            await dbContext.SaveChangesAsync();
            return productTypeEntity;
        }

        public async Task<bool> DeleteProductTypeAsync(Guid ProductTypeID)
        {
            var query = await dbContext.ProductTypes.FirstOrDefaultAsync(x => x.IDType == ProductTypeID);
            if (query is not null)
            {
                dbContext.ProductTypes.Remove(query);
                return await dbContext.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<IEnumerable<ProductTypeEntity>> GetProductTypeAsync(string? ProductTypeName)
        {
            var query = dbContext.ProductTypes.AsQueryable();
            if (ProductTypeName is not null)
            {
                query = query.Where(p => p.TypeName.Contains(ProductTypeName));
            }
            return await query.ToListAsync();
        }

        public async Task<ProductTypeEntity> UpdateProductTypeAsync(Guid ProductTypeID, ProductTypeEntity productTypeEntity)
        {
            var query = await dbContext.ProductTypes.FirstOrDefaultAsync(x => x.IDType == ProductTypeID);
            if (query is not null)
            {
                query.TypeName = productTypeEntity.TypeName;
                await dbContext.SaveChangesAsync();
                return query;
            }
            return productTypeEntity;
        }
    }
}
