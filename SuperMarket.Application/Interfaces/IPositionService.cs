using SuperMarket.Core.Entities;

namespace SuperMarket.Application.Interfaces
{
    public interface IPositionService
    {
        Task<PositionEntity> AddPositionAsync(PositionEntity position);
        Task<PositionEntity?> UpdatePositionAsync(Guid PositionID,PositionEntity position);
        Task<bool> DeletePositionAsync(Guid PositionID);
    }
}
