public class EmployeeByAgeDisplayed : IBaseEmployeeByAge
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Title { get; set; }
    public int? Age { get; set; }
}
