using AutoMapper;
using MediatR;
using SuperMarkerAPI.Models;
using SuperMarket.Application.DTOs.ProductTypeDTO;
using SuperMarket.Core.Interfaces;

namespace SuperMarket.Application.Commands.ProductType
{
    public record class UpdateProductTypeCommand(Guid IDType,UpdateTypeDTO UpdateTypeDTO) : IRequest<UpdateTypeDTO>;
    public class UpdateProductTypeCommandHandler : IRequestHandler<UpdateProductTypeCommand, UpdateTypeDTO>
    {
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly IMapper _mapper;
        public UpdateProductTypeCommandHandler(IProductTypeRepository _productTypeRepository, IMapper _mapper)
        {
            this._productTypeRepository = _productTypeRepository;
            this._mapper = _mapper;
        }

        public async Task<UpdateTypeDTO> Handle(UpdateProductTypeCommand request, CancellationToken cancellationToken)
        {
            var productTypeEntity = _mapper.Map<ProductTypeEntity>(request.UpdateTypeDTO);
            var result =  await _productTypeRepository.UpdateProductTypeAsync(request.IDType,productTypeEntity);
            return _mapper.Map<UpdateTypeDTO>(result);
        }
    }


}
