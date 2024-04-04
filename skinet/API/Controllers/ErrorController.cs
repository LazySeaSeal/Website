using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
        [Route("errors/{code}")]
        [ApiExplorerSettings(IgnoreApi = true)] // ignore so swagger can't see it so no errrs will be there
    public class ErrorController : BaseApiController
    {
        // this will treat the for api/"7aja mouch mawjouda" fil url
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
        
    }
}