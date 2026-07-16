using WebAPI_CleanArchitecture.Domain.Abstraction;

namespace WebAPI_CleanArchitecture.Domain.Exceptions
{
    public class RequestValidationException(List<string> errors) : Exception
    {
        public Error Errors { get; set; } = new()
        {
            ErrorCode = "RequestValidation.Error",
            ErrorMessages = errors
        };
    }
}
