using AutoMapper;
using MediatR;
using SuperMarket.Application.DTOs.SupplierDTO;
using SuperMarket.Core.Interfaces;

namespace SuperMarket.Application.Queries.Supplier
{
    public record GetSupplierCommand(string NameSupplier) : IRequest<IEnumerable<GetSupplierDTO>>;
    public class GetSupplierCommandHandler : IRequestHandler<GetSupplierCommand, IEnumerable<GetSupplierDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ISupplierRespository _respository;
        public GetSupplierCommandHandler(IMapper _mapper, ISupplierRespository _respository)
        {
            this._mapper = _mapper;
            this._respository = _respository;
        }
        public async Task<IEnumerable<GetSupplierDTO>> Handle(GetSupplierCommand request, CancellationToken cancellationToken)
        {
            var result = await _respository.GetSupplierSync(request.NameSupplier);
            return _mapper.Map<IEnumerable<GetSupplierDTO>>(result);
        }
    }
}
