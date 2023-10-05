using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;

namespace webapi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private JwtHelpers _jwtHelper { get; }
        public AuthController(JwtHelpers jwt){
            _jwtHelper = jwt;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public ActionResult SignIn(LoginModel loginModel)
        {
            if (ValidateUser(loginModel))
            {
                var token = _jwtHelper.GenerateToken(loginModel.Account);
                return Ok(token);
            }
            else
            {
                return BadRequest();
            }
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

// // 取得 JWT Token 中的使用者名稱
// app.MapGet("/username", (ClaimsPrincipal user) =>
//     {
//         return Results.Ok(user.Identity?.Name);
//     })
//     .WithName("Username")
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

        private bool ValidateUser(LoginModel loginoginModel)
        {
            return true;
        }
    }
}