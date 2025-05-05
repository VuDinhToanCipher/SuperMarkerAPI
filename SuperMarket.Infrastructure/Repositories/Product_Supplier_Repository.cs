using Microsoft.EntityFrameworkCore;
using SuperMarkerAPI.Data;
using SuperMarket.Core.Entities;
using SuperMarket.Core.Interfaces;

namespace SuperMarket.Infrastructure.Repositories
{
    public class Product_Supplier_Repository(ApplicationDbContext dbContext) : IProduct_Supplier_Respository
    {
        public async Task<Supplier_Product_Entity> AddSupplier_Product_Async(Guid ProductID, Guid SupplierID)
        {
            var exist = await dbContext.supplier_Product.FirstOrDefaultAsync(p => p.SupplierId == SupplierID && p.ProductId == ProductID);
            if (exist != null)
            {
                throw new Exception("This link is already exist");
            }
            var query = new Supplier_Product_Entity()
            {
                ProductId = ProductID,
                SupplierId = SupplierID
            };
            dbContext.supplier_Product.Add(query);
            await dbContext.SaveChangesAsync(); 
            return query;
        }
        public async Task<bool> DeleteSupplier_Product_Async(Guid? SupplierId, Guid? ProductId)
        {
           if(!SupplierId.HasValue||!ProductId.HasValue)
            {
                return false;
            }
           var query = await dbContext.supplier_Product.FirstOrDefaultAsync(p => p.SupplierId == SupplierId&&p.ProductId == ProductId);
            if(query != null)
            {
                dbContext.supplier_Product.Remove(query);
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<IEnumerable<Supplier_Product_Entity>> GetSupplier_Product_Async(Guid? SupplierId, Guid? ProductId)
        {
            var query = dbContext.supplier_Product.AsQueryable();
            if(SupplierId.HasValue)
            {
                query = query.Where(p => p.SupplierId == SupplierId);
            }
            if(ProductId.HasValue)
            {
                query = query.Where(p => p.ProductId == ProductId);
            }
            return await query.ToListAsync();
        }
    }
}
