using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace BetterboardOpgave.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T>CreateAsync(T entity);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? criteria = null, Func<IQueryable<T>,
         IIncludableQueryable<T, object>>? includes = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null);
    }
}
