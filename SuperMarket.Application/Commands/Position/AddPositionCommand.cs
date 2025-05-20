using AutoMapper;
using MediatR;
using SuperMarket.Application.DTOs.PositionDTO;
using SuperMarket.Application.Interfaces;
using SuperMarket.Core.Entities;

namespace SuperMarket.Application.Commands.Position
{
    public record AddPositionCommand(AddPositionDTO AddPositionDTO) : IRequest<AddPositionDTO>;
    public class AddPositionCommandHandler : IRequestHandler<AddPositionCommand, AddPositionDTO>
    {
        private readonly IMapper _mapper;
        private readonly IPositionService _positionService;
        public AddPositionCommandHandler(IMapper _mapper, IPositionService _positionService)
        {
            this._mapper = _mapper;
            this._positionService = _positionService;   
        }
        public async Task<AddPositionDTO> Handle(AddPositionCommand request, CancellationToken cancellationToken)
        {
            var Position = _mapper.Map<PositionEntity>(request.AddPositionDTO);
            var result = await _positionService.AddPositionAsync(Position);
            return  _mapper.Map<AddPositionDTO>(result);
        }
    }
}
