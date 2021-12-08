using FastReport.Data;
using HouseRentalManagementSystem.IRepository;
using HouseRentalManagementSystem.Models;
using HouseRentalManagementSystem.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseRentalManagementSystem
{
    public class Startup
    {
        private readonly IConfiguration iConfiguration;
        public Startup(IConfiguration _iConfiguration)
        {
            iConfiguration = _iConfiguration;

        }
        public void ConfigureServices(IServiceCollection services)
        {
            FastReport.Utils.RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));
            services.AddDbContext<HouseRentalManagementSystemContext>(options => options.UseSqlServer(iConfiguration.GetConnectionString("HouseRentalDB")));
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<HouseRentalManagementSystemContext>();
            services.AddControllersWithViews();
            services.ConfigureApplicationCookie(options => options.LoginPath = "/Security/Account/Login");
            services.AddScoped<IBuildingRepository, BuildingRepository>();
            services.AddScoped<IApartmentRepository, ApartmentRepository>();
            services.AddScoped<IApartmentImageRepository, ApartmentImageRepository>();
            services.AddScoped<IApartmentTypeRepository, ApartmentTypeRepository>();
            services.AddScoped<ITenantRepository, TenanRepository>();
            services.AddScoped<IApartmentBookingRepository, ApartmentBookingRepository>();
            services.AddScoped<IBookingStatusRepository, BookingStatusRepository>();
            services.AddScoped<IApartmentFacilityRepository, ApartmentFacilityRepository>();
            services.AddScoped<IApartmentWiseFacilityRepository, ApartmentWiseFacilityRepository>();
            services.AddScoped<IPaymentTypeRepository, PaymentTypeRepository>();
            services.AddScoped<IViewUnitStatusRepository, ViewUnitStatusRepository>();
            services.AddScoped<IBookingPaymentRepository, BookingPaymentRepository>();
            services.AddScoped<ISecurityDepositRepository, SecurityDepositRepository>();
            services.AddMvc();
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
                app.UseStatusCodePagesWithRedirects("Error/{0}");
            }
            app.UseHttpsRedirection(); 
            app.UseFastReport();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllerRoute("Error", "error/{statusCode}", defaults: new { controller = "Error", action = "HttpStatusCodeErrorHandler" });
                endpoint.MapControllerRoute(name: "default", pattern: "{area=User}/{controller=ApartmentBooking}/{action=Index}/{id?}");
            });
        }
    }
}
