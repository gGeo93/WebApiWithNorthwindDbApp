public class BaseOrdersDisplayModel : IBaseOrdersDisplayModel
{
    public DateTime? OrderDate { get; set; }
    public DateTime? RequiredDate { get; set; }
    public DateTime? ShippedDate { get; set; }
}
