using Microsoft.AspNetCore.Mvc.Filters;

namespace webapi.Filters
{
    public class ChatroomExceptionHandler : IActionFilter, IOrderedFilter, IExceptionFilter
    {
        private readonly ILogger<ChatroomExceptionHandler> _logger;

        /// <summary>
        /// 過濾器順序
        /// </summary>
        public int Order => int.MaxValue - 10;

        public ChatroomExceptionHandler(ILogger<ChatroomExceptionHandler> logger){
            
            
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context) 
        { 

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, context.Exception.Message);
        }
    }
}