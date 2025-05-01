using MediatR;
using SuperMarkerAPI.Models;
using SuperMarket.Application.DTOs.ProductTypeDTO;
using SuperMarket.Core.Interfaces;

namespace SuperMarket.Application.Commands.ProductType
{
    public record AddProductTypeCommand(AddProductTypeDTO ProductType) : IRequest<ProductTypeEntity>;

    public class AddProductTypeCommandHandler : IRequestHandler<AddProductTypeCommand, ProductTypeEntity>
    {
        private readonly IProductTypeRepository _productTypeRepository;

        public AddProductTypeCommandHandler(IProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }

        public async Task<ProductTypeEntity> Handle(AddProductTypeCommand request, CancellationToken cancellationToken)
        {
            // Chuyển đổi từ DTO sang Entity
            var productTypeEntity = new ProductTypeEntity
            {
                TypeName = request.ProductType.TypeName
            };

            // Gọi phương thức trong Repository để thêm vào cơ sở dữ liệu
            return await _productTypeRepository.AddProductTypeAsync(productTypeEntity);
        }
    }

}
