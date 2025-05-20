using FluentValidation;
using SuperMarket.Application.Commands.Position;
using SuperMarket.Core.Interfaces;

namespace SuperMarket.Application.FluentValidation.Position
{
    public class DeletePositionValidation : AbstractValidator<DeletePositionCommand>
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IPermissionRepository _permissionRepository;
        public DeletePositionValidation(IPositionRepository _positionRepository, IPermissionRepository permissionRepository)
        {
            this._positionRepository = _positionRepository;
            this._permissionRepository = permissionRepository;
            RuleFor(x => x.positionId).MustAsync(BeAValidPosition).WithMessage("Position does not exist");
        }
        public async Task<bool> BeAValidPosition(Guid positionId, CancellationToken cancellationToken)
        {
            return await _positionRepository.HasPositionAsync(positionId);
        }
    }
}
