using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Models;
using Models.IRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Repository.Context;

namespace SportStore
{
    public class Startup
    {
        
       

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton<ApplicationDbContext>();

            services.AddTransient<IProductRepository, EFProductRepository>();           
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc(routes => {
                routes.MapRoute(
                name: "default",
                template: "{controller=Product}/{action=List}/{id?}");
            });

            SeedData.EnsurePopulated(app);



        }
    }
}
