using BakTraCam.Core.DataAccess.Context;
using BakTraCam.Core.DataAccess.UnitOfWork;
using BakTraCam.Util.Mapping.Adapter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using System;
using System.Reflection;
using BakTraCam.Core.Business.Domain.Bakim;


namespace BakTraCam.Core.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddClassesMatchingInterfacesFrom(
                Assembly.GetAssembly(typeof(IBakimDomain)),
                Assembly.GetAssembly(typeof(IDatabaseUnitOfWork)));
            
            services.AddSingleton<ICustomMapper>(new CustomMapper());
            
            string connectionString = configuration.GetConnectionString("mainDb");
            
            services.AddDbContextEnsureCreatedMigrate<DatabaseContext>
                (options => options.UseSqlite(connectionString));

           
        }
        public static void AddClassesMatchingInterfacesFrom(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.RegisterAssemblyPublicNonGenericClasses(assemblies).AsPublicImplementedInterfaces(ServiceLifetime.Scoped);
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
            context.Database.Migrate();
            // context.Database.EnsureCreated();
            context.Database.Migrate();
        }
    }
}
