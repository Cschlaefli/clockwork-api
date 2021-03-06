using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Clockwork.API.Data;
using Clockwork.Models;
using System.Net.Http;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Extensions;
using Swashbuckle.AspNetCore.SwaggerGen;
using Clockwork.API.Swagger.Extenstions;

namespace Clockwork.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }
        public IHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o =>
            {
                o.AddPolicy("Permissive", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
                o.AddPolicy("Enforcing", builder =>
                {
                    builder.WithOrigins("")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();             
                });
            });




            if (env.IsDevelopment()){
                services.AddDbContextPool<BaseDbContext>(
                    dbContextOptions => dbContextOptions
                        .UseMySql(
                            Configuration.GetConnectionString("Tephra"),
                            // Replace with your server version and type.
                            // For common usages, see pull request #1233.
                            new MariaDbServerVersion(new Version(10, 1, 47)), // use MariaDbServerVersion for MariaDB
                            mySqlOptions => mySqlOptions
                                .CharSetBehavior(CharSetBehavior.NeverAppend))
                        // Everything from this point on is optional but helps with debugging.
                        .EnableSensitiveDataLogging()
                        .EnableDetailedErrors()
                );
            }else{
                services.AddDbContext<BaseDbContext>(
                    dbContextOptions => dbContextOptions
                        .UseSqlServer(Configuration.GetConnectionString("Azure"))
                );
            }

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "tephraAPI", Version = "v1" });
                //c.DocumentFilter<CustomModelDocumentFilter<AugmentFilter>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "tephraAPI v1"));

            //app.UseHttpsRedirection();
            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
