using AutoMapper;
using MediatR;
using SuperMarket.Application.DTOs.Permission;
using SuperMarket.Application.Interfaces;
using SuperMarket.Core.Entities;

namespace SuperMarket.Application.Commands.Permission
{
    public record AddPermissionCommand(AddPermisstionDTO AddPermisstionDTO) : IRequest<AddPermisstionDTO>;
    public class AddPermissionCommandHandler : IRequestHandler<AddPermissionCommand, AddPermisstionDTO>
    {
        private readonly IMapper _mapper;
        private readonly IpermisstionService _permisstionService;
        public AddPermissionCommandHandler(IMapper _mapper, IpermisstionService _permisstionService)
        {
            this._mapper = _mapper;
            this._permisstionService = _permisstionService;
        }
        public async Task<AddPermisstionDTO> Handle(AddPermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = _mapper.Map<PermissionEntity>(request.AddPermisstionDTO);
            var result = await _permisstionService.AddPermissionAsync(permission);
            return _mapper.Map<AddPermisstionDTO>(result);
        }
    }

}
