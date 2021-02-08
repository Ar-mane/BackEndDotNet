using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatalogApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

namespace CatalogApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CatalogRepository>(
                optionsAction => { optionsAction.UseInMemoryDatabase("DATABASE"); }
            );
            services.AddControllersWithViews();
            
        }

        public void Configure(IApplicationBuilder app, CatalogRepository catalogRepository, IWebHostEnvironment env)
        {
            
            PreExecute.Init(catalogRepository);
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}