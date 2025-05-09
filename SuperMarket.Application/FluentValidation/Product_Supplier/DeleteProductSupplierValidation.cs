using FluentValidation;
using SuperMarket.Application.Commands.Product_Supplier;
using SuperMarket.Core.Interfaces;

namespace SuperMarket.Application.FluentValidation.Product_Supplier
{
    public class DeleteProductSupplierValidation : AbstractValidator<Delete_Product_Supplier_Command>
    {
        private readonly IProductRepository _productRepository;
        private readonly ISupplierRespository _supplierRespository;
        public DeleteProductSupplierValidation(IProductRepository _productRepository, ISupplierRespository _supplierRespository)
        {
            this._productRepository = _productRepository;
            this._supplierRespository = _supplierRespository;
            RuleFor(x => x.ProductID).NotEmpty().WithMessage("Product Id required");
            RuleFor(x => x.SupplierID).NotEmpty().WithMessage("Supplier Id required");
            RuleFor(x => x.ProductID).MustAsync(BeAValidProduct).WithMessage("Product id does not exist");
            RuleFor(x => x.SupplierID).MustAsync(BeAValidSupplier).WithMessage("Supplier id does not exist");
        }
        private async Task<bool> BeAValidProduct(Guid productId, CancellationToken cancellationToken)
        {
            return await _productRepository.GetByIDAsync(productId) != null;    
        }
        private async Task<bool> BeAValidSupplier(Guid supplierId, CancellationToken cancellationToken)
        {
            return await _supplierRespository.GetSupplierByIdAsync(supplierId) != null;
        }
    }
}
