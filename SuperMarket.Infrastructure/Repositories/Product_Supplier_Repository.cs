using Microsoft.EntityFrameworkCore;
using SuperMarkerAPI.Data;
using SuperMarket.Core.Entities;
using SuperMarket.Core.Interfaces;

namespace SuperMarket.Infrastructure.Repositories
{
    public class Product_Supplier_Repository(ApplicationDbContext dbContext) : IProduct_Supplier_Respository
    {
        public async Task<Supplier_Product_Entity> AddSupplier_Product_Async(Supplier_Product_Entity supplier_Product_Entity)
        {
            dbContext.supplier_Product.Add(supplier_Product_Entity);
            await dbContext.SaveChangesAsync(); 
            return supplier_Product_Entity;
        }
        public async Task<bool> DeleteSupplier_Product_Async(Supplier_Product_Entity supplier_Product_Entity)
        {
            dbContext.supplier_Product.Remove(supplier_Product_Entity);
            return await dbContext.SaveChangesAsync() > 0;
        }
        public async Task<IEnumerable<Supplier_Product_Entity>> GetSupplier_Product_Async(Guid? SupplierId, Guid? ProductId)
        {
            var query = dbContext.supplier_Product.Include(p=>p.ProductEntity).Include(s => s.SupplierEntity).AsQueryable();
            if(SupplierId.HasValue)
            {
                query = query.Where(p => p.SupplierId == SupplierId.Value);
            }
            if(ProductId.HasValue)
            {
                query = query.Where(p => p.ProductId == ProductId.Value);
            }
            return await query.ToListAsync();
        }

        public async Task<Supplier_Product_Entity?> GetSupplier_Product_ByIDAsync(Guid ProductId, Guid SupplierId)
        {
            var exist = await dbContext.supplier_Product.FirstOrDefaultAsync(p => p.SupplierId == SupplierId && p.ProductId == ProductId);
            return exist;
        }
    }
}
