using SuperMarkerAPI.Models;

namespace SuperMarket.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductEntity>> GetProductByNameAndTypeAsync(string Name = "", string Type = "");
        Task<IEnumerable<ProductEntity>> GetProductByPriceAsync(Decimal? maxPrice = null, Decimal? minPrice = null);
        Task<ProductEntity> AddProductAsync(ProductEntity product);
        Task<ProductEntity> UpdateProductAsync(ProductEntity product);
        Task<bool> DeleteProductAsync(ProductEntity product);
        Task<ProductEntity?> GetByIDAsync(Guid ProductID);
    }
}
