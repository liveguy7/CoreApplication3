
using CoreApplication3.Data.Interfaces;
using CoreApplication3.Data.Mocks;

namespace CoreApplication3
{

    public class Startup
    {

        public Startup()
        {
            //Startup Constructor
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICarRepository, MockCarRepository>();
            services.AddTransient<ICategoryRepository, MockCategoryRepository>();
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




