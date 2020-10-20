using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using BakTraCam.Core.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using BakTraCam.Core.IoC;
using BakTraCam.Common.Helper;
using BakTraCam.Core.Business.Application;
using BakTraCam.Service.WebApi.Helpers;

namespace BakTraCam.Service.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddMemoryCache();

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.UseMemberCasing();
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();

                options.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            });

            services.AddControllers().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            

            services.AddDependencyInjection(Configuration);
           
            services.Configure<RequestLocalizationOptions>(opt =>
            {
                opt.SetDefaultCulture("tr-TR");

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env )
        {
            int sirketId = Configuration.GetSection("AppParameters").GetValue<int>("SirketId");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


    

            app.UseHttpsRedirection();
            string[] ClientApps = Configuration.GetSection("AppParameters").GetSection("ClientApps").Get<string[]>();
            app.UseCors(builder => builder
                            .WithOrigins(ClientApps)
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials());

            app.UseRouting();
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseAuthorization();
            app.UseEndpoints(ep =>
            {
                ep.MapControllers();
            });


           
        }
    }
}
