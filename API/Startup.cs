using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.Interfaces;
using DAL;
using DAL.Helper;
using DAL.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
               .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => {
                options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            services.AddControllers();
            services.AddTransient<IDatabaseHelper, DatabaseHelper>();
            services.AddTransient<ITinTucRepository, TinTucRepository>();
            services.AddTransient<ITinTucBusiness, TinTucBusiness>();
            services.AddTransient<ILoaiTinRepository, LoaiTinRepository>();
            services.AddTransient<ILoaiTinBusiness, LoaiTinBusiness>();
            services.AddTransient<IChuDeRepository, ChuDeRepository>();
            services.AddTransient<IChuDeBusiness, ChuDeBusiness>();
            services.AddTransient<ILoaiChuDeRepository, LoaiChuDeRepository>();
            services.AddTransient<ILoaiChuDeBusiness, LoaiChuDeBusiness>();
            services.AddTransient<IQuangCaoRepository, QuangCaoRepository>();
            services.AddTransient<IQuangCaoBusiness, QuangCaoBusiness>();
            services.AddTransient<ILoaiQuangCaoRepository, LoaiQuangCaoRepository>();
            services.AddTransient<ILoaiQuangCaoBusiness, LoaiQuangCaoBusiness>();
            /*services.AddTransient<ICustomerRepository, CustomerRepository>();*/
            /*services.AddTransient<ICustomerBusiness, CustomerBusiness>();*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseApiMiddleware();
            app.UseRouting();
            app.UseAuthorization();
            app.UseCors("AllowAll");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseHttpsRedirection();
        }
    }
}
