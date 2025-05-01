using AutoMapper;
using MediatR;
using SuperMarket.Application.DTOs.ProductTypeDTO;
using SuperMarket.Core.Interfaces;

namespace SuperMarket.Application.Commands.ProductType
{
    public record GetProductTypeCommand(string? Name) : IRequest<IEnumerable<GetProductTypeDTO>>;
    public class GetProductTypeCommandHandler : IRequestHandler<GetProductTypeCommand, IEnumerable<GetProductTypeDTO>>
    {
        private readonly IProductTypeRepository _repository;
        private readonly IMapper _mapper;
        public GetProductTypeCommandHandler(IProductTypeRepository _repository, IMapper _mapper)
        {
            this._repository = _repository;
            this._mapper = _mapper;
        }
        public async Task<IEnumerable<GetProductTypeDTO>> Handle(GetProductTypeCommand request, CancellationToken cancellationToken)
        {
            var result =  await _repository.GetProductTypeAsync(request.Name);
            return _mapper.Map<IEnumerable<GetProductTypeDTO>>(result);
        }
    }


}
