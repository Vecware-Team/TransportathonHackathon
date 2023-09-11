using System.ComponentModel;

namespace Core.CrossCuttingConcerns.Logging
{
    public static class LoggerFactory
    {
        private static List<BaseLogger> _loggers;

        public static void RegisterLogger(BaseLogger logger)
        {
            if (_loggers is null)
                _loggers = new List<BaseLogger>();

            _loggers.Add(logger);
        }

        public static void RegisterLoggers(BaseLogger[] loggers)
        {
            if (_loggers is null)
                _loggers = new List<BaseLogger>();

            _loggers.AddRange(loggers);
        }

        public static BaseLogger GetLogger(Type loggerType)
        {
            foreach (BaseLogger logger in _loggers)
                if (logger.GetType() == loggerType)
                    return logger;

            return null;
        }

        public static BaseLogger GetLogger(string className)
        {
            foreach (BaseLogger logger in _loggers)
                if (logger.GetType().Name == className)
                    return logger;

            return null;
        }

        public static List<BaseLogger> GetLoggers()
        {
            return _loggers;
        }

        public static void RunLogger(LogType logType, BaseLogger logger, string message)
        {
            if (_loggers is null)
                throw new InvalidOperationException("Loggers is null. Please try register a logger");

            if (logger is null)
                throw new InvalidOperationException("Logger is null");

            switch (logType)
            {
                case LogType.Verbose:
                    logger.Verbose(message);
                    break;
                case LogType.Fatal:
                    logger.Fatal(message);
                    break;
                case LogType.Info:
                    logger.Info(message);
                    break;
                case LogType.Warn:
                    logger.Warn(message);
                    break;
                case LogType.Debug:
                    logger.Debug(message);
                    break;
                case LogType.Error:
                    logger.Error(message);
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        public static void RunLoggers(LogType logType, string message)
        {
            if (_loggers is null)
                throw new InvalidOperationException("Loggers is null. Please try register a logger");

            for (int i = 0; i < _loggers.Count; i++)
            {
                switch (logType)
                {
                    case LogType.Verbose:
                        _loggers[i].Verbose(message);
                        break;
                    case LogType.Fatal:
                        _loggers[i].Fatal(message);
                        break;
                    case LogType.Info:
                        _loggers[i].Info(message);
                        break;
                    case LogType.Warn:
                        _loggers[i].Warn(message);
                        break;
                    case LogType.Debug:
                        _loggers[i].Debug(message);
                        break;
                    case LogType.Error:
                        _loggers[i].Error(message);
                        break;
                    default:
                        throw new InvalidEnumArgumentException();
                }
            }
        }

        public static void RunLoggersSafety(LogType logType, string message)
        {
            if (_loggers is null)
                return;

            for (int i = 0; i < _loggers.Count; i++)
            {
                switch (logType)
                {
                    case LogType.Verbose:
                        _loggers[i].Verbose(message);
                        break;
                    case LogType.Fatal:
                        _loggers[i].Fatal(message);
                        break;
                    case LogType.Info:
                        _loggers[i].Info(message);
                        break;
                    case LogType.Warn:
                        _loggers[i].Warn(message);
                        break;
                    case LogType.Debug:
                        _loggers[i].Debug(message);
                        break;
                    case LogType.Error:
                        _loggers[i].Error(message);
                        break;
                    default:
                        throw new InvalidEnumArgumentException();
                }
            }
        }
    }

    public enum LogType
    {
        Verbose,
        Fatal,
        Info,
        Warn,
        Debug,
        Error,
    }
}
