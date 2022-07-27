public class OrderDetails : IOrderDetails
{
    public int OrderId { get; set; }
    public decimal UnitPrice { get; set; }
    public short Quantity { get; set; }
    public float Discount { get; set; }
}
