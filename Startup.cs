using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; //require 'using' this for using DBContext
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using coreTutorials.DAL;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using coreTutorials.Controllers;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Antiforgery;
using FluentValidation.AspNetCore;
using coreTutorials.Models;

namespace core_tutorials
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            #region add session
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.CookieName = "localhost.session";
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.IsEssential = true;
            });
            #endregion

            //add antiforgerytoken => prevent csrf attack
            services.AddAntiforgery(options =>
            {
                options.FormFieldName = "_xsrf_token";
                options.HeaderName = null;
                //options.HeaderName = "x-xsrf-token-header";
                options.SuppressXFrameOptionsHeader = false;
            });

            //config to first uppercase json data return  from api
            //services.AddMvc().AddJsonOptions(options =>
            //{
            //    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            //});
            services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UsersValidator>())  //add fluent Validation
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //add cookies authentication
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.Cookie = new CookieBuilder()
                {
                    Expiration = TimeSpan.FromMinutes(30)
                };
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/signout";
                options.SlidingExpiration = true;
                options.EventsType = typeof(CookieActionhandle);
            });
            //add cutom handle cookies validaton
            services.AddScoped<CookieActionhandle>();
            //add MongoDbContext
            services.AddScoped<MongoDbContext>();
            //config webapp connect to SQL server
            var connectionString = Configuration.GetConnectionString("local_db");
            services.AddDbContext<MyDbContext>(options => options.UseSqlServer(connectionString));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IAntiforgery antiforgery)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            //add antiforgery token to cookies
            app.Use(next => context =>
            {

                if (
                string.Equals(context.Request.Path.Value, "/", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(context.Request.Path.Value, "/index", StringComparison.OrdinalIgnoreCase))
                {
                    var token = antiforgery.GetAndStoreTokens(context);
                    context.Response.Cookies.Append("X-XSRF-TOKEN", token.RequestToken, new CookieOptions
                    {
                        HttpOnly = false
                    });

                }


                return next(context);
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();//add authentication module
            app.UseCookiePolicy();
            app.UseSession();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
