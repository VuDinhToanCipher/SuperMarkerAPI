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
        Task<bool> DeleteProductTypeAsync(Guid ProductTypeID);
    }
}
