using Serilog;

namespace Core.CrossCuttingConcerns.Logging.Serilog
{
    public class SerilogServiceBase : BaseLogger
    {
        protected ILogger Logger { get; set; }

        public override void Verbose(string message) => Logger.Verbose(message);
        public override void Fatal(string message) => Logger.Fatal(message);
        public override void Info(string message) => Logger.Information(message);
        public override void Warn(string message) => Logger.Warning(message);
        public override void Debug(string message) => Logger.Debug(message);
        public override void Error(string message) => Logger.Error(message);
    }
}
