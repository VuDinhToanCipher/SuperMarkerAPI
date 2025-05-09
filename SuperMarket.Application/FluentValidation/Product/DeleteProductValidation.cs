using FluentValidation;
using SuperMarket.Application.Commands.Product;
using SuperMarket.Core.Interfaces;

namespace SuperMarket.Application.FluentValidation.Product
{
    public class DeleteProductValidation : AbstractValidator<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;
        public DeleteProductValidation(IProductRepository _productRepository)
        {
            this._productRepository = _productRepository;
            RuleFor(x => x.IDProduct).NotEmpty().WithMessage("Product id Required");
            RuleFor(x => x.IDProduct).MustAsync(BeAValidProduct).WithMessage("Product Id does not exist");
        }
        private async Task<bool> BeAValidProduct(Guid productId, CancellationToken cancellationToken)
        {
            return await _productRepository.GetByIDAsync(productId) != null;
        }
    }
}
