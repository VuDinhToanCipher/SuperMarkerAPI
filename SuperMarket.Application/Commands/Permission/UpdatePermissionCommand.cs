using AutoMapper;
using MediatR;
using SuperMarket.Application.DTOs.PermissionDTO;
using SuperMarket.Application.Interfaces;
using SuperMarket.Core.Entities;

namespace SuperMarket.Application.Commands.Permission
{
    public record UpdatePermissionCommand(Guid PermissionID, UpdatePermissionDTO UpdatePermissionDTO) : IRequest<UpdatePermissionDTO>;
    public class UpdatePermissionCommandHandler : IRequestHandler<UpdatePermissionCommand, UpdatePermissionDTO>
    {
        private readonly IpermisstionService _permisstionService;
        private readonly IMapper _mapper;
        public UpdatePermissionCommandHandler(IpermisstionService _permisstionService,IMapper _mapper)
        {
            this._permisstionService = _permisstionService;
            this._mapper = _mapper;
        }
        public async Task<UpdatePermissionDTO> Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
        {
            var Permission = _mapper.Map<PermissionEntity>(request.UpdatePermissionDTO);
            var result = await _permisstionService.UpdatePermissionAsync(request.PermissionID, Permission);
            return _mapper.Map<UpdatePermissionDTO>(result);    
        }
    }
}
