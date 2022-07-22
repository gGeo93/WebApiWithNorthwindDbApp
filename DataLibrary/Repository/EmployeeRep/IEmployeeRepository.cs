using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IEmployeeRepository : IRepository<Employee>
{
    Employee GetEmployeeByNumberOfAddress(int numberOfAddress);
}
