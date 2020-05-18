using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicalGoods.Data;
using MagicalGoods.Models;
using MagicalGoods.Models.Interfaces;
using MagicalGoods.Models.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MagicalGoods
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup()
        {
            var builder = new ConfigurationBuilder().AddEnvironmentVariables();
            builder.AddUserSecrets<Startup>();
            Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            // enables razor pages, has MVC under the hood
            services.AddRazorPages();

            services.AddTransient<IProductManager, ProductService>();
            services.AddTransient<ICartManager, CartService>();
            services.AddTransient<ICartProductManager, CartProductService>();
            services.AddTransient<IEmailSender, EmailSenderService>();
            services.AddTransient<IPaymentManager, PaymentService>();
            services.AddTransient<IOrderManager, OrderService>();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("IdentityDefault"));
            }
            );

            services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            }
            );

            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole(ApplicationRoles.Admin));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/api/error");
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            RoleInitializer.SeedData(serviceProvider);
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
