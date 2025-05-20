using System.Runtime.CompilerServices;
using AutoMapper;
using MediatR;
using SuperMarket.Application.DTOs.PositionDTO;
using SuperMarket.Core.Interfaces;

namespace SuperMarket.Application.Queries.Position
{
    public record GetAllPositionQuery : IRequest<IEnumerable<GetAllPoisitionDTO>>;
    public class GetAllPositionQueryHandler : IRequestHandler<GetAllPositionQuery, IEnumerable<GetAllPoisitionDTO>>
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IMapper _mapper;
        public GetAllPositionQueryHandler(IPositionRepository _positionRepository, IMapper _mapper)
        {
            this._positionRepository = _positionRepository;
            this._mapper = _mapper;
        }
        public async Task<IEnumerable<GetAllPoisitionDTO>> Handle(GetAllPositionQuery request, CancellationToken cancellationToken)
        {
            var query = await _positionRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<GetAllPoisitionDTO>>(query);
            return result;
        }
    }
}
