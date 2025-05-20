using SuperMarket.Core.Entities;

namespace SuperMarket.Application.Interfaces
{
    public interface IpermisstionService
    {
        Task<PermissionEntity> AddPermissionAsync(PermissionEntity permission);
        Task<PermissionEntity?> UpdatePermissionAsync(Guid PermissionID, PermissionEntity permission);
        Task<bool> DeletePermissionAsync(Guid PermissionID);
    }
}
