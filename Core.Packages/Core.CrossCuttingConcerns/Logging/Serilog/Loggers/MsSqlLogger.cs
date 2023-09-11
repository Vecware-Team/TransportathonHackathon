using Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;
using Core.CrossCuttingConcerns.Logging.Serilog.Messages;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace Core.CrossCuttingConcerns.Logging.Serilog.Loggers
{
    public class MsSqlLogger : SerilogServiceBase
    {
        private readonly IConfiguration _configuration;

        public MsSqlLogger(IConfiguration configuration)
        {
            _configuration = configuration;

            string configurationPath = "LogConfigurations:SerilogConfigurations:MsSqlLogConfiguration";
            MsSqlLogConfiguration logConfiguration = _configuration.GetSection(configurationPath).Get<MsSqlLogConfiguration>() ?? throw new Exception(SerilogMessages.NullOptionsMessage);

            MSSqlServerSinkOptions sinkOptions = new MSSqlServerSinkOptions()
            {
                TableName = logConfiguration.TableName,
                AutoCreateSqlTable = logConfiguration.AutoCreateSqlTable,
                AutoCreateSqlDatabase = true,
            };

            ColumnOptions columnOptions = new ColumnOptions();

            Logger = new LoggerConfiguration().WriteTo
                .MSSqlServer(
                    logConfiguration.ConnectionString,
                    sinkOptions: sinkOptions,
                    columnOptions: columnOptions
                ).CreateLogger();
        }
    }
}
