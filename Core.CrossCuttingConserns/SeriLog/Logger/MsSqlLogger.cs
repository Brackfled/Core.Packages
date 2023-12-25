using Core.CrossCuttingConserns.SeriLog.ConfigurationModels;
using Core.CrossCuttingConserns.SeriLog.Messages;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConserns.SeriLog.Logger
{
    public class MsSqlLogger:LoggerServiceBase
    {

        public MsSqlLogger(IConfiguration configuration)
        {
            MsSqlConfiguration logConfiguration = configuration.GetSection("SeriLogConfiguration:MsSqlConfiguration").Get<MsSqlConfiguration>()
            ?? throw new Exception(SeriLogMessages.NullOptionsMessage);

            MSSqlServerSinkOptions sinkOptions = new()
            {
                TableName = logConfiguration.TableName, AutoCreateSqlDatabase = logConfiguration.AutoCreateSqlTable
            };

            ColumnOptions columnOptions = new();

            global::Serilog.Core.Logger seriLogConfig = new LoggerConfiguration().WriteTo
                .MSSqlServer(logConfiguration.ConnectionString, sinkOptions, columnOptions:columnOptions)
                .CreateLogger();

            Logger = seriLogConfig;
        }

    }
}
