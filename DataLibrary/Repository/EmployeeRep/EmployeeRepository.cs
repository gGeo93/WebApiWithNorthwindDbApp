using DataLibrary.DataAccess;
using DataLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Repository.EmployeeRep
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly NorthwindContext context;
        public EmployeeRepository(NorthwindContext context) : base(context)
        {
            this.context = context;
        }

        public NorthwindContext NorthwindContext => context as NorthwindContext;
    }
}
