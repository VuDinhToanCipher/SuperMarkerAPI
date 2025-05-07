using AutoMapper;
using MediatR;
using SuperMarkerAPI.Models;
using SuperMarket.Application.DTOs.ProductTypeDTO;
using SuperMarket.Application.Interfaces;

namespace SuperMarket.Application.Commands.ProductType
{
    public record AddProductTypeCommand(AddProductTypeDTO ProductType) : IRequest<AddProductTypeDTO>;

    public class AddProductTypeCommandHandler : IRequestHandler<AddProductTypeCommand, AddProductTypeDTO>
    {
        private readonly IproductTypeService _iproductType;
        private readonly IMapper _mapper;
        public AddProductTypeCommandHandler(IproductTypeService _iproductType, IMapper _mapper)
        {
           this._iproductType = _iproductType;
            this._mapper = _mapper;
        }

        public async Task<AddProductTypeDTO> Handle(AddProductTypeCommand request, CancellationToken cancellationToken)
        {
            // Chuyển đổi từ DTO sang Entity
            var productTypeEntity = _mapper.Map<ProductTypeEntity>(request.ProductType);

            // Gọi phương thức trong Repository để thêm vào cơ sở dữ liệu
            var result =  await _iproductType.AddProductTypeAsync(productTypeEntity);
            return _mapper.Map<AddProductTypeDTO>(result);
        }
    }

}
