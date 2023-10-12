using Microsoft.AspNetCore.Mvc.Filters;

namespace webapi.Filters
{
    public class ChatroomExceptionHandler : IActionFilter, IOrderedFilter, IExceptionFilter
    {
        /// <summary>
        /// 過濾器順序
        /// </summary>
        public int Order => int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) 
        { 

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnException(ExceptionContext context)
        {
        }
    }
}