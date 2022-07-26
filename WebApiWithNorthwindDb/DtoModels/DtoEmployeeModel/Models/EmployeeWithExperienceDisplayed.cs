public class EmployeeWithExperienceDisplayed : IBaseEmployeeWithExperience
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string? Title { get; set; }
    public int? YearsOfWorkExperience { get; set; }
}
