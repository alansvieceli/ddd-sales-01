using DDD.Sales.Application.Services;
using DDD.Sales.Application.Services.Interfaces;
using DDD.Sales.Domain.Interfaces;
using DDD.Sales.Domain.Repository;
using DDD.Sales.Domain.Services.Categoria;
using DDD.Sales.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DDD.Sales.Application
{
    public class Startup
    {
        public static readonly ILoggerFactory SalesLoggerFactory
            = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter((category, level) =>
                        category == DbLoggerCategory.Database.Command.Name
                        && level == LogLevel.Debug)
                    .AddConsole();
            });
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<DDD.Sales.Application.DAL.ApplicationDbContext>( options => 
                options
                    .UseLoggerFactory(SalesLoggerFactory)
                    .UseSqlServer(Configuration.GetConnectionString("Sistema")));
          
            services.AddDbContext<DDD.Sales.Repository.DAL.ApplicationDbContext>( options => 
                options
                    .UseLoggerFactory(SalesLoggerFactory)
                    .UseSqlServer(Configuration.GetConnectionString("Sistema")));
            
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); //para trabalhar com sessão
            services.AddHttpContextAccessor();
            services.AddSession();
            
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ICategoriaService, CategoriaService>(); 
            services.AddScoped<ICategoriaAppService, CategoriaAppService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}