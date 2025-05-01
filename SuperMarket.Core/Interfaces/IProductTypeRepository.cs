using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarkerAPI.Models;

namespace SuperMarket.Core.Interfaces
{
    public interface IProductTypeRepository
    {
        Task<ProductTypeEntity> AddProductTypeAsync(ProductTypeEntity productTypeEntity);
        Task<ProductTypeEntity> UpdateProductTypeAsync(Guid ProductTypeID, ProductTypeEntity productTypeEntity);
        Task<IEnumerable<ProductTypeEntity>> GetProductTypeAsync(string? ProductTypeName);
        Task<bool> DeleteProductTypeAsync(Guid ProductTypeID);
    }
}
