using DataLibrary.DataAccess;
using DataLibrary.Repository.CategoryRep;
using DataLibrary.Repository.EmployeeRep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NorthwindContext context;
        public UnitOfWork(NorthwindContext context)
        {
            this.context = context;
            Employees = new EmployeeRepository(this.context);
            Categories = new CategoryRepository(this.context);
        }
        public IEmployeeRepository Employees { get; }
        public ICategoryRepository Categories { get; }

        public async Task Complete()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
