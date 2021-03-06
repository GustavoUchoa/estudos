﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RepositorioGeek.Data;
using RepositorioGeek.Models;
using RepositorioGeek.Services;

namespace RepositorioGeek
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
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            /*
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
             */

            services.AddDbContext<ApplicationDbContext>(Options => 
            Options.UseSqlServer(Configuration["RepoGeek:ConnectionStrings"]));

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            
            services.AddTransient<IFilmeService, FilmeService>();
            services.AddAuthentication().AddFacebook(options => {
                options.AppId = Configuration["Authentication:Facebook:AppId"];
                options.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            });
            
            services.AddMvc();            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
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
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
