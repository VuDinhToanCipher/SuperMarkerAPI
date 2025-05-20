namespace SuperMarket.Application.DTOs.PositionDTO
{
    public class AddPositionDTO
    {
        public required string PositionName { get; set; }
        public string? Description { get; set; }
        public Guid Permisstion {  get; set; }  
    }
}
