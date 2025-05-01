using MediatR;
using SuperMarkerAPI.Models;
using SuperMarket.Application.DTOs.ProductTypeDTO;
using SuperMarket.Core.Interfaces;

namespace SuperMarket.Application.Commands.ProductType
{
    public record class UpdateProductTypeCommand(Guid IDType,UpdateTypeDTO UpdateTypeDTO) : IRequest<ProductTypeEntity>;
    public class UpdateProductTypeCommandHandler : IRequestHandler<UpdateProductTypeCommand,ProductTypeEntity>
    {
        private readonly IProductTypeRepository _productTypeRepository;
        public UpdateProductTypeCommandHandler(IProductTypeRepository _productTypeRepository)
        {
            this._productTypeRepository = _productTypeRepository;
        }

        public async Task<ProductTypeEntity> Handle(UpdateProductTypeCommand request, CancellationToken cancellationToken)
        {
            var productTypeEntity = new ProductTypeEntity
            {
                TypeName = request.UpdateTypeDTO.TypeName
            };
            return await _productTypeRepository.UpdateProductTypeAsync(request.IDType,productTypeEntity);
        }
    }


}
