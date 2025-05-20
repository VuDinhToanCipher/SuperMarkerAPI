using AutoMapper;
using MediatR;
using SuperMarket.Application.DTOs.PositionDTO;
using SuperMarket.Application.Interfaces;
using SuperMarket.Core.Entities;

namespace SuperMarket.Application.Commands.Position
{
    public record UpdatePositionCommand(Guid positionId,UpdatePositionDTO PositionDTO) : IRequest<UpdatePositionDTO>;
    public class UpdatePositionCommandHandler : IRequestHandler<UpdatePositionCommand, UpdatePositionDTO>
    {
        private readonly IMapper _mapper;
        private readonly IPositionService _positionService;
        public UpdatePositionCommandHandler(IMapper _mapper, IPositionService _positionService)
        {
            this._mapper = _mapper;
            this._positionService = _positionService;   
        }
        public async Task<UpdatePositionDTO> Handle(UpdatePositionCommand request, CancellationToken cancellationToken)
        {
            var Position = _mapper.Map<PositionEntity>(request.PositionDTO);
            var result = await _positionService.UpdatePositionAsync(request.positionId,Position);
            return _mapper.Map<UpdatePositionDTO>(result);
        }
    }
}
