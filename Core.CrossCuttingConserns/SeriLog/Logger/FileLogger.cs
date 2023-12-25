﻿using Core.CrossCuttingConserns.SeriLog.ConfigurationModels;
using Core.CrossCuttingConserns.SeriLog.Messages;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConserns.SeriLog.Logger
{
    public class FileLogger:LoggerServiceBase
    {

        private readonly IConfiguration _configuration;

        public FileLogger(IConfiguration configuration)
        {
            _configuration = configuration;

            FileLogConfiguration logConfig = configuration.GetSection("SeriLogConfiguration:FileLogConfiguration").Get<FileLogConfiguration>()
            ?? throw new Exception(SeriLogMessages.NullOptionsMessage);

            string logFilePath = string.Format(format:"{0}{1}", arg0:Directory.GetCurrentDirectory()+logConfig.FolderPath, arg1:".txt");

            Logger = new LoggerConfiguration().WriteTo.File(
                    logFilePath,
                    rollingInterval:RollingInterval.Day,
                    retainedFileCountLimit:null,
                    fileSizeLimitBytes:5000000,
                    outputTemplate:"{Timestamp:yyyy-MM--dd HH:mm:ss:fff zzz} [{level}] {Message}{NewLine}{Exception}"
                ).CreateLogger();
        }
    }
}
