using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IOrderRepository : IRepository<Order>
{
    Task<int> GetLastOrderId();
    Task<List<Order>> GetOrdersByCustomerInfo(string companyNameOfCustomer);
    Task<List<Order>> GetOrdersByEmployeeInfo(string firstName, string lastName, string title);
}
