public class TurnoverByCustomerModel
{
    public BaseCustomerModel BaseCustomer { get; set; }
    public List<decimal?> TurnoverFromSpecificCustomer { get; set; } = new List<decimal?>();
}
