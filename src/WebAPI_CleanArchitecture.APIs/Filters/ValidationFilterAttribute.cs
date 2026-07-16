using Microsoft.AspNetCore.Mvc.Filters;
using WebAPI_CleanArchitecture.Domain.Exceptions;

namespace WebAPI_CleanArchitecture.APIs.Filters
{

    // This Code instead of right this part in every Endpoint
    //if (!ModelState.IsValid)
    //{
    //    return BadRequest(ModelState);
    //}
public class ValidationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage).ToList();

                if (errors.Any(x => x.Contains("request")))
                    throw new PayloadFormatException(errors);
                else
                    throw new RequestValidationException(errors);
            }
        }
    }
}
