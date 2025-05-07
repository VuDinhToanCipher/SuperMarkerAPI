using AutoMapper;
using MediatR;
using SuperMarkerAPI.Models.DTOs.ProductsDTO;
using SuperMarket.Core.Interfaces;

namespace SuperMarket.Application.Queries.Product
{
    public record GetProductByPriceCommand(decimal? MaxValue,decimal? MinValue) : IRequest<IEnumerable<GetProductsDTO>>;
    public class GetProductByPriceCommandHandler : IRequestHandler<GetProductByPriceCommand, IEnumerable<GetProductsDTO>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetProductByPriceCommandHandler(IProductRepository _productRepository, IMapper _mapper)
        {
            this._productRepository = _productRepository;
            this._mapper = _mapper;
        }

        public async Task<IEnumerable<GetProductsDTO>> Handle(GetProductByPriceCommand request, CancellationToken cancellationToken)
        {
            var result =  await _productRepository.GetProductByPriceAsync(request.MaxValue, request.MinValue);
            var productDTO = _mapper.Map<IEnumerable<GetProductsDTO>>(result);
            return productDTO;
        }
    }


}
