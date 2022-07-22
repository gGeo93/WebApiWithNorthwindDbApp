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
}
