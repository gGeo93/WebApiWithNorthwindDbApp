using DataLibrary.DataAccess;
using DataLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Repository;

public class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    private readonly NorthwindContext context;
    public CustomerRepository(NorthwindContext context) : base(context)
    {
        this.context = context;
    }

    NorthwindContext CustomerContext => context as NorthwindContext;    
}
