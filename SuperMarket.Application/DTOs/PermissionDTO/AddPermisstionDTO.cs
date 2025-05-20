namespace SuperMarket.Application.DTOs.Permission
{
    public class AddPermisstionDTO
    {
        public required string PermissionName { get; set; }
        public string PermissionDescription { get; set; } = string.Empty;
    }
}
