using WebAPI_CleanArchitecture.Domain.Abstraction;

namespace WebAPI_CleanArchitecture.Domain.Exceptions
{
    public class NullObjectException(List<string> errors) : Exception
    {
        public Error Errors { get; set; } = new()
        {
            ErrorCode = "NullObject.Error",
            ErrorMessages = errors
        };
    }
}
