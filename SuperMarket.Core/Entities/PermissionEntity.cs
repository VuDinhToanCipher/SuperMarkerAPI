namespace SuperMarket.Core.Entities
{
    public class PermissionEntity
    {
        public Guid PermissionID { get; set; }
        public required string PermissionName { get; set; }
        public string PermissionDescription { get; set; } = string.Empty;
        public ICollection<Position_Permission_Entity>? Position { get; set; }
    }
}
