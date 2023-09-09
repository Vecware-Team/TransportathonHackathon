namespace Core.CrossCuttingConcerns.Exceptions.ExceptionTypes
{
    public class AuthorizationDeniedException : BaseException
    {
        public AuthorizationDeniedException() : base("Authorization Denied", 403)
        {
        }

        public AuthorizationDeniedException(string message) : base(message, 403)
        {
        }

        public AuthorizationDeniedException(string message, Exception inner) : base(message, 403, inner)
        {
        }
    }
}
