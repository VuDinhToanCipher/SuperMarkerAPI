namespace SuperMarket.Core.Entities
{
    public class PositionEntity
    {
        public Guid PositionID { get; set; }
        public required string PositionName { get; set; }
        public string? positionDescription{ get; set; }
        public ICollection<Position_Permission_Entity>? Permission { get; set; }
    }
}
