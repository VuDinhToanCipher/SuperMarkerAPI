using SuperMarket.Application.Interfaces;
using SuperMarket.Core.Entities;
using SuperMarket.Core.Interfaces;

namespace SuperMarket.Application.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRespository _supplierRespository;
        public SupplierService(ISupplierRespository _supplierRespository)
        {
            this._supplierRespository = _supplierRespository;
        }
        public async Task<SupplierEntity> AddSupplierAsync(SupplierEntity supplierEntity)
        {
            supplierEntity.SupplierId = Guid.NewGuid();
            return await _supplierRespository.AddSupplierAsync(supplierEntity);
        }

        public async Task<bool> DeleteSupplierAsync(Guid IDSupplier)
        {
            var result = await _supplierRespository.GetSupplierByIdAsync(IDSupplier);
            if (result is null)
            {
                return false;
            }
            return await _supplierRespository.DeleteSupplierAsync(result);
        }

        public async Task<SupplierEntity?> UpdateSupplierAsync(Guid IDSupplier, SupplierEntity supplierEntity)
        {

            var result = await _supplierRespository.GetSupplierByIdAsync(IDSupplier);
            if (result is null)
            {
                return null;
            }
            result.SupplierName = supplierEntity.SupplierName;
            result.SupplierPhoneNummber = supplierEntity.SupplierPhoneNummber;
            result.SupplierAddress = supplierEntity.SupplierAddress;
            result.Email = supplierEntity.Email;
            result.SupplierDescription = supplierEntity.SupplierDescription;
            return await _supplierRespository.UpdateSupplierAsync(result);
        }
    }
}
