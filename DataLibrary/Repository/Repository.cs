using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext context;

        public Repository(DbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> Get(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }
        public async Task Add(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRange(IEnumerable<TEntity> collectionOfTheEntity)
        {
            await context.Set<TEntity>().AddRangeAsync(collectionOfTheEntity);
        }

        public async Task<IEnumerable<TEntity>> FindAll(Expression<Func<TEntity,bool>> expression)
        {
            return await context.Set<TEntity>().Where(expression).ToListAsync();
        }


        public void Remove(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> collectionOfTheEntity)
        {
            context.Set<TEntity>().RemoveRange(collectionOfTheEntity);
        }
    }
}
