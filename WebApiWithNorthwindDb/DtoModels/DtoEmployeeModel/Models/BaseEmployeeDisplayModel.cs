public class BaseEmployeeDisplayModel : IBaseEmployeeDisplayModel
{
    public string LastName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string? Title { get; set; }
    //public int? YearsOfWorkExperience { get; set; }
    //public int? Age { get; set; }
    //public List<OrdersDisplay?> Orders { get; set; } = new List<OrdersDisplay?>();
}
