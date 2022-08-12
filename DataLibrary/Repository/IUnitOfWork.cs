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
    ISpRepository TurnoverPerCustomer { get; }
    ICustomerDemographicRepository CustomersDemographic { get; }
    IOrderDetailsRepository OrderDetails { get; }
    IOrderRepository Orders { get; }
    IProductRepository Products { get; }
    IRegionRepository Regions { get; }
    IShipperRepository Shippers { get; }
    ISupplierRepository Suppliers { get; }
    ITerritoryRepository Territories { get; }

    Task Complete();
}
