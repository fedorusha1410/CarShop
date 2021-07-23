using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.Data;
using Shop.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shop.Data.mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Data.Repository;
using Shop.Data.Models;
using Microsoft.AspNetCore.Routing;

namespace Shop
{
    public class Startup
    {

        private IConfigurationRoot _confString;

        public Startup(IHostEnvironment hostEnv) => _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbSettings.json").Build();



        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppBDContent>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));         
            services.AddTransient<IAllCars, CarRepository>();
            services.AddTransient<ICarsCategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();

            services.AddScoped(sp => ShopCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes => 
                      { routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                        routes.MapRoute(name: "categoryFilter", template: "Car/{action}/{category?}",
                                                       defaults: new { Controller = "Car", action = "List" });
                          });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppBDContent content = scope.ServiceProvider.GetRequiredService<AppBDContent>();
                DbObjects.Initial(content);
            }


        }
    }
}
