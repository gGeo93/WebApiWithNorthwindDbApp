using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    private readonly NorthwindContext context;

    public OrderRepository(NorthwindContext context) : base(context)
    {
        this.context = context;
    }

    NorthwindContext Orders => context as NorthwindContext;


    async Task<int> IOrderRepository.GetLastOrderId()
    {
        Order order = await context.Set<Order>().OrderBy(o => o.OrderId).LastAsync();
        return order.OrderId;
    }

    async Task<List<Order>> IOrderRepository.GetOrdersByCustomerInfo(string companyNameOfCustomer)
    {
        return await context.Set<Order>().Include(c => c.Customer).Include(d => d.OrderDetails).Where(ord => ord.Customer.CompanyName == companyNameOfCustomer).ToListAsync();
    }
    public async Task<List<Order>> GetOrdersByEmployeeInfo(string firstName, string lastName, string title)
    {
        return await context.Set<Order>().Include(emp => emp.Employee).Where(
            ord => ord.Employee.FirstName == firstName 
            && ord.Employee.LastName == lastName
            && ord.Employee.Title == title).ToListAsync();
    }
}
