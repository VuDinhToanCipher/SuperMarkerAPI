using MediatR;
using SuperMarket.Application.Interfaces;

namespace SuperMarket.Application.Commands.Product_Supplier
{
    public record Delete_Product_Supplier_Command(Guid ProductID,Guid SupplierID) : IRequest<bool>;
    public class Delete_Product_Supplier_CommandHandler : IRequestHandler<Delete_Product_Supplier_Command, bool>
    {
        private readonly IProduct_Supplier_Service _service;
        public Delete_Product_Supplier_CommandHandler(IProduct_Supplier_Service _service)
        {
            this._service = _service;
        }
        public async Task<bool> Handle(Delete_Product_Supplier_Command request, CancellationToken cancellationToken)
        {
            return await _service.DeleteSupplier_Product_Async(request.ProductID, request.SupplierID);  
        }
    }
}
