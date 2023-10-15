using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    /// <summary>
    /// 聊天室群組
    /// </summary>
    public class ChatController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult> CreateChatListAsync()
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GetChatListAsync()
        {
            await Task.CompletedTask;
            return Ok();
        }
    }
}