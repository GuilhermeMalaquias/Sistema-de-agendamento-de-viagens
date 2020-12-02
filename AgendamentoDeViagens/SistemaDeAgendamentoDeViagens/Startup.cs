using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SistemaDeAgendamentoDeViagens.Data;

namespace SistemaDeAgendamentoDeViagens
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
            services.AddDbContext<ViagemContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ViagemAgendamentoConnection")));
            services.AddControllersWithViews();
            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);
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
                endpoints.MapControllerRoute(
                    name: "passageiro",
                    pattern: "{controller=Passageiro}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                   name: "assento",
                   pattern: "{controller=Assento}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                   name: "reserva",
                   pattern: "{controller=Reserva}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                   name: "voo",
                   pattern: "{controller=Voo}/{action=Index}/{id?}");
            });
        }
    }
}
