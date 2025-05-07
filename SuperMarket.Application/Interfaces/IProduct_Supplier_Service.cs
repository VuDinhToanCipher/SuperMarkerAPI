using SuperMarket.Core.Entities;

namespace SuperMarket.Application.Interfaces
{
    public interface IProduct_Supplier_Service
    {
        Task<Supplier_Product_Entity?> AddSupplier_Product_Async(Guid ProductID, Guid SupplierID);
        Task<bool> DeleteSupplier_Product_Async(Guid SupplierId, Guid ProductId);
    }
}
