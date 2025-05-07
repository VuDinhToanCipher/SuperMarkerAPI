using MediatR;
using SuperMarket.Application.Interfaces;

namespace SuperMarket.Application.Commands.Product
{
    public record DeleteProductCommand(Guid IDProduct) : IRequest<bool>;
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductServices _productServices;

        public DeleteProductCommandHandler(IProductServices _productServices)
        {
           this._productServices = _productServices;
        }
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return await _productServices.DeleteProductAsync(request.IDProduct);
        }
    }
}
