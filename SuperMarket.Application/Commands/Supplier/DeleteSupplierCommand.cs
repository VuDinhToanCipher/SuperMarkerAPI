using MediatR;
using SuperMarket.Application.Interfaces;

namespace SuperMarket.Application.Commands.Supplier
{
    public record DeleteSupplierCommand(Guid IDSupplier) : IRequest<bool>;
    public class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand, bool>
    {
        private readonly ISupplierService _supplierService;
        public DeleteSupplierCommandHandler(ISupplierService _supplierService)
        {
            this._supplierService = _supplierService;
        }
        public async Task<bool> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {
            return await _supplierService.DeleteSupplierAsync(request.IDSupplier);
        }
    }
}
