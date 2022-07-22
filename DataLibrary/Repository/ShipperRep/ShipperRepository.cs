using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ShipperRepository : Repository<Shipper>, IShipperRepository
{
    private readonly NorthwindContext context;

    public ShipperRepository(NorthwindContext context) : base(context)
    {
        this.context = context;
    }
    NorthwindContext Shippers => context as NorthwindContext;
}
