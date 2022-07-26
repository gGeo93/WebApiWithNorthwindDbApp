
namespace BusinessLogicLibrary;

public interface IEmployeeControllerLogic
{
    Task<IEnumerable<EmployeeDisplayModel>> GetAllDisplayModelEmployees();
    EmployeeDisplayModel GetEmployeeByNumberOfaddress(int numberOfaddress);
}
