using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IUnitOfWork : IDisposable
{
    IEmployeeRepository Employees { get; }
    ICategoryRepository Categories { get; }
    ICustomerRepository Customers { get; }
    ICustomerDemographicRepository CustomersDemographic { get; }
    IOrderDetailsRepository OrderDetails { get; }
    Task Complete();
}
