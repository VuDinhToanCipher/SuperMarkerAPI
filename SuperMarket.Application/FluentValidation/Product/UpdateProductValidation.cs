using FluentValidation;
using SuperMarket.Application.Commands.Product;
using SuperMarket.Core.Interfaces;

namespace SuperMarket.Application.FluentValidation.Product
{
    public class UpdateProductValidation : AbstractValidator<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductTypeRepository _productTypeRepository;
        public UpdateProductValidation(IProductRepository _productRepository, IProductTypeRepository _productTypeRepository)
        {
            this._productRepository = _productRepository;
            this._productTypeRepository = _productTypeRepository;
            RuleFor(x => x.IDProduct)
                .NotEmpty().WithMessage("Product Id required");
            RuleFor(x => x.IDProduct)
                .MustAsync(BeAValidProduct).WithMessage("Product ID does not exist")
                .When(x => x.IDProduct != Guid.Empty);
            RuleFor(x => x.putProductsDTO.ProductType)
                .NotEmpty().WithMessage("ProductType Id required");
            RuleFor(x => x.putProductsDTO.ProductType)
                .MustAsync(BeAValidProductType).WithMessage("ProductType ID does not exist")
                .When(x => x.putProductsDTO.ProductType != Guid.Empty);
            RuleFor(x => x.putProductsDTO.NameProduct)
                 .NotEmpty().WithMessage("Name product required");
            RuleFor(x => x.putProductsDTO.ProductPrice)
                 .NotEmpty().WithMessage("Price required");
        }
        private async Task<bool> BeAValidProduct(Guid productId, CancellationToken cancellationToken)
        {
            return await _productRepository.GetByIDAsync(productId) != null;    
        }
        private async Task<bool> BeAValidProductType(Guid productTypeID, CancellationToken cancellationToken)
        {
            return await _productTypeRepository.ExistAsync(productTypeID);
        }
    }
}
