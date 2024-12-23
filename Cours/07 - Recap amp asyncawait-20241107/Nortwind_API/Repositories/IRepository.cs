using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Nortwind_API.Repositories
{
    // interface générique pour les repositories
    public interface IRepository<T> 
    {
        Task InsertAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IList<T>> SearchForAsync(Expression<Func<T, bool>> predicate);
        // save entity, test via predicate if entity exists
        Task<bool?> SaveAsync(T entity, Expression<Func<T, bool>> predicate);
        Task<bool?> SaveAsync(T entity);
        Task<IList<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
    }
}
