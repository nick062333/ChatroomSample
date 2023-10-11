using System.Security.Claims;
using Core;
using DataClass.DTOs;
using Duende.IdentityServer.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utility.Authentication;
using webapi.ViewModels.Auth;


namespace webapi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtHelpers _jwtHelper;
        private readonly IUserService _userService;

        public AuthController(JwtHelpers jwt, IUserService userService){
            _jwtHelper = jwt;
            _userService = userService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult> SignInAsync(LoginViewModel loginViewModel)
        {
            var validateResult = await _userService.ValidateUserAsync(new ValidateUserRequest(loginViewModel.Account, loginViewModel.Password));

            if (!validateResult.IsVaild)
                return BadRequest();
   
            var token = _jwtHelper.GenerateToken(validateResult.UserId, validateResult.UserName);
            return Ok(token);
        }

        [HttpGet("username")]
        public ActionResult GetUseName()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var userNameClaim = identity?.FindFirst(ClaimTypes.Name)?.Value ?? string.Empty;
            return Ok(userNameClaim);
        }

        [HttpGet("userId")]
        public ActionResult GetId()
        {
            return Ok(User.Identity?.Name);
        }

//         // 登入並取得 JWT Token
// app.MapPost("/signin", (LoginViewModel login, JwtHelpers jwt) =>
//     {
//         if (ValidateUser(login))
//         {
//             var token = jwt.GenerateToken(login.Username);
//             return Results.Ok(new { token });
//         }
//         else
//         {
//             return Results.BadRequest();
//         }
//     })
//     .WithName("SignIn")
//     .AllowAnonymous();

// // 取得 JWT Token 中的所有 Claims
// app.MapGet("/claims", (ClaimsPrincipal user) =>
//     {
//         return Results.Ok(user.Claims.Select(p => new { p.Type, p.Value }));
//     })
//     .WithName("Claims")
//     .RequireAuthorization();

// // 取得使用者是否擁有特定角色
// app.MapGet("api/isInRole", (ClaimsPrincipal user, string name) =>
//     {
//         return Results.Ok(user.IsInRole(name));
//     })
//     .WithName("IsInRole")
//     .RequireAuthorization();

// // 取得 JWT Token 中的 JWT ID
// app.MapGet("/api/jwtid", (ClaimsPrincipal user) =>
//     {
//         return Results.Ok(user.Claims.FirstOrDefault(p => p.Type == "jti")?.Value);
//     })
//     .WithName("JwtId")
//     .RequireAuthorization();

    }
}