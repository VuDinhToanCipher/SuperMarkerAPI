using SuperMarket.Application.Interfaces;
using SuperMarket.Core.Entities;
using SuperMarket.Core.Interfaces;

namespace SuperMarket.Application.Services
{
    public class PermisstionService : IpermisstionService
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermisstionService(IPermissionRepository _permissionRepository)
        {
            this._permissionRepository = _permissionRepository;
        }
        public async Task<PermissionEntity> AddPermissionAsync(PermissionEntity permission)
        {
           permission.PermissionID = Guid.NewGuid();
           return await _permissionRepository.AddPermissionAsync(permission);
        }

        public async Task<bool> DeletePermissionAsync(Guid PermissionID)
        {
            var query = await _permissionRepository.GetPermissitionByIDAsync(PermissionID);
            if (query == null)
            {
                return false;
            }
            return await _permissionRepository.DeletePermissionAsync(query);
        }

        public async Task<PermissionEntity?> UpdatePermissionAsync(Guid PermissionID, PermissionEntity permission)
        {
            var query = await _permissionRepository.GetPermissitionByIDAsync(PermissionID);
            if(query == null)
            {
                return null;
            }
            query.PermissionName = permission.PermissionName;
            query.PermissionDescription = permission.PermissionDescription; 
            return await _permissionRepository.UpdatePermissionAsync(query);
        }
    }
}
