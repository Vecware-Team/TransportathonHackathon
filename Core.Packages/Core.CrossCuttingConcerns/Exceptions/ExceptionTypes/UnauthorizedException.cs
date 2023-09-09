namespace Core.CrossCuttingConcerns.Exceptions.ExceptionTypes
{
    public class UnauthorizedException : BaseException
    {
        public UnauthorizedException() : base("Unauthorized User", 401)
        {
        }

        public UnauthorizedException(string message) : base(message, 401)
        {
        }

        public UnauthorizedException(string message, Exception inner) : base(message, 401, inner)
        {
        }
    }
}
