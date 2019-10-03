using BookService.WebAPI.Data;
using BookService.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookService.WebAPI.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        protected readonly BookServiceContext db;

        public Repository(BookServiceContext context)
        {
            db = context;
        }

        public virtual async Task<T> GetById(int id)
        {
            return await db.Set<T>().FindAsync(id);
        }

        // get an IQueryAble: to manipulate with deferred execution
        public virtual IQueryable<T> GetAll()
        {
            // Entities won't be manipulated directly on this set --> faster with AsNoTracking()
            return db.Set<T>().AsNoTracking();
        }

        public async Task<IEnumerable<T>> ListAll()
        {
            return await GetAll().ToListAsync();
        }


        public virtual IQueryable<T> GetFiltered(Expression<Func<T, bool>> predicate)
        {
            return db.Set<T>()
                   .Where(predicate).AsNoTracking();
        }

        public async virtual Task<IEnumerable<T>> ListFiltered(Expression<Func<T, bool>> predicate)
        {
            return await GetFiltered(predicate).ToListAsync();
        }

        public async Task<T> Add(T entity)
        {
            db.Set<T>().Add(entity);
            try
            {
                await db.SaveChangesAsync();
            }
            catch
            {
                return null;
            }
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            try
            {
                await db.SaveChangesAsync();
            }
            catch
            {
                return null;
            }
            return entity;
        }

        public async Task<T> Delete(T entity)
        {
            db.Set<T>().Remove(entity);
            try
            {
                await db.SaveChangesAsync();
            }
            catch
            {
                return null;
            }
            return entity;
        }

        public async Task<T> Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null) return null;
            return await Delete(entity);
        }

        private async Task<bool> Exists(int id)
        {
            return await db.Set<T>().AnyAsync(e => e.Id == id);
        }
    }
}
