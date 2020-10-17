using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrdersAPI.Data;
using OrdersAPI.Repositories.Interfaces;

namespace OrdersAPI.Repositories
{
    public abstract class ACRUDRepository<T> : ICRUDRepository<T> where T : class
    {
        protected DataContext Context { get; private set; }
        protected DbSet<T> DbSet { get; private set; }

        public ACRUDRepository(DataContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }

        public virtual async Task<T> Insert(T entity)
        {
            await DbSet.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> Update(T entity)
        {
            DbSet.Update(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> Delete(T entity)
        {
            DbSet.Remove(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<List<T>> Get(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> result = DbSet;
            foreach (var include in includes)
                result = result.Include(include);

            var finalResult = await result.AsNoTracking().ToListAsync();
            return finalResult;
        }

        public virtual async Task<T> GetByID(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> result = DbSet;
            foreach (var include in includes)
                result = result.Include(include);

            var finalResult = await result.SingleOrDefaultAsync(where);
            return finalResult;
        }

        public virtual async Task<T> Find(int id)
        {
            var result = await DbSet.FindAsync(id);
            return result;
        }
    }
}