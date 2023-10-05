using System.Security.Claims;
using Microsoft.AspNetCore.SignalR;

namespace webapi
{
    public class JWTUserIdProvider : IUserIdProvider
    {
        public string? GetUserId(HubConnectionContext connection)
        {
            // return connection.User?.FindFirst(ClaimTypes.Email)?.Value!;
            return connection.User?.Identity?.Name;
        }
    }
}