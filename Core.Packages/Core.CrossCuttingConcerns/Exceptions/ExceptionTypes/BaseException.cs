namespace Core.CrossCuttingConcerns.Exceptions.ExceptionTypes
{
    [Serializable]
    public abstract class BaseException : Exception
    {
        public BaseException(int statusCode)
        {
            StatusCode = statusCode;
        }

        public BaseException(string message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        public BaseException(string message, int statusCode, Exception inner) : base(message, inner)
        {
            StatusCode = statusCode;
        }

        public int StatusCode { get; }
    }
}
