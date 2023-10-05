using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.SignalR;

namespace webapi
{
    public class JWTUserIdProvider : IUserIdProvider
    {
        public string? GetUserId(HubConnectionContext connection)
        {
            //  return connection.User?.FindFirst(ClaimTypes.Email)?.Value!;
            Debug.WriteLine(connection.User?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value!);
            Debug.WriteLine(connection.User?.FindFirst(ClaimTypes.Email)?.Value!);
            Debug.WriteLine(connection.User?.Identity?.Name);
            return connection.User?.Identity?.Name;
        }
    }
}