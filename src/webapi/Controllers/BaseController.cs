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
        public new OkObjectResult Ok() 
            => base.Ok(new ResponseBase(ChatroomStatusCode.Success));

        public override OkObjectResult Ok([ActionResultObjectValue] object? value) 
            => base.Ok(new ResponseBase(value));
    }
}