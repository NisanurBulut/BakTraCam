using BakTraCam.Core.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BakTraCam.Core.DataAccess.UnitOfWork
{
    public sealed class DatabaseUnitOfWork : IDatabaseUnitOfWork
    {

        private DatabaseContext Context { get; }

        public DatabaseUnitOfWork(DatabaseContext context)
        {
            Context = context;
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return Context.Database.BeginTransaction();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await Context.Database.BeginTransactionAsync();
        }

        public async Task ExecuteSqlCommand(string sql, params object[] parameters)
        {
            await Context.Database.ExecuteSqlRawAsync(sql, parameters);
        }

        public async Task<List<TResult>> RawQueryAsync<TResult>(string sql, params object[] parameters) where TResult : class
        {
            return await Context.Set<TResult>().FromSqlRaw(sql, parameters).ToListAsync();
        }
    }
}
