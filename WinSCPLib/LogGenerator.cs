using System;
using NLog;

namespace WinSCPLib
{
    public class LogGenerator
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public static void Config()
        {
            var config = new NLog.Config.LoggingConfiguration();

            // Targets where to log to: File and Console
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "WinSCPLib" + DateTime.Now.ToString("ddMMyyyy") + ".log" };
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

            // Rules for mapping loggers to targets            
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            // Apply config           
            NLog.LogManager.Configuration = config;
        }

        public static void Add(string msg, Enumerators.LogLevels logLevels)
        {
            switch (logLevels)
            {
                case Enumerators.LogLevels.Debug:
                    logger.Debug(msg);
                    break;
                case Enumerators.LogLevels.Error:
                    logger.Error(msg);
                    break;
                case Enumerators.LogLevels.Fatal:
                    logger.Fatal(msg);
                    break;
                case Enumerators.LogLevels.Info:
                    logger.Info(msg);
                    break;
                case Enumerators.LogLevels.Trace:
                    logger.Trace(msg);
                    break;
                case Enumerators.LogLevels.Warn:
                    logger.Warn(msg);
                    break;
            }
        }
    }
}
