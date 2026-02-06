using CoreApplication3.Data;
using CoreApplication3.Data.Interfaces;
using CoreApplication3.Data.Mocks;
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
            services.AddMvc(options =>
                             options.EnableEndpointRouting = false);

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
            app.UseMvcWithDefaultRoute();
                
        }
    }

}




