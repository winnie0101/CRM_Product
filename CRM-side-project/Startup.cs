using CRM_side_project.Application;
using CRM_side_project.Application.Common;
using CRM_side_project.Contexts;
using CRM_side_project.DAL.Repository;
using CRM_side_project.Handler;
using CRM_side_project.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NSwag;
using NSwag.Generation.Processors.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_side_project
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

            services.AddRazorPages();
            services.AddControllers();
            services.AddOpenApiDocument();
            services.AddSingleton<IGenerateId>(s => new SnowflakeHandler(Environment.MachineName));
            services.AddControllers(
                s =>
                { s.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true; }
                )
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.IgnoreNullValues = true;

                })
                .AddNewtonsoftJson(
                config =>
                {
                    config.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    config.SerializerSettings.Converters.Add(new StringEnumConverter());
                    config.SerializerSettings.Converters.Add(new LongValueConverter());
                });
            
            services.AddDbContext<CRMsideprojectContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Mssql"));
            });
            services.AddScoped<IProductService, ProductService>()
                .AddScoped<IProductRepository, ProductRepository>(); 

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            app.UseOpenApi();       // serve OpenAPI/Swagger documents
            app.UseSwaggerUi3();    // serve Swagger UI
            app.UseReDoc(config =>  // serve ReDoc UI
            {
                // 這裡的 Path 用來設定 ReDoc UI 的路由 (網址路徑) (一定要以 / 斜線開頭)
                config.Path = "/redoc";
            });


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
