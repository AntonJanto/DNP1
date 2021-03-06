using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNP_FamilyOverview1.Data.Authentication;
using DNP_FamilyOverview1.Data.Authentication.Impl;
using DNP_FamilyOverview1.Data.Families;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DNP_FamilyOverview1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<IFamilyService, CloudFamilyService>();
            services.AddSingleton<IUserService, CloudUserService>();
            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Create", a =>
                a.RequireAuthenticatedUser().RequireClaim("Permissions", "0", "1", "2"));
                options.AddPolicy("Delete", a =>
                a.RequireAuthenticatedUser().RequireClaim("Permissions", "2"));
                options.AddPolicy("Update", a =>
                a.RequireAuthenticatedUser().RequireClaim("Permissions", "1", "2"));

            });
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
