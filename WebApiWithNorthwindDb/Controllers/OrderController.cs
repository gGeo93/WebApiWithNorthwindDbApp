using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiWithNorthwindDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("GetAllOrderDates")]
        public async Task<ActionResult<IEnumerable<IBaseOrdersDisplayModel>>> GetAllOrderDates()
        {
            var allOrderInfoFromDb = await unitOfWork.Orders.GetAll();
            List<IBaseOrdersDisplayModel> allOrderDates = new List<IBaseOrdersDisplayModel>();
            foreach (var order in allOrderInfoFromDb)
            {
                allOrderDates.Add(new BaseOrdersDisplayModel
                {
                    OrderDate = order.OrderDate,
                    RequiredDate = order.RequiredDate,
                    ShippedDate = order.ShippedDate
                });
            }
            return Ok(allOrderDates);
        }
        [HttpGet("GetOrdersBasedOnCustomerComapny")]
        public async Task<ActionResult<List<BaseOrderWithAllOrderDetails>>> GetOrdersBasedOnCustomerComapny([FromQuery]CustomerBasedOrder customerBasedOrder) 
        {
            List<Order> ordersMetTheCustomerCondition = await unitOfWork.Orders.GetOrdersByCustomerInfo(customerBasedOrder.CompanyNameOfCustomer);
            if (ordersMetTheCustomerCondition == null || ordersMetTheCustomerCondition.Count == 0) 
            {
                return NotFound($"There is no order on schedule or delivered to {customerBasedOrder.CompanyNameOfCustomer}");
            }
            
            List<BaseOrderWithAllOrderDetails> baseOrders = new List<BaseOrderWithAllOrderDetails>();
            
            List<OrderDetailsDisplay> orderDetailsDisplay = new List<OrderDetailsDisplay>();
            foreach (var ord in ordersMetTheCustomerCondition)
            {
                List<OrderDetail> orderDetails = ord.OrderDetails.ToList();
                foreach (var det in orderDetails)
                {
                    orderDetailsDisplay.Add(new OrderDetailsDisplay { ProductId = det.ProductId, UnitPrice = det.UnitPrice, Quantity = det.Quantity, Discount = det.Discount });
                }

            }
            foreach (var ord in ordersMetTheCustomerCondition)
            {
                baseOrders.Add(new BaseOrderWithAllOrderDetails
                {
                    OrderDate = ord.OrderDate,
                    RequiredDate = ord.RequiredDate,
                    ShippedDate = ord.ShippedDate,
                    AllOrderDetails = orderDetailsDisplay
                });
                
            }
           
            return Ok(baseOrders);
        }
        [HttpGet("GetAllOrdersDeliveredToSpecificCustomer")]
        public async Task<ActionResult<IEnumerable<OrderDeliveredToCustomer>>> GetAllOrdersDeliveredToSpecificCustomer([FromQuery] CustomerBasedOrder customerBasedOrder) 
        { 
            var ordersToCustomerFromDb = await unitOfWork.Orders.GetOrdersByCustomerInfo(customerBasedOrder.CompanyNameOfCustomer);
            if (ordersToCustomerFromDb == null || ordersToCustomerFromDb.Count == 0)
            {
                return NotFound($"There is no Customer Company registered as {customerBasedOrder.CompanyNameOfCustomer}");
            }
            List<OrderDeliveredToCustomer> ordersDeliveredToCustomerForDisplaying = new List<OrderDeliveredToCustomer>();
            foreach (var order in ordersToCustomerFromDb)
            {
                ordersDeliveredToCustomerForDisplaying.Add(new OrderDeliveredToCustomer
                {
                    CustomerBasedOrder = new CustomerBasedOrder { CompanyNameOfCustomer = order.Customer.CompanyName },
                    OrderDate = order.OrderDate,
                    ShippedDate = order.ShippedDate,
                    RequiredDate = order.RequiredDate
                });
            }
            return Ok(ordersDeliveredToCustomerForDisplaying);
        }
        [HttpGet("GetAllOrdersAssignToOneEmployee")]
        public async Task<ActionResult<IEnumerable<OrderAssignedToEmployee>>> GetAllOrdersAssignToOneEmployee([FromQuery] EmployeeBasedOrder employeeBasedOrder) 
        {
            var ordersFromEmployeeDb = await unitOfWork.Orders.GetOrdersByEmployeeInfo(employeeBasedOrder.EmployeeFirstName, employeeBasedOrder.EmployeeLastName, employeeBasedOrder.EmployeeTitle);
            
            if (ordersFromEmployeeDb == null || ordersFromEmployeeDb.Count == 0) 
            {
                return NotFound($"These Employee information do not match with any of our employees");
            }
            
            List<OrderAssignedToEmployee> ordersAssignedToEmployee = new List<OrderAssignedToEmployee>();
            
            foreach (var order in ordersFromEmployeeDb)
            {
                ordersAssignedToEmployee.Add(new OrderAssignedToEmployee
                {
                    EmployeeBasedOrder = new EmployeeBasedOrder
                    {
                        EmployeeFirstName = order.Employee.FirstName,
                        EmployeeLastName = order.Employee.LastName,
                        EmployeeTitle = order.Employee.Title
                    },
                    OrderDate = order.OrderDate,
                    ShippedDate = order.ShippedDate,
                    RequiredDate = order.RequiredDate
                });
            }
            return Ok(ordersAssignedToEmployee);
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<OrderDetailsProductDisplay>>> PostProduct(OrderAsAwhole orderAsAwhole)
        {
            int empId = unitOfWork.Employees.Find(emp => emp.LastName == orderAsAwhole.EmployeeBasedOrder.EmployeeLastName).EmployeeId;
            string? customerId = unitOfWork.Customers.Find(cust => cust.CompanyName == orderAsAwhole.CustomerBasedOrder.CompanyNameOfCustomer).CustomerId;

            Order order = new Order()
            {
                EmployeeId = empId,
                CustomerId = customerId,
                OrderDate = orderAsAwhole.OrderDate,
                RequiredDate = orderAsAwhole.RequiredDate,
                ShippedDate = orderAsAwhole.ShippedDate,
                ShipVia = orderAsAwhole.ShipVia,
                Freight = orderAsAwhole.Freight,
                ShipName = orderAsAwhole.ShipName,
                ShipAddress = orderAsAwhole.ShipAddress,
                ShipCity = orderAsAwhole.ShipCity,
                ShipRegion = orderAsAwhole.ShipRegion,
                ShipPostalCode = orderAsAwhole.ShipPostalCode,
                ShipCountry = orderAsAwhole.ShipCountry
            };

            List<Product> beingOrderedProductsInDb = new List<Product>();
            List<OrderDetailsProductDisplay> orderDetailsProductDisplayed = new List<OrderDetailsProductDisplay>();


            foreach (var details in orderAsAwhole.AllOrderDetails)
            {
                order.OrderDetails.Add(new OrderDetail
                {
                    ProductId = details.ProductId,
                    UnitPrice = details.UnitPrice,
                    Quantity = details.Quantity,
                    Discount = details.Discount
                });
                beingOrderedProductsInDb.Add(unitOfWork.Products.Find(pro => pro.ProductId == details.ProductId));
                orderDetailsProductDisplayed.Add(new OrderDetailsProductDisplay
                {
                    ProductName = beingOrderedProductsInDb[beingOrderedProductsInDb.Count - 1].ProductName,
                    UnitsInstoke = (short?)(beingOrderedProductsInDb[beingOrderedProductsInDb.Count - 1].UnitsInStock - details.Quantity)
                });
            }

            await unitOfWork.Orders.Add(order);
            await unitOfWork.Complete();

            return Ok(orderDetailsProductDisplayed);
        }

    }
}    