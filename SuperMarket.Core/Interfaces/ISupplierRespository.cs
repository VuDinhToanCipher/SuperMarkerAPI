using SuperMarket.Core.Entities;

namespace SuperMarket.Core.Interfaces
{
    public interface ISupplierRespository
    {
        Task<IEnumerable<SupplierEntity>> GetSupplierSync(string? Name);
        Task<SupplierEntity> AddSupplierAsync(SupplierEntity supplierEntity);
        Task<SupplierEntity> UpdateSupplierAsync(SupplierEntity supplierEntity);
        Task<bool> DeleteSupplierAsync(SupplierEntity supplierEntity);
        Task<SupplierEntity?> GetSupplierByIdAsync(Guid SupplierId);
    }
}
