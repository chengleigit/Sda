using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Sda.Application.HREntitys;
using Sda.Core.Repositories;
using Sda.EntityFrameworkCore;
using Sda.EntityFrameworkCore.Repositories;
using Sda.EntityFrameworkCore.Seed;
using System;
using System.IO;
using System.Reflection;

namespace Sda.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContextPool<AppDbContext>(options=>options.UseNpgsql(Configuration.GetConnectionString("SdaDBConnection")));

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sda.Api", Version = "v1" });
                // 设置Swagger JSON和UI的注释路径
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            #endregion

            #region 依赖注入

            services.AddTransient(typeof(IRepository<,>), typeof(RepositoryBase<,>));
            services.AddScoped<IHREntityService, HREntityService>();

            #endregion


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sda.Api v1"));
            }

            //数据初始化
            app.UseDataInitializer();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}