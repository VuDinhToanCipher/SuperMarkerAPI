using SuperMarket.Core.Entities;

namespace SuperMarket.Application.Interfaces
{
    public interface ISupplierService
    {
        Task<SupplierEntity> AddSupplierAsync(SupplierEntity supplierEntity);
        Task<SupplierEntity?> UpdateSupplierAsync(Guid IDSupplier, SupplierEntity supplierEntity);
        Task<bool> DeleteSupplierAsync(Guid IDSupplier);
    }
}
