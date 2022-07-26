using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IEmployeeRepository : IRepository<Employee>
{
    Task<IEnumerable<Employee>> GetEmployeesOrderByWorkExperience(bool ascending);
    Task<IEnumerable<Employee>> GetEmployeesOrderByAge(bool descending);
    Task<IEnumerable<Employee>> GetEmployeesOrders();
    Task<Employee> SearchEmployee(Employee employee);
}
