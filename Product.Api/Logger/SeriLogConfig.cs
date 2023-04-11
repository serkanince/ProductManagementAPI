

using NpgsqlTypes;
using Serilog;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Product.Api.Logger
{
    public static class SeriLogConfig
    {
        public static Action<HostBuilderContext, LoggerConfiguration> Configure =>
           (context, configuration) =>
           {
               //best practice solution here would be elastic search and kibana (ELK) solution. (but the solution below will work, you got it)
               //https://github.com/serilog-contrib/serilog-sinks-elasticsearch

               var logFilePath = "logs/log.txt";

               configuration
                    .Enrich.FromLogContext()
                    .Enrich.WithMachineName()
                    .WriteTo.Debug()
                    .WriteTo.Console()
                    .WriteTo.File(logFilePath, rollingInterval: RollingInterval.Hour)
                    .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                    .Enrich.WithProperty("Application", context.HostingEnvironment.ApplicationName)
                    .ReadFrom.Configuration(context.Configuration);
           };
    }
}
