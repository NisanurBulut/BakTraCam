using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BakTraCam.Core.DataAccess.Repositores.Base
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> Queryable { get; }
        IQueryable<T> AllQueryable { get; }

        IQueryable<T> RawQuery(string sql, params object[] parameters);

        #region CRUD
        void Add(T item);
        Task AddAsync(T item);
        void AddRange(IEnumerable<T> items);
        Task AddRangeAsync(IEnumerable<T> items);
        void Update(T item);
        Task UpdateAsync(T item);
        void Delete(Expression<Func<T, bool>> where, bool ignoreSoftDelete = false);
        Task DeleteAsync(Expression<Func<T, bool>> where, bool ignoreSoftDelete = false);
        #endregion
        #region SelectOnlyActive
        bool Any();
        Task<bool> AnyAsync();
        bool Any(Expression<Func<T, bool>> where);
        Task<bool> AnyAsync(Expression<Func<T, bool>> where);
        long Count();
        Task<long> CountAsync();
        long Count(Expression<Func<T, bool>> where);
        Task<long> CountAsync(Expression<Func<T, bool>> where);
        T FirstOrDefault(Expression<Func<T, bool>> where);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where);
        TResult FirstOrDefault<TResult>(Expression<Func<T, bool>> where);
        Task<TResult> FirstOrDefaultAsync<TResult>(Expression<Func<T, bool>> where);
        T FirstOrDefault(params Expression<Func<T, object>>[] include);
        Task<T> FirstOrDefaultAsync(params Expression<Func<T, object>>[] include);
        T FirstOrDefault(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);
        IEnumerable<T> List();
        Task<IEnumerable<T>> ListAsync();
        IEnumerable<TResult> List<TResult>();
        Task<IEnumerable<TResult>> ListAsync<TResult>();
        IEnumerable<T> List(Expression<Func<T, bool>> where);
        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> where);
        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> where, Expression<Func<T, object>> order, bool desc);
        IEnumerable<TResult> List<TResult>(Expression<Func<T, bool>> where);
        Task<IEnumerable<TResult>> ListAsync<TResult>(Expression<Func<T, bool>> where);
        Task<IEnumerable<TResult>> ListAsync<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, object>> order, bool desc);
        IEnumerable<T> List(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);
        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);
        IEnumerable<TResult> List<TResult>(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);
        Task<IEnumerable<TResult>> ListAsync<TResult>(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

        #endregion
        #region SelectWithDeleted
        bool AnyWithDeleted();
        Task<bool> AnyWithDeletedAsync();
        bool AnyWithDeleted(Expression<Func<T, bool>> where);
        Task<bool> AnyWithDeletedAsync(Expression<Func<T, bool>> where);
        long CountWithDeleted();
        Task<long> CountWithDeletedAsync();
        long CountWithDeleted(Expression<Func<T, bool>> where);
        Task<long> CountWithDeletedAsync(Expression<Func<T, bool>> where);
        T FirstOrDefaultWithDeleted(Expression<Func<T, bool>> where);
        Task<T> FirstOrDefaultWithDeletedAsync(Expression<Func<T, bool>> where);
        TResult FirstOrDefaultWithDeleted<TResult>(Expression<Func<T, bool>> where);
        Task<TResult> FirstOrDefaultWithDeletedAsync<TResult>(Expression<Func<T, bool>> where);
        T FirstOrDefaultWithDeleted(params Expression<Func<T, object>>[] include);
        Task<T> FirstOrDefaultWithDeletedAsync(params Expression<Func<T, object>>[] include);
        T FirstOrDefaultWithDeleted(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);
        Task<T> FirstOrDefaultWithDeletedAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);
        IEnumerable<T> ListWithDeleted();
        Task<IEnumerable<T>> ListWithDeletedAsync();
        IEnumerable<TResult> ListWithDeleted<TResult>();
        Task<IEnumerable<TResult>> ListWithDeletedAsync<TResult>();
        IEnumerable<T> ListWithDeleted(Expression<Func<T, bool>> where);
        Task<IEnumerable<T>> ListWithDeletedAsync(Expression<Func<T, bool>> where);
        IEnumerable<TResult> ListWithDeleted<TResult>(Expression<Func<T, bool>> where);
        Task<IEnumerable<TResult>> ListWithDeletedAsync<TResult>(Expression<Func<T, bool>> where);

        #endregion
    }
    
}
