using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
{
    private readonly NorthwindContext context;
    public EmployeeRepository(NorthwindContext context) : base(context)
    {
        this.context = context;
    }

    public NorthwindContext EmployeeContext => context as NorthwindContext;

    public async Task<IEnumerable<Employee>> GetEmployeesOrderByWorkExperience(bool descending)
    {
        if (descending)
        {
            return await context.Set<Employee>().OrderByDescending(emp => emp.HireDate).ToListAsync();
        }
        else 
        {
            return await context.Set<Employee>().OrderBy(emp => emp.HireDate).ToListAsync();
        }
    }
    public async Task<IEnumerable<Employee>> GetEmployeesOrderByAge(bool descending)
    {
        if (descending)
        {
            return await context.Set<Employee>().OrderByDescending(emp => emp.BirthDate).ToListAsync();
        }
        else
        {
            return await context.Set<Employee>().OrderBy(emp => emp.BirthDate).ToListAsync();
        }
    }

    public async Task<IEnumerable<Employee>> GetEmployeesOrders()
    {
        return await context.Set<Employee>().Include(ord => ord.Orders).ToListAsync();
    }

    public async Task<Employee?> SearchEmployee(Employee employee)
    {
       return await context.Set<Employee>().FirstOrDefaultAsync(e => e.LastName == employee.LastName && e.FirstName == employee.FirstName && e.Title == employee.Title);
    }
}
