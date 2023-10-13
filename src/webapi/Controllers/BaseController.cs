using DataClass;
using DataClass.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        [NonAction]
        public new OkObjectResult Ok() 
            => base.Ok(new ResponseBase(ChatroomStatusCode.Success));

        [NonAction]
        public override OkObjectResult Ok([ActionResultObjectValue] object? value) 
            => base.Ok(new ResponseBase(value));
    }
}