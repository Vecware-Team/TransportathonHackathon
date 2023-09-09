namespace Core.CrossCuttingConcerns.Exceptions.ExceptionTypes
{
    [Serializable]
    public class BusinessException : BaseException
    {
        public BusinessException() : base(400) { }
        public BusinessException(int statusCode) : base(statusCode) { }
        public BusinessException(string message) : base(message, 400) { }
        public BusinessException(string message, Exception inner) : base(message, 400, inner) { }
    }
}
