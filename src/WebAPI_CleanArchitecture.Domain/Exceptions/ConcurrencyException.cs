using WebAPI_CleanArchitecture.Domain.Abstraction;

namespace WebAPI_CleanArchitecture.Domain.Exceptions
{
    public class ConcurrencyException(List<string> errors) : Exception
    {
        public Error Errors { get; set; } = new()
        {
            ErrorCode = "Concurrency.Error",
            ErrorMessages = errors
        };
    }
}
