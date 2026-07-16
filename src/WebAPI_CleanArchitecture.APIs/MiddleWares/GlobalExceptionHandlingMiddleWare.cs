using WebAPI_CleanArchitecture.Domain.Abstraction;
using WebAPI_CleanArchitecture.Domain.Exceptions;

namespace WebAPI_CleanArchitecture.APIs.MiddleWares
{
    public class GlobalExceptionHandlingMiddleWare(RequestDelegate _next, ILogger<GlobalExceptionHandlingMiddleWare> _logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // move to the next middle ware
            }
            catch(Exception exception)
            {
                _logger.LogError(exception, "Exception Occurred: {Message}", exception.Message); // {Message} => Structured Logging
                { }

                var exceptionDetails = GetExceptionDetails(exception);

                context.Response.StatusCode = exceptionDetails.StatusCode;

                await context.Response.WriteAsJsonAsync(exceptionDetails);
            }
        }

        private static Result<NoContentDto> GetExceptionDetails(Exception exception) =>
            exception switch
            {
                RequestValidationException validationException
                => Result<NoContentDto>.Failed(StatusCodes.Status400BadRequest, validationException.Errors),

                ConcurrencyException concurrencyException
                => Result<NoContentDto>.Failed(StatusCodes.Status400BadRequest, concurrencyException.Errors),

                NullObjectException nullObjectException
                => Result<NoContentDto>.Failed(StatusCodes.Status400BadRequest, nullObjectException.Errors),

                BadRequestException badRequestException
                => Result<NoContentDto>.Failed(StatusCodes.Status400BadRequest, badRequestException.Errors),

                PayloadFormatException pyloadFormatException
                => Result<NoContentDto>.Failed(StatusCodes.Status400BadRequest, pyloadFormatException.Errors),



                _ => Result<NoContentDto>.Failed(
                    StatusCodes.Status500InternalServerError, new Error
                    {
                        ErrorCode = "Internal Server Error",
                        ErrorMessages = ["Please Take An Advice Immediately"]

                    })
            };
    }
}
