namespace SuperMarket.Core.Entities
{
    public class Position_Permission_Entity
    {
        public Guid PositionID { get; set; }
        public Guid PermissionID { get; set; }
        public PositionEntity? PositionEntity { get; set; }
        public PermissionEntity? PermissionEntity { get; set; }
    }
}
