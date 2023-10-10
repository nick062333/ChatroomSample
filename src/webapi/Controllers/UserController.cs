using DataService;
using Microsoft.AspNetCore.Mvc;
using webapi.ViewModels.Users;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController(IUserService userService) 
        { 

        }

        [HttpGet]
        public Task<ActionResult> CreateAsync(UserViewModel user) 
        { 
            throw new NotSupportedException();
        }
    }
}
