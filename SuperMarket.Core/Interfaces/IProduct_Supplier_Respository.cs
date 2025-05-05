using SuperMarket.Core.Entities;

namespace SuperMarket.Core.Interfaces
{
    public interface IProduct_Supplier_Respository
    {
        Task<Supplier_Product_Entity> AddSupplier_Product_Async(Guid ProductID, Guid SupplierID);
        Task<bool> DeleteSupplier_Product_Async(Guid? SupplierId, Guid? ProductId);
        Task<IEnumerable<Supplier_Product_Entity>> GetSupplier_Product_Async(Guid? SupplierId, Guid? ProductId);
    }
}
