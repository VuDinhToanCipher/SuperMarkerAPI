using FluentValidation;
using SuperMarket.Application.Commands.Supplier;
using SuperMarket.Core.Interfaces;

namespace SuperMarket.Application.FluentValidation.Supplier
{
    public class DeleteSupplierValidation : AbstractValidator<DeleteSupplierCommand>
    {
        private readonly ISupplierRespository _supplierRespository;
        public DeleteSupplierValidation(ISupplierRespository _supplierRespository)
        {
            this._supplierRespository = _supplierRespository;
            RuleFor(x => x.IDSupplier).NotEmpty().WithMessage("Supplier id required");
            RuleFor(x => x.IDSupplier).MustAsync(BeAValidSupplier).WithMessage("Supplier id does not exist");
        }
        private async Task<bool> BeAValidSupplier(Guid supplierId, CancellationToken cancellationToken)
        {
            return await _supplierRespository.GetSupplierByIdAsync(supplierId) != null;
        }
    }
}
