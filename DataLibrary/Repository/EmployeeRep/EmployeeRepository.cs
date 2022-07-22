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

    public Employee GetEmployeeByNumberOfAddress(int numberOfAddress)
    {
        string addressTextNumber = numberOfAddress.ToString();
        Employee employee = EmployeeContext.Set<Employee>().FirstOrDefault(emp => emp.Address.Contains(addressTextNumber));
        if (employee == null) 
        {
            return null;
        }
        string address = employee.Address;
        string[] addressPropertySplit = address.Split(' ');
        if (addressPropertySplit == null || addressPropertySplit[0] == null || addressPropertySplit[0] != addressTextNumber) 
        {
            return null;
        }
        return employee;
    }
}
