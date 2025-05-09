using FluentValidation;
using SuperMarket.Application.Commands.Product_Supplier;
using SuperMarket.Core.Interfaces;

namespace SuperMarket.Application.FluentValidation.Product_Supplier
{
    public class AddProductSupplierValidation : AbstractValidator<Add_Product_Supplier_Command>
    {
        private readonly IProductRepository _productRepository;
        private readonly ISupplierRespository _supplierRespository;
        public AddProductSupplierValidation(IProductRepository _productRepository, ISupplierRespository _supplierRespository)
        {
            this._productRepository = _productRepository;
            this._supplierRespository = _supplierRespository;
            RuleFor(x => x.ProductID)
                .NotEmpty().WithMessage("Product Id must required");
            RuleFor(x => x.ProductID)
                .MustAsync(BeAValidProduct).WithMessage("Product ID does not exist")
                .When(x => x.ProductID != Guid.Empty);
            RuleFor(x => x.SupplierID).NotEmpty().WithMessage("Supplier Id must required");
            RuleFor(x => x.SupplierID)
                .MustAsync(BeAValidSupplier).WithMessage("Product ID does not exist")
                .When(x => x.SupplierID != Guid.Empty);

        }
        private async Task<bool> BeAValidProduct(Guid productID, CancellationToken cancellationToken)
        {
            return await _productRepository.GetByIDAsync(productID) != null; 
        }
        private async Task<bool> BeAValidSupplier(Guid supplierID, CancellationToken cancellationToken)
        {
            return await _supplierRespository.GetSupplierByIdAsync(supplierID) != null;
        }

    }
}
