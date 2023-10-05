using System.Diagnostics;
using Microsoft.AspNetCore.SignalR;

namespace webapi
{
    public class HubFilter : IHubFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessr;

        public HubFilter(IHttpContextAccessor httpContextAccessr){
            _httpContextAccessr = httpContextAccessr;
        }

        public async ValueTask<object> InvokeMethodAsync(HubInvocationContext invocationContext
            , Func<HubInvocationContext, ValueTask<object>> next)
        {
            Console.WriteLine($"Calling hub method '{invocationContext.HubMethodName}'");
            try
            {
                return await next(invocationContext);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception calling '{invocationContext.HubMethodName}': {ex}");
                throw;
            }
        }

        // Optional method
        public Task OnConnectedAsync(HubLifetimeContext context, Func<HubLifetimeContext, Task> next)
        {
            var httpContext = context.Context.GetHttpContext();
            httpContext.Request.Headers.TryGetValue("Groupid", out var groupId);

            // _ = _httpContextAccessr.HttpContext.Request.Headers.TryGetValue("Groupid", out var groupId);
            Debug.WriteLine($"{context.Hub.Context.ConnectionId} onnected!");
            return next(context);
        }

        // Optional method
        public Task OnDisconnectedAsync(
            HubLifetimeContext context, Exception exception, Func<HubLifetimeContext, Exception, Task> next)
        {
            Debug.WriteLine($"{context.Hub.Context.ConnectionId} Disconnect!");
            return next(context, exception);
        }
    }
}