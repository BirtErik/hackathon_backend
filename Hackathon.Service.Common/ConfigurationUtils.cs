using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Hackathon.Service.Common
{
    public static class ConfigurationUtils
    {
        public static string GetDbConnectionString(IConfiguration configuration)
        {
            string connectionString = configuration.GetValue(Constants.ENV_VAR_DB_CONN_STRING, "");
            if (string.IsNullOrEmpty(connectionString))
            {
                Log.Logger.Information("No database configured via ENV parameters. Using one from 'appsettings.*.json'");
                return configuration.GetValue(Constants.APP_SET_DB_CONN_STRING, "");
            }

            return connectionString;
        }
        public static void ConfigureCommon(this IServiceCollection services, string dbConnectionString = null, bool trimStringValue = true)
        {
            services.AddHttpContextAccessor();

            //services.AddHeaderPropagation(options =>
            //{
            //    options.Headers.Add(CorrelationIdMiddleware.CORRELATION_ID_HEADER_KEY);
            //});

            //if (trimStringValue)
            //    services.ConfigureSystemTextJson();

            //services.ConfigureHealthChecks(dbConnectionString);

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.AddSerilog(Log.Logger, true);
            });
        }
    }
}
