public class OrderDeliveredToCustomer : IBaseOrderToCustomer
{
    public DateTime? OrderDate { get; set; }
    public DateTime? RequiredDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public CustomerBasedOrder CustomerBasedOrder { get; set; } = new CustomerBasedOrder();
}
