using SuperMarket.Application.Interfaces;
using SuperMarket.Core.Entities;
using SuperMarket.Core.Interfaces;

namespace SuperMarket.Application.Services
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _positionRepository;
        public PositionService(IPositionRepository _positionRepository)
        {
            this._positionRepository = _positionRepository;
        }
        public async Task<PositionEntity> AddPositionAsync(PositionEntity position)
        {
             position.PositionID = Guid.NewGuid();
            return await _positionRepository.CreateAsync(position);
        }

        public async Task<bool> DeletePositionAsync(Guid PositionID)
        {
            var exist = await _positionRepository.GetByIdAsync(PositionID);
            if (exist is null)
            {
                return false;
            }
            return await _positionRepository.DeleteAsync(exist);
        }

        public async Task<PositionEntity?> UpdatePositionAsync(Guid PositionID, PositionEntity position)
        {
            var exist = await _positionRepository.GetByIdAsync(PositionID);
            if (exist is null)
            {
                return null;
            }
            exist.PositionName = position.PositionName;
            exist.positionDescription = position.positionDescription;
            exist.Permission = position.Permission;
            return await _positionRepository.UpdateAsync(exist);
        }
    }
}
