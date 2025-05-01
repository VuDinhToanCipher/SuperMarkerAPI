using MediatR;
using SuperMarket.Core.Interfaces;

namespace SuperMarket.Application.Commands.ProductType
{
    public record DeleteProductTypeCommand(Guid IDType):IRequest<bool>;
    public class DeleteProductTypeHandler : IRequestHandler<DeleteProductTypeCommand, bool>
    {
        private readonly IProductTypeRepository _productTypeRepository;
        public DeleteProductTypeHandler(IProductTypeRepository _productTypeRepository)
        {
            this._productTypeRepository = _productTypeRepository;
        }
        public async Task<bool> Handle(DeleteProductTypeCommand request, CancellationToken cancellationToken)
        {
            return await _productTypeRepository.DeleteProductTypeAsync(request.IDType);
        }
    }
}
