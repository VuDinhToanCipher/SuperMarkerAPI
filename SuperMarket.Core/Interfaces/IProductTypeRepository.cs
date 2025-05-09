using SuperMarkerAPI.Models;

namespace SuperMarket.Core.Interfaces
{
    public interface IProductTypeRepository
    {
        Task<ProductTypeEntity> AddProductTypeAsync(ProductTypeEntity productTypeEntity);
        Task<ProductTypeEntity> UpdateProductTypeAsync(ProductTypeEntity productTypeEntity);
        Task<IEnumerable<ProductTypeEntity>> GetProductTypeAsync(string? ProductTypeName);
        Task<bool> DeleteProductTypeAsync(ProductTypeEntity productTypeEntity);
        Task<ProductTypeEntity?> GetProductTypeByIDAsync(Guid ProductTypeID);
        Task<bool> ExistAsync(Guid ProductTypeID);
    }
}
