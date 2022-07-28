
using ContactManagement.Interface;
using ContactManagement.Service;
using ContactManagement.Services;

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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagement
{
    public class Startup
    {


        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins"; //Edited//error 1

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
           services.AddDbContext<ModelContext>(options => options.UseOracle(Configuration.GetConnectionString("OracleDBConnection")));
            //ADDED
            services.AddScoped<IUserRegistrationsService, UserRegistrationsService>();
            services.AddScoped<IUserLoginService, UserLoginService>();
            services.AddScoped<IAuthorizationRequestService, AuthorizationRequestService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ContactManagement", Version = "v1" });
            });

            /*** Edit Start error1 ***/
            var url = Configuration.GetSection("url").Value;
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins, builder => builder
                 .SetIsOriginAllowed(_ => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                );
            });
            /*** Edit End error1 ***/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ContactManagement v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();


            /*** Edit Start error1 ***/
            app.UseCors(MyAllowSpecificOrigins);
            /*** Edit End error1***/

            app.UseAuthorization();


            /*** Edit Start error1***/

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireCors(MyAllowSpecificOrigins);
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            /*** Edit End error1***/

          
        }
    }
}
