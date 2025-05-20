using Microsoft.EntityFrameworkCore;
using SuperMarkerAPI.Data;
using SuperMarket.Core.Entities;
using SuperMarket.Core.Interfaces;

namespace SuperMarket.Infrastructure.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private readonly ApplicationDbContext _context;
        public PositionRepository(ApplicationDbContext _context)
        {
            this._context = _context;
        }
        public async Task<PositionEntity> CreateAsync(PositionEntity position)
        {
            _context.Positions.Add(position);
            await _context.SaveChangesAsync();
            return position;
        }

        public async Task<bool> DeleteAsync(PositionEntity position)
        {
            _context.Positions.Remove(position);
            return await _context.SaveChangesAsync() > 0; 
        }

        public async Task<IEnumerable<PositionEntity>> GetAllAsync()
        {
            return await _context.Positions.AsNoTracking().ToListAsync();
        }

        public async Task<PositionEntity?> GetByIdAsync(Guid PositionId)
        {
            return await _context.Positions.FindAsync(PositionId);
        }

        public async Task<bool> HasPositionAsync(Guid positionID)
        {
            return await _context.Positions.AnyAsync(x => x.PositionID == positionID);    
        }

        public async Task<PositionEntity> UpdateAsync(PositionEntity position)
        {
            _context.Positions.Update(position);
            await _context.SaveChangesAsync();
            return position;
        }
    }
}
