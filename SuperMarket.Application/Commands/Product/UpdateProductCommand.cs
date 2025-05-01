using AutoMapper;
using MediatR;
using SuperMarkerAPI.Models;
using SuperMarkerAPI.Models.DTOs.ProductsDTO;
using SuperMarket.Core.Interfaces;

namespace SuperMarket.Application.Commands.Product
{
    public record UpdateProductCommand(Guid IDProduct, PutProductsDTO putProductsDTO) : IRequest<PutProductsDTO>;
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, PutProductsDTO>
    {
        public readonly IProductRepository _productRepository;
        public readonly IMapper _mapper;
        public UpdateProductCommandHandler(IProductRepository _productRepository, IMapper _mapper)
        {
            this._productRepository = _productRepository;
            this._mapper = _mapper;
        }
        public async Task<PutProductsDTO> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<ProductEntity>(request.putProductsDTO);
            var result = await _productRepository.UpdateProductAsync(request.IDProduct, product);
            var productDTO = _mapper.Map<PutProductsDTO>(result);
            return productDTO;

        }
    }
}
