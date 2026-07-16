using WebAPI_CleanArchitecture.Domain.Abstraction;

namespace WebAPI_CleanArchitecture.Domain.Exceptions
{
    public class BadRequestException(List<string> errors) : Exception
    {
        public Error Errors { get; set; } = new()
        {
            ErrorCode = "BadRequest.Error",
            ErrorMessages = errors
        };
    }
}
