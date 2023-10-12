using DataClass;
using DataClass.Enums;
using Duende.IdentityServer.Extensions;
using Utility;

namespace webapi.Filters
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ChatroomException ex)
            {
                await context.Response.WriteJsonAsync(new ResponseBase(ex.ChatroomStatusCode, ex?.StatusMessage));
            }
            catch (Exception ex)
            {
                await context.Response.WriteJsonAsync(new ResponseBase(ChatroomStatusCode.ServiceError, ex.Message));
            }
        }
    }
}