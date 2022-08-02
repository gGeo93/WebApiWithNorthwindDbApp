public class BaseOrderWithAllOrderDetails : IBaseOrderWithAllOrderDetails
{
    public DateTime? OrderDate { get; set; }
    public DateTime? RequiredDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public List<OrderDetailsDisplay> AllOrderDetails { get; set; } = new List<OrderDetailsDisplay>();
}
