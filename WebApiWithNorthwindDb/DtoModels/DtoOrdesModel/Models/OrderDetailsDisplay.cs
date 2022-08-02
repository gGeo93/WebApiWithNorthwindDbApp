using System.ComponentModel.DataAnnotations;

public class OrderDetailsDisplay : IOrderDetails
{
    [Range(1,77)]
    public int ProductId { get; set; }
    public decimal UnitPrice { get; set; }
    public short Quantity { get; set; }
    public float Discount { get; set; }
}

