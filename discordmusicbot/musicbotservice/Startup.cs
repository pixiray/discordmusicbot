using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using musicbotservice.Services.Mail;
using Microsoft.Extensions.Configuration;

namespace musicbotservice
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            Trace.TraceInformation($"{DateTime.Now} Called Startup");

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            Trace.TraceInformation(env.EnvironmentName);
            Trace.TraceInformation($"{DateTime.Now} Is Development {env.IsDevelopment()}");
            Trace.TraceInformation($"{DateTime.Now} Is Staging {env.IsStaging()}");

            var variables = Environment.GetEnvironmentVariables();

            foreach (var set in variables.Values)
            {
                Trace.TraceInformation(set.ToString());
            }

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see https://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets<Startup>();
            }

            Trace.TraceInformation("Loading Variables");
            builder.AddEnvironmentVariables();
            Trace.TraceInformation("builder build app");
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Add application services.
            Trace.TraceInformation("add mail");
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
