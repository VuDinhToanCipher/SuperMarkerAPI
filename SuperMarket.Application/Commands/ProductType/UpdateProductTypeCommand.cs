using AutoMapper;
using MediatR;
using SuperMarkerAPI.Models;
using SuperMarket.Application.DTOs.ProductTypeDTO;
using SuperMarket.Application.Interfaces;
using SuperMarket.Core.Interfaces;

namespace SuperMarket.Application.Commands.ProductType
{
    public record class UpdateProductTypeCommand(Guid IDType,UpdateTypeDTO UpdateTypeDTO) : IRequest<UpdateTypeDTO>;
    public class UpdateProductTypeCommandHandler : IRequestHandler<UpdateProductTypeCommand, UpdateTypeDTO>
    {
        private readonly IproductTypeService _iproductType;
        private readonly IMapper _mapper;
        public UpdateProductTypeCommandHandler(IproductTypeService _iproductType, IMapper _mapper)
        {
           this._iproductType = _iproductType;
            this._mapper = _mapper;
        }

        public async Task<UpdateTypeDTO> Handle(UpdateProductTypeCommand request, CancellationToken cancellationToken)
        {
            var productTypeEntity = _mapper.Map<ProductTypeEntity>(request.UpdateTypeDTO);
            var result =  await _iproductType.UpdateProductTypeAsync(request.IDType,productTypeEntity);
            return _mapper.Map<UpdateTypeDTO>(result);
        }
    }


}
