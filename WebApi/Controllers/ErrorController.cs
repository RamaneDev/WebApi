using Microsoft.AspNetCore.Mvc;
using WebApi.Errors;

namespace WebApi.Controllers
{
    [Route("errors/{code}")]
    public class ErrorController : BaseApiController
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }

    }
}
