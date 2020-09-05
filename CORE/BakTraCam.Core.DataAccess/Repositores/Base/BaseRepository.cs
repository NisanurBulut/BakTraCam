using BakTraCam.Core.DataAccess.Context;
using BakTraCam.Util.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BakTraCam.Core.DataAccess.Repositores.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected DbContext Context { get; }



        public BaseRepository(DatabaseContext  factory)
        {

            Context = factory;
           
        }

    

        public virtual IQueryable<T> Queryable => AllQueryable;

        public IQueryable<T> AllQueryable => Set.AsQueryable();

        protected DbSet<T> Set => Context.Set<T>();



        public IQueryable<T> RawQuery(string sql, params object[] parameters)
        {
            return Set.FromSqlRaw(sql, parameters);
        }

        #region CRUD
        public void Add(T item)
        {
          

            Set.Add(item);
        }

        public async Task AddAsync(T item)
        {
            

            await Set.AddAsync(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            Set.AddRange(items);
        }

        public Task AddRangeAsync(IEnumerable<T> items)
        {
            return Set.AddRangeAsync(items);
        }

        public void Update(T item)
        {
            Context.DetectChangesLazyLoading(true);

           

            Set.Attach(item);
            var entry = Context.Entry(item);
            entry.State = EntityState.Modified;

            Context.DetectChangesLazyLoading(false);
        }

        public Task UpdateAsync(T item)
        {
            Update(item);

            return Task.CompletedTask;
        }

        public virtual void Delete(Expression<Func<T, bool>> where, bool ignoreSoftDelete = false)
        {
            Context.DetectChangesLazyLoading(true);

            IQueryable<T> items = Set.Where(where);

            if (items == null)
                return;

            Set.RemoveRange(items);

            Context.DetectChangesLazyLoading(false);
        }

        public Task DeleteAsync(Expression<Func<T, bool>> where, bool ignoreSoftDelete = false)
        {
            Delete(where, ignoreSoftDelete);

            return Task.CompletedTask;
        }
        #endregion

        #region SelectOnlyActive
        public bool Any()
        {
            return Queryable.Any();
        }

        public Task<bool> AnyAsync()
        {
            return Queryable.AnyAsync();
        }

        public bool Any(Expression<Func<T, bool>> where)
        {
            return Queryable.Any(where);
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> where)
        {
            return Queryable.AnyAsync(where);
        }

        public long Count()
        {
            return Queryable.LongCount();
        }

        public Task<long> CountAsync()
        {
            return Queryable.LongCountAsync();
        }

        public long Count(Expression<Func<T, bool>> where)
        {
            return Queryable.LongCount(where);
        }

        public Task<long> CountAsync(Expression<Func<T, bool>> where)
        {
            return Queryable.LongCountAsync(where);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> where)
        {
            return Queryable.Where(where).FirstOrDefault();
        }

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where)
        {
            return Queryable.Where(where).FirstOrDefaultAsync();
        }

        public TResult FirstOrDefault<TResult>(Expression<Func<T, bool>> where)
        {
            return Queryable.Where(where).Project<T, TResult>().FirstOrDefault();
        }

        public Task<TResult> FirstOrDefaultAsync<TResult>(Expression<Func<T, bool>> where)
        {
            return Queryable.Where(where).Project<T, TResult>().FirstOrDefaultAsync();
        }

        public T FirstOrDefault(params Expression<Func<T, object>>[] include)
        {
            return Queryable.Include(include).FirstOrDefault();
        }

        public Task<T> FirstOrDefaultAsync(params Expression<Func<T, object>>[] include)
        {
            return Queryable.Include(include).FirstOrDefaultAsync();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return Queryable.Where(where).Include(include).FirstOrDefault();
        }

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return Queryable.Where(where).Include(include).FirstOrDefaultAsync();
        }

        public IEnumerable<T> List()
        {
            return Queryable.ToList();
        }

        public async Task<IEnumerable<T>> ListAsync()
        {
            return await Queryable.ToListAsync().ConfigureAwait(false);
        }

        public IEnumerable<TResult> List<TResult>()
        {
            return Queryable.Project<T, TResult>().ToList();
        }

        public async Task<IEnumerable<TResult>> ListAsync<TResult>()
        {
            return await Queryable.Project<T, TResult>().ToListAsync().ConfigureAwait(false);
        }

        public IEnumerable<T> List(Expression<Func<T, bool>> where)
        {
            return Queryable.Where(where).ToList();
        }

        public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> where)
        {
            return await Queryable.Where(where).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> where, Expression<Func<T, object>> order, bool desc)
        {
            if (desc)
                return await Queryable.Where(where).OrderByDescending(order).ToListAsync().ConfigureAwait(false);
            else
                return await Queryable.Where(where).OrderBy(order).ToListAsync().ConfigureAwait(false);
        }

        public IEnumerable<TResult> List<TResult>(Expression<Func<T, bool>> where)
        {
            return Queryable.Where(where).Project<T, TResult>().ToList();
        }

        public async Task<IEnumerable<TResult>> ListAsync<TResult>(Expression<Func<T, bool>> where)
        {
            return await Queryable.Where(where).Project<T, TResult>().ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<TResult>> ListAsync<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, object>> order, bool desc)
        {
            if (desc)
                return await Queryable.Where(where).OrderByDescending(order).Project<T, TResult>().ToListAsync().ConfigureAwait(false);
            else
                return await Queryable.Where(where).OrderBy(order).Project<T, TResult>().ToListAsync().ConfigureAwait(false);
        }

        public IEnumerable<T> List(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return Queryable.Where(where).Include(include).ToList();
        }

        public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return await Queryable.Where(where).Include(include).ToListAsync().ConfigureAwait(false);
        }

        public IEnumerable<TResult> List<TResult>(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return Queryable.Where(where).Include(include).Project<T, TResult>().ToList();
        }

        public async Task<IEnumerable<TResult>> ListAsync<TResult>(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return await Queryable.Where(where).Include(include).Project<T, TResult>().ToListAsync().ConfigureAwait(false);
        }

       

       
        #endregion

        #region SelectWithDeleted
        public bool AnyWithDeleted()
        {
            return AllQueryable.Any();
        }

        public Task<bool> AnyWithDeletedAsync()
        {
            return AllQueryable.AnyAsync();
        }

        public bool AnyWithDeleted(Expression<Func<T, bool>> where)
        {
            return AllQueryable.Any(where);
        }

        public Task<bool> AnyWithDeletedAsync(Expression<Func<T, bool>> where)
        {
            return AllQueryable.AnyAsync(where);
        }

        public long CountWithDeleted()
        {
            return AllQueryable.LongCount();
        }

        public Task<long> CountWithDeletedAsync()
        {
            return AllQueryable.LongCountAsync();
        }

        public long CountWithDeleted(Expression<Func<T, bool>> where)
        {
            return AllQueryable.LongCount(where);
        }

        public Task<long> CountWithDeletedAsync(Expression<Func<T, bool>> where)
        {
            return AllQueryable.LongCountAsync(where);
        }

        public T FirstOrDefaultWithDeleted(Expression<Func<T, bool>> where)
        {
            return AllQueryable.Where(where).FirstOrDefault();
        }

        public Task<T> FirstOrDefaultWithDeletedAsync(Expression<Func<T, bool>> where)
        {
            return AllQueryable.Where(where).FirstOrDefaultAsync();
        }

        public TResult FirstOrDefaultWithDeleted<TResult>(Expression<Func<T, bool>> where)
        {
            return AllQueryable.Where(where).Project<T, TResult>().FirstOrDefault();
        }

        public Task<TResult> FirstOrDefaultWithDeletedAsync<TResult>(Expression<Func<T, bool>> where)
        {
            return AllQueryable.Where(where).Project<T, TResult>().FirstOrDefaultAsync();
        }

        public T FirstOrDefaultWithDeleted(params Expression<Func<T, object>>[] include)
        {
            return AllQueryable.Include(include).FirstOrDefault();
        }

        public Task<T> FirstOrDefaultWithDeletedAsync(params Expression<Func<T, object>>[] include)
        {
            return AllQueryable.Include(include).FirstOrDefaultAsync();
        }

        public T FirstOrDefaultWithDeleted(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return AllQueryable.Where(where).Include(include).FirstOrDefault();
        }

        public Task<T> FirstOrDefaultWithDeletedAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return AllQueryable.Where(where).Include(include).FirstOrDefaultAsync();
        }

        public IEnumerable<T> ListWithDeleted()
        {
            return AllQueryable.ToList();
        }

        public async Task<IEnumerable<T>> ListWithDeletedAsync()
        {
            return await AllQueryable.ToListAsync().ConfigureAwait(false);
        }

        public IEnumerable<TResult> ListWithDeleted<TResult>()
        {
            return AllQueryable.Project<T, TResult>().ToList();
        }

        public async Task<IEnumerable<TResult>> ListWithDeletedAsync<TResult>()
        {
            return await AllQueryable.Project<T, TResult>().ToListAsync().ConfigureAwait(false);
        }

        public IEnumerable<T> ListWithDeleted(Expression<Func<T, bool>> where)
        {
            return AllQueryable.Where(where).ToList();
        }

        public async Task<IEnumerable<T>> ListWithDeletedAsync(Expression<Func<T, bool>> where)
        {
            return await AllQueryable.Where(where).ToListAsync().ConfigureAwait(false);
        }

        public IEnumerable<TResult> ListWithDeleted<TResult>(Expression<Func<T, bool>> where)
        {
            return AllQueryable.Where(where).Project<T, TResult>().ToList();
        }

        public async Task<IEnumerable<TResult>> ListWithDeletedAsync<TResult>(Expression<Func<T, bool>> where)
        {
            return await AllQueryable.Where(where).Project<T, TResult>().ToListAsync().ConfigureAwait(false);
        }

     

     
        #endregion
    }
}
