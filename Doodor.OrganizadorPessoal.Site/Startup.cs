using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Doodor.OrganizadorPessoal.Site.Data;
using Doodor.OrganizadorPessoal.Site.Models;
using Doodor.OrganizadorPessoal.Site.Services;
using Doodor.OrganizadorPessoal.Application.Interfaces;
using Doodor.OrganizadorPessoal.Application.Services;
using Doodor.OrganizadorPessoal.CrossCutting;
using Microsoft.AspNetCore.Http;
using Doodor.OrganizadorPessoal.CrossCutting.Bus;
using AutoMapper;
using Doodor.OrganizadorPessoal.Domain.Financeiro.Authentication.Interfaces;

namespace Doodor.OrganizadorPessoal.Site
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped<IUser, AspNetUser>();

            services.AddMvc();
            services.AddAutoMapper();            

            services.AddInjectionDependencies();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IHttpContextAccessor accessor)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Contas}/{action=Index}");
            });

            InMemoryBus.ContainerAccessor = () => accessor.HttpContext.RequestServices;
        }
    }
}
