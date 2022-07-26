using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLibrary;

public class EmployeeControllerLogic : IEmployeeControllerLogic
{
    private readonly IUnitOfWork unitOfWork;

    public EmployeeControllerLogic(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<EmployeeDisplayModel>> GetAllDisplayModelEmployees()
    {
        var employees = await unitOfWork.Employees.GetAll();
        List<EmployeeDisplayModel> employeesDisplaying = new List<EmployeeDisplayModel>();
        foreach (var emp in employees)
        {
            employeesDisplaying.Add(new EmployeeDisplayModel { LastName = emp.LastName, FirstName = emp.FirstName });
        }
        return employeesDisplaying;
    }

    public EmployeeDisplayModel GetEmployeeByNumberOfaddress(int numberOfAddress)
    {
        var employee = unitOfWork.Employees.GetEmployeeByNumberOfAddress(numberOfAddress);

        if (employee == null)
        {
            return  null;
        }

        EmployeeDisplayModel employeeDisplaying = new EmployeeDisplayModel()
        {
            LastName = employee.LastName,
            FirstName = employee.FirstName
        };

        return employeeDisplaying;
    }
}
