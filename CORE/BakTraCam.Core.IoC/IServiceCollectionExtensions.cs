using BakTraCam.Core.DataAccess.Context;
using BakTraCam.Util.Mapping.Adapter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NetCore.AutoRegisterDi;
using System;
using System.Linq;
using System.Reflection;


namespace BakTraCam.Core.IoC
{
    public static class IServiceCollectionExtensions
    {
        public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ICustomMapper>(new CustomMapper());
            
            string connectionString = configuration.GetConnectionString("mainDb");
            services.AddDbContextEnsureCreatedMigrate<DatabaseContext>
                (options => options.UseSqlite(connectionString));

           
        }
        public static T GetService<T>(this IServiceCollection services)
        {
            return services.BuildServiceProvider().GetService<T>();
        }
        public static T GetService<T>(this IServiceCollection services, string database)
        {
            return services.BuildServiceProvider().GetService<T>();
        }
        public static void AddDbContextEnsureCreatedMigrate<T>(this IServiceCollection services,
          Action<DbContextOptionsBuilder> options) where T : DbContext
        {
            services.AddDbContextPool<T>(options);
            T context = services.GetService<T>();
            context.Database.EnsureCreated();
            context.Database.Migrate();
        }
    }
}
