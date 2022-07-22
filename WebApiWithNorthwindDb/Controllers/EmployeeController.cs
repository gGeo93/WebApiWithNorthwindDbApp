using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiWithNorthwindDb.Display_Models;

namespace WebApiWithNorthwindDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public EmployeeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDisplayModel>>> GetAllEmployees()
        {
            var employees = await unitOfWork.Employees.GetAll();
            List<EmployeeDisplayModel> employeesDisplaying = new List<EmployeeDisplayModel>();
            foreach (var emp in employees)
            {
                employeesDisplaying.Add(new EmployeeDisplayModel { LastName = emp.LastName, FirstName = emp.FirstName });
            }
            return Ok(employeesDisplaying);
        }
        [HttpGet("{numberOfAddress}")]
        public async Task<ActionResult<EmployeeDisplayModel>> GetEmployeeByNumberOfaddress(int numberOfAddress) 
        { 
            var employee = await unitOfWork.Employees.GetEmployeeByNumberOfAddress(numberOfAddress);
            
            if (employee == null) 
            {
                return NotFound("There is no Employee with this address number.");
            }

            EmployeeDisplayModel employeeDisplaying = new EmployeeDisplayModel()
            {
                LastName = employee.LastName,
                FirstName = employee.FirstName
            };
            return Ok(employeeDisplaying);
        }
    }
}
