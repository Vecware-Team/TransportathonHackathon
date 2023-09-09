namespace Core.CrossCuttingConcerns.Exceptions.ExceptionTypes
{
    public class NotFoundException : BaseException
    {
        public NotFoundException() : base("Not Found", 404)
        {
        }

        public NotFoundException(string message) : base(message, 404)
        {
        }

        public NotFoundException(string message, Exception inner) : base(message, 404, inner)
        {
        }
    }
}
