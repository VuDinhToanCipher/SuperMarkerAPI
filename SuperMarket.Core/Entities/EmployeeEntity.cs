namespace SuperMarket.Core.Entities
{
    public class EmployeeEntity
    {
        public Guid EmployeeID { get; set; }
        public required string EmployeeName { get; set; }
        public required string EmployeePhoneNumber { get; set; }
        public required string EmployeeEmail { get; set; }
        public required string EmployeeAddress { get; set; }
        public Guid PositionID { get; set; }
        public string? EmployeeDescription { get; set; }
        public PositionEntity? Position { get; set; }
        public ICollection<InvoiceEntity>? Invoices { get; set; }
        public Guid? WarehouseID { get; set; }
        public WarehouseEntity? Warehouse { get; set; }
    }
}
