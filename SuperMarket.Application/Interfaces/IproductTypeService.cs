using SuperMarkerAPI.Models;

namespace SuperMarket.Application.Interfaces
{
    public interface IproductTypeService
    {
        Task<ProductTypeEntity> AddProductTypeAsync(ProductTypeEntity productTypeEntity);
        Task<ProductTypeEntity?> UpdateProductTypeAsync(Guid ProductTypeID, ProductTypeEntity productTypeEntity);
        Task<bool> DeleteProductTypeAsync(Guid ProductTypeID);
    }
}
