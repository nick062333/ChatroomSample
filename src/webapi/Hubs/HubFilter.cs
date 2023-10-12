using DataClass.Enums;
using Microsoft.AspNetCore.SignalR;
using Utility;

namespace webapi
{
    public class HubFilter : IHubFilter
    {
        private readonly ILogger<HubFilter> _logger;

        public HubFilter(ILogger<HubFilter> logger)
        {
            _logger = logger;
        }

        public async ValueTask<object> InvokeMethodAsync(HubInvocationContext invocationContext
            , Func<HubInvocationContext, ValueTask<object>> next)
        {
            try
            {
                var httpContext = invocationContext.Context.GetHttpContext();
                
                if(!httpContext.Request.Query.Any(x => x.Key == "GroupId"))
                    throw new ChatroomException(ChatroomStatusCode.DataVerificationFailed, "group id is not null");

                return await next(invocationContext);  
            }
            catch(ChatroomException ex)
            {
                _logger.LogError(ex, "ChatroomStatusCode:{@ChatroomStatusCode} StatusMessage:{@StatusMessage}", ex.ChatroomStatusCode, ex.StatusMessage);
                throw;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, " HubName:{@HubMethodName} ", invocationContext.HubMethodName);
                throw;
           }
        }

        public Task OnConnectedAsync(HubLifetimeContext context, Func<HubLifetimeContext, Task> next)
        {
            try
            {
                var httpContext = context.Context.GetHttpContext();

                if(httpContext.Request.Query.TryGetValue("GroupId", out var groupId))
                    context.Hub.Groups.AddToGroupAsync(context.Context.ConnectionId, groupId.ToString());
                else
                    throw new ChatroomException(ChatroomStatusCode.DataVerificationFailed, "group id is not null");

                _logger.LogInformation("{@ConnectionId} onnected!", context.Hub.Context.ConnectionId);

                return next(context);
            }
            catch(ChatroomException ex)
            {
                _logger.LogError(ex, "ChatroomStatusCode:{@ChatroomStatusCode} StatusMessage:{@StatusMessage}", ex.ChatroomStatusCode, ex.StatusMessage);
                throw;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, " HubName:{@ConnectionId} ", context.Context.ConnectionId);
                throw;
           }
        }

        // Optional method
        public Task OnDisconnectedAsync(
            HubLifetimeContext context, Exception exception, Func<HubLifetimeContext, Exception, Task> next)
        {
            _logger.LogInformation("{@ConnectionId} Disconnect!", context.Hub.Context.ConnectionId);

            return next(context, exception);
        }
    }
}