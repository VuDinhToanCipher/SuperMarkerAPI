using Microsoft.EntityFrameworkCore;
using SuperMarkerAPI.Data;
using SuperMarket.Core.Entities;
using SuperMarket.Core.Interfaces;

namespace SuperMarket.Infrastructure.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly ApplicationDbContext _context;
        public PermissionRepository(ApplicationDbContext _context)
        {
            this._context = _context;
        }
        public async Task<PermissionEntity> AddPermissionAsync(PermissionEntity permission)
        {
            _context.Permission.Add(permission);
            await _context.SaveChangesAsync();
            return permission;
        }

        public async Task<bool> DeletePermissionAsync(PermissionEntity permission)
        {
            _context.Permission.Remove(permission);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<PermissionEntity>> GetAllPermissionEntitiesAsync()
        {
            return await _context.Permission.ToListAsync();
        }

        public async Task<PermissionEntity?> GetPermissitionByIDAsync(Guid PermisstionID)
        {
            return await _context.Permission.FindAsync(PermisstionID);
        }

        public async Task<bool> HasPermissionAsync(Guid PermisstionID)
        {
            return await _context.Permission.AnyAsync(x => x.PermissionID == PermisstionID);
        }

        public async Task<PermissionEntity> UpdatePermissionAsync(PermissionEntity permission)
        {
            _context.Permission.Update(permission);
            await _context.SaveChangesAsync();
            return permission;
        }
    }
}
