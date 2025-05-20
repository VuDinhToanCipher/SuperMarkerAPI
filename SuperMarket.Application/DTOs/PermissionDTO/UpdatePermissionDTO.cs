namespace SuperMarket.Application.DTOs.PermissionDTO
{
    public class UpdatePermissionDTO
    {
        public required string PermissionName { get; set; }
        public string PermissionDescription { get; set; } = string.Empty;
    }
}
