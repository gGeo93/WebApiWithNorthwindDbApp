public interface IOrderDetails
{
    int OrderId { get; set; }
    decimal UnitPrice { get; set; }
    short Quantity { get; set; }
    float Discount { get; set; }
}
