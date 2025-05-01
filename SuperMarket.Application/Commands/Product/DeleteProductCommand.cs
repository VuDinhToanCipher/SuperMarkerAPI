using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SuperMarket.Core.Interfaces;

namespace SuperMarket.Application.Commands.Product
{
    public record DeleteProductCommand(Guid IDProduct) : IRequest<bool>;
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _repository;
       
        public DeleteProductCommandHandler(IProductRepository _repository, IMapper _mapper)
        {
            this._repository = _repository;
        }
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteProductAsync(request.IDProduct);
        }
    }
}
