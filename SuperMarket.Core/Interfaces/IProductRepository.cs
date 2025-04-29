using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarkerAPI.Models;

namespace SuperMarket.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductEntity>> GetProductByNameAndTypeAsync(string Name = "", string Type = "");
        Task<IEnumerable<ProductEntity>> GetProductByPriceAsync(Decimal? maxPrice = null, Decimal? minPrice = null);
        Task<ProductEntity> AddProductAsync(ProductEntity product);
        Task<ProductEntity> UpdateProductAsync(Guid ProductID, ProductEntity product);
        Task<bool> DeleteProductAsync(Guid ProductID);
    }
}
