using DataClass;
using DataClass.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace webapi.Controllers
{
    [Authorize]
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


        protected long GetUserId(){
            _ = long.TryParse(User?.Identity?.Name, out long userId);
            return userId;
        }
    }
}