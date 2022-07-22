using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class TerritoryRepository : Repository<Territory>, ITerritoryRepository
{
    private readonly NorthwindContext context;

    public TerritoryRepository(NorthwindContext context) : base(context)
    {
        this.context = context;
    }
    public NorthwindContext Territories => context as NorthwindContext;
}
