using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DAL;

namespace WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)

        {
            /*Restaurant DAL BLL*/
            services.AddScoped<IRestaurantManager, RestaurantManager>();
            services.AddScoped<IRestaurantDB, RestaurantDB>();

            /*DISH DAL BLL*/
            services.AddScoped<IDishManager, DishManager>();
            services.AddScoped<IDishDB, DishDB>();

            /*CITY DAL BLL*/
            services.AddScoped<ICityManager, CityManager>();
            services.AddScoped<ICityDB, CityDB>();

            /*RESTO TYPES DALL BLL*/
            services.AddScoped<IRestoTypeManager, RestoTypeManager>();
            services.AddScoped<IRestoTypeDB, RestoTypeDB>();

            /*ORDER DAL BLL*/

            //services.AddScoped<IOrderManager, OrderManager>();
            //services.AddScoped<IOrderDB, OrderDB>();

            /*CUSTOMER DAL BLL*/
            services.AddScoped<ICustomerManager, CustomerManager>();
            services.AddScoped<ICustomerDB, CustomerDB>();

            /*ORDERDETAILS DAL BLL*/
            services.AddScoped<IOrderDetailsManager, OrderDetailsManager>();
            services.AddScoped<IOrderDetailsDB,OrderDetailsDB>();


            services.AddSession();

            services.AddControllersWithViews();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();

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
