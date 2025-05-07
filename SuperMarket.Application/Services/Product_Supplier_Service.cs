using SuperMarket.Application.Interfaces;
using SuperMarket.Core.Entities;
using SuperMarket.Core.Interfaces;

namespace SuperMarket.Application.Services
{
    public class Product_Supplier_Service : IProduct_Supplier_Service
    {
        private readonly IProduct_Supplier_Respository _respository;
        public Product_Supplier_Service(IProduct_Supplier_Respository _respository)
        {
            this._respository = _respository;
        }
        public async Task<Supplier_Product_Entity?> AddSupplier_Product_Async(Guid ProductID, Guid SupplierID)
        {
            var exist = await _respository.GetSupplier_Product_ByIDAsync(ProductID, SupplierID);
            if (exist is not null)
            {
                return null;
            }
            var result = new Supplier_Product_Entity()
            {
                ProductId = ProductID,
                SupplierId = SupplierID 
            };
            return await _respository.AddSupplier_Product_Async(result);
        }

        public async Task<bool> DeleteSupplier_Product_Async(Guid SupplierId, Guid ProductId)
        {
            var exist = await _respository.GetSupplier_Product_ByIDAsync(ProductId, SupplierId);
            if (exist is null)
            {
                return false;
            }
           return await _respository.DeleteSupplier_Product_Async(exist);
        }
    }
}
