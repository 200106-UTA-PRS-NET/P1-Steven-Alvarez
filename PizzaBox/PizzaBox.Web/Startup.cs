using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using PizzaBox.Storing.Repositories;

using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Entities;

namespace PizzaBox.Web
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
            services.AddControllersWithViews();

            string connectionString = Configuration.GetConnectionString("PizzaBoxDB");

           
           services.AddDbContext<PizzaBoxDbContext>(options =>
               options.UseSqlServer(connectionString));
            // Adding Dependency to your Controller to use Db

            /*
             
            services.AddTransient<IRepository, SQLAdapter>();
            */
            /*
            services.AddTransient<IRepository, OrderRepos>();
            services.AddTransient<IRepository, StoreRepos>();
            services.AddTransient<IRepository, UserRepos>();
            services.AddTransient<IRepository, PizzaRepos>();
            */
            /*
            services.AddScoped<IRepository, OrderRepos>();
            services.AddScoped<IRepository, StoreRepos>();
            services.AddScoped<IRepository, UserRepos>();
            services.AddScoped<IRepository, PizzaRepos>();
            */
            /*
            services.AddTransient<IRepository, IOrder();
            services.AddTransient<IRepository, IStore();
            services.AddTransient<IRepository, IUser>();
            services.AddTransient<IRepository, IPizza>();
            */

            services.AddTransient<IOrder, OrderRepos>();
            services.AddTransient<IStore, StoreRepos>();
            services.AddTransient<IUser, UserRepos>();
            services.AddTransient<IPizza, PizzaRepos>();
           
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
