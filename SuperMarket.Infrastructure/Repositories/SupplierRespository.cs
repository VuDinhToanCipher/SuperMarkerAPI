using Microsoft.EntityFrameworkCore;
using SuperMarkerAPI.Data;
using SuperMarket.Core.Entities;
using SuperMarket.Core.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SuperMarket.Infrastructure.Repositories
{
    public class SupplierRespository(ApplicationDbContext dbContext) : ISupplierRespository
    {
        public async Task<SupplierEntity> AddSupplierAsync(SupplierEntity supplierEntity)
        {
            dbContext.Suppliers.Add(supplierEntity);
            await dbContext.SaveChangesAsync();
            return supplierEntity;
        }
        public async Task<bool> DeleteSupplierAsync(SupplierEntity supplierEntity)
        {
            dbContext.Suppliers.Remove(supplierEntity);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<SupplierEntity?> GetSupplierByIdAsync(Guid SupplierId)
        {
            var result = await dbContext.Suppliers.FirstOrDefaultAsync(s => s.SupplierId == SupplierId);    
            return result;
        }

        public async Task<IEnumerable<SupplierEntity>> GetSupplierSync(string? Name)
        {
            var query = dbContext.Suppliers.AsQueryable();
            if (Name is not null)
            {
                query = query.Where(s => s.SupplierName.Contains(Name));
            }
            return await query.ToListAsync();
        }
        public async Task<SupplierEntity> UpdateSupplierAsync(SupplierEntity supplierEntity)
        {
            dbContext.Suppliers.Update(supplierEntity);
            await dbContext.SaveChangesAsync();
            return supplierEntity;
        }
    }
}
