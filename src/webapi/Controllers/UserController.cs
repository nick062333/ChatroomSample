using Core;
using DataClass.DTOs;
using Microsoft.AspNetCore.Mvc;
using webapi.ViewModels.Users;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) 
        {
            _userService = userService;
        }

        [HttpPost("register")]
        // [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterAsync(UserViewModel user) 
        { 
            await _userService.RegisterAsync(new RegisterRequest(user.UserName, user.Account, user.Password));
            return Ok();
        }
    }
}
