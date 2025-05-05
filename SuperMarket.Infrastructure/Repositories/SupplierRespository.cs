using Microsoft.EntityFrameworkCore;
using SuperMarkerAPI.Data;
using SuperMarket.Core.Entities;
using SuperMarket.Core.Interfaces;

namespace SuperMarket.Infrastructure.Repositories
{
    public class SupplierRespository(ApplicationDbContext dbContext) : ISupplierRespository
    {
        public async Task<SupplierEntity> AddSupplierAsync(SupplierEntity supplierEntity)
        {
            supplierEntity.SupplierId = Guid.NewGuid();
            dbContext.Suppliers.Add(supplierEntity);
            await dbContext.SaveChangesAsync();
            return supplierEntity;
        }
        public async Task<bool> DeleteSupplierAsync(Guid SupplierId)
        {
            var query = await dbContext.Suppliers.FirstOrDefaultAsync(p => p.SupplierId == SupplierId);
            if (query!= null)
            {
                dbContext.Suppliers.Remove(query);
                return await dbContext.SaveChangesAsync() > 0;
            }
            return false;
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
        public async Task<SupplierEntity> UpdateSupplierAsync(Guid SupplierId, SupplierEntity supplierEntity)
        {
            var query = await dbContext.Suppliers.FirstOrDefaultAsync(s => s.SupplierId == SupplierId);
            if (query!= null)
            {
                query.SupplierName = supplierEntity.SupplierName;
                query.SupplierPhoneNummber = supplierEntity.SupplierPhoneNummber;
                query.SupplierAddress = supplierEntity.SupplierAddress;
                query.SupplierDescription = supplierEntity.SupplierDescription;
                query.Email = supplierEntity?.Email;
                await  dbContext.SaveChangesAsync();
                return query;
            }
            return supplierEntity;
        }
    }
}
