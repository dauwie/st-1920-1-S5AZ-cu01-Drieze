using BookService.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookService.WebAPI.Repositories
{
    public interface IRepository<T> where T: EntityBase
    {
        Task<T> GetById(int id);
        IQueryable<T> GetAll();
        Task<IEnumerable<T>> ListAll();
        IQueryable<T> GetFiltered(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> ListFiltered(Expression<Func<T, bool>> predicate);
        Task<T> Add(T entity);
        Task<T> Delete(T entity);
        Task<T> Delete(int id);
        Task<T> Update(T entity);
    }
}
