using System.Net;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Utility;

namespace webapi.Filters
{
    public class ChatroomExceptionHandler : IActionFilter, IOrderedFilter
    {
        /// <summary>
        /// 過濾器順序
        /// </summary>
        public int Order => int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //TODO:後續要調整
            if (context.Exception is ChatroomException httpResponseException)
            {
                context.Result = new OkObjectResult(httpResponseException);
                context.ExceptionHandled = true;
                context.Exception = null;
            }
        }
    }
}