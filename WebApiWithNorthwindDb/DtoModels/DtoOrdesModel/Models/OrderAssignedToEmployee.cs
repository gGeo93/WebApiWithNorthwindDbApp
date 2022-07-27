public class OrderAssignedToEmployee : IBaseOrderToEmployee
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string? Title { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? RequiredDate { get; set; }
    public DateTime? ShippedDate { get; set; }
}
