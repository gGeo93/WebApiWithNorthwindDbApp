using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SupplierRepository : Repository<Supplier>, ISupplierRepository
{
    private readonly NorthwindContext context;

    public SupplierRepository(NorthwindContext context) : base(context)
    {
        this.context = context;
    }
    public NorthwindContext Suppliers => context as NorthwindContext;
}
