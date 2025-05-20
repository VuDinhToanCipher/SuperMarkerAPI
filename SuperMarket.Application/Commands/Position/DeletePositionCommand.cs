using MediatR;
using SuperMarket.Application.Interfaces;

namespace SuperMarket.Application.Commands.Position
{
    public record DeletePositionCommand(Guid positionId) : IRequest<bool>;
    public class DeletePositionCommandHandler : IRequestHandler<DeletePositionCommand, bool>
    {
        private readonly IPositionService _positionService;
        public DeletePositionCommandHandler(IPositionService _positionService)
        {
            this._positionService = _positionService;
        }
        public async Task<bool> Handle(DeletePositionCommand request, CancellationToken cancellationToken)
        {
            return await _positionService.DeletePositionAsync(request.positionId);
        }
    }
}
