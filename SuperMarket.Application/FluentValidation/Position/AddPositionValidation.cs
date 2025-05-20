using FluentValidation;
using SuperMarket.Application.Commands.Position;
using SuperMarket.Core.Interfaces;

namespace SuperMarket.Application.FluentValidation.Position
{
    public class AddPositionValidation : AbstractValidator<AddPositionCommand>
    {
        private readonly IPermissionRepository _permisstionrepo;
        public AddPositionValidation(IPermissionRepository _permisstionrepo)
        {
            this._permisstionrepo = _permisstionrepo;
            RuleFor(x => x.AddPositionDTO.Permisstion).NotEmpty().WithMessage("Permisstion is required")
                .MustAsync(BeAValidPermisstionAsync).WithMessage("Permisstion does not exist");
        }
        private async Task<bool> BeAValidPermisstionAsync(Guid PermisstionID,CancellationToken cancellationToken)
        {
           return await _permisstionrepo.HasPermissionAsync(PermisstionID);
        }
    }
}
