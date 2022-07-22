using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ProductRepository : Repository<Product>, IProductRepository
{
    private readonly NorthwindContext context;

    public ProductRepository(NorthwindContext context) : base(context)
    {
        this.context = context;
    }

    public NorthwindContext Products => context as NorthwindContext;
}
