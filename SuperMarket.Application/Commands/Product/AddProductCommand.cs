using AutoMapper;
using MediatR;
using SuperMarkerAPI.Models;
using SuperMarkerAPI.Models.DTOs.ProductsDTO;
using SuperMarket.Application.Interfaces;

namespace SuperMarket.Application.Commands.Product
{
    public record AddProductCommand(PostProductsDTO PostProducts) : IRequest<PostProductsDTO>;

    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, PostProductsDTO>
    {
        
        private readonly IProductServices _productServices;
        private readonly IMapper _mapper;

        
        public AddProductCommandHandler(IProductServices _productServices, IMapper _mapper)
        {
           this._productServices = _productServices;
           this._mapper = _mapper;
        }

        // Handle là phương thức thực thi lệnh
        public async Task<PostProductsDTO> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            // Chuyển đổi DTO sang Entity
            var productEntity = _mapper.Map<ProductEntity>(request.PostProducts);
            // Gọi phương thức repository để thêm sản phẩm vào database
            var result =  await _productServices.CreateProductAsync(productEntity);
            return _mapper.Map<PostProductsDTO>(result);
        }
    }
}
