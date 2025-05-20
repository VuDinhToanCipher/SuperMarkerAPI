namespace SuperMarket.Core.Entities
{
    public class CustomerEntity
    {
        public Guid CustomerID { get; set; }
        public required string CustomerName { get; set; }
        public Guid PermissionID { get; set; }
        public CustomerPermissionEntity? CustomerPermission{ get; set; }
        public string? CustomerEmail { get; set; }
        public required string CustomerPhoneNumber { get; set; }
        public string? CustomerAddress { get; set; }
        public ICollection<InvoiceEntity>? Invoices { get; set; }
    }
}
