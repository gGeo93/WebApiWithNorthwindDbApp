using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("AllEmployeesWithTheirBasicInformation")]
        public async Task<ActionResult<IEnumerable<IBaseEmployeeDisplayModel>>> GetAllEmployees()
        {
            var employees = await unitOfWork.Employees.GetAll();
            List<IBaseEmployeeDisplayModel> employeesDisplaying = new List<IBaseEmployeeDisplayModel>();
            foreach (var emp in employees)
            {
                employeesDisplaying.Add(new BaseEmployeeDisplayModel
                {
                    LastName = emp.LastName,
                    FirstName = emp.FirstName,
                    Title = emp.Title
                });
            }
            return employeesDisplaying;
        }
        [HttpGet("SingleEmployeeByName")]
        public async Task<ActionResult<IBaseEmployeeDisplayModel>> GetEmployeeByName(int id)
        {
            var employee = await unitOfWork.Employees.Get(id);
            if (employee == null)
            {
                return BadRequest("Wrong Input");
            }
            IBaseEmployeeDisplayModel employeeDisplaying = new BaseEmployeeDisplayModel
            {
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                Title = employee.Title
            };
            return Ok(employeeDisplaying);
        }
        [HttpGet("OrderedByWorkExperience{descending:bool}")]
        public async Task<ActionResult<IEnumerable<IBaseEmployeeWithExperience>>> GetEmployeesByWorkingExperience(bool descending)
        {
            var dbEmployeesOrdered = await unitOfWork.Employees.GetEmployeesOrderByWorkExperience(descending);
            List<EmployeeWithExperienceDisplayed> employeesDisplaying = new List<EmployeeWithExperienceDisplayed>();
            foreach (var emp in dbEmployeesOrdered)
            {
                employeesDisplaying.Add(new EmployeeWithExperienceDisplayed {
                    LastName = emp.LastName,
                    FirstName = emp.FirstName,
                    Title = emp.Title,
                    YearsOfWorkExperience = DateTime.Now.Year - emp.HireDate.Value.Year
                });
            }
            return employeesDisplaying;
        }

        [HttpGet("OrderedByAge{descending:bool}")]
        public async Task<ActionResult<IEnumerable<IBaseEmployeeByAge>>> GetEmployeesByAge(bool descending)
        {
            var dbEmployeesOrdered = await unitOfWork.Employees.GetEmployeesOrderByAge(descending);
            List<EmployeeByAgeDisplayed> employeesDisplaying = new List<EmployeeByAgeDisplayed>();
            foreach (var emp in dbEmployeesOrdered)
            {
                employeesDisplaying.Add(new EmployeeByAgeDisplayed {
                    LastName = emp.LastName,
                    FirstName = emp.FirstName,
                    Title = emp.Title,
                    Age = DateTime.Now.Year - emp.BirthDate.Value.Year });
            }
            return employeesDisplaying;
        }

        [HttpGet("IncludingOrders")]
        public async Task<ActionResult<IEnumerable<IBaseEmployeeWithOrders>>> GetEmployeesIncludingOrders()
        {
            var dbEmployeesOrdered = await unitOfWork.Employees.GetEmployeesOrders();
            List<EmployeeOrders> employeesDisplaying = new List<EmployeeOrders>();

            foreach (var emp in dbEmployeesOrdered)
            {
                employeesDisplaying.Add(new EmployeeOrders
                {
                    LastName = emp.LastName,
                    FirstName = emp.FirstName,
                    Title = emp.Title,
                });

                List<Order> Orders = emp.Orders.ToList();

                for (int i = 0; i < employeesDisplaying.Count; i++)
                {
                    employeesDisplaying[i].Orders.Add(new OrdersDisplay
                    {
                        OrderDate = Orders[i].OrderDate.Value.ToShortDateString(),
                        RequiredDate = Orders[i].RequiredDate.Value.ToShortDateString(),
                        ShippedDate = Orders[i].ShippedDate == null ? null : Orders[i].ShippedDate.Value.ToShortDateString()
                    });
                }
            }
            return employeesDisplaying;
        }
        [HttpPost]
        public async Task<IActionResult> HireNewEmployee(BaseEmployeeDisplayModel newEmployee)
        {
            Employee emp = new Employee
            {
                LastName = newEmployee.LastName,
                FirstName = newEmployee.FirstName,
                Title = newEmployee.Title
            };
            await unitOfWork.Employees.Add(emp);
            await unitOfWork.Complete();
            return Ok($"The Employee {emp.LastName} {emp.FirstName} has been Hired");
        }
        [HttpDelete]
        public async Task<IActionResult> FireAnEmployee(BaseEmployeeDisplayModel firedEmployee)
        {
            Employee empToSearch = new Employee
            {
                LastName = firedEmployee.LastName,
                FirstName = firedEmployee.FirstName,
                Title = firedEmployee.Title
            };
            Employee empToFire = await unitOfWork.Employees.SearchEmployee(empToSearch);
            if (empToFire == null) 
            {
                return NotFound($"There is no employee called {empToSearch.LastName} {empToSearch.FirstName} working as {empToSearch.Title}");
            }
            unitOfWork.Employees.Remove(empToFire);
            await unitOfWork.Complete();
            return Ok($"The Employee {empToFire.LastName} {empToFire.FirstName} has been Fired");
        }
    }
}
