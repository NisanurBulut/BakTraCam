using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Reflection;

namespace BakTraCam.Core.DataAccess.Context
{
    public class DatabaseContextFactory: IDesignTimeDbContextFactory<DatabaseContext>
    {
        private IConfiguration Configuration { get; }
        public DatabaseContextFactory() { }
        public DatabaseContextFactory(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public DatabaseContext CreateDbContext(string[] args)
        {
            string dbName = args.FirstOrDefault();

            string connectionString = Configuration?.GetConnectionString("mainDb") ?? "Datasource=BakTraCam.db";
            DbContextOptionsBuilder<DatabaseContext> builder = new DbContextOptionsBuilder<DatabaseContext>();
            builder.UseSqlite(connectionString, options => options.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name));
            return new DatabaseContext(builder.Options);
        }
    }
}