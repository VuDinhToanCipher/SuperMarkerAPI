using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SuperMarkerAPI.Models;
using SuperMarkerAPI.Models.DTOs.ProductsDTO;
using SuperMarket.Application.DTOs.ProductTypeDTO;
using SuperMarket.Core.Interfaces;

namespace SuperMarket.Application.Commands.Product
{
    public record AddProductCommand(PostProductsDTO PostProducts) : IRequest<ProductEntity>;

    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, ProductEntity>
    {
        private readonly IProductRepository _productRepository;

        // Constructor nhận vào repository
        public AddProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // Handle là phương thức thực thi lệnh
        public async Task<ProductEntity> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            // Chuyển đổi DTO sang Entity
            var productEntity = new ProductEntity
            {
                NameProduct = request.PostProducts.NameProduct,
                ProductTypeID = request.PostProducts.ProductTypeID, 
                ProductPrice = request.PostProducts.ProductPrice,
                ProductUnit = request.PostProducts.ProductUnit,
                ExpirationDate = request.PostProducts.ExpirationDate,
                ManufactureDate = request.PostProducts.ManufactureDate,
                IsExpired = request.PostProducts.IsExpired,
            };

            // Gọi phương thức repository để thêm sản phẩm vào database
            return await _productRepository.AddProductAsync(productEntity);
        }
    }
}
