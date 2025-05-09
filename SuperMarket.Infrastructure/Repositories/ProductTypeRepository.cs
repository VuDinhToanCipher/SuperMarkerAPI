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
            dbContext.ProductTypes.Add(productTypeEntity);
            await dbContext.SaveChangesAsync();
            return productTypeEntity;
        }

        public async Task<bool> DeleteProductTypeAsync(ProductTypeEntity productTypeEntity)
        {
            dbContext.ProductTypes.Remove(productTypeEntity);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> ExistAsync(Guid ProductTypeID)
        {
            return await dbContext.ProductTypes.AnyAsync(pt => pt.IDType == ProductTypeID);
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

        public async Task<ProductTypeEntity?> GetProductTypeByIDAsync(Guid ProductTypeID)
        {
            var result = await dbContext.ProductTypes.FirstOrDefaultAsync(p => p.IDType == ProductTypeID);
            return result;
        }
        public async Task<ProductTypeEntity> UpdateProductTypeAsync(ProductTypeEntity productTypeEntity)
        {
            dbContext.ProductTypes.Update(productTypeEntity);   
            await dbContext.SaveChangesAsync();
            return productTypeEntity;
        }
    }
}
