using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarkerAPI.Models;
using SuperMarket.Application.Interfaces;
using SuperMarket.Core.Interfaces;

namespace SuperMarket.Application.Services
{
    public class ProductService : IProductServices
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository _productRepository)
        {
            this._productRepository = _productRepository;
        }
        public async Task<ProductEntity> CreateProductAsync(ProductEntity product)
        {
            product.IDProduct = Guid.NewGuid();
            return await _productRepository.AddProductAsync(product);
        }

        public async Task<bool> DeleteProductAsync(Guid id)
        {
            var product = await _productRepository.GetByIDAsync(id);
            if(product is null)
            {
                return false;
            }
            return await _productRepository.DeleteProductAsync(product);
        }

        public async Task<ProductEntity?> UpdateProductAsync(Guid id, ProductEntity updateData)
        {
            var exist = await _productRepository.GetByIDAsync(id);
            if (exist is null)
            {
                return null;
            }
            exist.NameProduct = updateData.NameProduct;
            exist.ExpirationDate = updateData.ExpirationDate;
            exist.ManufactureDate = updateData.ManufactureDate;
            exist.ProductTypeID = updateData.ProductTypeID;
            exist.ProductPrice = updateData.ProductPrice;
            return await _productRepository.UpdateProductAsync(exist);
        }

    }
}
