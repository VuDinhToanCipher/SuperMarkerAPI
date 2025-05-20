namespace SuperMarket.Application.DTOs.PositionDTO
{
    public class UpdatePositionDTO
    {
        public required string PositionName { get; set; }
        public string? Description { get; set; }
        public Guid Permisstion { get; set; }
    }
}
