using SuperMarket.Core.Entities;

namespace SuperMarket.Core.Interfaces
{
    public interface IPermissionRepository
    {
        Task<PermissionEntity> AddPermissionAsync(PermissionEntity permission);
        Task<PermissionEntity> UpdatePermissionAsync(PermissionEntity permission);
        Task<bool> DeletePermissionAsync(PermissionEntity permission);
        Task<IEnumerable<PermissionEntity>> GetAllPermissionEntitiesAsync();
        Task<bool> HasPermissionAsync(Guid PermisstionID);
        Task<PermissionEntity?> GetPermissitionByIDAsync(Guid PermisstionID);
    }
}
