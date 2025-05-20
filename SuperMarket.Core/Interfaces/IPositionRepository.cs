using SuperMarket.Core.Entities;

namespace SuperMarket.Core.Interfaces
{
    public interface IPositionRepository
    {
        Task<PositionEntity> CreateAsync(PositionEntity position);
        Task<PositionEntity> UpdateAsync(PositionEntity position);
        Task<bool> DeleteAsync(PositionEntity position);
        Task<bool> HasPositionAsync(Guid positionID);
        Task<PositionEntity?> GetByIdAsync(Guid PositionId);
        Task <IEnumerable<PositionEntity>> GetAllAsync();


    }
}
