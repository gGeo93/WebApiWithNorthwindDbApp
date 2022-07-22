using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
{
    private readonly NorthwindContext context;
    public EmployeeRepository(NorthwindContext context) : base(context)
    {
        this.context = context;
    }

    public NorthwindContext EmployeeContext => context as NorthwindContext;
}
