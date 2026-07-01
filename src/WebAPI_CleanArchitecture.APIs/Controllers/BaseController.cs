using Azure;
using Microsoft.AspNetCore.Mvc;
using Abstraction = WebAPI_CleanArchitecture.Domain.Abstraction;

namespace WebAPI_CleanArchitecture.APIs.Controllers
{
    //[NonController] // only for inheritance
    [ApiController]
    public class BaseController : ControllerBase
    {
        public IActionResult CreateResult<Dto>(Abstraction.Result<Dto> result) where Dto : Abstraction.IResult
            // Return 204 No Content for empty responses to comply with HTTP standards, otherwise return the result object.
        => result.StatusCode == 204 ? new ObjectResult(null) { StatusCode = 204 }
        : new ObjectResult(result) { StatusCode = result.StatusCode };
    }
}
