using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RegionRepository : Repository<Region>, IRegionRepository
{
    private readonly NorthwindContext context;

    public RegionRepository(NorthwindContext context) : base(context)
    {
        this.context = context;
    }
    public NorthwindContext Regions => context as NorthwindContext;
}
