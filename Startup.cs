using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using HayGym_API.Models;

namespace HayGym_API
{
    public class Startup
    {
        readonly string MyCors = "_myCors";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            var settings = Configuration.GetSection("AppSettings");
            string connectionString = settings.Get<AppSettings>().HaiGymConnectionString;

            services.Configure<AppSettings>(settings);

            services.AddDbContext<HaiGymContext>(option => option.UseSqlServer(connectionString));

            /*
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                    builder.SetIsOriginAllowed(_ => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            */

            services.AddCors(options =>
            {
                options.AddPolicy(
                    name: MyCors,
                    builder =>
                    {
                        builder.WithOrigins(
                            "http://localhost:5000",
                            "https://localhost:5001",
                            "https://localhost:44378")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                        //.AllowCredentials();
                    });
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(MyCors);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
