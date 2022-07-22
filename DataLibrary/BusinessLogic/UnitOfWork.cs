using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UnitOfWork : IUnitOfWork
{
    private readonly NorthwindContext context;
    public UnitOfWork(NorthwindContext context)
    {
        this.context = context;
        Employees = new EmployeeRepository(this.context);
        Categories = new CategoryRepository(this.context);
        Customers = new CustomerRepository(this.context);
    }
    public IEmployeeRepository Employees { get; }
    public ICategoryRepository Categories { get; }
    public ICustomerRepository Customers { get; }

    public async Task Complete()
    {
        await context.SaveChangesAsync();
    }

    public void Dispose()
    {
        context.Dispose();
    }
}
