using Core;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    /// <summary>
    /// 聊天室群組
    /// </summary>
    public class ChatController : BaseController
    {
        private readonly IChatroomService _chatroomService;

        public ChatController(IChatroomService chatroomService)
        {
            _chatroomService = chatroomService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync()
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GetListAsync()
        {
            var chatroomList = await _chatroomService.GetChatroomListAsnyc();
            return Ok(chatroomList);
        }
    }
}