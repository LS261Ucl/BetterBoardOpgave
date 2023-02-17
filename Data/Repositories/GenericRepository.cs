using BetterboardOpgave.Application.Interfaces;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BetterboardOpgave.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _context;

        public GenericRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                await _context.SaveChangesAsync();

                return entity;
            }//try
            catch (Exception ex)
            {
                throw new Exception("Repository", ex.InnerException);
            }//catch
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? criteria = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? includes = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null)
        {
            try
            {
                IQueryable<T> query = _context.Set<T>().AsNoTracking();

                if (criteria != null)
                {
                    query = query.Where(criteria);
                }//if

                if (includes != null)
                {
                    query = includes(query);
                }//if

                if (orderBy != null)
                {
                    query = orderBy(query);
                }//if

                return await query.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Repository", ex.InnerException);
            }
        }
    }
}
