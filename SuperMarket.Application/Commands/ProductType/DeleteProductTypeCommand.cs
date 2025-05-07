using MediatR;
using SuperMarket.Application.Interfaces;
using SuperMarket.Core.Interfaces;

namespace SuperMarket.Application.Commands.ProductType
{
    public record DeleteProductTypeCommand(Guid IDType):IRequest<bool>;
    public class DeleteProductTypeHandler : IRequestHandler<DeleteProductTypeCommand, bool>
    {
        private readonly IproductTypeService _iproductType;
        public DeleteProductTypeHandler(IproductTypeService _iproductType)
        {
            this._iproductType = _iproductType;
        }
        public async Task<bool> Handle(DeleteProductTypeCommand request, CancellationToken cancellationToken)
        {
            return await _iproductType.DeleteProductTypeAsync(request.IDType);
        }
    }
}
