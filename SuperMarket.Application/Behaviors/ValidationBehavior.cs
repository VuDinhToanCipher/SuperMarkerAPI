using FluentValidation;
using MediatR;

namespace SuperMarket.Application.Behaviors
{
    public class ValidationBehavior<TRequest,TRespone> : IPipelineBehavior<TRequest,TRespone>
        where TRequest : IRequest<TRespone>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> _validators)
        {
            this._validators = _validators;
        }
        public async Task<TRespone> Handle(TRequest request, RequestHandlerDelegate<TRespone> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var ValidResult = await Task.WhenAll(
                    _validators.Select(validator => validator.ValidateAsync(context,cancellationToken)));
                var failures = ValidResult
                    .SelectMany(validator => validator.Errors)
                    .Where(error => error != null)
                    .ToList();
                if(failures.Any())
                {
                    throw new ValidationException(failures);
                }
            }
            return await next();
        }
    }
}
