public class EmployeeOrders : IBaseEmployeeWithOrders
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Title { get; set; }
    public List<OrdersCommitedPerEmployeeDisplay> Orders { get; set; } = new List<OrdersCommitedPerEmployeeDisplay>();
}
