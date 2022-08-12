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
        CustomersDemographic = new CustomerDemographicRepository(this.context);
        OrderDetails = new OrderDetailsRepository(this.context);
        Orders = new OrderRepository(this.context);
        Products = new ProductRepository(this.context);
        Regions = new RegionRepository(this.context);
        Shippers = new ShipperRepository(this.context);
        Suppliers = new SupplierRepository(this.context);
        Territories = new TerritoryRepository(this.context);
        TurnoverPerCustomer = new SpRepository(this.context);
    }
    public IEmployeeRepository Employees { get; }
    public ICategoryRepository Categories { get; }
    public ICustomerRepository Customers { get; }
    public ICustomerDemographicRepository CustomersDemographic { get; }
    public IOrderDetailsRepository OrderDetails { get; }
    public IOrderRepository Orders { get; }
    public IProductRepository Products { get; }
    public IRegionRepository Regions { get; }
    public IShipperRepository Shippers { get; }
    public ISupplierRepository Suppliers { get; }
    public ITerritoryRepository Territories { get; }
    public ISpRepository TurnoverPerCustomer { get; }

    public async Task Complete()
    {
        await context.SaveChangesAsync();
    }

    public void Dispose()
    {
        context.Dispose();
    }
}
