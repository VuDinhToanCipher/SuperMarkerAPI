using SuperMarkerAPI.Models;

namespace SuperMarket.Application.Interfaces
{
    public interface IProductServices
    {
           Task<ProductEntity> CreateProductAsync(ProductEntity product);
           Task<ProductEntity?> UpdateProductAsync(Guid id, ProductEntity updateData);
           Task<bool> DeleteProductAsync(Guid id);
    }
}
