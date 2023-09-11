namespace Core.CrossCuttingConcerns.Logging
{
    public abstract class BaseLogger
    {
        public abstract void Verbose(string message);
        public abstract void Fatal(string message);
        public abstract void Info(string message);
        public abstract void Warn(string message);
        public abstract void Debug(string message);
        public abstract void Error(string message);
    }
}
