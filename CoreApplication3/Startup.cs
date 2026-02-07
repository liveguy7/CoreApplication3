using CoreApplication3.Data;
using CoreApplication3.Data.Interfaces;
using CoreApplication3.Data.Mocks;
using CoreApplication3.Data.Models;
using CoreApplication3.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CoreApplication3
{

    public class Startup
    {
        private IConfigurationRoot _configurationRoot;

        public Startup(Microsoft.Extensions.Hosting.IHostEnvironment hostingEnvironment)
        {
            _configurationRoot = new ConfigurationBuilder().SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(_configurationRoot.GetConnectionString("DCString")));

            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShoppingCart.GetCart(sp));
            services.AddMvc(options =>
                             options.EnableEndpointRouting = false);
            services.AddMemoryCache();
            services.AddSession();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvcWithDefaultRoute();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "categoryFilter", template: "Car/{action}/{category?}", defaults: new
                {
                    Controller = "Car",
                    Action = "List"
                });
                
            });

            app.UseMvcWithDefaultRoute();

        }
    }

}




