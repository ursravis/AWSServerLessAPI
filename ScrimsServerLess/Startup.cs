using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ScrimsServerLess.Models;
using Microsoft.EntityFrameworkCore;

namespace ScrimsServerLess
{
    public class Startup
    {
        public const string AppS3BucketKey = "AppS3Bucket";

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public static IConfigurationRoot Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            //var connection = @"Server=.\SQLEXPRESS;Database=scrims-test;Trusted_Connection=True;";
            var connection = @"Server=scrims-test.cnxbhgiegzg3.us-west-1.rds.amazonaws.com,1234;Database=scrims-test;User Id=scrimsadmin;Password=Testpassword#2";
            //var connection = @"Server=scrims-test.database.windows.net;Database=scrims-test;User Id=scrimsadmin;Password=Testpassword#2";
            services.AddDbContext<ScrimsDbContext>(options => options.UseSqlServer(connection));

            // Pull in any SDK confptions(Configuration.GetAWSOptions());
            services.AddDefaultAWSOptions(Configuration.GetAWSOptions());
            // Add S3 to the ASP.NET Core dependency injection framework.
            services.AddAWSService<Amazon.S3.IAmazonS3>();
          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseCors("MyPolicy");
            loggerFactory.AddLambdaLogger(Configuration.GetLambdaLoggerOptions());
            app.UseMvc();
            
        }
    }
}
