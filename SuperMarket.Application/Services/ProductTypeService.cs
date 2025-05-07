using SuperMarkerAPI.Models;
using SuperMarket.Application.Interfaces;
using SuperMarket.Core.Interfaces;

namespace SuperMarket.Application.Services
{
    public class ProductTypeService : IproductTypeService
    {
        private readonly IProductTypeRepository _repository;
        public ProductTypeService(IProductTypeRepository _repository)
        {
            this._repository = _repository;
        }
        public Task<ProductTypeEntity> AddProductTypeAsync(ProductTypeEntity productTypeEntity)
        {
            productTypeEntity.IDType = Guid.NewGuid();
            return _repository.AddProductTypeAsync(productTypeEntity);
        }

        public async Task<bool> DeleteProductTypeAsync(Guid ProductTypeID)
        {
            var result = await _repository.GetProductTypeByIDAsync(ProductTypeID);
            if(result is null)
            {
                return false;
            }
           return await _repository.DeleteProductTypeAsync(result);
        }

        public async Task<ProductTypeEntity?> UpdateProductTypeAsync(Guid ProductTypeID, ProductTypeEntity productTypeEntity)
        {
            var result = await _repository.GetProductTypeByIDAsync(ProductTypeID);
            if (result is null)
            {
                return null;
            }
            result.TypeName = productTypeEntity.TypeName;
            return await _repository.UpdateProductTypeAsync(productTypeEntity);
        }
    }
}
