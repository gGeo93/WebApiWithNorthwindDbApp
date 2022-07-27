public class OrderWitlALlOrderDetails : IBaseOrderWitlAllOrderDetails
{
    public DateTime? OrderDate { get; set; }
    public DateTime? RequiredDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public ICollection<OrderDetails> AllOrderDetails { get; set; } = new List<OrderDetails>();
}
