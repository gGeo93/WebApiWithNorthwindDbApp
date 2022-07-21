using DataLibrary.DataAccess;
using DataLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Repository.CategoryRep
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly NorthwindContext context;
        public CategoryRepository(NorthwindContext context) : base(context)
        {
            this.context = context;
        }

        public NorthwindContext Categories => context as NorthwindContext;
    }
}
