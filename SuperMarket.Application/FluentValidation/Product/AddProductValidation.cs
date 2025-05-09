using FluentValidation;
using SuperMarket.Application.Commands.Product;
using SuperMarket.Core.Interfaces;

namespace SuperMarket.Application.FluentValidation.Product
{
    public class AddProductValidation : AbstractValidator<AddProductCommand>
    {
        private readonly IProductTypeRepository _productTypeRepository;
        public AddProductValidation(IProductTypeRepository _productTypeRepository)
        {
            this._productTypeRepository = _productTypeRepository;
            RuleFor(x => x.PostProducts.ProductTypeID)
                .NotEmpty().WithMessage("Product Type id required")
                .MustAsync(BeAValidProductType).WithMessage("Product Type does not Exist");
        }
        private async Task<bool> BeAValidProductType(Guid productTypeId, CancellationToken cancellationToken)
        {
            return await _productTypeRepository.ExistAsync(productTypeId);
        }
    }
}
