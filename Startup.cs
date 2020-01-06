using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using erplite.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace erplite
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            /**
             * rejestracja AplicationDbContext jako us³ugi w aplikacji
             * serwis ³¹cz¹cy siê do bazy
             * dane do po³¹czenia przekazywane z appsettings.json 
             */
            // !! OPCJA 1 !! je¿eli odkomentowana to ³¹czy siê do MS SQL
            // services.AddDbContext<AplicationDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("dbMSSQLConfig")));


            // !! OPCJA 2 !! je¿eli odkomentowana to ³¹czy siê do MySQL
            services.AddDbContextPool<AplicationDbContext>(options => options.UseMySql(Configuration.GetConnectionString("dbMySQLConfig"), mySqlOptions => mySqlOptions
                    // Do ustawienia wersja MySQL + Typ 
                    //TODO do zrobienia w Configu 
                   .ServerVersion(new Version(10, 1, 43), ServerType.MySql))
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();

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
                    //zdefikowane domyslne kontrolery + akcje + (opcjonalnie) atrybuty
                    pattern: "{controller=Contractor}/{action=Index}/{id?}");
            });

            
            
        }
    }
}
