using WebAPI_CleanArchitecture.Domain.Abstraction;

namespace WebAPI_CleanArchitecture.Domain.Exceptions
{
    public class PayloadFormatException(List<string> errors) : Exception
    {
        public Error Errors { get; set; } = new()
        {
            ErrorCode = "PayloadFormate.Error",
            ErrorMessages = errors
        };
    }
}
