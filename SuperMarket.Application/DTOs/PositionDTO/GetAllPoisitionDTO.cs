namespace SuperMarket.Application.DTOs.PositionDTO
{
    public class GetAllPoisitionDTO
    {
        public required string PositionName { get; set; }
        public string? Description { get; set; }
        public required string PermisstionName { get; set; }
    }
}
