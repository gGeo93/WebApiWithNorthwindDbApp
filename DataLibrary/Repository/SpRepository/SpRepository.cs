using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SpRepository : Repository<TurnoverPerCustomer>, ISpRepository
{
    private readonly NorthwindContext context;

    public SpRepository(NorthwindContext context) : base(context)
    {
        this.context = context;
    }

    public NorthwindContext TurnoverPerCustomerContext => context as NorthwindContext;

    public IEnumerable<TurnoverPerCustomer> TurnoverPerCustomer()
    {
        var spResult = context.TurnoverPerCustomers.FromSqlRaw($"EXEC [dbo].[TurnoverPerCustomer]").ToList();
        return spResult;
    }
}
