using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OrdersAPI.Repositories.Interfaces
{
    public interface ICRUDRepository<T>
    {
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
        Task<List<T>> Get(params Expression<Func<T, object>>[] includes);
        Task<T> GetByID(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes);
        Task<T> Find(int id);
    }
}