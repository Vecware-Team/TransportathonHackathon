namespace Core.CrossCuttingConcerns.Exceptions.ExceptionTypes
{
    [Serializable]
    public class ValidationException : BaseException
    {
        public ValidationException() : base("Validation Failed", 400)
        {
            Errors = Array.Empty<ValidationExceptionModel>();
        }

        public ValidationException(string message) : base(message, 400)
        {
            Errors = Array.Empty<ValidationExceptionModel>();
        }

        public ValidationException(string message, Exception inner) : base(message, 400, inner)
        {
            Errors = Array.Empty<ValidationExceptionModel>();
        }

        public ValidationException(IEnumerable<ValidationExceptionModel> errors) : base(BuildErrorMessage(errors), 400)
        {
            Errors = errors;
        }

        public IEnumerable<ValidationExceptionModel> Errors { get; }

        private static string BuildErrorMessage(IEnumerable<ValidationExceptionModel> errors)
        {
            IEnumerable<string> messages = errors.Select(
                error => $"{Environment.NewLine} -- {error.Property}: {string.Join(Environment.NewLine, values: error.Errors ?? Array.Empty<string>())}"
            );

            return $"Validation failed: {string.Join(string.Empty, messages)}";
        }
    }
    public class ValidationExceptionModel
    {
        public string? Property { get; set; }
        public IEnumerable<string>? Errors { get; set; }
    }
}
