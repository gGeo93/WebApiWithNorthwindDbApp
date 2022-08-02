public class OrderAssignedToEmployee : IBaseOrderToEmployee
{
    public EmployeeBasedOrder EmployeeBasedOrder { get; set; } = new();
    public DateTime? OrderDate { get; set; }
    public DateTime? RequiredDate { get; set; }
    public DateTime? ShippedDate { get; set; }
}
