using LoggerService.Implement;
using LoggerService.Model;
using LoggerService.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerService.IOC
{
    public static class LoggerServiceIOC
    {
        public static void AddLoggerService(this WebApplicationBuilder builder, string provider)
        {
            builder.Logging.ClearProviders();

            if (string.IsNullOrEmpty(provider))
                throw new Exception("provider is null or empty");

            else if (provider.ToLower() == "elasticsearch")
                builder.Services.AddSingleton<ILoggerService, ElasticSearchService>();
            else if (provider.ToLower() == "serilog")
            {
                builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));
                builder.Services.AddSingleton<ILoggerService, SeriLogService>();
            }

            else
                throw new Exception("provider is not defined in service!");
        }
        public static void MiddleWare(this IApplicationBuilder app)
        {
            app.UseSerilogRequestLogging();
        }
    }
}
