using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BakTraCam.Core.DataAccess.UnitOfWork
{
    public interface IDatabaseUnitOfWork
    {
        int SaveChanges();

        Task<int> SaveChangesAsync();

        IDbContextTransaction BeginTransaction();

        Task<IDbContextTransaction> BeginTransactionAsync();

        Task ExecuteSqlCommand(string sql, params object[] parameters);

        Task<List<TResult>> RawQueryAsync<TResult>(string sql, params object[] parameters) where TResult : class;
    }
}
