using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontDeskApp.Configurations;
using FrontDeskApp.Controllers;
using FrontDeskApp.EntityDataModel;
using FrontDeskApp.Implementation.APIResponse;
using FrontDeskApp.Implementation.Customer;
using FrontDeskApp.Implementation.Login;
using FrontDeskApp.Implementation.Storage;
using FrontDeskApp.Interface.APIResponse;
using FrontDeskApp.Interface.Configurations;
using FrontDeskApp.Interface.Customer;
using FrontDeskApp.Interface.Logging;
using FrontDeskApp.Interface.Login;
using FrontDeskApp.Interface.Storage;
using FrontDeskApp.Utilities.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace FrontDeskApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //Scaffold-DbContext 'Server=tcp:storagedemo.c8dnwyshrrsm.us-east-2.rds.amazonaws.com,1433;Initial Catalog=Storage;User ID=Admin;Password=StorageDemo;Trusted_Connection=false;' Microsoft.EntityFrameworkCore.SqlServer -OutputDir EntityDataModel -f


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Storage Demo API", Version = "v1" });
            });

            services.AddDbContext<StorageContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("StorageDemo")));

            services.AddScoped<ICustomer, CustomerService>();
            services.AddScoped<IStorage, StorageService>();
            services.AddScoped<IAPIResonse, APIResponseService>();
            services.AddScoped<ILogging, LogginService>();
            services.AddScoped<IDatabaseConn, DatabaseConnService>();
            services.AddScoped<ILogin, LoginService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowOrigin");

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Storage Demo API");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
