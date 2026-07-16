using WebAPI_CleanArchitecture.APIs.MiddleWares;

namespace WebAPI_CleanArchitecture.APIs.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseCustomExceptionHandler(this IApplicationBuilder app)
            => app.UseMiddleware<GlobalExceptionHandlingMiddleWare>();
    }
}
