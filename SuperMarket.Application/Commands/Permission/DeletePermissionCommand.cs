using MediatR;
using SuperMarket.Application.Interfaces;

namespace SuperMarket.Application.Commands.Permission
{
    public record DeletePermissionCommand(Guid PermissionID) : IRequest<bool>;
    public class DeletePermissionCommandHandler : IRequestHandler<DeletePermissionCommand, bool>
    {
        private readonly IpermisstionService _permisstionService;
        public DeletePermissionCommandHandler(IpermisstionService _permisstionService)
        {
            this._permisstionService = _permisstionService;
        }
        public async Task<bool> Handle(DeletePermissionCommand request, CancellationToken cancellationToken)
        {
            return await _permisstionService.DeletePermissionAsync(request.PermissionID);
        }
    }
}
