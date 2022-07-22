using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class OrderDetailsRepository : Repository<OrderDetail>,IOrderDetailsRepository
{
    private readonly NorthwindContext context;
    public OrderDetailsRepository(NorthwindContext context) : base(context)
    {
        this.context = context;
    }

    NorthwindContext OrderDetails => context as NorthwindContext;
}
