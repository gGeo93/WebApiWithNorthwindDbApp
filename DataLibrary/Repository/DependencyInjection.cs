using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class DependencyInjection
{
    public static IServiceCollection AddRepository(this IServiceCollection services) 
    {
        services.AddDbContext<NorthwindContext>();

        services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<ICustomerRepository, CustomerRepository>();
        services.AddTransient<ICustomerDemographicRepository, CustomerDemographicRepository>();
        services.AddTransient<IOrderDetailsRepository, OrderDetailsRepository>();
        services.AddTransient<IOrderRepository, OrderRepository>();
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IRegionRepository, RegionRepository>();
        services.AddTransient<IShipperRepository, ShipperRepository>();
        services.AddTransient<ISupplierRepository, SupplierRepository>();
        services.AddTransient<ITerritoryRepository, TerritoryRepository>();

        services.AddTransient<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
