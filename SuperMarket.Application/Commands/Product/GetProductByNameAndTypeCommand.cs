using AutoMapper;
using MediatR;
using SuperMarkerAPI.Models.DTOs.ProductsDTO;
using SuperMarket.Core.Interfaces;

namespace SuperMarket.Application.Commands.Product
{
    public record class GetProductByNameAndTypeCommand(string Name,String Type) : IRequest<IEnumerable<GetProductsDTO>>;
    public class GetProductByNameAndTypeCommandHandler : IRequestHandler<GetProductByNameAndTypeCommand, IEnumerable<GetProductsDTO>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetProductByNameAndTypeCommandHandler(IProductRepository _productRepository, IMapper _mapper)
        {
            this._productRepository = _productRepository;
            this._mapper = _mapper;
        }

        public async Task<IEnumerable<GetProductsDTO>> Handle(GetProductByNameAndTypeCommand request, CancellationToken cancellationToken)
        {
            var  products = await _productRepository.GetProductByNameAndTypeAsync(request.Name, request.Type);
            var productDTO = _mapper.Map<IEnumerable<GetProductsDTO>>(products);
            return productDTO;
        }
    }


}
