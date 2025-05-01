using AutoMapper;
using MediatR;
using SuperMarkerAPI.Models;
using SuperMarket.Application.DTOs.ProductTypeDTO;
using SuperMarket.Core.Interfaces;

namespace SuperMarket.Application.Commands.ProductType
{
    public record AddProductTypeCommand(AddProductTypeDTO ProductType) : IRequest<AddProductTypeDTO>;

    public class AddProductTypeCommandHandler : IRequestHandler<AddProductTypeCommand, AddProductTypeDTO>
    {
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly IMapper _mapper;
        public AddProductTypeCommandHandler(IProductTypeRepository productTypeRepository, IMapper _mapper)
        {
            _productTypeRepository = productTypeRepository;
            this._mapper = _mapper;
        }

        public async Task<AddProductTypeDTO> Handle(AddProductTypeCommand request, CancellationToken cancellationToken)
        {
            // Chuyển đổi từ DTO sang Entity
            var productTypeEntity = _mapper.Map<ProductTypeEntity>(request.ProductType);

            // Gọi phương thức trong Repository để thêm vào cơ sở dữ liệu
            var result =  await _productTypeRepository.AddProductTypeAsync(productTypeEntity);
            return _mapper.Map<AddProductTypeDTO>(result);
        }
    }

}
