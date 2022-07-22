using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CustomerDemographicRepository : Repository<CustomerDemographic>, ICustomerDemographicRepository
{
    private readonly NorthwindContext context;

    public CustomerDemographicRepository(NorthwindContext context) : base(context)
    {
        this.context = context;
    }

    public NorthwindContext CustomerDemographics => context as NorthwindContext;
}
