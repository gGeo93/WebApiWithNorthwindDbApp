public interface IOrderDetails
{
    int ProductId { get; set; }
    decimal UnitPrice { get; set; }
    short Quantity { get; set; }
    float Discount { get; set; }
}
