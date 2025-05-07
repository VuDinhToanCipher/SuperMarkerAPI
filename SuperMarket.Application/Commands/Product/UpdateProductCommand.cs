using AutoMapper;
using MediatR;
using SuperMarkerAPI.Models;
using SuperMarkerAPI.Models.DTOs.ProductsDTO;
using SuperMarket.Application.Interfaces;

namespace SuperMarket.Application.Commands.Product
{
    public record UpdateProductCommand(Guid IDProduct, PutProductsDTO putProductsDTO) : IRequest<PutProductsDTO>;
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, PutProductsDTO>
    {
        private readonly IProductServices _productServices;

        public readonly IMapper _mapper;
        public UpdateProductCommandHandler(IProductServices _productServices, IMapper _mapper)
        {
            this._productServices = _productServices;
            this._mapper = _mapper;
        }
        public async Task<PutProductsDTO> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<ProductEntity>(request.putProductsDTO);
            var result = await _productServices.UpdateProductAsync(request.IDProduct, product);
            var productDTO = _mapper.Map<PutProductsDTO>(result);
            return productDTO;

        }
    }
}
